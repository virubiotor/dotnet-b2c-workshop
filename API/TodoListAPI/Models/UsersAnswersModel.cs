namespace TodoListAPI.Models
{
    public class UsersAnswersModel
    {
        public AnswerModel AuthenticationAnswers { get; set; }
        public AnswerModel OidcAnswers { get; set; }
        public AnswerModel AadAnswers { get; set; }
        public AnswerModel B2cAnswers { get; set; }
    }
}
