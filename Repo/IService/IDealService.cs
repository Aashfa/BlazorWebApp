﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repo.IService
{
    public interface IDealService
    {
        Task<List<Deal>> GetAllDeals();
        Task<Deal> GetDealById(int dealId);
        Task<int> CreateDeal(Deal deal);
        Task<bool> UpdateDeal(Deal deal);
        Task<bool> DeleteDeal(int dealId);
        //List<Deal> GetAllDeals();
        //Deal GetDealById(int dealId);
        //int CreateDeal(Deal deal);
        //bool UpdateDeal(Deal deal);
        //bool DeleteDeal(int dealId);
    }
}
