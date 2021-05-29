using AutoMapper;
using LD.AS.Interfaces;
using LD.Domain.DTO;
using LD.Domain.Entities;
using LD.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using SD.BuildingBlocks.Infrastructure;
using System;
using System.Threading.Tasks;

namespace LD.ApplicationServices
{
    public class FindLevenshteinDistanceBetweenTwoInputsService : IFindLevenshteinDistance
    {
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitofWork;

        readonly IGenericMetaDataRequestRepos _genericMetaDataRequestRepos;
        readonly IGenericStringsComputationsRequestRepos _genericStringsComputationsRequestRepos;

        ServiceResponse response = new ServiceResponse();
        public FindLevenshteinDistanceBetweenTwoInputsService(IUnitOfWork unitOfWork,
            IGenericMetaDataRequestRepos genericMetaDataRequestRepos,
            IGenericStringsComputationsRequestRepos genericStringsComputationsRequestRepos,
            IMapper mapper

            )
        {
            _unitofWork = unitOfWork;
            _genericMetaDataRequestRepos = genericMetaDataRequestRepos;
            _genericStringsComputationsRequestRepos = genericStringsComputationsRequestRepos;
            _mapper = mapper;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputOne"></param>
        /// <param name="inputTwo"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> AddCalculatedLevenshteinDistance(AddLevenshteinDistanceBetweenTwoStrings request, string createdBy)
        {

            try
            {

                var levenshteinDistance = _genericStringsComputationsRequestRepos.Get(x => x.Active && x.Source == request.Source && x.Target == request.Target);
                if (levenshteinDistance == null)
                {
                    GenericStringsComputations gsc = new GenericStringsComputations
                    {
                        ID = Guid.NewGuid().ToString(),
                        Source = request.Source,
                        Target = request.Target,
                        LevenshteinDistance = request.LevenshteinDistanceVal,
                        Active = true,
                        CreatedBy = createdBy,
                        CreatedDate = DateTime.Now
                    };
                    _genericStringsComputationsRequestRepos.Add(gsc);
                    await _unitofWork.CommitAsync();

                    response.success = true;
                }
                return await Task.Run(() => response);
            }

            catch (Exception ex)
            { throw; }
        }

        /// <summary>
        /// Method to calculate Levenshtein Distance Between Two string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> FindLevenshteinDistanceBetweenTwoInputs(FindLevenshteinDistanceRequest request, string requestedUser)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {

                int n = request.Source.Length;
                int m = request.Target.Length;
                int[,] d = new int[n + 1, m + 1];

                if (!string.IsNullOrEmpty(request.Source))
                    request.Source = request.Source.ToUpper();

                if (!string.IsNullOrEmpty(request.Target))
                    request.Target = request.Target.ToUpper();

                if (!string.IsNullOrEmpty(requestedUser))
                    requestedUser = requestedUser.ToUpper();
                else
                    requestedUser = CommonConstants.SYSTEM;


                if (n == 0)
                {
                    n = m;    // return m;
                }

                if (m == 0)
                {
                    m = n;  //return n;
                }

                for (int i = 0; i <= n; i++)
                    d[i, 0] = i;
                for (int j = 0; j <= m; j++)
                    d[0, j] = j;

                for (int j = 1; j <= m; j++)
                    for (int i = 1; i <= n; i++)
                        if (request.Source[i - 1] == request.Target[j - 1])
                            d[i, j] = d[i - 1, j - 1];  //no operation
                        else
                            d[i, j] = Math.Min(Math.Min(
                                d[i - 1, j] + 1,    //a deletion
                                d[i, j - 1] + 1),   //an insertion
                                d[i - 1, j - 1] + 1 //a substitution
                                );
                response.data = d[n, m];


                int levenshteinDistanceVal = Convert.ToInt32(response.data);

                var addLevenshteinDistanceBetweenTwoStrings = new AddLevenshteinDistanceBetweenTwoStrings();
                addLevenshteinDistanceBetweenTwoStrings.Source = request.Source;
                addLevenshteinDistanceBetweenTwoStrings.Target = request.Target;
                addLevenshteinDistanceBetweenTwoStrings.LevenshteinDistanceVal = levenshteinDistanceVal;

                var addLevenshteinDistanceVal = AddCalculatedLevenshteinDistance(addLevenshteinDistanceBetweenTwoStrings, requestedUser);

                response.msg = CommonConstants.Successfull;
                response.success = true;


                response.success = true;
                return await Task.Run(() => response);
            }
            catch (Exception ex) { throw; }
        }

        /// <summary>
        /// Method added to retrieve all Levenshtein distance for all the strings
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse> GetAllStringsLevenshteinDistance()
        {
            try
            {
                var data = _genericStringsComputationsRequestRepos.GetAll(x => x.Active);
                if (data.Any())
                {
                    response.data = data;
                    response.msg = CommonConstants.RecordsRetrievedSuccessfully;

                }
                else
                    response.msg = CommonConstants.NoDataAvailable;

                response.success = true;
                return await Task.Run(() => response);
            }
            catch (Exception ex)
            { throw; }
        }
    }
}
