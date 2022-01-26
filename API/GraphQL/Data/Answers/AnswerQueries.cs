using BLL.Data;
using BLL.Interfaces;
using HotChocolate.AspNetCore.Authorization;

namespace GraphQL.Data.Answers
{
    [ExtendObjectType(OperationTypeNames.Query)]
    [Authorize]
    public class AnswerQueries
    {
        public async Task<List<Answer>> GetAnswers([Service] IAnswerRepository answerRepository, CancellationToken cancellationToken)
        => await answerRepository.GetAllAsync(cancellationToken);

        public async Task<Answer?> GetAnswerById(Guid id, [Service] IAnswerRepository answerRepository, CancellationToken cancellationToken)
        => await answerRepository.GetByIdAsync(id, cancellationToken);

        public async Task<List<Answer>> GetAnswerByTicketId(Guid ticketId, [Service] IAnswerRepository answerRepository, CancellationToken cancellationToken)
        {
            var result = await answerRepository.GetAllAsync(cancellationToken);
            return result.Where(answer => answer.TicketId == ticketId).ToList();
        }
    }
}
