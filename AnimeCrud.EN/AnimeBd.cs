using System;
using System.Collections.Generic;

namespace AnimeCrud.EN;

public partial class AnimeBd
{
    public int IdAnime { get; set; }

    public string Nombre { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public int Temporada { get; set; }

    public DateTime FechaLanzamiento { get; set; }
}
