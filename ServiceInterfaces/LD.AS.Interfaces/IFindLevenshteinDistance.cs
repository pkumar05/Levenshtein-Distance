using LD.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LD.AS.Interfaces
{
    public interface IFindLevenshteinDistance
    {
        Task<ServiceResponse> FindLevenshteinDistanceBetweenTwoInputs(string source, string target, string requestedUser);

        Task<ServiceResponse> AddCalculatedLevenshteinDistance(string inputOne, string inputTwo, int levenshteinDistanceVal, string createdBy);
    }
}
