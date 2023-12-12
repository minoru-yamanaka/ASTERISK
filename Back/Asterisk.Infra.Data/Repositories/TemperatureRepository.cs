using Asterisk.Domain.Entities;
using Asterisk.Domain.Interfaces;
using Asterisk.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Asterisk.Infra.Data.Repositories
{
    public class TemperatureRepository : ITemperatureRepository
    {
        private readonly AsteriskContext _context;

        public TemperatureRepository(AsteriskContext context)
        {
            _context = context;
        }

        public void Create(Temperature temperature)
        {
            _context.Temperatures.Add(temperature);

            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _context.Temperatures.Remove(SearchById(id));

            _context.SaveChanges();
        }

        public IEnumerable<Temperature> Read()
        {
            return _context.Temperatures
                .AsNoTracking()
                .OrderBy(t => t.CreatedDate);
        }

        public Temperature SearchById(Guid id)
        {
            return _context.Temperatures
                .AsNoTracking()
                .FirstOrDefault(t => t.Id == id);
        }

        public void Update(Temperature temperature)
        {
            _context.Entry(temperature).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
