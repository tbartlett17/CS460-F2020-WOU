using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HW7Project.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace HW7Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            string secret = _config["GitHub:PersonalAccessToken"];
            //Debug.WriteLine("key: " + secret);

            string myGitJsonUser = SendRequest("https://api.github.com/user", secret, "tbartlett17");
            string myGitJsonRepos = SendRequest("https://api.github.com/user/repos", secret, "tbartlett17");

            GitHubUser user = JsonConvert.DeserializeObject<GitHubUser>(myGitJsonUser);
            user.Repos = JsonConvert.DeserializeObject<IEnumerable<GitHubRepo>>(myGitJsonRepos);

            foreach (GitHubRepo r in user.Repos)
            {
                DateTime d1 = DateTime.Now;
                DateTime d2 = DateTime.Parse(r.Updated_at, null, System.Globalization.DateTimeStyles.RoundtripKind);
                TimeSpan ts = d1 - d2;
                r.Updated_at = ts.Days.ToString();

            }

            //Debug.WriteLine("1st repo owner: {0} 1st Repo Last Updated: {1}", user.Repos.FirstOrDefault().Owner.Name, user.Repos.FirstOrDefault().LastUpdated);
            //Debug.WriteLine("\n\nName: {0} \n Email: {1} Repo1: {2} \n\n", user.Name, user.Email, user.Repos.First().Owner.Login); //this seems to work so gucci 
            //Debug.WriteLine("\n\n" + myGitJsonRepos + "\n\n");
            return View(user);
        }

        public IActionResult Commits(string user, string repo)
        {
            string secret = _config["GitHub:PersonalAccessToken"];

            string commitsReq = SendRequest("https://api.github.com/repos/" + user + "/" + repo + "/commits", secret, "tbartlett17");
            return Json(commitsReq);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }

    }
}
