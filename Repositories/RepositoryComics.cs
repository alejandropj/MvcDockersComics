using Microsoft.EntityFrameworkCore;
using MvcDockersComics.Data;
using MvcDockersComics.Models;

namespace MvcDockersComics.Repositories
{
    public class RepositoryComics
    {
        private ComicsContext context;

        public RepositoryComics(ComicsContext context)
        {
            this.context = context;
        }

        public async Task<List<Comic>> GetComicsAsync()
        {
            return await this.context.Comics.ToListAsync();
        }        
        private async Task<int> GetMaxIdAsync()
        {
            return await this.context.Comics.MaxAsync(z => z.IdComic) + 1;
        }
        public async Task InsertComicAsync(string nombre, string imagen)
        {
            Comic comic = new Comic();
            comic.IdComic = await this.GetMaxIdAsync();
            comic.Nombre = nombre;
            comic.Imagen = imagen;
            this.context.Comics.Add(comic);
            await this.context.SaveChangesAsync();
        }
    }
}
