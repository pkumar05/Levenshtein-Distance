using LD.AS.Interfaces;
using LD.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LD.API.Controllers.LevenshteinDistance
{
    [Produces("application/json")]
    [Route("api/[controller]")]
   // [Authorize]  // Comment this line until token authentication mechanism (JWT token) available
    public class LevenshteinDistanceController : LDControllerBase
    {
        private readonly IFindLevenshteinDistance _findLevenshteinDistance;

        public LevenshteinDistanceController(IFindLevenshteinDistance findLevenshteinDistance,
            ILogger<LevenshteinDistanceController> logger
            ) : base(logger)
        {
            _findLevenshteinDistance = findLevenshteinDistance;
        }

        /// <summary>
        /// API added to find Levenshtein Distance between two string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FindLevenshteinDistance")]
        //[HasPermission(ProcessName = "ADMIN", SubProcessName = "CREATE")]
        public async Task<IActionResult> FindLevenshteinDistance(FindLevenshteinDistanceRequest request)
        {
            string user = User.Identity.Name;
            try
            {
                var result = await _findLevenshteinDistance.FindLevenshteinDistanceBetweenTwoInputs(request, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                return HandleUserException(ex);
            }
        }

        /// <summary>
        /// API added to get all the saved strings Levenshtein Distance
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllSavedStringsLevenshteinDistance")]
        //[HasPermission(ProcessName = "ADMIN", SubProcessName = "CREATE")]
        public async Task<IActionResult> GetAllSavedStringsLevenshteinDistance()
        {
            string user = User.Identity.Name;
            try
            {
                var result = await _findLevenshteinDistance.GetAllStringsLevenshteinDistance();
                return Ok(result);
            }

            catch (Exception ex)
            {
                return HandleUserException(ex);
            }
        }

    }
}
