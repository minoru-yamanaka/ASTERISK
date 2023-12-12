using Asterisk.Domain.Entities;
using Asterisk.Domain.Interfaces;
using Asterisk.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Asterisk.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AsteriskContext _ctx;

        public UserRepository(AsteriskContext ctx)
        {
            _ctx = ctx;
        }


        // Commands:

        public void Add(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }

        public void Update(User user)
        {
            _ctx.Entry(user).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _ctx.Users.Remove(SearchById(id));
            _ctx.SaveChanges();
        }



        // Queries:

        public IEnumerable<User> List()
        {
            return _ctx.Users
                .AsNoTracking()
                .ToList();
        }

        public User SearchById(Guid id)
        {
            return _ctx.Users.FirstOrDefault(x => x.Id == id);
        }

        public User SearchByEmail(string email)
        {
            return _ctx.Users.FirstOrDefault(x => x.Email == email);
        }

    }
}
