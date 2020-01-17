using System;
using System.Collections.Generic;
using System.Text;

namespace Oqtane.Core.Shared.Interfaces
{
    public interface IModuleServiceResolver
    {
        T GetModuleService<T>();
    }
}
