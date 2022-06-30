using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace justine_webapp.Models
{
    public class Instrument
    {
        public int Id {get; set; }

        public item Item {get; set; }

        public int ItemId {get; set; }

        public Type Type {get; set; }

        public int TypeId {get; set; }

        public int Price {get; set; }

        public string ImagePath {get; set; }
    }
}