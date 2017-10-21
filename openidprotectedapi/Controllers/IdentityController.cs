using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("identity")]
[Authorize]
public class IdentityController : Controller
{
    [HttpGet]
    public IActionResult Get(){
        var clms = from c in User.Claims
                     select new {c.Type,c.Value};
        return new JsonResult(clms);
    }
}