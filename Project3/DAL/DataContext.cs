﻿using Project3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Project3.DAL
{
    public class DataContext : DbContext
    {
        public DataContext() :base("products")
        {
            Database.SetInitializer<DataContext>(new DropCreateDatabaseAlways<DataContext>());
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}