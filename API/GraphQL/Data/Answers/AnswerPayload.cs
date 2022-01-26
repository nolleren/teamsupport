using GraphQL.Data.Common;
using BLL.Data;

namespace GraphQL.Data.Answers
{
    public class AnswerPayload
    {
        public AnswerPayload(UserError error)
        {
            Errors = new[] { error };
        }

        public AnswerPayload(Answer answer)
        {
            Answer = answer;
        }

        public AnswerPayload()
        {
        }

        protected AnswerPayload(IReadOnlyList<UserError>? errors = null)
        {
            Errors = errors;
        }

        public IReadOnlyList<UserError>? Errors { get; }
        public Answer? Answer { get; set; }
    }
}
