﻿using System.Linq;
using GiftBox.Data.Models;

namespace GiftBox.Services.Data.Contracts
{
    public interface IHomeService
    {
        IQueryable<Home> GetAll();

        IQueryable<Home> GetAllApproved();

        IQueryable<Home> GetHomeById(int? id);

        void Add(Home home);

        void Update();
    }
}
