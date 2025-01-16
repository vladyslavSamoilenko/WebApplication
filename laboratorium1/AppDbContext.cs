using laboratorium1.Entities;
using laboratorium1.Models;
using Microsoft.EntityFrameworkCore;

namespace laboratorium1;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    public string DbPath { get; set; }

    protected AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "contacts.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}