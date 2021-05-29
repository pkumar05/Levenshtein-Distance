using FluentValidation;
using LD.ApplicationServices;
using LD.AS.Interfaces;
using LD.Domain.DTO;
using LD.Domain.Interfaces;
using LD.Domain.Validator;
using LD.SQL.Infrastructure.Data;
using LD.SQL.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SD.BuildingBlocks.Infrastructure;
using SD.BuildingBlocks.Repository;

namespace LD.API.DependencyConfig
{
    public class DependencyConfig
    {
        private IServiceCollection _services;
        private IConfiguration _configuration;

        public DependencyConfig(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void ConfigureServices()
        {
            AddDependencyService();
            AddDependencyRepository();
            AddDependencyValidator();
            AddEmailClient();
            AddBizTalkEMailClient();
            AddDependencyBus();
        }


        /// <summary>
        /// AddDependencyValidator
        /// </summary>
        private void AddDependencyValidator()
        {
            _services.AddScoped<IValidator<FindLevenshteinDistanceRequest>,FindLevenshteinDistanceValidator>();
            

        }
        /// <summary>
        /// AddDependencyRepository
        /// </summary>
        private void AddDependencyRepository()
        {
            _services.AddScoped(typeof(IRepository<>), typeof(RepositoryEF<>));

            _services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            _services.AddScoped<IGenericMetaDataRequestRepos, GenericMetaDataRequestRepository>();
            _services.AddScoped<IGenericStringsComputationsRequestRepos, GenericStringsComputationsRequestRepository>();


        }

        /// <summary>
        /// AddDependencyService
        /// </summary>
        private void AddDependencyService()
        {
            _services.AddScoped<IFindLevenshteinDistance, FindLevenshteinDistanceBetweenTwoInputsService>();

        }

        public void AddEmailClient()
        {
            
        }

        public void AddBizTalkEMailClient()
        {
        }

        private void AddDependencyBus()
        {
        }



    }
}
