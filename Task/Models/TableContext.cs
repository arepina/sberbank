using System;
using System.Data.Entity;

namespace Task.Models
{
    public class Entry
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public decimal Income { get; set; }

        public decimal Silver { get; set; }

        public decimal Index { get; set; }

    }
    public class TableContext : DbContext
    {
        public DbSet<Entry> Entries { get; set; }
    }

}