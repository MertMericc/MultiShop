﻿using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Context
{
    public class CargoContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("@Server=(local);Database=MultiShopCargoDb;Integrated Security=True;TrustServerCertificate=True");
        }
        public DbSet<CargoCompany>CargoCompanies { get; set; }
        public DbSet<CargoCustomer>CargoCustomers { get; set; }
        public DbSet<CargoDetail>CargoDetails { get; set; }
        public DbSet<CargoOperation>CargoOperations { get; set; }
    }
}
