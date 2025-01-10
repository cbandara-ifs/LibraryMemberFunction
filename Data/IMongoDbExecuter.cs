using LibraryMemberFunction.Domain;

namespace LibraryMemberFunction.Data
{
    public interface IMongoDbExecuter
    {
        Task<List<Member>> GetAllMembersAsync();

        Task<Member> GetMemberByIdAsync(string memberId);
    }
}