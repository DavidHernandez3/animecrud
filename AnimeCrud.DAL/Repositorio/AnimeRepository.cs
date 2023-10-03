using AnimeCrud.DAL.DataContext;
using AnimeCrud.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeCrud.DAL.Repositorio
{
    public class AnimeRepository : IGenericRepository<AnimeBd>
    {
        private readonly AnimeBdContext _animeContext;

        public AnimeRepository(AnimeBdContext context)
        {
            _animeContext = context;
        }

        public async Task<bool> Actualizar(AnimeBd modelo)
        {
           _animeContext.AnimeBds.Update(modelo);
            await _animeContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
           AnimeBd Categoria = _animeContext.AnimeBds.First(c=> c.IdAnime==id);
            _animeContext.AnimeBds.Remove(Categoria);
            await _animeContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(AnimeBd modelo)
        {
            _animeContext.AnimeBds.Add(modelo);
            await _animeContext.SaveChangesAsync();
            return true;
        }

        public async Task<AnimeBd> Obtener(int id)
        {
            return await _animeContext.AnimeBds.FindAsync(id);

        }

        public async Task<IQueryable<AnimeBd>> ObtenerTodo()
        {
            IQueryable<AnimeBd> queryAnimeSQL = _animeContext.AnimeBds;
            return queryAnimeSQL;
        }
    }
}
