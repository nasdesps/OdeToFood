using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    //[Route("about")] or [Route("company/about")]
    [Route("company/[controller]/[action]")]
    public class AboutController
    {
        //[Route("")]
        //[Route("[action]")]
        public string Phone() => "1+555+555+5555";

        //[Route("address")]
        //[Route("[action]")]
        public string Address() => "USA";
        

    }
}
