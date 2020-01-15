using System.Collections.Generic;

namespace Oqtane.Core.Modules
{
    public interface IModule
    {
        Dictionary<string, string> Properties { get; }
    }
}
