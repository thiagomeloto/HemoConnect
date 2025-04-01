﻿using HemoConnect.Core.Entities;
using HemoConnect.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly HemoConnectDbContext _dbContext;
        public DonationRepository(HemoConnectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(Donation donation)
        {
            await _dbContext.Donation.AddAsync(donation);
            await _dbContext.SaveChangesAsync();

            return donation.Id;
        }

        public async Task<List<Donation>> GetAllDonationsAsync()
        {
            return await _dbContext.Donation.ToListAsync();
        }
    }
}
