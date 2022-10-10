using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Using_AJAX_In_ASP.NET_MVC.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<tbl_Student> Students { get; set; }
    }
}