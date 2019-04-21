using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Connection;
using DataLayer.DataManager;

namespace BusinessLayer
{
    public class ProductsManagement
    {
        public List<ProductBusiness> getProductList()
        {
            List<ProductData> productsDataList = Connection.getList();
            List<ProductBusiness> productsBusinessList = new List<ProductBusiness>();
            foreach (ProductData p in productsDataList)
            {
                ProductBusiness productbusiness = new ProductBusiness();
                productbusiness.Name = p.Name;
                productbusiness.Price = p.Price;
                productbusiness.Id = p.Id;
                productsBusinessList.Add(productbusiness);
            }
            return productsBusinessList;
        }

        public ProductBusiness findProductBusiness(int id)
        {
            ProductData productData = Connection.findProduct(id);
            ProductBusiness productbusiness = new ProductBusiness();
            productbusiness.Name = productData.Name;
            productbusiness.Price = productData.Price;
            productbusiness.Id = productData.Id;
            return productbusiness;
        }

        public void addProductBusiness(ProductBusiness productBusiness)
        {
            ProductData productData = new ProductData();
            productData.Id = productBusiness.Id;
            productData.Name = productBusiness.Name;
            productData.Price = productBusiness.Price;
            Connection.addProduct(productData);
        }
    }
}
