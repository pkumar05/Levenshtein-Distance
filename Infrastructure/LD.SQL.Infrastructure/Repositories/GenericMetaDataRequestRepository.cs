using LD.Domain.Entities;
using LD.Domain.Interfaces;
using LD.SQL.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using SD.BuildingBlocks.Repository;

namespace LD.SQL.Infrastructure.Repositories
{
    public class GenericMetaDataRequestRepository : RepositoryEF<GenericMetaData>, IGenericMetaDataRequestRepos
    {
        private readonly LDDBContext dbContext;
        public IConfiguration configuration;

        public GenericMetaDataRequestRepository(LDDBContext _dBContext, IConfiguration _configuration) : base(_dBContext)
        {
            dbContext = _dBContext;
            configuration = _configuration;

        }

    }
}
