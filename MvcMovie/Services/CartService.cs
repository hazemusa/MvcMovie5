//using MvcMovie.Models;
//using MvcMovie.Models.Identity;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity.Core.Metadata.Edm;
//using System.Linq;
//using System.Web;

//namespace MvcMovie.Services
//{
//    //public class CartService : ICartService
//    {
//        // 
//        private readonly ApplicationDbContext _dbContext;
//        private List<CartItem> ItemCollection = new List<CartItem>();
//        public CartService(ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public void AddItem(Movie movie, int Quantity)
//        {

//            //_dbContext.Carts.Add(new CartItem { Movie = movie, Count = Quantity });
//            //_dbContext.SaveChanges();

//            //    CartItem Item = ItemCollection.Where(m => m.Movie == movie)
//            //        .FirstOrDefault();

//            //    if (Item == null)
//            //    {
//            //        ItemCollection.Add(new CartItem { Movie = movie, Count = Quantity });

//            //    }
//            //    else
//            //    {
//            //        Item.Count += Quantity;

//            //    }
//            //}
//        }

//        public void RemoveItem(CartItem item)
//        {
//            //_dbContext.Carts.Remove(item);

//        }
//        public decimal GetCartTotal()
//        {
//            return ItemCollection.Sum(m => m.Movie.Price * m.Count);
//        }
//        //public IEnumerable<CartItem> GetCartItems()
//        //{
//        //   // return _dbContext.Cart.AsEnumerable();
//        //}
//        public void EmptyCart()
//        {
//            ItemCollection.Clear();
//        }

       
//    }
//}
