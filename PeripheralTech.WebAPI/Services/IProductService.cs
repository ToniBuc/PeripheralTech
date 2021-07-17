using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeripheralTech.WebAPI.Services
{
    public interface IProductService
    {
        List<Model.Product> Get(ProductSearchRequest request);
        List<Model.Product> GetRecentProducts(ProductSearchRequest request);
        List<Model.Product> GetDiscountedProducts(ProductSearchRequest request);
        List<Model.Product> GetCustomizableProducts(ProductSearchRequest request);
        List<Model.Product> GetProductsForCustomOrder(ProductSearchRequest request);
        Model.Product GetById(int id);
        Model.Product Insert(ProductUpsertRequest request);
        Model.Product Update(int id, ProductUpsertRequest request);
    }
}
