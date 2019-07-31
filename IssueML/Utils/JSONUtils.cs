using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueML.Utils
{
    public class JSONUtils
    {
        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public static string SerializeObject(object o)
        {
            //return JsonConvert.SerializeObject(o, Formatting.Indented, new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});
            return JsonConvert.SerializeObject(o, Formatting.Indented, serializerSettings);
        }
    }
}
