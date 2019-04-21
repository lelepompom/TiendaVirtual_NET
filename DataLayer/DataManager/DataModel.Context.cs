using DataLayer.DataManager;
using DataLayer.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Connection
{
    public class Connection
    {
        public static List<ProductData> getList()
        {
            TiendaDBEntities te = new TiendaDBEntities();
            return te.getProducts();
        }
        public static ProductData findProduct(int id)
        {
            TiendaDBEntities te = new TiendaDBEntities();
            Product product = te.Products.Find(id);
            return te.getProduct(product);
        }

        public static void addProduct(ProductData productData)
        {
            TiendaDBEntities te = new TiendaDBEntities();
            Product product = new Product();
            product.Id = productData.Id;
            product.Name = productData.Name;
            product.Price = productData.Price;
            te.Products.Add(product);
            te.SaveChanges();
        }
    }
}

namespace DataLayer.EF
{
    public partial class TiendaDBEntities : DbContext, IAccess
    {
        public List<ProductData> getProducts()
        {
            List<ProductData> pros = new List<ProductData>();
            foreach (Product p in this.Products)
            {
                ProductData pr = new ProductData();
                pr.Name = p.Name;
                pr.Price = p.Price;
                pr.Id = p.Id;
                pros.Add(pr);
            }
            return pros;
        }
        public ProductData getProduct(Product product)
        {
            ProductData pr = new ProductData();
            pr.Name = product.Name;
            pr.Price = product.Price;
            pr.Id = product.Id;
            return pr;
        }
    }
}
