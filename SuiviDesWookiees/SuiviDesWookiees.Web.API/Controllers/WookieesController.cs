using Microsoft.AspNetCore.Mvc;
using SuiviDesWookiees.Libs;
using SuiviDesWookiees.Libs.Services;

namespace SuiviDesWookiees.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class WookieesController : ControllerBase
    {

        [HttpGet]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        //[ProducesResponseType(typeof(IEnumerable<Wookiee>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Wookiee>> Get(IWookieeService service)
        {
            //throw new NotImplementedException();
            var result = service.GetAll();

            //var wookie = service.GetOne();

            return this.Ok(result);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public IActionResult Add(CacheItemMultiple item)//([FromQuery] string filter)
        {
            if (ModelState.IsValid)
            {

            }

            return this.Ok();
        }

        [BindProperty(Name = "NbPartiesGagnees", SupportsGet = true)]
        public int NbPartiesGagnees { get; set; }

        [BindProperty(Name = "FilterTest", SupportsGet = true)]
        [FromHeader]
        // [Required]
        public string? Filter { get; set; } = string.Empty;
    }

    public class CacheItemMultiple
    {
        [FromHeader(Name = "Accept")]
        public string Accept { get; set; } = "";

        [FromQuery(Name = "filter")]
        public string? Filter { get; set; }
    }

    //public class CacheItem
    //{
    //    public int Id { get; set; }

    //    //[AllowNull]
    //    public required string Name { get; set; }

    //    [Required]
    //    public string Surname { get; set; } = string.Empty;
    //}
}
