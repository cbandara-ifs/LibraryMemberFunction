namespace LibraryMemberFunction
{
    public interface IMemberRepository
    {
        Task<List<Author>> GetAllAsync();
    }
}
