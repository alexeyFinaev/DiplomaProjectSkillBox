using DiplomaProjectWebApi.Models;
using DiplomaProjectWebApi.Models.Content;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProjectWebApi.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<CallToAction> CallToActions { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Autorization> Autorizations { get; set; }
        

        public ApplicationContext(DbContextOptions options) : base(options) { }

    }
}
