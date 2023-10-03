using Microsoft.AspNetCore.Mvc;
using AnimeCrud.UI.Models;
using AnimeCrud.UI.Models.ViewModels;
using AnimeCrud.BL.ServiceBL;
using AnimeCrud.EN;
using System.Diagnostics;
using System.Globalization;
using System.Diagnostics.Contracts;

namespace AnimeCrud.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimeService _animeService;

        public HomeController(IAnimeService AnimeSer)
        {
            _animeService = AnimeSer;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {

            IQueryable<AnimeBd> queryAnimeBdSQL = await _animeService.ObtenerTodo();

            List<VMAnime> lista = queryAnimeBdSQL
                                                     .Select(c => new VMAnime()
                                                     {
                                                         IdAnime = c.IdAnime,
                                                         Nombre = c.Nombre,
                                                         Categoria = c.Categoria,
                                                         Temporada= c.Temporada,
                                                         FechaLanzamiento = c.FechaLanzamiento.ToString("dd/MM/yyyy")
                                                     }).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);

        }


        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMAnime modelo)
        {

            AnimeBd NuevoModelo = new AnimeBd()
            {
                Nombre = modelo.Nombre,
                Categoria = modelo.Categoria,
                Temporada = modelo.Temporada,
                FechaLanzamiento = DateTime.ParseExact(modelo.FechaLanzamiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-SV"))
            };

            bool respuesta = await _animeService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMAnime modelo)
        {

            AnimeBd NuevoModelo = new AnimeBd()
            {
                IdAnime = modelo.IdAnime,
                Nombre = modelo.Nombre,
                Categoria = modelo.Categoria,
                Temporada = modelo.Temporada,
                FechaLanzamiento = DateTime.ParseExact(s: modelo.FechaLanzamiento,
                                                       "dd/MM/yyyy",
                                                       CultureInfo.CreateSpecificCulture("es-PE"))
            };

            bool respuesta = await _animeService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {

            bool respuesta = await _animeService.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}