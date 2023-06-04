using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Identity.Web.Resource;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoListAPI.Models;
using TodoListAPI.Options;

namespace TodoListAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly GraphApiOptions graphApiOptions;
        private readonly CustomAttributesExtensionsOptions customAttributesExtensionOptions;

        public UsersController(IOptions<GraphApiOptions> graphApiOptions,
            IOptions<CustomAttributesExtensionsOptions> customAttributesExtensionOptions)
        {
            this.graphApiOptions = graphApiOptions?.Value ?? throw new ArgumentNullException(nameof(graphApiOptions));
            this.customAttributesExtensionOptions = customAttributesExtensionOptions?.Value ?? throw new ArgumentNullException(nameof(graphApiOptions));
        }

        [HttpGet]
        [Route("answers")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAdB2C:Scopes:Read")]
        public async Task<ActionResult<UsersAnswersModel>> GetAll()
        {
            var scopes = new[] { "https://graph.microsoft.com/.default" };

            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            var clientSecretCredential = new ClientSecretCredential(
                graphApiOptions.TenantId, graphApiOptions.ClientId, graphApiOptions.ClientSecret, options);

            var graphClient = new GraphServiceClient(clientSecretCredential, scopes);
            var requestParams = new Microsoft.Graph.Users.UsersRequestBuilder.UsersRequestBuilderGetQueryParameters
            {
                Select = new[]
                {
                    customAttributesExtensionOptions.AuthenticationAnswer,
                    customAttributesExtensionOptions.OidcAnswer,
                    customAttributesExtensionOptions.AadAnswer,
                    customAttributesExtensionOptions.B2cAnswer
                }
            };
            var users = await graphClient.Users.GetAsync(x => x.QueryParameters = requestParams);
            var usersAnswers = users.Value.Select(x => new
            {
                AuthAnswer = x.AdditionalData.FirstOrDefault(y => y.Key == customAttributesExtensionOptions.AuthenticationAnswer).Value,
                OIDCAnswer = x.AdditionalData.FirstOrDefault(y => y.Key == customAttributesExtensionOptions.OidcAnswer).Value,
                AADAnswer = x.AdditionalData.FirstOrDefault(y => y.Key == customAttributesExtensionOptions.AadAnswer).Value,
                B2CAnswer = x.AdditionalData.FirstOrDefault(y => y.Key == customAttributesExtensionOptions.B2cAnswer).Value,
            }).ToList();

            var answers = new UsersAnswersModel
            {
                AuthenticationAnswers = new AnswerModel(usersAnswers.Select(x=>x.AuthAnswer)),
                OidcAnswers = new AnswerModel(usersAnswers.Select(x => x.OIDCAnswer)),
                AadAnswers = new AnswerModel(usersAnswers.Select(x => x.AADAnswer)),
                B2cAnswers = new AnswerModel(usersAnswers.Select(x => x.B2CAnswer)),
            };

            return answers;
        }
    }
}
