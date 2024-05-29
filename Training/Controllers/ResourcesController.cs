using Microsoft.AspNetCore.Mvc;

namespace Training.Controllers
{
    [Route("Res")]
    public class ResourcesController : Controller
    {

        [HttpGet("ResourceData")]

        public ActionResult GetResult()
        {

            var res = new
            {
                name = "RAGHUL",
                message = "HEllo World",
            };


            return Json(res);
        }

        [HttpPost("SendData")]

        public ActionResult GetResult(string name, string Message)
        {
            var res = new
            {
                User_Name = name,
                Message = Message

            };
            return Json(res);
        }
    }
}
