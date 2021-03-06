﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLibary.Models;
using Newtonsoft.Json;

namespace RURS.Persistency
{
    class PersistencyVaegtKontrol
    {

        private const string URI = "http://localhost:60096/api/VaegtKontrol";



        public async static Task<List<VaegtKontrol>> GetAll()
        {
            List<VaegtKontrol> vaegtKontrols = new List<VaegtKontrol>();
            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync(URI);
                await resTask;
                String jsonStr = resTask.Result;
                vaegtKontrols = JsonConvert.DeserializeObject<List<VaegtKontrol>>(jsonStr);
            }
            return vaegtKontrols;
        }


        public async static Task<int> GetMax(int ponid)
        {
            int vaegtKontrolMax = 0;
            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync(URI + "/max/" + ponid);
                await resTask;
                String jsonStr = resTask.Result;
                vaegtKontrolMax = JsonConvert.DeserializeObject<int>(jsonStr);
            }

            return vaegtKontrolMax;
        }




        public static VaegtKontrol GetOne(int id)
        {
            VaegtKontrol vaegtKontrol = new VaegtKontrol();
            using (HttpClient client = new HttpClient())
            {
                Task<string> resTask = client.GetStringAsync(URI + $"/{id}");
                string jsonStr = resTask.Result;
                vaegtKontrol = JsonConvert.DeserializeObject<VaegtKontrol>(jsonStr);
            }

            return vaegtKontrol;
        }


        public bool Post(VaegtKontrol vaegtKontrol)
        {
            bool ok = true;
            using (HttpClient client = new HttpClient())
            {
                String jsonStr = JsonConvert.SerializeObject(vaegtKontrol);
                StringContent content = new StringContent(jsonStr, Encoding.ASCII, "application/json");

                Task<HttpResponseMessage> postAsync = client.PostAsync(URI, content);

                HttpResponseMessage resp = postAsync.Result;
                if (resp.IsSuccessStatusCode)
                {
                    String jsonResStr = resp.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonResStr);
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
