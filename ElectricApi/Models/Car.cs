using ElectricApi.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ElectricApi.Models {
    public class Car {

        #region Properties
        public int id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public double MaxSpeed { get; set; }
        public double MaxRange { get; set; }
        public double ChargeTime { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public double Rating => CalculateRating();
        public int AmountOfRatings => Reviews.Count;
        #endregion

        public Car() {
            this.Reviews = new List<Review>();
        }

        public Car(string model, string brand, double maxSpeed, double maxRange, double chargeTime, double price, byte[] image) : this() {
            this.Model = model;
            this.Brand = brand;
            this.MaxSpeed = maxSpeed;
            this.MaxRange = maxRange;
            this.ChargeTime = chargeTime;
            this.Price = price;
            this.Image = image;
        }


        #region Methods
        public double CalculateRating() {
            if (Reviews.Count != 0) {
                if (Reviews.Count == 1) {
                    return Reviews.FirstOrDefault().Rating;
                }
                else {
                    return (Reviews.Select(r => r.Rating).Sum()) / AmountOfRatings;
                }
            }

            return 0.0;
        }

        public void AddReview(ReviewDTO review, Customer customer) {
            this.Reviews.Add(new Review() {
                CarId = this.id,
                Comment = review.Comment,
                Rating = review.Rating,
                DatePosted = DateTime.Now,
                Customer = customer            
            });
        }

        public static byte[] ImageToByteArray(Image imageIn) {
            using (var ms = new MemoryStream()) {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public static string ByteArrayToImageData(byte[] byteArrayIn) {
            return Convert.ToBase64String(byteArrayIn);
        }
        #endregion
    }
}
