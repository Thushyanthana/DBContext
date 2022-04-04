using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Database context is a  main class it coordinates with Entity framework functionality for a model
//Installed Microsoft.EntityFrameworkCore.InMemory in mangenugeget packeges
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {

        public  TodoContext(DbContextOptions<TodoContext>  options):base (options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; } = null;


    }
}
