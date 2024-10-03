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

        /// <summary>
        /// Calculates total spiciness based on the ingredients passed
        /// </summary>
        /// <returns>
        /// Returns the total spiciness ( int )
        /// </returns>
        /// <param name="ingredients">
        /// Contains the different chilli names
        /// </param>
        /// <example>
        /// GET /api/j1/chillipeppers?ingredients=poblano,cayene,thai,poblano returns 118000
        /// </example>

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
                    return -1;
                }
            }

            // Return the total spiciness
            return totalSpice;
        }

        /// <summary>
        /// Calculates size of the Dusa when he runs away - details attached in question image
        /// </summary>
        /// <returns>
        /// Returns the size of Dusa when he ran away ( int )
        /// </returns>
        /// <param name="input">
        /// Contains the different chilli names
        /// </param>
        /// <example>
        /// GET /api/j1/chillipeppers?ingredients=5,3,2,9,20 returns 19
        /// </example>

        [HttpGet(template: "dusa-yobis")]

        public int getSizeOfDuseOnExit([FromQuery] string input)
        {
            List<string> sizes = new List<string>(input.Split(','));
            bool runAway = false;
            int dusaSize = int.Parse(sizes[0]);

            while(runAway == false)
            {
                for(int i = 1; i < sizes.Count; i++)
                {
                    if (int.Parse(sizes[i]) > dusaSize)
                    {
                        runAway = true;
                        break;
                    }
                    else
                    {
                        dusaSize = dusaSize + int.Parse(sizes[i]);
                    }
                }
            }

            return dusaSize;
        }
    }
}
