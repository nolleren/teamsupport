using BLL.Data;

namespace BLL.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<IReadOnlyDictionary<Guid, List<Answer>>> GetByTickedIdAsync(IReadOnlyList<Guid> ids);
    }
}
