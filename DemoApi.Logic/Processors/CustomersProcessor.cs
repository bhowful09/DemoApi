using AutoMapper;
using DemoApi.Data.Entities;
using DemoApi.Data.Repositories;
using DemoApi.Domain;
using System.Collections.Generic;

namespace DemoApi.Logic.Processors
{
    public class CustomersProcessor
    {
        private readonly CustomersRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersProcessor(CustomersRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _mapper.Map<IEnumerable<Customer>>(_customerRepository.GetAll());
        }

        public Customer GetById(int id)
        {
            return _mapper.Map<Customer>(_customerRepository.GetById(id));
        }

        public bool ExistsById(int id)
        {
            return _customerRepository.ExistsById(id);
        }

        public Customer Update(Customer customer)
        {
            Customer returnValue = null;

            if (ExistsById(customer.Id.GetValueOrDefault()))
            {
                var entity = _mapper.Map<CustomerEntity>(customer);
                var returnEntity = _customerRepository.Update(entity);
                returnValue = _mapper.Map<Customer>(returnEntity);
            }

            return returnValue;
        }

        public Customer Insert(CustomerCreate value)
        {
            Customer returnValue = null;

            var entity = _mapper.Map<CustomerEntity>(value);
            var returnEntity = _customerRepository.Insert(entity);
            returnValue = _mapper.Map<Customer>(returnEntity);

            return returnValue;
        }

        public void Delete(int id)
        {
            if (_customerRepository.ExistsById(id))
            {
                _customerRepository.Delete(id);
            }
        }
    }
}