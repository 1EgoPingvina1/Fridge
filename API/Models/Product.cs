using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int? DefaultQuantity { get; set; }

    public virtual ICollection<FridgeProduct> FridgeProducts { get; set; } = new List<FridgeProduct>();
}
