using LD.Domain.Entities;
using LD.Domain.Interfaces;
using LD.SQL.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using SD.BuildingBlocks.Repository;

namespace LD.SQL.Infrastructure.Repositories
{
    public class GenericStringsComputationsRequestRepository : RepositoryEF<GenericStringsComputations>, IGenericStringsComputationsRequestRepos
    {
        private readonly LDDBContext dbContext;
        public IConfiguration configuration;

        public GenericStringsComputationsRequestRepository(LDDBContext _dBContext, IConfiguration _configuration) : base(_dBContext)
        {
            dbContext = _dBContext;
            configuration = _configuration;

        }

    }
}
