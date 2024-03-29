﻿using CRM.DAL.Entities;
using CRM.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRM.Infrastructure.DebugServices
{
    public class DebugShippersRepository : IRepository<Shipper>
    {
        public DebugShippersRepository()
        {
            var random = new Random();

            Entities = Enumerable.Range(1, 10)
                .Select(i => new Shipper
                {
                    Name = $"Shipper {i}",
                    ContactNumber = random.Next(100000000, 999999999).ToString()
                }).AsQueryable();
        }

        public IQueryable<Shipper>? Entities { get; set; }
        public bool AutoSaveChanges { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Shipper? Add(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public Task<Shipper?>? AddAsync(Shipper entity, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public void Archive(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public Task ArchiveAsync(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public Shipper? Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Shipper?>? GetAsync(int id, CancellationToken cancellation = default)
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

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UnArchive(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public Task UnArchiveAsync(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Shipper entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Shipper entity, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }
    }
}
