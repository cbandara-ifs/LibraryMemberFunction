using LibraryMemberFunction.Application.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace LibraryMemberFunction.Application.HttpTriggers
{
    public class LibraryMemberFunctions
    {
        private readonly ILogger<LibraryMemberFunctions> _logger;
        private readonly ILibraryMemberService _libraryMemberService;

        public LibraryMemberFunctions(ILogger<LibraryMemberFunctions> logger, ILibraryMemberService libraryMemberService)
        {
            _logger = logger;
            _libraryMemberService = libraryMemberService;
        }

        [Function("GetMembers")]
        public async Task<HttpResponseData> GetListMongo(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "members")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            var list = await _libraryMemberService.GetMembersAsync();
            if (list == null)
            {
                return req.CreateResponse(HttpStatusCode.NotFound);
            }
            await response.WriteStringAsync(JsonSerializer.Serialize(list));
            return response;
        }
    }
}
