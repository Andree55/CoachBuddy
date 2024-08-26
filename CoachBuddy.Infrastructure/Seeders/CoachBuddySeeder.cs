﻿using CoachBuddy.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Infrastructure.Seeders
{
    public class CoachBuddySeeder
    {
        private readonly CoachBuddyDbContext _dbContext;

        public CoachBuddySeeder(CoachBuddyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Clients.Any())
                {
                    var adamK = new Domain.Entities.Client()
                    {
                        Name = "Adam Kowalski",
                        Description = "Some description",
                        ContactDetails = new()
                        {
                            City="Warsaw",
                            Street="Warszawska 2",
                            PostalCode="02-797",
                            PhoneNumber="+48765879564"
                        }
                    };
                    adamK.EncodeName();
               
                    _dbContext.Clients.Add(adamK);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
