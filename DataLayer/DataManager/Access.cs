using DataLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataManager
{
    public interface IAccess
    {
        List<ProductData> getProducts();
        ProductData getProduct(Product product);
    }
}
