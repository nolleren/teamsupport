using BLL.Data;

namespace GraphQL.Data.Subscriptions
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class AnswerSubscription
    {
        [Subscribe]
        public Answer AnswerAdded([EventMessage] Answer answer) => answer;
    }
}
