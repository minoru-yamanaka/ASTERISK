using Asterisk.Domain.Entities;
using Asterisk.Domain.Interfaces;
using Asterisk.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Asterisk.Infra.Data.Repositories
{
    public class LineRepository : ILineRepository
    {
        private readonly AsteriskContext _context;

        public LineRepository(AsteriskContext context)
        {
            _context = context;
        }

        public void Create(Line line)
        {
            _context.Lines.Add(line);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _context.Remove(SearchById(id));

            _context.SaveChanges();
        }

        public IEnumerable<Line> Read()
        {
            return _context.Lines
                .AsNoTracking()
                .OrderBy(l => l.CreatedDate);
        }

        public Line SearchById(Guid id)
        {
            return _context.Lines
                .AsNoTracking()
                .FirstOrDefault(l => l.Id == id);
        }

        public void Update(Line line)
        {
            _context.Entry(line).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
