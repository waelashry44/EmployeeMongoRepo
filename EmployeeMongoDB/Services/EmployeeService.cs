using EmployeeMongoDB.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMongoDB.Services
{
   
        public class EmployeeService
        {
            private readonly IMongoCollection<Employee> _employees;
            public EmployeeService(IEmployeeDatabaseSettings settings)
            {
                var client = new MongoClient(settings.ConnectionString);
                var database = client.GetDatabase(settings.DatabaseName);

                _employees = database.GetCollection<Employee>(settings.EmployeesCollectionName);

            }
       
        public Employee Get(int id)
        {
            return _employees.Find(emp => emp.ID == id).FirstOrDefault();
        }

        public List<Employee> GetAll()
        {
            return _employees.Find(emp => true).ToList();
        }

        public void Delete(int id)
        {
            _employees.DeleteOne(s => s.ID == id);
        }

        public void Insert(Employee employee)
        {
            _employees.InsertOne(employee);
        }

        public void Update(Employee employee)
        {
            _employees.ReplaceOne(s => s.ID == employee.ID, employee);
        }

    }
}
