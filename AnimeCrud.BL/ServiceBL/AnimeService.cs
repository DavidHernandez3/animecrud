using AnimeCrud.DAL.Repositorio;
using AnimeCrud.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeCrud.BL.ServiceBL
{

    public class AnimeService : IAnimeService
    {
        private readonly IGenericRepository<AnimeBd> _animeRepo;

        public AnimeService(IGenericRepository<AnimeBd> AnimeRepo)
        {
            _animeRepo = AnimeRepo; 
        }

        public async Task<bool> Actualizar(AnimeBd modelo)
        {
           return await _animeRepo.Actualizar(modelo);

        }

        public async Task<bool> Eliminar(int id)
        {
            return await _animeRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(AnimeBd modelo)
        {
            return await _animeRepo.Insertar(modelo);

        }

        public async Task<AnimeBd> Obtener(int id)
        {
           return await _animeRepo.Obtener(id);
        }

        public async Task<AnimeBd> ObtenerPorNombre(String nombreAnime)
        {
            IQueryable<AnimeBd> queryAnimeSQL = await _animeRepo.ObtenerTodo();
            AnimeBd anime = queryAnimeSQL.Where(c=> c.Nombre== nombreAnime).FirstOrDefault();
            return anime;
        }

        public async Task<IQueryable<AnimeBd>> ObtenerTodo()
        {
            return await _animeRepo.ObtenerTodo();
        }
    }
}
