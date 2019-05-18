﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using Newtonsoft.Json;

namespace AdminRURS.Persistency
{
    public class PersistenceAdminProcessOrdre
    {
        private const string URI = "http://localhost:60096/api/ProcessOrdre";

        public static List<ProcessOrdre> GetAll()
        {
            List<ProcessOrdre> processOrdrer = new List<ProcessOrdre>();


            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync(URI);
                string jsonStr = resTask.Result;

                processOrdrer = JsonConvert.DeserializeObject<List<ProcessOrdre>>(jsonStr);
            }

            return processOrdrer;
        }
    }
}