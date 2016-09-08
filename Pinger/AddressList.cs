﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pinger
{
    class Addresses
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = " ";
        public string OOO { get; set; } = " ";
        public string Address { get; set; } = " ";
        public string IP { get; set; } = " ";
        public string UTMVer { get; set; } = " ";
        public string PKI { get; set; } = " ";
        public string Gost { get; set; } = " ";
        

        public void CSVtoJson(string CSVpath,string jsonPath)
        {
            string[] address = null;
            List<Addresses> result = new List<Addresses>();
            using (StreamReader sr = new StreamReader(CSVpath))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine())!=null)
                {
                    i++;
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
