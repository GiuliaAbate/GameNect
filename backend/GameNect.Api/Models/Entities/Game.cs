using System;
using System.Collections.Generic;

namespace GameNect.Api.Entities;

public partial class Game
{
    public int GameId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
