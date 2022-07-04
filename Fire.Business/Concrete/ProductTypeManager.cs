using Fire.Business.Abstrack;
using Fire.DataAccess.Abstrack;
using Fire.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fire.Business.Concrete
{
    public class ProductTypeManager : IProductTypeService
    {
        private readonly IProductTypeDal _productTypeDal;
        public ProductTypeManager(IProductTypeDal productTypeDal)
        {
            _productTypeDal = productTypeDal;
        }
        public void Create(ProductType entity)
        {
            _productTypeDal.Create(entity);
        }

        public void Delete(ProductType entity)
        {
            _productTypeDal.Delete(entity);
        }

        public List<ProductType> GetAll()
        {
            return _productTypeDal.GetAll();
        }

        public ProductType GetById(int id)
        {
            return _productTypeDal.GetById(id);
        }

        public ProductType GetProductTypeByName(string name)
        {
            return _productTypeDal.GetProductTypeByName(name);
        }

        public void Update(ProductType entity)
        {
            _productTypeDal.Update(entity);
        }
    }
}
