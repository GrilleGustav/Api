using Entities.Context;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PvSystemPlugin.Entities.Models.Pv.Storage;
using PvSystemPlugin.Services.Interfaces.Pv.Storage;
using PvSystemPlugin.Services.Pv.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
  public class CellTypeTests : ServiceFixture<ICellTypeService>
  {
    private static ICellTypeService _cellTypeService;
    private static CellType _cellType;

    [OneTimeSetUp]
    public void VendorTestOneTimeSetUp()
    {
      ServiceCollection.AddScoped<ICellTypeService, CellTypeService>();
      ServiceProvider = ServiceCollection.BuildServiceProvider();
      RepositoryContext = (RepositoryContext)ServiceProvider.GetService(typeof(RepositoryContext));
      RepositoryContext.Database.EnsureDeleted();
      RepositoryContext.Database.EnsureCreated();

      _cellType = new CellType
      {
        Id = 2,
        Name = "Bleisäure",
        Code = 'P',
        Description = "Unittest"
      };
    }

    [SetUp]
    public void VendorSetUp()
    {
      _cellTypeService = _service;
    }

    [Test, Order(1)]
    public void Create()
    {
      var result = _cellTypeService.Create(_cellType).Result;
      Assert.IsTrue(result.IsSuccess);
      var result2 = _cellTypeService.GetOne(2).Result;
      result2.Data.Should().BeEquivalentTo(_cellType, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(2)]
    public void GetAll()
    {
      var result = _cellTypeService.GetAll().Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      result.Data.Should().HaveCount(2);
      result.Data.Where(x => x.Id == 2).SingleOrDefault().Should().BeEquivalentTo(_cellType, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(3)]
    public void GetOne()
    {
      var result = _cellTypeService.GetOne(2).Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      Assert.IsTrue(result.IsSuccess);
      result.Data.Should().BeEquivalentTo(_cellType, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(4)]
    public void Update()
    {
      var cellType = _cellTypeService.GetOne(2).Result.Data;
      cellType.Code = 'A';
      var result = _cellTypeService.Update(cellType).Result;
      Assert.IsTrue(result.IsSuccess);
      cellType.Should().BeEquivalentTo(_cellTypeService.GetOne(2).Result.Data, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp));
    }

    [Test, Order(5)]
    public void Cocurrency()
    {
      var cellType = _cellTypeService.GetOne(2).Result.Data;
      cellType.Code = 'h';
      var result = _cellTypeService.Update(cellType).Result;
      Assert.IsTrue(result.IsSuccess);
      cellType.Code = 'G';
      cellType.ConcurrencyStamp = DateTime.Now;
      var result2 = _cellTypeService.Update(cellType).Result;
      Assert.IsFalse(result2.IsSuccess);
      "2001".Should().BeEquivalentTo(result2.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(6)]
    public void AlreadyExist()
    {
      var result = _cellTypeService.Create(_cellType).Result;
      Assert.IsFalse(result.IsSuccess);
      "15".Should().BeEquivalentTo(result.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(7)]
    public void Delete()
    {
      var result = _cellTypeService.Delete(2).Result;
      Assert.IsTrue(result.IsSuccess);
    }
  }
}
