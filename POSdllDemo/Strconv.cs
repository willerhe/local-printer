using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GprinterDEMO
{
    class Strconv
    {
        public static Dictionary<string, object> String2Dict(string str)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(str);
        }
    }
}
