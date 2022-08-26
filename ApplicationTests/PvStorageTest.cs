using Entities.Context;
using Entities.Models.Pv;
using Entities.Models.Pv.Storage;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Services.Interfaces.Pv.Storage;
using Services.Pv.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
  internal class PvStorageTest : ServiceFixture<IPvStorageService>
  {
    private static IPvStorageService _pvStorageService;
    private static PvStorage _pvStorage;

    [OneTimeSetUp]
    public void VendorTestOneTimeSetUp()
    {
      ServiceCollection.AddScoped<IPvStorageService, PvStorageService>();
      ServiceProvider = ServiceCollection.BuildServiceProvider();
      RepositoryContext = (RepositoryContext)ServiceProvider.GetService(typeof(RepositoryContext));
      RepositoryContext.Database.EnsureDeleted();
      RepositoryContext.Database.EnsureCreated();

      _pvStorage = new PvStorage
      {
        Id = 1,
        Name = "BleckedePv",
        UsableCapacity = 50.5,
        Capacity = 56,
        BatteryVoltage = 56,
        Description = "UnitTest",
        BatteryBlocks = new List<BatteryBlock>(),
        PvComments = new List<PvComments>()
      };
    }

    [SetUp]
    public void VendorSetUp()
    {
      _pvStorageService = _service;
    }

    [Test, Order(1)]
    public void Create()
    {
      var result = _pvStorageService.Create(_pvStorage).Result;
      Assert.IsTrue(result.IsSuccess);
      var result2 = _pvStorageService.GetOne(1).Result;
      result2.Data.Should().BeEquivalentTo(_pvStorage, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(2)]
    public void GetAll()
    {
      var result = _pvStorageService.GetAll().Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      result.Data.Should().HaveCount(1);
      result.Data.Where(x => x.Id == 1).SingleOrDefault().Should().BeEquivalentTo(_pvStorage, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn).Excluding(o => o.PvComments));
    }

    [Test, Order(3)]
    public void GetOne()
    {
      var result = _pvStorageService.GetOne(1).Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      Assert.IsTrue(result.IsSuccess);
      result.Data.Should().BeEquivalentTo(_pvStorage, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(4)]
    public void Update()
    {
      var pvStorage = _pvStorageService.GetOne(1).Result.Data;
      pvStorage.Name = "HamburgPv";
      var result = _pvStorageService.Update(pvStorage).Result;
      Assert.IsTrue(result.IsSuccess);
      pvStorage.Should().BeEquivalentTo(_pvStorageService.GetOne(1).Result.Data, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp));
    }

    [Test, Order(5)]
    public void Cocurrency()
    {
      var pvStorage = _pvStorageService.GetOne(1).Result.Data;
      pvStorage.Name = "BleckedePv";
      var result = _pvStorageService.Update(pvStorage).Result;
      Assert.IsTrue(result.IsSuccess);
      pvStorage.Name = "LüneburgPv";
      pvStorage.ConcurrencyStamp = DateTime.Now;
      var result2 = _pvStorageService.Update(pvStorage).Result;
      Assert.IsFalse(result2.IsSuccess);
      "2001".Should().BeEquivalentTo(result2.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(6)]
    public void AlreadyExist()
    {
      var result = _pvStorageService.Create(_pvStorage).Result;
      Assert.IsFalse(result.IsSuccess);
      "15".Should().BeEquivalentTo(result.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(7)]
    public void Delete()
    {
      var result = _pvStorageService.Delete(1).Result;
      Assert.IsTrue(result.IsSuccess);
    }
  }
}
