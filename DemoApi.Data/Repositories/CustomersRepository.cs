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
    }
}