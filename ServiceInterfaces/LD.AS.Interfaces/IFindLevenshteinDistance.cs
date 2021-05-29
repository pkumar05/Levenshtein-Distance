using LD.Domain.DTO;
using System.Threading.Tasks;

namespace LD.AS.Interfaces
{
    public interface IFindLevenshteinDistance
    {
        Task<ServiceResponse> FindLevenshteinDistanceBetweenTwoInputs(FindLevenshteinDistanceRequest request, string requestedUser);

        Task<ServiceResponse> AddCalculatedLevenshteinDistance(AddLevenshteinDistanceBetweenTwoStrings request, string createdBy);

        Task<ServiceResponse> GetAllStringsLevenshteinDistance();
    }
}
