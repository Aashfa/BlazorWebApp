using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using Entities;
using Repo.IService;

namespace Repo.Service
{
    public class DealService : IDealService
    {
        public async Task<List<Deal>> GetAllDeals()
        {
            // If DALDeal.GetAllDeals() is synchronous:
            return await Task.Run(() => DALDeal.GetAllDeals());

            // If DALDeal.GetAllDeals() is already async:
            // return await DALDeal.GetAllDeals();
        }

        public async Task<Deal> GetDealById(int dealId)
        {
            return await Task.Run(() => DALDeal.GetDealById(dealId));
        }

        public async Task<int> CreateDeal(Deal deal)
        {
            if (deal == null)
                throw new ArgumentNullException(nameof(deal));

            return await Task.Run(() => DALDeal.CreateDeal(deal));
        }

        public async Task<bool> UpdateDeal(Deal deal)
        {
            if (deal == null)
                throw new ArgumentNullException(nameof(deal));

            return await Task.Run(() => DALDeal.UpdateDeal(deal));
        }

        public async Task<bool> DeleteDeal(int dealId)
        {
            if (dealId <= 0)
                throw new ArgumentException("Invalid Deal ID");

            return await Task.Run(() => DALDeal.DeleteDeal(dealId));
        }
    }
}