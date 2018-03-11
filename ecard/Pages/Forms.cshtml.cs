using ecard.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ecard.Pages
{
    public class FormsModel : PageModel
    {
        // 1.Steps to use the Database in the controller- able to maniplute in controller... BEFORE YOU LOAD IT WE ARE GOING TO BIND IT
        [BindProperty]
        public Greetings _myGreetings { get; set; }

        // 2. WOWOCO:
        private DbBridge _myDbBridge { get; set; }

        // 3.WOWOCO:
        private IConfiguration _myConfiguration { get; set; }

        //4. WOWOCO:
        public FormsModel(DbBridge DbBridge, IConfiguration Configuration)
        {
            _myDbBridge = DbBridge;
            _myConfiguration = Configuration;

        }

        public void OnGet() { }

        [HttpPost]
        public async Task<IActionResult> OnPost()
        {

            if (await isValid())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        // DB Related Customized values added with each record
                        _myGreetings.created = DateTime.Now.ToString();
                        _myGreetings.created_ip = this.HttpContext.Connection.RemoteIpAddress.ToString();

                        //replacing  the i with a 3 
                        _myGreetings.friendsName = _myGreetings.friendsName.Replace("i", "3");

                        //
                        _myGreetings.friendsName = _myGreetings.friendsName.Replace("She said", \"Hello!\"", "");


                        //escaping the quote
                        _myGreetings.friendsName = _myGreetings.friendsName.Replace("\"", "&quot;");

                        //Clean Data before insertion... the field sender email... make it lower case 
                        _myGreetings.yourEmail = _myGreetings.yourEmail.ToLowerInvariant();
                        _myGreetings.friendsEmail = _myGreetings.friendsEmail.ToUpperInvariant();

                        // DB Related add record... add to the db and save
                        _myDbBridge.Greetings.Add(_myGreetings);
                        _myDbBridge.SaveChanges();

                        //REDIRECT to the page with a new operator (name/value pair)
                        return RedirectToPage("Forms", new { id = _myGreetings.ID });
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return RedirectToPage("Index");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("_myGreetings.reCaptcha", "Please verify you're not a robot!");
            }

            return Page();

        }

        /**
         * reCAPTHCA SERVER SIDE VALIDATION 
         * 
         *      Create an HttpClient and store the the secret/response pair
         *      Await for the sever to return a json obect 
         * */
        private async Task<bool> isValid()
        {
            var response = this.HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(response))
                return false;

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>();
                    //values.Add("secret", "6Le5_S0UAAAAADVyjgJOG_4ptTimv71jLTGh8ZI0");
                    values.Add("secret", _myConfiguration["ReCaptcha:PrivateKey"]);

                    values.Add("response", response);
                    //values.Add("remoteip", this.HttpContext.Connection.RemoteIpAddress.ToString()); 

                    var query = new FormUrlEncodedContent(values);

                    var post = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", query);

                    var json = await post.Result.Content.ReadAsStringAsync();

                    if (json == null)
                        return false;

                    var results = JsonConvert.DeserializeObject<dynamic>(json);

                    return results.success;
                }

            }
            catch { }

            return false;
        }

    }
}
