using Asterisk.Domain.Entities;

namespace Asterisk.Domain.Interfaces
{
    public interface ITemperatureRepository
    {
        IEnumerable<Temperature> Read();

        Temperature SearchById(Guid id);

        void Create(Temperature temperature);

        void Update(Temperature temperature);

        void Deletar(Guid id);
    }
}
