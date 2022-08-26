using Entities.Context;
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
  public class CellSpecificationTests : ServiceFixture<ICellSpecificationService>
  {
    private static ICellSpecificationService _cellSpecificationService;
    private static CellSpecification _cellSpecification;

    [OneTimeSetUp]
    public void VendorTestOneTimeSetUp()
    {
      ServiceCollection.AddScoped<ICellSpecificationService, CellSpecificationService>();
      ServiceProvider = ServiceCollection.BuildServiceProvider();
      RepositoryContext = (RepositoryContext)ServiceProvider.GetService(typeof(RepositoryContext));
      RepositoryContext.Database.EnsureDeleted();
      RepositoryContext.Database.EnsureCreated();

      _cellSpecification = new CellSpecification()
      {
        Id = 2,
        Name = "LF310K",
        Code = "87",
        Description = "UnitTest"
      };
    }

    [SetUp]
    public void VendorSetUp()
    {
      _cellSpecificationService = _service;
    }

    [Test, Order(1)]
    public void Create()
    {
      var result = _cellSpecificationService.Create(_cellSpecification).Result;
      Assert.IsTrue(result.IsSuccess);
      var result2 = _cellSpecificationService.GetOne(2).Result;
      result2.Data.Should().BeEquivalentTo(_cellSpecification, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(2)]
    public void GetAll()
    {
      var result = _cellSpecificationService.GetAll().Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      result.Data.Should().HaveCount(2);
      result.Data.Where(x => x.Id == 2).SingleOrDefault().Should().BeEquivalentTo(_cellSpecification, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(3)]
    public void GetOne()
    {
      var result = _cellSpecificationService.GetOne(2).Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      Assert.IsTrue(result.IsSuccess);
      result.Data.Should().BeEquivalentTo(_cellSpecification, options => options.Excluding(o => o.ConcurrencyStamp).Excluding(o => o.UpdatedOn).Excluding(o => o.CreatedOn));
    }

    [Test, Order(4)]
    public void Update()
    {
      var vendor = _cellSpecificationService.GetOne(2).Result.Data;
      vendor.Code = "aaa";
      var result = _cellSpecificationService.Update(vendor).Result;
      Assert.IsTrue(result.IsSuccess);
      vendor.Should().BeEquivalentTo(_cellSpecificationService.GetOne(2).Result.Data, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp));
    }

    [Test, Order(5)]
    public void Cocurrency()
    {
      var vendor = _cellSpecificationService.GetOne(2).Result.Data;
      vendor.Code = "123";
      var result = _cellSpecificationService.Update(vendor).Result;
      Assert.IsTrue(result.IsSuccess);
      vendor.Code = "abc";
      vendor.ConcurrencyStamp = DateTime.Now;
      var result2 = _cellSpecificationService.Update(vendor).Result;
      Assert.IsFalse(result2.IsSuccess);
      "2001".Should().BeEquivalentTo(result2.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(6)]
    public void AlreadyExist()
    {
      var result = _cellSpecificationService.Create(_cellSpecification).Result;
      Assert.IsFalse(result.IsSuccess);
      "15".Should().BeEquivalentTo(result.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(7)]
    public void Delete()
    {
      var result = _cellSpecificationService.Delete(2).Result;
      Assert.IsTrue(result.IsSuccess);
    }
  }
}
