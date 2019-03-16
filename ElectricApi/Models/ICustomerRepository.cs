using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricApi.Models {
    public interface ICustomerRepository {
        Customer GetBy(string email);
        void Add(Customer bezoeker);
        void SaveChanges();
    }
}
