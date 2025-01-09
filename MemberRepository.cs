using Microsoft.EntityFrameworkCore;

namespace LibraryMemberFunction
{
    public class MemberRepository : IMemberRepository
    {
        private readonly PubDb _db;

        public MemberRepository(PubDb db)
        {
            _db = db;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _db.Authors.ToListAsync();
        }
    }
}
