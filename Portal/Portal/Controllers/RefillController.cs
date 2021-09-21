using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portal.Models;
using Portal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    public class RefillController : Controller
    {
        IData _data;
        private MailOrderContext _context;
        public RefillController(IData data,MailOrderContext context)
        {
            _data = data;
            _context = context;
        }
        public IActionResult getIdforRefilldetails()
        {
            return View();
        }

        [HttpGet("id")]
        public async Task<IActionResult> ViewRefillDetails(int subId)
        {
            try
            { 
                string Token = HttpContext.Request.Cookies["Token"];
                Client obj = new Client();
                HttpClient httpClient = obj.RefillApi();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/Refill/SubscriptionId?subscriptionId="+subId))
                    {
                        request.Headers.TryAddWithoutValidation("accept", "*");

                        var response = await httpClient.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = JsonConvert.DeserializeObject<RefillOrder>(response.Content.ReadAsStringAsync().Result);
                            //ViewBag.Message = responseData;//"Your Succesfully Unsubscribe";
                            return View("ViewRefillDetails", responseData);
                        }
                    }
            
                return View("Index", "Member");
            }
            catch (Exception e)
            {
                Console.Write("Exception " + e);
                return RedirectToAction("Privacy", "Home");
            }
        }
        public IActionResult ViewRefillDues()
        {
            return View();
        }

        [HttpGet("subId/fromDate")]
        public async Task<IActionResult> ViewRefillDuesDetails(int subId, DateTime fromDate)
        {
            try
            { 
                string Token = HttpContext.Request.Cookies["Token"];
                Client obj = new Client();
                HttpClient httpClient = obj.RefillApi();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/Refill/GetRefillDueAsofdate?subscriptionId=" + subId + "&fromDates=" + fromDate))
                    {
                        request.Headers.TryAddWithoutValidation("accept", "*");

                        var response = await httpClient.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = JsonConvert.DeserializeObject<List<RefillOrder>>(response.Content.ReadAsStringAsync().Result);
                            //ViewBag.Message = responseData;//"Your Succesfully Unsubscribe";
                            return View("ViewRefillDuesDetails", responseData);
                        }
                    }
            
                return View("Index", "Member");
            }
            catch (Exception e)
            {
                Console.Write("Exception " + e);
                return RedirectToAction("Privacy", "Home");
            }
        }
        public IActionResult AdhokRefillOrder()
        {
            return View();
        }

        [HttpPost("refillOrderItem")]
        public async Task<IActionResult> adhokRefillDetails([FromForm]RefillOrderLineItem refillOrderLineItem)
        {
            try
            {
                string Token = HttpContext.Request.Cookies["Token"];
                Client obj = new Client();
                HttpClient httpClient = obj.RefillApi();
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "/api/Refill/requestAdhocRefill"))
                    {
                        //_data = new Data();
                        ViewBag.Message = null;
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                        request.Headers.TryAddWithoutValidation("accept", "application/json;");

                        var str = Newtonsoft.Json.JsonConvert.SerializeObject(refillOrderLineItem);

                        request.Content = new StringContent(str);
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var response = httpClient.SendAsync(request).Result;


                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = JsonConvert.DeserializeObject<RefillOrder>(response.Content.ReadAsStringAsync().Result);
                            //ViewBag.Message = responseData;//"Your Subscription Accepted successfully";

                            _data.AddData(responseData);
                            _data.Savedata();                        

                            return View("ViewRefillDetails",responseData);
                        }
                
                }
                return View("Index", "Member");
            }
            catch (Exception e)
            {
                Console.Write("Exception " + e);
                return RedirectToAction("Privacy", "Home");
            }
        }
    }
}
