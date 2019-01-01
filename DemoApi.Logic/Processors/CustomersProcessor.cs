using AutoMapper;
using DemoApi.Data.Repositories;
using DemoApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}