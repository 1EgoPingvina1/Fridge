using System;
using System.Collections.Generic;

namespace API.Models;

public partial class FridgeProduct
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public Guid FridgeId { get; set; }

    public int Quantity { get; set; }

    public virtual Fridge Fridge { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
