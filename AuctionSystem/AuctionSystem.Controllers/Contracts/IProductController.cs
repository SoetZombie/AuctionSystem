﻿namespace AuctionSystem.Controllers.Contracts
{
    using Models;
    using System;
    using System.Collections.Generic;

    public interface IProductController
    {
        void CreateProduct(string name, string description, decimal price, DateTime startDate, DateTime endDate);

        bool UpdateProduct(int id, string property, string value);

        bool DeleteProduct(int id);

        Product GetProductByName(string name);

        Product GetProductById(int id);

        bool IsProductExisting(string productName);

        int CountUserBidsForProduct(int id);

        IList<User> GetProductUsers(int id);
    }
}