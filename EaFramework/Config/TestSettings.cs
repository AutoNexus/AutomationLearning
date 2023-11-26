using EaFramework.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaFramework.Config
{
    public class TestSettings
    {
        public string ApplicationUrl { get; set; }
        public BrowserType Browser { get; set; }
        public float? TimeoutInterval { get; set; }
    }
}
