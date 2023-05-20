using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Fridge
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string OwnerName { get; set; } = null!;

    public Guid? ModelId { get; set; }

    public virtual ICollection<FridgeProduct> FridgeProducts { get; set; } = new List<FridgeProduct>();

    public virtual FridgeModel? Model { get; set; }
}
