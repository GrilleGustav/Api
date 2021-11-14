// <copyright file="DataServiceBase.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>


using Contracts;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class DataServiceBase<T> : IDataServiceBase
  {
    private readonly IRepositoryManager _repository;
    private readonly ILogger<T> _logger;

    public DataServiceBase(IRepositoryManager repository, ILogger<T> logger)
    {
      _repository = repository;
      _logger = logger;
    }

  }
}
