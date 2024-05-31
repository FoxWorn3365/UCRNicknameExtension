using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCRNicknamesExtension
{
    internal class Config : IConfig
    {
        [Description("Do enable the plugin?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Do enable the developer (debug) mode?")]
        public bool Debug { get; set; } = false;

        [Description("Choose the nicknames for each custom role by it's Id")]
        public Dictionary<int, string> Nicknames { get; set; } = new()
        {
            {
                1,
                "D-%dnumber%"
            },
            {
                2,
                "Dr. %nickname%"
            }
        };
    }
}
