using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace converterCSVtoJson
{
    class Addresses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OOO { get; set; }
        public string Address { get; set; }
        public string IP { get; set; }

        public void CSVtoJson(string CSVpath, string jsonPath)
        {
            string[] address = null;
            List<Addresses> result = new List<Addresses>();
            using (StreamReader sr = new StreamReader(CSVpath))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    i++;
                    byte[] toBytes = Encoding.UTF8.GetBytes(line);
                    line= Encoding.UTF8.GetString(toBytes);
                    address = line.Split(';');
                    result.Add(new Addresses()
                    {
                        Id = i,
                        OOO = address[0],
                        Address = address[1],
                        Name = address[2],
                        IP = address[3],
                    });
                }
            }
            using (StreamWriter sw = new StreamWriter(jsonPath))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    JsonSerializer js = new JsonSerializer();
                    js.Formatting = Formatting.Indented;
                    js.Serialize(jw, result);
                }
            }
        }
    }
}
