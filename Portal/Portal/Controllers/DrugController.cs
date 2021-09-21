using Portal.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    public class DrugController : Controller
    {
        public ActionResult Index()
        {
            //code added
            DateTime TokenExpiry = Convert.ToDateTime(HttpContext.Request.Cookies["Expiry"]);
            DateTime current = DateTime.Now;
            // Console.WriteLine(TokenExpiry + "    expiray time   and current time " + current);
            if (DateTime.Compare(TokenExpiry, current) < 0)                 //if token expired redirect to login
            {
                return RedirectToAction("Login", "Member");
            }

            return View();
        }

        public async Task<ActionResult> Check_DrugByName(string name)
        {
            try
            {
                string Token = HttpContext.Request.Cookies["Token"];
                Client obj = new Client();
                HttpClient httpClient = obj.DrugApi();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/Drug/name?name=" + name))
                {
                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = JsonConvert.DeserializeObject<Drug>(response.Content.ReadAsStringAsync().Result);
                       
                        return View(responseData);
                    }
                }

                return RedirectToAction("Login", "Member");
            }
            catch (Exception e)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }




        public IActionResult GetDrugId()
        {
            return View();
        }

        
        public async Task<ActionResult> Check_DrugByID(int id)
        {
            try
            {
                string Token = HttpContext.Request.Cookies["Token"];
                Client obj = new Client();
                HttpClient httpClient = obj.DrugApi();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/Drug/id?drugId=" + id))
                {
                    var response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = JsonConvert.DeserializeObject<Drug>(response.Content.ReadAsStringAsync().Result);
                        return View(responseData);
                    }
                }

                return RedirectToAction("Login", "Member");
            }
            catch(Exception e)
            {
                return RedirectToAction("Privacy", "Home");
            }
        }

        public IActionResult DrugDetailsall()
        {
            return View();
        }

        [HttpGet("id/loc")]
        public async Task<ActionResult> GetByAll(int id, string loc)
        {
            try
            {

                string Token = HttpContext.Request.Cookies["Token"];


                Client obj = new Client();
                HttpClient client = obj.DrugApi();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/Drug/Location/id?drugId=" + id + "&location=" + loc))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");

                    var response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = JsonConvert.DeserializeObject<DrugLocation>(response.Content.ReadAsStringAsync().Result);
                        return View(responseData);
                    }
                }

                return View();
            }
            catch (Exception e)
            {
                Console.Write("Exception " + e);
                return RedirectToAction("Privacy", "Home");
            }
        }
   
    }
}
