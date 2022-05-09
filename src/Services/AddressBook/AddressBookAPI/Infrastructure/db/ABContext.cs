﻿using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Infrastructure.db
{
    public class ABContext : DbContext
    {
        public ABContext(DbContextOptions<ABContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("ContactsAddressBook");
        }
    }
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public AddressType AddressType { get; set; }
        public static DateTime LastUpdatedDate { get; internal set; }

        public Contact()
        {
            AddressType = AddressType.Home;
        }
    }
    public enum AddressType
    {
        Home = 0,
        Work = 1,
    }
}
