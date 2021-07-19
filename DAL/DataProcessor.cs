using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProcessor
    {
        public void SaveToFile<T>(T obj, string Name)
        {
            string SeriasizedObject = JsonConvert.SerializeObject(obj);
            if (!Directory.Exists("SavedData"))
            {
                Directory.CreateDirectory("SavedData");
            }
            File.WriteAllText("SavedData\\" + Name + ".json", SeriasizedObject);
        }
        public T LoadFromFile<T>(string Name)
        {
            if (Directory.Exists("SavedData"))
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText("SavedData\\" + Name + ".json"));
            }
            return default;
        }
    }
}
