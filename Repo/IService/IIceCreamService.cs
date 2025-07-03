using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repo.IService
{
    public interface IIceCreamService
    {
        List<IceCream> GetProducts();
        void SaveProduct(IceCream obj);
        void DeleteProduct(int pid);

        void UpdateProduct(IceCream obj);


    }
}
