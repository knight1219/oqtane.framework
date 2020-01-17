using System;
using System.Collections.Generic;

namespace Oqtane.Core.Themes
{
    public interface ITheme
    {
        Dictionary<string, string> Properties { get; }
    }
}
