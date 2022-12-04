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
    public class Query
    {
        private static GraphQLHttpClient _graphQLHttpClient;

        static Query()
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="completeQueryString"></param>
        /// <returns></returns>
        public static async Task<T> ExceuteQueryAsync<T>(string completeQueryString, bool auth = false, string bearer = "")
        {
            try
            {
                var request = new GraphQLRequest
                {
                    Query = completeQueryString
                };
                if (auth)
                    _graphQLHttpClient.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearer}");

                var response = await _graphQLHttpClient.SendQueryAsync<object>(request);

                var jsonResult = response.Data.ToString();
                return JsonConvert.DeserializeObject<T>(jsonResult);

            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<T>(string.Empty);

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchValue"></param>
        /// <param name="searchType"></param>
        /// <param name="completeQueryString"></param>
        /// <returns></returns>
        public static async Task<T> ExceuteQueryAsync<T>(string searchValue, string completeQueryString)
        {
            var request = new GraphQLRequest
            {
                Query = completeQueryString,
                Variables = new
                {
                    searchValue = searchValue
                }
            };
            var setting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore

            };

            var response = await _graphQLHttpClient.SendQueryAsync<object>(request);

            var jsonResult = response.Data.ToString();
            return JsonConvert.DeserializeObject<T>(jsonResult, setting);

        }
    }
}
