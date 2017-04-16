using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int? id);
        IEnumerable<Customer> GetAllCustomers();
        Customer CreateCustomer(Customer customer);
        Customer EditCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}