using DataAccess.Context;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class GroupsRepository
    {
        private StudentDbContext Context { get; }

        public GroupsRepository(StudentDbContext _context)
        {
            Context = _context;
        }

        public IQueryable<Group> GetGroups()
        {
            return this.Context.Groups;
        }
    }
}