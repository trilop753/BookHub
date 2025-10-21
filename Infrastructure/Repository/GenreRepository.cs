using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(BookHubDbContext context)
            : base(context) { }
    }
}
