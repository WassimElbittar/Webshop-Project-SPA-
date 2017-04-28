using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WebshopProject.Models
{
    public class ModelClass
    {
        public string Search { get; set; }
    }
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [DisplayName("Category")]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        [DisplayName("Movie Picture")]
        public string MovieImage { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public virtual Category category { get; set; }

    }
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int MoiveId { get; set; }
        public virtual Movie Movies { get; set; }

        public int CustumertId { get; set; }
        public virtual Customer Custumers { get; set; }

        public int TotalCost { get; set; }
        public DateTime OrderPlaced { get; set; }

    }
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string BillingAddress { get; set; }
        public string PhoneNumber { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public string CartId { get; set; }

        public int MovietId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Movie Movie { get; set; }

    }

    public class WebshopContext : DbContext
    {
        public WebshopContext() : base("DefaultConnection")
        {

        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Custumer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}