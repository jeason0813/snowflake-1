﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snowflake.Extensibility;
using Snowflake.Scraping;
using Snowflake.Scraping.Extensibility;
using Snowflake.Support.Scraping.RecordScrapeEngine.Utility;

namespace Snowflake.Support.Scraping.RecordScrapeEngine
{
    [Plugin("RecordScrapeEngine-ResultCuller")]
    public class ResultCuller : Culler
    {
        public ResultCuller()
            : base(typeof(ResultCuller), "result")
        {
        }

        public override IEnumerable<ISeed> Filter(IEnumerable<ISeed> seedsToTrim, ISeedRootContext context)
        {
            var clientResult = seedsToTrim.FirstOrDefault(s => s.Source == ScrapeJob.ClientSeedSource);
            if (clientResult != null)
            {
                yield return clientResult;
                yield break;
            }

            var crc32Results = seedsToTrim.Where(s => context[s.Parent]?.Content.Type == "search_crc32");
            var mostDetailedCrc32 =
                crc32Results.OrderByDescending(s => context.GetChildren(s).Count()).FirstOrDefault();

            var mostDetailedTitle = (from seed in seedsToTrim
                let parent = context[seed.Parent]
                where parent?.Content.Type == "search_title"
                let title = context.GetChildren(seed).FirstOrDefault(s => s.Content.Type == "title")
                where title != null
                let r = title.Content.Value
                let distance = r.CompareTitle(parent.Content.Value)
                orderby distance, context.GetChildren(seed).Count()
                select seed).FirstOrDefault();

            yield return (from seed in new[] {mostDetailedCrc32, mostDetailedTitle}
                orderby context.GetChildren(seed).Count()
                select seed).FirstOrDefault();
        }
    }
}
