using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using Repo.IService;
namespace Repo.Service
{
    public class IceCreamService : IIceCreamService
    {
        public List<IceCream> GetProducts()
        {
            return DALIceCream.GetProducts();
            
        }
        public void SaveProduct(IceCream obj)
        {
            DALIceCream.SaveProduct(obj);
        }
        public void DeleteProduct(int pid)
        {
            DALIceCream.DeleteProduct(pid);

        }

        public void UpdateProduct(IceCream obj)
        {
            DALIceCream.UpdateProduct(obj);
        }

    }
}
