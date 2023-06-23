using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DangDuyHien0230.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<DangDuyHien0230.Models.DDHSinhvien> DDHSinhvien { get; set; } = default!;

        public DbSet<DangDuyHien0230.Models.DDHHocsinhgioi> DDHHocsinhgioi { get; set; } = default!;
    }
}
