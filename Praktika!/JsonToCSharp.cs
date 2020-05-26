using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Praktika
{
    static class ParksData
    {

        private static TechnoPark[] _parks;

        public static void LoadData(string fileName)
        {
            var fullPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), fileName);

            var jsonString = File.ReadAllText(fullPath, Encoding.Default);

            JObject jobject = JObject.Parse(jsonString);

            var parks = jobject["Parks"].ToList();

            _parks = new TechnoPark[parks.Count];

            int i = 0;
            foreach (var park in parks)
            {
                _parks[i] = park.ToObject<TechnoPark>();
                i++;
            }
        }

        public static TechnoPark[] GetParks()
        {
            return _parks;
        }

        public static TechnoPark[] GetParks(string search)
        {
            if (search != null)
            {
                return _parks.Where<TechnoPark>(park => park.Name.ToLower().Contains(search.ToLower())).ToArray();
            }
            else
            {
                return _parks;
            }
        }
    }

    class TechnoPark
    {
        public string Name { get; set;}

        public string Infrastructure { get; set; }

        public string Address { get; set; }

        public List<PublicPhoneItem> PublicPhone { get; set; }

        public string WebSite { get; set; }

        public List<SpecialtyItem> Specialty { get; set; }
    }

    public class PublicPhoneItem
    {
        public string PublicPhone { get; set; }
    }

    public class SpecialtyItem
    {
        public string Specialty { get; set; }
    }
}
