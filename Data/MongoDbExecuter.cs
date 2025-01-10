using LibraryMemberFunction.Application;
using LibraryMemberFunction.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LibraryMemberFunction.Data
{
    public class MongoDbExecuter : IMongoDbExecuter
    {
        private readonly DatabaseSettings _dbSettings;

        public MongoDbExecuter(DatabaseSettings dbSettings)
        {
            _dbSettings = dbSettings;
        }

        public async Task<List<Member>> GetAllMembersAsync()
        {
            var collection = GetCollection("pub_db", "memberDetails");
            var documents = await collection.Find(_ => true).ToListAsync();

            var members = new List<Member>();

            if (documents == null) return members;

            foreach (var document in documents)
            {
                members.Add(convertBsonToMember(document));
            }

            return members;
        }

        public async Task<Member> GetMemberByIdAsync(string memberId)
        {
            var collection = GetCollection("pub_db", "memberDetails");
            var memberQuery = await collection.FindAsync(
                Builders<BsonDocument>.Filter.Eq("MemberId", memberId));
            var document = memberQuery.FirstOrDefault();

            if (document == null)
            {
                return new Member();
            }

            return convertBsonToMember(document);
        }

        private IMongoCollection<BsonDocument> GetCollection(string databaseName, string collectionName)
        {
            var url = new MongoUrl(_dbSettings.MongoDBConnectionString);
            var client = new MongoClient(url);
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);
            return collection;
        }

        private Member convertBsonToMember(BsonDocument bsonDocument)
        {
            if (bsonDocument == null) return null;

            return new Member
            {
                MemberId = bsonDocument["MemberId"].AsString,
                MemberType = bsonDocument["MemberType"].AsString,
                Name = bsonDocument["Name"].AsString,
                Email = bsonDocument["Email"].AsString
            };
        }
    }
}
