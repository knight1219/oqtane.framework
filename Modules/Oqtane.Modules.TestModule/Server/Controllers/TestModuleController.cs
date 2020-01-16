using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Oqtane.Core.Shared.Enums;
using Oqtane.Core.Shared.Models;
using Oqtane.Core.Shared;
using Oqtane.Core.Server.Interfaces;

namespace Oqtane.Module.TestModule.Controllers
{
    [Route("{site}/api/[controller]")]
    public class TestModuleController
    {
        [HttpGet]
        public string Get()
        {
            return "This is a test API from a module";
        }
    }
}