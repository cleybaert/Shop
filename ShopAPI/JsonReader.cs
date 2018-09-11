using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    public class JsonReader<T>
    {
        public IEnumerable<T> Read(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                var json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }
    }
}
