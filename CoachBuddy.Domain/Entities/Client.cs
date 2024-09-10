﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? Email { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ClientContactDetails ContactDetails { get; set; } = default!;

        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        public string? About { get; set; }
        public string EncodedName { get; private set; } = default!;

        public List<ClientTraining> Trainings { get; set; } = new();
        public void EncodeName() => EncodedName = $"{Name.ToLower().Replace(" ", "-")}-{LastName.ToLower().Replace(" ", "-")}";
    }
}
