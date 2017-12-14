using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using netCore_mongodb.Models;

namespace netCore_mongodb.Controllers
{
    [Produces("application/json")]
    [Route("api/People")]
    public class PeopleController : Controller
    {
        private IMongoCollection<Person> people;

        public PeopleController(MongoClient client)
        {
            var database = client.GetDatabase("gokudb1");
            people = database.GetCollection<Person>(nameof(people));
        }

        // GET api/values
        [HttpGet]
        public async Task<string> GetAsync()
        {
            Person person = new Person();
            person.Id = new ObjectId();
            person.Name = "2222";
            person.Idcard = "330222";
            await people.InsertOneAsync(person);
            return person.Id.ToString();
        }

        // GET api/values/5
        [HttpGet("{key}")]
        public async Task<List<Person>> GetAsync(string key)
        {
            var person = await people.FindAsync(Builders<Person>.Filter.Eq(p => p.Name, key));
            List<Person> list = await person.ToListAsync();
            return list;
        }       
    }
}
