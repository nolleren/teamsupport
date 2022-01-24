using BLL.Data;
using BLL.DataLoader;

namespace GraphQL.API.Resolvers
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
