﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Snowflake.Emulator;
namespace Snowflake.Emulator
{
    public class EmulatorAssembly : IEmulatorAssembly
    {
        public string MainAssembly { get; }
        public string EmulatorID { get; }
        public string EmulatorName { get; }
        public EmulatorAssemblyType AssemblyType { get; }

        public EmulatorAssembly(string mainAssembly, string emulatorId, string name, string assemblyTypeString)
        {
            EmulatorAssemblyType assemblyType;
            if (!Enum.TryParse<EmulatorAssemblyType>(assemblyTypeString, true, out assemblyType)) assemblyType = EmulatorAssemblyType.EMULATOR_MISC;
            this.MainAssembly = mainAssembly;
            this.EmulatorID = emulatorId;
            this.EmulatorName = name;
            this.AssemblyType = assemblyType;
        }

        public EmulatorAssembly(string mainAssembly, string emulatorId, string name, EmulatorAssemblyType assemblyType)
        {
            this.MainAssembly = mainAssembly;
            this.EmulatorID = emulatorId;
            this.EmulatorName = name;
            this.AssemblyType = assemblyType;
        }

        public static EmulatorAssembly FromJsonProtoTemplate (IDictionary<string, string> emulatorAssembly){
            return new EmulatorAssembly(emulatorAssembly["main"], emulatorAssembly["id"], emulatorAssembly["name"], emulatorAssembly["type"]);
        }
    }
}
