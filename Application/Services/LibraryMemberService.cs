using LibraryMemberFunction.Data;
using LibraryMemberFunction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMemberFunction.Application.Services
{
    public class LibraryMemberService : ILibraryMemberService
    {
        private readonly IMongoDbExecuter _mongoDbExecuter;

        public LibraryMemberService(IMongoDbExecuter mongoDbExecuter)
        {
            _mongoDbExecuter = mongoDbExecuter;
        }

        public async Task<Member> GetMemberByIdAsync(string id)
        {
            return await _mongoDbExecuter.GetMemberByIdAsync(id);
        }

        public async Task<List<Member>> GetMembersAsync()
        {
            return await _mongoDbExecuter.GetAllMembersAsync();
        }
    }
}
