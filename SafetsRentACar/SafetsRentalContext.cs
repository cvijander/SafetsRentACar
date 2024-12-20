﻿using Microsoft.EntityFrameworkCore;
using SafetsRentACar.Models;

namespace SafetsRentACar
{
    public class SafetsRentalContext :DbContext
    {

        public SafetsRentalContext(DbContextOptions<SafetsRentalContext> options) :base (options) { }


        public DbSet<Car> Cars { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet <User> Users { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Payments> Payments { get; set; }
    }
}
