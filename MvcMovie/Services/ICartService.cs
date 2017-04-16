using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovie.Services
{
    public interface ICartService
    {
        void AddItem(Movie movie, int Quantity);
        void RemoveItem(CartItem item);
        decimal GetCartTotal();
        IEnumerable<CartItem> GetCartItems();
        void EmptyCart();


    }
}