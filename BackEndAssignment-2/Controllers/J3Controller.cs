using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace BackEndAssignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {
        [HttpPost(template:"bronze")]

        /// <summary>
        /// Calculates the bronze score, and how many players had that score
        /// </summary>
        /// <returns>
        /// Returns the bronze score and the no. of players that had that score
        /// </returns>
        /// <param name="comp">
        /// Contains the no. of players and a string of scores
        /// </param>
        /// <example>
        /// 
        /// curl -X 'POST' \
        /// 'https://localhost:7049/api/J3/bronze' \
        ///   -H 'accept: text/plain' \
        /// -H 'Content-Type: application/json' \
        /// -d '{
        /// "noOfPlayers": 7,
        /// "scores": "10,20,30,30,30,40,50"
        ///  }'
        ///  
        /// returns 30 3
        /// 
        /// </example>

        public string bronzeScoreAndNumberofWinners([FromBody] CompInfo comp)
        {
            Answer answer = new Answer();
            answer.Score = 10;
            answer.PlayersWon = 2;

            // create a list by converting them all to ints
            List<int> scoresList = comp.Scores.Split(',')
                                    .Select(int.Parse)
                                    .ToList();
            //sort the list
            scoresList.Sort((a, b) => b.CompareTo(a));

            //getting the bronze score
            int bronzeScore = scoresList[2];

            //count how many times this values occurs in our list of scores
            int count = scoresList.Count(x => x == bronzeScore);

            //putting these values in the answer object
            answer.PlayersWon = count;
            answer.Score = bronzeScore;
            
            return $"{answer.Score} {answer.PlayersWon}";
        }

    }

    

    public class CompInfo
    {
        public int NoOfPlayers { get; set; }
        public string Scores { get; set; }
    }

    public class Answer 
    {
        public int Score { get; set; }
        public int PlayersWon { get; set; }
    }
}
