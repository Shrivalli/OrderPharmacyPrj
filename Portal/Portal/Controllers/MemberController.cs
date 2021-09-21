using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Portal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace Portal.Controllers
{
    public class MemberController : Controller
    {
        IConfiguration _config;
        //  private readonly JwtTokenExp tokenclass;
        //code added
        private IJsonSerializer _serializer = new JsonNetSerializer();
        private IDateTimeProvider _provider = new UtcDateTimeProvider();
        private IBase64UrlEncoder _urlEncoder = new JwtBase64UrlEncoder();
        private IJwtAlgorithm _algorithm = new HMACSHA256Algorithm();
        //code above added


        public MemberController(IConfiguration config)
        {

            _config = config;
        }
        /// <summary>
        /// This method Returns the Login Page View
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            //HttpContext.Response.Cookies.Delete("Token");
            return View();

        }
        /// <summary>
        /// This method creates the View for Authorized Users
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(Member obj)
        {
            string TokenForLogin;
            string data = JsonConvert.SerializeObject(obj);

            try
            {
                Client obj1 = new Client();
                HttpClient client = obj1.Authapi();

                TokenForLogin = GetToken(client, obj);

                if (!string.IsNullOrEmpty(TokenForLogin))
                {

                    HttpContext.Response.Cookies.Append("Token", TokenForLogin);
                    //my added code below  

                    IJwtValidator _validator = new JwtValidator(_serializer, _provider);
                    IJwtDecoder decoder = new JwtDecoder(_serializer, _validator, _urlEncoder, _algorithm);
                    var tokenExp = decoder.DecodeToObject<JwtTokenExp>(TokenForLogin);
                    DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(tokenExp.exp);
                    DateTime timeExp = dateTimeOffset.LocalDateTime;

                    HttpContext.Response.Cookies.Append("Expiry", timeExp.ToString());
                    //my addedcode above
                    return View("Index");
                }
                ViewBag.Message = "Invalid ID or Password";
                return View("Login");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        public ActionResult Index()
        {

            string Token = HttpContext.Request.Cookies["Token"];
            if (string.IsNullOrEmpty(Token))
            {
                return View("Login");
            }
            return View();
        }



        /// <summary>
        /// This method generates Token for Authorized Users
        /// </summary>
        /// <param name="url"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        static string GetToken(HttpClient client, Member user)
        {

            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync("/api/Auth", data).Result;
                if (response.IsSuccessStatusCode)
                {
                    string token = response.Content.ReadAsStringAsync().Result;
                    return token;
                }

                return null;
            
        }
    }
}
