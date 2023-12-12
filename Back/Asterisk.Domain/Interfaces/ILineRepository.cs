using Asterisk.Domain.Entities;

namespace Asterisk.Domain.Interfaces
{
    public interface ILineRepository
    {
        IEnumerable<Line> Read();

        Line SearchById(Guid id);

        void Create(Line line);

        void Update(Line line);

        void Delete(Guid id);
    }
}
