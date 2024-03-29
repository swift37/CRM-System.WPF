﻿using CRM.DAL.Entities;
using CRM.Interfaces;
using CRM.Models;
using System.Threading.Tasks;

namespace CRM.Services.Interfaces
{
    public interface IStatisticsCollectionService
    {
        GlobalStatistics CollectGlobalStatistics(
            IRepository<Order> ordersRepository, 
            TimePeriod period);

        public Task<GlobalStatistics> CollectGlobalStatisticsAsync(
            IRepository<Order> ordersRepository,
            TimePeriod period);

        StatisticsDetails CollectProductStatistics(
            Product? product, 
            IRepository<OrderDetails> ordersDetailsRepository);

        StatisticsDetails CollectCategoryStatistics(
            Category? category,
            IRepository<OrderDetails> ordersDetailsRepository);

        StatisticsDetails CollectEmployeeStatistics(
            Employee? employee,
            IRepository<Order> ordersRepository);

        public enum TimePeriod
        {
            Today = 1,
            Week = 7, 
            Month = 30,
            Year = 365
        }

    }
}
