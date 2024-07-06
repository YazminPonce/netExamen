using System;
using System.Collections.Generic;

namespace piyama.models;

public partial class Piyama
{
    public int IdPiyama { get; set; }

    public int? IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public int? Precio { get; set; }

    public string? Imagen { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; }
}
