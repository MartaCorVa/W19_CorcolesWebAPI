using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W19_CorcolesWebAPI.Models
{
    public class CollectibleAPIModel
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public string PlayerId { get; set; }

    }
}