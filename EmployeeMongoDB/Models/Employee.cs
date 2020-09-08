using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeMongoDB.Models
{
    public class Employee
    {
        [BsonId]
       // [JsonConverter(typeof(ObjectIdConverter))]

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        //db.Employees.insertMany([{'ID':1,'Name':'wael','Address':'cairo','Phone':'01017416875','Email':'waelashry@gmail.com'},{'ID':2,'Name':'ahmed','Address':'giza','Phone':'01017434785','Email':'ahmed@gmail.com'},{'ID':3,'Name':'mohamed','Address':'fayoum','Phone':'01217438899','Email':'mohamed@gmail.com'}])

    }
}
