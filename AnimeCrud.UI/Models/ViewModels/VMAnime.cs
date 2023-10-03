namespace AnimeCrud.UI.Models.ViewModels
{
    public class VMAnime
    {
        public int IdAnime { get; set; }

        public string Nombre { get; set; } = null!;

        public string Categoria { get; set; } = null!;

        public int Temporada { get; set; }

        public string? FechaLanzamiento { get; set; }

        public static implicit operator DateTime(VMAnime v)
        {
            throw new NotImplementedException();
        }
    }
}
