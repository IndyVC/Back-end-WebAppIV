using ElectricApi.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
namespace ElectricApi.Data {
    public class ElectricDataInitializer {
        private readonly ElectricContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ElectricDataInitializer(ElectricContext context, UserManager<IdentityUser> userManager) {
            _context = context;
            _userManager = userManager;
        }

        public async Task InitializeData() {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated()) {
                //Seeding happens here
                //Creating Customers first.
                Customer customer1 = new Customer {
                    Email = "Indy.vancanegem@student.hogent.be",
                    FirstName = "Indy",
                    LastName = "Van Canegem"
                };
                _context.Customers.Add(customer1);
                await CreateUser(customer1.Email, "P@ssword1111");

                Customer HoGent = new Customer {
                    Email = "student@student.hogent.be",
                    FirstName = "Student",
                    LastName = "HoGent"

                };
                _context.Customers.Add(HoGent);
                await CreateUser(HoGent.Email, "P@ssword1111");
                _context.SaveChanges();

                Car car1 = new Car() {
                    Brand = "Audi",
                    ChargeTime = 4.5,
                    Image = Car.ImageToByteArray(Image.FromFile("etron.jpg")),
                    Model = "etron",
                    MaxRange = 500,
                    MaxSpeed = 200,
                    Price = 30.000
                };
                _context.Cars.Add(car1);
                _context.SaveChanges();

            }
        }

        private async Task CreateUser(string email, string password) {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
        }
    }
}
