using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;
using LibraryManager.Model.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Model.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly HomelibraryContext _context;

        public GenreRepository(HomelibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> IsAnyGenreAsync()
        {
            return await _context.Genres.AnyAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre?> GetGenreByIdAsync(int genreId)
        {
            return await _context.Genres.FirstOrDefaultAsync(g => g.Id == genreId);
        }

        public async Task InsertAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genre genre)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
    }
}

