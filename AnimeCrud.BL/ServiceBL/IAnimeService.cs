using AnimeCrud.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeCrud.BL.ServiceBL
{
    public interface IAnimeService
    {
        Task<bool> Insertar(AnimeBd modelo);

        Task<bool> Actualizar(AnimeBd modelo);

        Task<bool> Eliminar(int id);

        Task<AnimeBd> Obtener(int id);

        Task<IQueryable<AnimeBd>> ObtenerTodo();

        Task<AnimeBd> ObtenerPorNombre(string nombreAnime);
    }
}
