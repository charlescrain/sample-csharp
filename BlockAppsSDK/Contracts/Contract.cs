using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockAppsSDK.Users;

namespace BlockAppsSDK.Contracts
{
    public class Contract : Account
    {
        public string Name { get; set; }

        public List<string> Methods { get; set; }
        
        public List<string> Properties { get; set; }


    }
}
