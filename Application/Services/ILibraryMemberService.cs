using LibraryMemberFunction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMemberFunction.Application.Services
{
    public interface ILibraryMemberService
    {
        Task<List<Member>> GetMembersAsync();

        Task<Member> GetMemberByIdAsync(string id);
    }
}
