using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;
using Repo.IService;

namespace Repo.Service
{
   public class DealService:IDealService
    {

        public List<Deal> GetAllDeals()
        {
            return DALDeal.GetAllDeals();
        }

        public Deal GetDealById(int dealId)
        {
            return DALDeal.GetDealById(dealId);
        }

        public int CreateDeal(Deal deal)
        {
            if (deal == null)
                throw new ArgumentNullException(nameof(deal));

            return DALDeal.CreateDeal(deal);
        }

        public bool UpdateDeal(Deal deal)
        {
            if (deal == null)
                throw new ArgumentNullException(nameof(deal));

            return DALDeal.UpdateDeal(deal);
        }

        public bool DeleteDeal(int dealId)
        {
            if (dealId <= 0)
                throw new ArgumentException("Invalid Deal ID");

            return DALDeal.DeleteDeal(dealId);
        }
    }
}

