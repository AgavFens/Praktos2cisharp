using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Praktos2cisharp
{
    internal class MyConvert
    {
        public static void MySerialize<T>(T zametkis)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(zametkis);
            File.WriteAllText(desktop+"\\agavtop.json", json);
        }
        public static T MyDeserialize<T>()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(desktop+"\\agavtop.json");
            T zametkis = JsonConvert.DeserializeObject<T>(json);
            return zametkis;
        }
    }
}
