﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snowflake.Framework.Remoting.Electron;

using Snowflake.Framework.Remoting.GraphQL.Attributes;
using Snowflake.Framework.Remoting.GraphQL.Query;
using Snowflake.Support.Remoting.Electron.ThemeProvider.GraphQl.Types;

namespace Snowflake.Support.Remoting.Electron.ThemeProvider.GraphQl
{
    public class ElectronPackageQueries : QueryBuilder
    {
        private IElectronPackageProvider PackageProvider { get; set; }

        public ElectronPackageQueries(IElectronPackageProvider packageProvider)
        {
            this.PackageProvider = packageProvider;
        }

        [Connection("electronPackages", "Gets all loaded electron Packages", typeof(ElectronPackageGraphType))]
        public IEnumerable<IElectronPackage> GetElectronPackages()
        {
            return this.PackageProvider.Interfaces.ToList();
        }
    }
}
