using Newtonsoft.Json;
using System.Web.Mvc;

namespace GJF.Controllers
{
    [Authorize]
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class BaseController : Controller
    {
        protected ContentResult SerializeAsJson(object obj, ReferenceLoopHandling referenceLoopHandling = ReferenceLoopHandling.Ignore)
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(json, "application/json");
        }
    }
}