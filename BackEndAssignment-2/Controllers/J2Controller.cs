using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAssignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        [HttpGet(template:"chilipeppers")]

        public string calcSpiciness([FromQuery] string ingredients)
        {
            // Split the ingredients by comma and store them in a list
            List<string> ingredientList = new List<string>(ingredients.Split(','));

            // You can now work with the list of ingredients as needed
            return $"Received ingredients: {string.Join(", ", ingredientList)}";
        }
    }
}
