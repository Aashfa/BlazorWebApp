using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repo.IService
{
    public interface IDealService
    {
        List<Deal> GetAllDeals();
        Deal GetDealById(int dealId);
        int CreateDeal(Deal deal);
        bool UpdateDeal(Deal deal);
        bool DeleteDeal(int dealId);
    }
}
