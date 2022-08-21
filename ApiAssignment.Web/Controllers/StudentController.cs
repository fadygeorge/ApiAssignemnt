using ApiAssignment.Logic.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace IdentityAuthApi.Web.Controllers
{
    public class StudentController : Controller
    {
        public string GetToken()
        {
            RestClient client = new RestClient("https://localhost:44355/api/Account/Login"); // localhost
            RestRequest request = new RestRequest();
            var model = new LoginViewModel { UserName = "Youssef", Password = "Aa@123456" };
            request.AddBody(model);
            var response = client.ExecutePost(request);
            var res = JsonConvert.DeserializeObject<ResultViewModel>(response.Content);
            return res.Data.ToString();
        }
        // GET: StudentController
        public ActionResult Index()
        {
            RestClient client = new RestClient("https://localhost:44355/api/Student/Get"); // localhost
            RestRequest request = new RestRequest();
            string s = "Bearer " + GetToken(); // token from postman or function
            request.AddHeader("Authorization", s);
            var response = client.ExecuteGet(request);
            var model = JsonConvert.DeserializeObject<IEnumerable<StudentViewModel>>(response.Content);
            return View(model);
        }

        
        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            RestClient client = new RestClient("https://localhost:44355/api/Student/GetS"); // localhost
            RestRequest request = new RestRequest(); // Config API
            request.AddParameter("id", id); // Send parameters to .Api as json
            string s = "Bearer " + GetToken(); // token from postman or function
            request.AddHeader("Authorization", s);
            var response = client.ExecuteGet(request);
            var model = JsonConvert.DeserializeObject<StudentViewModel>(response.Content); // Consume response returned from API
            return View(model);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel model)
        {
            try
            {
                RestClient client = new RestClient("https://localhost:44355/api/Student/Add"); // localhost
                RestRequest request = new RestRequest();
                request.AddBody(model);
                string s = "Bearer " + GetToken(); // token from postman or function
                request.AddHeader("Authorization", s);
                var response = client.ExecuteGet(request);
                var result = JsonConvert.DeserializeObject<ResultViewModel>(response.Content);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            RestClient client = new RestClient("https://localhost:44355/api/Student/GetS"); // localhost
            RestRequest request = new RestRequest(); // Config API
            request.AddParameter("id", id);
            string s = "Bearer " + GetToken(); // token from postman or function
            request.AddHeader("Authorization", s);
            var response = client.ExecuteGet(request);
            var model = JsonConvert.DeserializeObject<StudentViewModel>(response.Content); // Consume response returned from API
            return View(model);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentViewModel model)
        {
            try
            {
                RestClient client = new RestClient("https://localhost:44355/api/Student/Edit"); // localhost
                RestRequest request = new RestRequest();
                request.AddBody(model);
                string s = "Bearer " + GetToken(); // token from postman or function
                request.AddHeader("Authorization", s);
                var response = client.ExecuteGet(request);
                var result = JsonConvert.DeserializeObject<ResultViewModel>(response.Content);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            RestClient client = new RestClient("https://localhost:44355/api/Student/GetS"); // localhost
            RestRequest request = new RestRequest(); // Config API
            request.AddParameter("id", id);
            string s = "Bearer " + GetToken(); // token from postman or function
            request.AddHeader("Authorization", s);
            var response = client.ExecuteGet(request);
            var model = JsonConvert.DeserializeObject<StudentViewModel>(response.Content); // Consume response returned from API
            return View(model);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, StudentViewModel model)
        {
            try
            {
                RestClient client = new RestClient("https://localhost:44355/api/Student/Delete"); // localhost
                RestRequest request = new RestRequest(); // Config API
                request.AddParameter("id", id);
                string s = "Bearer " + GetToken(); // token from postman or function
                request.AddHeader("Authorization", s);
                var response = client.ExecuteGet(request);
                var res = JsonConvert.DeserializeObject<ResultViewModel>(response.Content); // Consume response returned from API
                if (res.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }
    }
}
