


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
    public class QFormModel : PageModel
    {

        // WOWOCO: 1
        [BindProperty]
        public Questions _myQuestions { get; set; }

        // WOWOCO: 2
        private DbBridge _myDbBridge { get; set; }

        // WOWOCO: 3
        private IConfiguration _myConfiguration { get; set; }

        // WOWOCO: 4
        public QFormModel(DbBridge DbBridge, IConfiguration Configuration)
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
                        _myQuestions.created = DateTime.Now.ToString();
                        _myQuestions.created_ip = this.HttpContext.Connection.RemoteIpAddress.ToString();


                        //_myQuestions.friendname = _myQuestions.friendname.Replace("i", "3");
                        //_myQuestions.friendname = _myQuestions.friendname.Replace("She said, \"Hello!\"", "");
                        //_myQuestions.senderemail = _myQuestions.senderemail.ToLowerInvariant();
                        //_myQuestions.friendemail = _myQuestions.friendemail.ToUpperInvariant();

                        // DB Related add record
                        _myDbBridge.Questions.Add(_myQuestions);
                        _myDbBridge.SaveChanges();

                        //REDIRECT to the page with a new operator (name/value pair)
                        return RedirectToPage("QForm", new { id = _myQuestions.ID });
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        return RedirectToPage("QForm");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("_myQuestions.reCaptcha", "Please verify you're not a robot!");
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
                    //values.Add("secret", "6LfVpjEUAAAAAK0FdygAgh0P1gZ8QU24ildwT86r");
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
