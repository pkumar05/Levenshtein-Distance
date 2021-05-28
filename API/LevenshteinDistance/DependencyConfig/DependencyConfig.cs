using LD.ApplicationServices;
using LD.AS.Interfaces;
using LD.Domain.Interfaces;
using LD.SQL.Infrastructure.Data;
using LD.SQL.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SD.BuildingBlocks.Infrastructure;
using SD.BuildingBlocks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            #region Commented Codes
            //_services.AddScoped<IValidator<GroupsRequest>, GroupsRequestValidator>();
            //_services.AddScoped<IValidator<CompanyRequest>, CompanyRequestValidator>();

            #endregion

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
            #region Commented Codes
            //_services.AddScoped<INotificationService, RabbitMqNotificationService>();

            //_services.AddScoped<IUserSession, UserSession>();

            #endregion

            _services.AddScoped<IFindLevenshteinDistance, FindLevenshteinDistanceBetweenTwoInputsService>();

        }

        public void AddEmailClient()
        {
            #region commented Codes
            //    if (_configuration["SMTP:SMTPEnabled"] == "true")
            //        _services.Configure<SmtpOptions>(_configuration.GetSection("SMTP"));
            //    _services.AddSingleton<ISmtpEmailClient, SmtpEmailClient>();
            #endregion
        }

        public void AddBizTalkEMailClient()
        {
            #region commented Codes
            //var baseUrl = _configuration["BiztalkEmailClient:EmailBase"];
            //var apiMethod = _configuration["BiztalkEmailClient:ApiMethod"];
            //var proxy = _configuration["BiztalkEmailClient:Proxy"];
            //_services.AddScoped<IEmailClient>(x =>
            //{
            //    return new BizTalkEMailClient
            //    {
            //        BaseUrl = baseUrl,
            //        ApiMethod = apiMethod,
            //        Proxy = proxy
            //    };
            //});
            #endregion
        }

        private void AddDependencyBus()
        {
        }



    }
}
