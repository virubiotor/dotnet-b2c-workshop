namespace TodoListAPI.Options
{
    public class CustomAttributesExtensionsOptions
    {
        public const string SectionName = "CustomAttributes";

        public string AuthenticationAnswer { get; set; }

        public string OidcAnswer { get; set; }

        public string AadAnswer { get; set; }

        public string B2cAnswer { get; set; }
    }
}
