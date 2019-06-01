using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Blog.Helper
{
    public class HashByRedis : IHash
    {
        private readonly IConfiguration _configuration;

        private readonly ConnectionMultiplexer _redisConnection;

        public HashByRedis(IConfiguration configuration)
        {
            this._configuration = configuration;
            _redisConnection = ConnectionMultiplexer.Connect(_configuration["redis:connection"]);
        }

        public int GenerateArticleId(string username)
        {
            IDatabase database = _redisConnection.GetDatabase();
            RedisValue hashstring = database.StringGet(username);
            int userid = (int)hashstring;
            return userid;
        }

        public int GenerateArticleId(string username, string pageid)
        {
            throw new NotImplementedException();
        }

        public int GenerateCommentId(string username, string pageid)
        {
            throw new NotImplementedException();
        }

        public int GetUserNameHash(string username)
        {
            throw new NotImplementedException();
        }
    }
}
