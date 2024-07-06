using System;
using System.Collections.Generic;

namespace piyama.models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Piyama> Piyamas { get; set; } = new List<Piyama>();
}
