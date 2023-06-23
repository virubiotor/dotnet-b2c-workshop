using Microsoft.AspNetCore.Mvc;

namespace B2CDemo.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class B2CController : ControllerBase
    {
        public class UserModel
        {
            public string RegistrationCode { get; set; } = string.Empty;
        }

        public class ValidateRegistrationCodeResponse
        {
            public bool IsValidUser { get; set; }
        }

        private readonly ILogger<B2CController> _logger;

        public B2CController(ILogger<B2CController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("validate-registration-code")]
        [ProducesResponseType(typeof(ValidateRegistrationCodeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public ValidateRegistrationCodeResponse ValidateRegistrationCode(UserModel user)
        {
            _logger.LogInformation($"Called ValidateRegistrationCode with RegistrationCode: {user.RegistrationCode}");
            if (user.RegistrationCode == "DotNetMadrid2023")
            {
                return new ValidateRegistrationCodeResponse
                {
                    IsValidUser = true
                };
            }
            else
            {
                return new ValidateRegistrationCodeResponse
                {
                    IsValidUser = false
                };
            }
        }
    }
}