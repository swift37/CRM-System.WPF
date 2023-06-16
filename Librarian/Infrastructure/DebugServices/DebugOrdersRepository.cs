﻿using Librarian.DAL.Entities;
using Librarian.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Librarian.Infrastructure.DebugServices
{
    public class DebugOrdersRepository : IRepository<Order>
    {
        public DebugOrdersRepository()
        {
            var customersRepository = new DebugCustomersRepository();
            var employeesRepository = new DebugEmployeesRepository();

            if (customersRepository.Entities is null || employeesRepository.Entities is null) 
                throw new ArgumentNullException("Error defining entity collection in one of the debug repositories");

            var random = new Random();

            var dates = Enumerable.Range(1, 100).Select(d => DateTime.UtcNow.AddDays(-random.Next(175))).ToArray();

            Entities = Enumerable.Range(1, 100)
                .Select(i => new Order
                {
                    OrderDate = dates[i],
                    ShippedDate = dates[i].AddDays(random.Next(5)),
                    RequiredDate = dates[i].AddDays(random.Next(5, 5)),
                    Employee = random.NextItem(employeesRepository.Entities.ToArray()),
                    Customer = random.NextItem(customersRepository.Entities.ToArray()),
                    ShipName = $"Name {i}",
                    ShipAddress = $"USA, New York, Test st.",
                    ShippingCost = (decimal)(random.NextDouble() * 300 + 50),
                }).AsQueryable();
        }

        public IQueryable<Order>? Entities { get; }

        public Order? Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<Order?>? AddAsync(Order entity, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Order? Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order?>? GetAsync(int id, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Order entity, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
    }
}