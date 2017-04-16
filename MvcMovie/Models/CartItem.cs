using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    public class CartItem
    {
        [Key]
        public int CartLineId { get; set; }
        public string CartId { get; set; }
        public int MovieId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Movie Movie { get; set; }

    }
}


