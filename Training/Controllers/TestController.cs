using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
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
        public IActionResult GetInfo()
        {
            var userInfo = new
            {
                UserName = "John Doe",
                UserEmail = "john@example.com",
                MobileNumber = "123-456-7890",
                Address = "123 Main St, City"
            };

            return Json(userInfo);
        }

        [HttpGet("getstringasjson")]
        public IActionResult GetStringAsJson()
        {
            var namePairs = new
            {
                First_Name = "John ",
                Secound_Name = "Doe",
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

        [HttpGet("responces")]

        public HttpResponseMessage GetCompanyName()

        {

            Console.WriteLine("Hello workd");

          
            try
            {
                //string mReponseList = "Easy design systems";
                Console.WriteLine("Hello");
                var response = new
                {
                    ResponseCode = 2000,
                    ResponseMessage = "Success",
                    ResponseList = "Easy design systems"
                };

                var json = JsonSerializer.Serialize(response);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = content };
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    ResponseCode = 5000,
                    ResponseMessage = ex.Message,
                    ResponseList = "Easy design systems"
                };

                var json = JsonSerializer.Serialize(errorResponse);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = content };
            }
        }


        public IActionResult MyAction()
        {
            var model = new TestModel
            {
                Id = 1,
                Name = "Product A",
                Price = 99,
            };
            return View(model);
        }




    }
}
