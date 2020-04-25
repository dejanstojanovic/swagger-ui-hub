using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Swagger.UI.Hub.Models
{
    public class ServicesConfigItem
    {
        public String Name { get; set; }
        public Uri Url { get; set; }
        public Boolean Default { get; set; }
    }
}
