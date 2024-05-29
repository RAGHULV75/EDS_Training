using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json;
using Training.Models;

namespace Training.Controllers
{
    [Route("test")]
    public class TestController : Controller
    {
        [HttpGet("greetings")]
        public IActionResult Greetings([FromQuery] string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                string greeting = $"Welcome, {name}!";
                return Json(greeting);
            }
            else
            {
                return BadRequest("Please provide a valid name.");
            }
        }


        [Route("getinfo")]
        public String GetInfo()
        {
            String UserName = "John Doe";

            return UserName;
        }

        [HttpGet("GetRes")]
        public IActionResult GetStringAsJson()
        {
            var namePairs = new
            {
                ResponceCode = 204,
                ResponceMessage = "RAGHUL V",
                ResponceList = "hello world",
               
            };

            return Json(namePairs);
        }

        [HttpGet("loopoperation")]
        public IActionResult NumOperation()
        {
            var resultDictionary = new Dictionary<string, int>();

            for (int n = 1; n <= 10; n++)
            {
                resultDictionary[$"key {n}"] = n;
            }

            return Json(resultDictionary);
        }

        [HttpGet("Airthmatic_Operation")]
        public IActionResult Add()
        {

            var namePairs = new
            {
                Add = 22 + 55,
                subtract = 50 - 30,
                multiply = 30 * 2,
                divide = 500 / 2,
            };

            return Json(namePairs);
        }

        [HttpGet("current")]
        public IActionResult GetCurrentDateTime()
        {
            DateTime currentDateTime = DateTime.Now;

            var result = new
            {
                Day = currentDateTime.Day,
                Month = currentDateTime.Month,
                Year = currentDateTime.Year,
                Hour = currentDateTime.Hour,
                Minute = currentDateTime.Minute,
                Second = currentDateTime.Second
            };

            return Json(result);
        }

        [HttpGet("getrandomnumbers")]
        public IActionResult GetRandomNumberAsJson()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);

            var result = new
            {
                Random_Number = randomNumber
            };

            return Json(result);
        }

        [Route("hello/greetings")]
        [HttpGet]
        public HttpResponseMessage WelcomeGreetings()
        {
            try
            {
                // Prepare the welcome message
                string welcomeMessage = "Welcome!";

                // Create a successful HTTP response with the message
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(welcomeMessage, Encoding.UTF8, "text/plain")
                };

                return response;
            }
            catch (Exception ex)
            {
                // Handle exceptions gracefully
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"An error occurred: {ex.Message}", Encoding.UTF8, "text/plain")
                };
            }
        }



        dynamic APIOutputResponse;

        [Route("GetData")]
        [HttpGet]
        public HttpResponseMessage Details()
        {
            string name = "hello world";
            var response = CreateResponse(220, name, "How Are You?");
            return response;
        }


        [Route("GetString")]
        [HttpGet]

        public HttpResponseMessage GetCompanyName()
        {
            try
            {
                string mReponseList = "Easy design systems";
                APIOutputResponse = CreateResponse(2000, "Success", mReponseList);
            }
            catch (Exception ex)
            {
                APIOutputResponse = CreateResponse(5000, ex.Message, "");
            }

            return APIOutputResponse;
        }

        private HttpResponseMessage CreateResponse(int aResponseCode, string aReponseMessage, dynamic aResponseList)
        {
            APIResponse mAPIResponse = null;
            HttpResponseMessage mHttpResponseMessage = null;
            try
            {
                mHttpResponseMessage = new HttpResponseMessage();
                mAPIResponse = new APIResponse();
                mAPIResponse.ResponseCode = aResponseCode;
                mAPIResponse.ResponseMessage = aReponseMessage;
                mAPIResponse.ResponseList = aResponseList;
                if (aResponseCode == 5000)
                {
                    mHttpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                }
                mHttpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(mAPIResponse), Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                mAPIResponse.ResponseCode = 5000;
                mAPIResponse.ResponseMessage = ex.Message;
                mHttpResponseMessage.StatusCode = HttpStatusCode.BadRequest;
                mHttpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(mAPIResponse), Encoding.UTF8, "application/json");
            }
            return mHttpResponseMessage;
        }

        public class APIResponse
        {
            public int ResponseCode { get; set; }
            public string ResponseMessage { get; set; }
            public dynamic ResponseList { get; set; }
        }


    }
}

