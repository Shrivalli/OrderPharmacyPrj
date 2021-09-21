using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Portal.Controllers
{
    public class SubscriptionController : Controller
    {
        public IActionResult subscriber()
        {
            return View();
        }

        public async Task<IActionResult> Subscribe([FromForm] MemberPrescription memberDetail)
        {
            try
            {
                string Token = HttpContext.Request.Cookies["Token"];
                Client obj = new Client();
                HttpClient httpClient = obj.SubscriptionApi();
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "/api/Subcription/Subscribe"))
                {
                    //_data = new Data();
                    ViewBag.Message = null;
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    request.Headers.TryAddWithoutValidation("accept", "application/json;");

                    var str = Newtonsoft.Json.JsonConvert.SerializeObject(memberDetail);

                    request.Content = new StringContent(str);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = httpClient.SendAsync(request).Result;


                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = response.Content.ReadAsStringAsync().Result;

                        ViewBag.Message = responseData;//"Your Subscription Accepted successfully";
                        return View("subscriber");
                    }
                    else
                        return View("Member", "Index");
                }
                return View("Member", "Login");
            }
            catch (Exception e)
            {
                Console.Write("Exception " + e);
                return RedirectToAction("Privacy", "Home");
            }
        }


        public IActionResult unsubscriber()
        {
            return View();
        }
        public async Task<IActionResult> UnSubscribe(int mid,int sid)
        {
            try
            { 
                string Token = HttpContext.Request.Cookies["Token"];
                Client obj = new Client();
                HttpClient httpClient = obj.SubscriptionApi();
                 using (var request = new HttpRequestMessage(new HttpMethod("POST"), "/api/Subcription/Unsubscribe?member_id="+mid+"&subscription_id="+sid))
                    {
                        request.Headers.TryAddWithoutValidation("accept", "text/plain");
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                        request.Content = new StringContent("");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                        var response = await httpClient.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseData = response.Content.ReadAsStringAsync().Result;
                            ViewBag.Message = responseData;//"Your Succesfully Unsubscribe";
                            return View("unsubscriber");
                        }
                    }
            
                return View("Index","Member");
            }
            catch (Exception e)
            {
                Console.Write("Exception " + e);
                return RedirectToAction("Privacy", "Home");
            }
        }
        


    }
}
