using DemoApi.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DemoApi.Data.Repositories
{
    public class CustomersRepository
    {
        private readonly BenHowardDevContext _dbContext;

        public CustomersRepository(BenHowardDevContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CustomerEntity> GetAll()
        {
            return _dbContext.Customers;
        }

        public CustomerEntity GetById(int id)
        {
            return _dbContext.Customers.FirstOrDefault(x => x.Id == id);
        }

        public CustomerEntity Update(CustomerEntity entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public CustomerEntity Insert(CustomerEntity entity)
        {
            _dbContext.Customers.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool ExistsById(int id)
        {
            return _dbContext.Customers.Any(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _dbContext.Customers.Remove(entity);
            _dbContext.SaveChanges();

            return;
        }
    }
}