using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAssignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        // A dictionary to store chili names values
        private static readonly Dictionary<string, int> ChiliSpiceValues = new Dictionary<string, int>
        {
            { "poblano", 1500 },
            { "mirasol", 6000 },
            { "serrano", 15500 },
            { "cayenne", 40000 },
            { "thai", 75000 },
            { "habanero", 125000 }
        };

        [HttpGet(template: "chilipeppers")]
        public int CalcSpiciness([FromQuery] string ingredients)
        {
            // Split the ingredients by comma
            List<string> ingredientList = new List<string>(ingredients.Split(','));

            // Initialize a variable to keep track of total spiciness
            int totalSpice = 0;

            // Iterate through each ingredient
            foreach (var ingredient in ingredientList)
            {
                // Trim any extra spaces and convert to lowercase to match dictionary keys
                string trimmedIngredient = ingredient.Trim().ToLower();

                // Check if the ingredient exists in the dictionary
                if (ChiliSpiceValues.TryGetValue(trimmedIngredient, out int spiceValue))
                {
                    // Add the spice value to the total
                    totalSpice += spiceValue;
                }
                else
                {
                    // Handle the case where the ingredient is not found in the dictionary
                    return 0;
                }
            }

            // Return the total spiciness
            return totalSpice;
        }
    }
}
