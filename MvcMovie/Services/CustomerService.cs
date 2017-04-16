using MvcMovie.Models;
using MvcMovie.Models.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcMovieApplication;

namespace MvcMovie.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

       
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.AsEnumerable();
        }

        public Customer GetCustomerById(int? id)
        {
            return _dbContext.Customers.Find(id);
        }
        public Customer EditCustomer(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(int id)
        {
            var customerToRemove = _dbContext.Customers.Find(id);
            if (customerToRemove != null)
            {
                _dbContext.Customers.Remove(customerToRemove);
            }
            _dbContext.SaveChanges();
        }
    }
}