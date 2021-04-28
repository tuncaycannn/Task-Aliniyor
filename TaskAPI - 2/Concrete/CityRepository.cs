using ChoETL;
using System.IO;
using System.Linq;
using TaskAPI.Models;
using TaskAPI.Helper;
using System.Xml.Linq;
using Newtonsoft.Json;
using TaskAPI.Abstract;

namespace TaskAPI.Concrete
{
    public class CityRepository : ICityRepository
    {
        public string GetAdress(string from, string filterby, string value, string shorting)
        {
            string json = "";

            //veri kaynağı belirlenip json'a dönüştürülüyor.
            switch (from)
            {
                case "xml":
                    XDocument doc = XDocument.Load(@"C:\Users\Admin\Desktop\TaskAPI - 2\Data\sample.xml");
                    json = JsonConvert.SerializeXNode(doc);
                    break;
                case "csv":
                    var lines = File.ReadAllLines(@"C:\Users\Admin\Desktop\TaskAPI - 2\Data\sample.csv");
                    var xml = new XElement("TopElement",
                                lines.Select(line => new XElement("Item",
                                line.Split(';')
                              .Select((column, index) => new XElement("Column" + index, column)))));
                    json = JsonConvert.SerializeXNode(xml);
                    break;
            }

           
            /*
             filterby : city or district
             value : aranacak veri
             shorting : asc or desc

            değerler boş gelmiyorsa json içinde arama yapıp sıralanmalı
             
             */
            //if (string.IsNullOrEmpty(filterby) && string.IsNullOrEmpty(value))
            //{
            //    var result = ObjectConverter.Deserialize<JsonModel>(json);
            //    var list = result.AddressInfo.City.Where(x => true).Select(x => new { x.Name, x.Code }).ToList();
            //    //var list = result.AddressInfo.City.Where(x => x.Name.ToLower().Contains(value.ToLower())).Select(x => new { x.Name, x.Code }).ToList();
            //    json = JsonConvert.SerializeObject(list);
            //}


            return json;
        }
    }
}
