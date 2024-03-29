﻿
using IGEG.ToolShop.Domain.Models;

namespace IGEG.ToolShop.Application.Contracts.Percistance
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> CheckCategoryUnique(string name);
        Task<Category> GetCategoryByUrlAsync(string url);
    }
}
