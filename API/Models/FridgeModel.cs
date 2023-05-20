using System;
using System.Collections.Generic;

namespace API.Models;

public partial class FridgeModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public virtual ICollection<Fridge> Fridges { get; set; } = new List<Fridge>();
}
