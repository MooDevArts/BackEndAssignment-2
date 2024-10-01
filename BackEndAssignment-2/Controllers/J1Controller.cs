using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAssignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        /// <summary>
        /// Calculates total points based on deliveries and collisions.
        /// </summary>
        /// <returns>
        /// Returns the total points as an integer.
        /// </returns>
        /// <param name="info">
        /// Contains the number of deliveries and collisions.
        /// </param>
        /// <example>
        /// POST /api/j1/deliveroid with { "deliveries": 5, "collisions": 2 } returns 730.
        /// </example>


        [HttpPost("deliveroid")]

        public int getPoints([FromBody] GameInfo info)
        {
            int pointsForDeliveries = info.Deliveries * 50;
            int pointsForCollisions = info.Collisions * 10 * -1;
            int moreDels = 0;

            if(info.Deliveries > info.Collisions) {
                moreDels = 500;
            }

            return pointsForDeliveries + pointsForCollisions + moreDels;
        }
    }

    public class GameInfo
    {
        public int Deliveries { get; set; }
        public int Collisions { get; set; }
    }
}
