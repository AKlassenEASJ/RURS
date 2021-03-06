﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Models;
using Newtonsoft.Json;

namespace RURS.Persistency
{
    class PersistenceTappeKontrol
    {
        private const string URI = "http://localhost:60096/api/";

        public static bool GET_ONE(int PONR, DateTime Tid)
        {
            TappeKontrol tappeKontrol = new TappeKontrol();

            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync(URI + "/" + PONR + "/" + Tid);
                string jsonStr = resTask.Result;
                tappeKontrol = JsonConvert.DeserializeObject<TappeKontrol>(jsonStr);
            }

            //if (tappeKontrol != null)
            //{
                
            //}

            return tappeKontrol == null ? false : true;
        }

        /// <summary>
        /// Metode til at overføre en TappeKontrol til database
        /// </summary>
        /// <param name="NewTappeKontrol">En ny tappeKontrol</param>
        /// <returns>Retunere en bool, om den er gået igennem til databasen </returns>
        public static bool Post(TappeKontrol NewTappeKontrol)
        {
            bool ok = true;
            using (HttpClient client = new HttpClient())
            {
                string serializeObject = JsonConvert.SerializeObject(NewTappeKontrol);
                StringContent content = new StringContent(serializeObject, Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> postAsync = client.PostAsync($"{URI}/TappeKontrols", content);
                HttpResponseMessage resps = postAsync.Result;
                if (resps.IsSuccessStatusCode)
                {
                    string jsonStr = resps.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonStr);
                }
                else
                {
                    ok = false;
                }
            }

            return ok;

        }
    }
}
