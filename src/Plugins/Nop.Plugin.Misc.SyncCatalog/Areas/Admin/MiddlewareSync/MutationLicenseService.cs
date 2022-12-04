using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using ModernHttpClient;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models;
using Nop.Services.Configuration;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync
{
    public class MutationLicenseService
    {
        private static GraphQLHttpClient _graphQLHttpClient;

        static MutationLicenseService()
        {
            var setting = EngineContext.Current.Resolve<ISettingService>().LoadSettingAsync<SettingModel>().Result;
            var uri = new Uri(setting.UrlService);
            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = uri,
                HttpMessageHandler = new NativeMessageHandler(),
            };

            _graphQLHttpClient = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());
        }

        public static async Task<T> ExceuteMutationAsyn<T>(string completeQueryString)
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = completeQueryString
                };

                var response = await _graphQLHttpClient.SendMutationAsync<object>(request);
                var jsonResult = response.Data.ToString();
                return JsonConvert.DeserializeObject<T>(jsonResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
