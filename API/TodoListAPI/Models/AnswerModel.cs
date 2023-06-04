using System.Collections.Generic;
using System.Linq;

namespace TodoListAPI.Models
{
    public class AnswerModel
    {
        public AnswerModel(IEnumerable<object> answers)
        {
            Yes = answers.Where(x => x != null && bool.Parse(x.ToString())).Count();
            No = answers.Where(x => x != null && !bool.Parse(x.ToString())).Count();
            NoAnswer = answers.Where(x => x is null).Count();
        }

        public int Yes { get; private set; }
        public int No { get; private set; }
        public int NoAnswer { get; private set; }
    }
}
