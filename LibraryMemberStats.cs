using LibraryMemberFunction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Library.Member.Function
{
    public class LibraryMemberStats
    {
        private readonly ILogger<LibraryMemberStats> _logger;
        private readonly IMemberRepository _memberRepository;

        public LibraryMemberStats(ILogger<LibraryMemberStats> logger, IMemberRepository memberRepository)
        {
            _logger = logger;
            _memberRepository = memberRepository;
        }

        [Function("GetMembers")]
        public async Task<HttpResponseData> GetList(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "authors")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            var list = await _memberRepository.GetAllAsync();
            if (list == null)
            {
                return req.CreateResponse(HttpStatusCode.NotFound);
            }
            await response.WriteStringAsync(JsonSerializer.Serialize(list));
            return response;
        }
    }
}
