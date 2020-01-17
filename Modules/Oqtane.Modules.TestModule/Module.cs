using Oqtane.Core.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oqtane.Module.TestModule
{
    public class ModuleInfo : IModule
    {
        public Dictionary<string, string> Properties
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>
                {
                    { "Name", "Test Module" },
                    { "Description", "Using Oqtane.Core.Modules, create a self-contained module." },
                    { "Version", "1.0.0" }
                };
                return properties;
            }
        }
    }
}
