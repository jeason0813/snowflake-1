﻿using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;

namespace Snowflake.Support.Remoting.GraphQL.Types.PlatformInfo
{
    internal class FileTypeGraphType : ObjectGraphType<FileType>
    {
        public FileTypeGraphType()
        {
            Name = "FileType";
            Description = "A FileType is defined by its common extension, and a mimetype, usually of";
            Field(p => p.Extension).Description("The file extension of the file type");
            Field(p => p.Mime).Description("The mimetype of the file type");
        }
    }

    internal class FileType
    {
        public string Extension { get; set; }
        public string Mime { get; set; }
    }
}
