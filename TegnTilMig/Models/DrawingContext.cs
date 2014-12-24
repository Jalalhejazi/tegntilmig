using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TegnTilMig.Models
{
    public class DrawingContext : DbContext
    {
        public DbSet<Drawing> Drawings { get; set; }
    }
}