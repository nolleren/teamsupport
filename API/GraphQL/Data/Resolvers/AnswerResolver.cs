using BLL.Data;
using GraphQL.Data.DataLoader;

namespace GraphQL.Data.Resolvers
{
    public class AnswerResolver
    {
        public async Task<List<Answer>> GetAnswersAsync(
            [Parent] Ticket ticket,
            AnswerBatchDataLoader answerBatchDataLoaderTest)
        {
            return await answerBatchDataLoaderTest.LoadAsync(ticket.Id);
        }
    }
}
