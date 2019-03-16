using ElectricApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricApi.Data.Repositories {
    public class CustomerRepository : ICustomerRepository {
        private readonly ElectricContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(ElectricContext context) {
            _context = context;
            _customers = context.Customers;
        }

        public Customer GetBy(string email) {
            return _customers.SingleOrDefault(c => c.Email == email);
        }

        public void Add(Customer customer) {
            _customers.Add(customer);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
