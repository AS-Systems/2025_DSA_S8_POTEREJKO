using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.Model.Entities;


namespace LibraryManager.Model.Repositories.Interfaces
{
    internal interface IGenreRepository
    {
        Task<bool> IsAnyGenreAsync();
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre?> GetGenreByIdAsync(int genreId);
        Task InsertAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task DeleteAsync(Genre genre);
    }
}
