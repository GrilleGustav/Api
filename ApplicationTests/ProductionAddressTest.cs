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
  public class ProductionAddressTest : ServiceFixture<IProductionAddressService>
  {
    private static IProductionAddressService _productionAddressService;
    private static ProductionAddress _productionAddress;

    [OneTimeSetUp]
    public void VendorTestOneTimeSetUp()
    {
      ServiceCollection.AddScoped<IProductionAddressService, ProductionAddressService>();
      ServiceProvider = ServiceCollection.BuildServiceProvider();
      RepositoryContext = (RepositoryContext)ServiceProvider.GetService(typeof(RepositoryContext));
      RepositoryContext.Database.EnsureDeleted();
      RepositoryContext.Database.EnsureCreated();

      _productionAddress = new ProductionAddress()
      {
        Id = 3,
        Name = "Hamburg",
        Code = "HH",
        Description = "UnitTest"
      };
    }

    [SetUp]
    public void VendorSetUp()
    {
      _productionAddressService = _service;
    }

    [Test, Order(1)]
    public void Create()
    {
      var result = _productionAddressService.Create(_productionAddress).Result;
      Assert.IsTrue(result.IsSuccess);
      var result2 = _productionAddressService.GetOne(3).Result;
      result2.Data.Should().BeEquivalentTo(_productionAddress, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(2)]
    public void GetAll()
    {
      var result = _productionAddressService.GetAll().Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      result.Data.Should().HaveCount(3);
      result.Data.Where(x => x.Id == 3).SingleOrDefault().Should().BeEquivalentTo(_productionAddress, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(3)]
    public void GetOne()
    {
      var result = _productionAddressService.GetOne(3).Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      Assert.IsTrue(result.IsSuccess);
      result.Data.Should().BeEquivalentTo(_productionAddress, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(4)]
    public void Update()
    {
      var productionAddress = _productionAddressService.GetOne(3).Result.Data;
      productionAddress.Code = "LG";
      var result = _productionAddressService.Update(productionAddress).Result;
      Assert.IsTrue(result.IsSuccess);
      productionAddress.Should().BeEquivalentTo(_productionAddressService.GetOne(3).Result.Data, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp));
    }

    [Test, Order(5)]
    public void Cocurrency()
    {
      var productionAddress = _productionAddressService.GetOne(3).Result.Data;
      productionAddress.Code = "123";
      var result = _productionAddressService.Update(productionAddress).Result;
      Assert.IsTrue(result.IsSuccess);
      productionAddress.Code = "abc";
      productionAddress.ConcurrencyStamp = DateTime.Now;
      var result2 = _productionAddressService.Update(productionAddress).Result;
      Assert.IsFalse(result2.IsSuccess);
      "2001".Should().BeEquivalentTo(result2.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(6)]
    public void AlreadyExist()
    {
      var result = _productionAddressService.Create(_productionAddress).Result;
      Assert.IsFalse(result.IsSuccess);
      "15".Should().BeEquivalentTo(result.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(7)]
    public void Delete()
    {
      var result = _productionAddressService.Delete(3).Result;
      Assert.IsTrue(result.IsSuccess);
    }
  }
}
