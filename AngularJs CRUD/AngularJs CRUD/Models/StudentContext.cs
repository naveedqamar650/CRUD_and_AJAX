using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJs_CRUD.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<tbl_Student> Students { get; set; }
    }
}