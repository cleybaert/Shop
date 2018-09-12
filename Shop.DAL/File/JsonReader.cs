using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.File
{
    public class JsonReader<T>
    {
        public IEnumerable<T> ReadFile(string value)
        {
            using (var sr = new StreamReader(value))
            {
                var json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }

        public IEnumerable<T> ReadResource(string value)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(value);
            if (stream == null)
            {
                Debug.WriteLine("Available resources:");
                foreach (var item in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                {
                    Debug.WriteLine(item);
                }
                throw new FileNotFoundException(value);
            }
            using (var sr = new StreamReader(stream))
            {
                var json = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }
    }
}
