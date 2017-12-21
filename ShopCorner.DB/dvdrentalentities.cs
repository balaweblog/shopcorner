using ShopCorner.DB.Models;
using System.Data.Entity;
using System.Linq;
using CodeFirstStoreFunctions;
using Npgsql;
using System;

namespace ShopCorner.DB
{
    public partial class dvdrentalentities : DbContext
    {
        public dvdrentalentities() : base(nameOrConnectionString: "dvdrental") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new FunctionsConvention("public", typeof(dvdrentalentities)));
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Film> Films { get; set;}
        public DbSet<FilmActor> FilmActors { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Store> Stores { get; set; }

        [DbFunction("CodeFirstDatabaseSchema", "IsInventoryinStock")]
        public virtual bool IsInventoryinStock(int inventoryid)
        {
            NpgsqlParameter inventoryidparam = new NpgsqlParameter("p_inventory_id", inventoryid);
            return this.Database.SqlQuery<bool>("select * from inventory_in_stock(@p_inventory_id)", inventoryidparam).SingleOrDefault();
        }
        [DbFunction("CodeFirstDatabaseSchema", "GetCustomerBalance")]
        public virtual decimal GetCustomerBalance(int customerid)
        {
            NpgsqlParameter customeridparam = new NpgsqlParameter("p_customer_id", customerid);
            NpgsqlParameter effectivedateparam = new NpgsqlParameter("p_effective_date", DateTime.Now);
            return this.Database.SqlQuery<decimal>("select * from get_customer_balance(@p_customer_id,@p_effective_date)", customeridparam,effectivedateparam).SingleOrDefault();
        }
    }
}
