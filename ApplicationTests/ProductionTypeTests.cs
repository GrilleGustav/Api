using Entities.Context;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using PvSystemPlugin.Entities.Models.Pv.Storage;
using PvSystemPlugin.Services.Interfaces.Pv.Storage;
using PvSystemPlugin.Services.Pv.Storage;
using System;
using System.Linq;

namespace ApplicationTests
{
  public class ProductionTypeTests : ServiceFixture<IProductionTypeService>
  {
    private static IProductionTypeService _productionTypeService;
    private static ProductionType _productionType;

    [OneTimeSetUp]
    public void ProductionTypeTestOneTimeSetUp()
    {
      ServiceCollection.AddScoped<IProductionTypeService, ProductionTypeService>();
      ServiceProvider = ServiceCollection.BuildServiceProvider();
      RepositoryContext = (RepositoryContext)ServiceProvider.GetService(typeof(RepositoryContext));
      RepositoryContext.Database.EnsureDeleted();
      RepositoryContext.Database.EnsureCreated();

      _productionType = new ProductionType
      {
        Id = 2,
        Name = "Round",
        Code = 'R',
        Description = "UnitTest"
      };
    }

    [SetUp]
    public void VendorSetUp()
    {
      _productionTypeService = _service;
    }

    [Test, Order(1)]
    public void Create()
    {
      var result = _productionTypeService.Create(_productionType).Result;
      Assert.IsTrue(result.IsSuccess);
      var result2 = _productionTypeService.GetOne(2).Result;
      result2.Data.Should().BeEquivalentTo(_productionType, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(2)]
    public void GetAll()
    {
      var result = _productionTypeService.GetAll().Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      result.Data.Should().HaveCount(2);
      result.Data.Where(x => x.Id == 2).SingleOrDefault().Should().BeEquivalentTo(_productionType, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(3)]
    public void GetOne()
    {
      var result = _productionTypeService.GetOne(2).Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      Assert.IsTrue(result.IsSuccess);
      result.Data.Should().BeEquivalentTo(_productionType, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(4)]
    public void Update()
    {
      var productionType = _productionTypeService.GetOne(2).Result.Data;
      productionType.Code = 'a';
      var result = _productionTypeService.Update(productionType).Result;
      Assert.IsTrue(result.IsSuccess);
      productionType.Should().BeEquivalentTo(_productionTypeService.GetOne(2).Result.Data, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp));
    }

    [Test, Order(5)]
    public void Cocurrency()
    {
      var productionType = _productionTypeService.GetOne(2).Result.Data;
      productionType.Code = 'V';
      var result = _productionTypeService.Update(productionType).Result;
      Assert.IsTrue(result.IsSuccess);
      productionType.Code = 'Q';
      productionType.ConcurrencyStamp = DateTime.Now;
      var result2 = _productionTypeService.Update(productionType).Result;
      Assert.IsFalse(result2.IsSuccess);
      "2001".Should().BeEquivalentTo(result2.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(6)]
    public void AlreadyExist()
    {
      var result = _productionTypeService.Create(_productionType).Result;
      Assert.IsFalse(result.IsSuccess);
      "15".Should().BeEquivalentTo(result.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(7)]
    public void Delete()
    {
      var result = _productionTypeService.Delete(2).Result;
      Assert.IsTrue(result.IsSuccess);
    }
  }
}
