using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Abstract;
using JinxyLounge.Domain.Entities;
using JinxyLounge.Domain.Models;

namespace JinxyLounge.Domain.Concrete
{
    public class EFProductRepository : IProductRepository {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {

            get { return context.Products; }

        }

        public IEnumerable<Product> GetAllProducts
        {

            get { return context.Products; }

        }

        public IEnumerable<Product> SearchProduct(string searchTerm)
        {
            var Products = context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Products = Products.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return Products.ToList();
        }

        public void SaveProduct(Product product)
        {       

            context.Products.Add(product);

            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {

            context.Entry(product).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {

            context.Entry(product).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        public Product GetProductById(int Id)
        {

            return context.Products.Find(Id);
        }
        public List<ProductImage> GetImagesByProductID(int productID)
        {
            return context.Products.Find(productID).ProductImages.ToList();
        }

        public void SaveImageURL(string url, int Id)
        {
            var model = context.Products.Find(Id);
            model.ProductURL = url;
            context.SaveChanges();
        }


        public void Dispose()
        {
            context.Dispose();
        } 
    }
}

      
