﻿using AlvesMello_IntraNet.Models;

namespace AlvesMello_IntraNet.Repositories.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<Category> Categories { get; }
}
