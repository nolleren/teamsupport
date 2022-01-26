using BLL.Data;
using BLL.Interfaces;

namespace GraphQL.Data.DataLoader
{
    public class AnswerBatchDataLoader : BatchDataLoader<Guid, List<Answer>>
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerBatchDataLoader(
            [Service] IAnswerRepository answerRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null)
            : base(batchScheduler, options)
        {
            _answerRepository = answerRepository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, List<Answer>>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken)
        {
            // instead of fetching one answer, we fetch multiple answers
            return await _answerRepository.GetByTickedIdAsync(keys);
        }
    }
}
