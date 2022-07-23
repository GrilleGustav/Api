using Entities.Context;
using Entities.Models.Settings.Email;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTests
{
  public class TemplateTypeTests : ServiceFixture<ITemplateTypeService>
  {
    private static ITemplateTypeService _templateTypeService;
    private static TemplateType _templateType;

    [OneTimeSetUp]
    public void TemplateTypeOneTimeSetUp()
    {
      ServiceCollection.AddScoped<ITemplateTypeService, TemplateTypeService>();
      ServiceProvider = ServiceCollection.BuildServiceProvider();
      RepositoryContext = (RepositoryContext)ServiceProvider.GetService(typeof(RepositoryContext));
      RepositoryContext.Database.EnsureDeleted();
      RepositoryContext.Database.EnsureCreated();

      _templateType = new TemplateType()
      {
        Id = 3,
        Name = "UnitTestName",
        PluginName = "UnitTest"
      };
    }

    [SetUp]
    public void EmailServerSetUp()
    {
      _templateTypeService = _service;
    }

    [Test, Order(1)]
    public void Create()
    {
      var result = _templateTypeService.Create(_templateType).Result;
      Assert.IsNotNull(result);
      Assert.IsTrue(result.IsSuccess);
      var result2 = _templateTypeService.GetOne(3).Result;
      result2.Data.Should().BeEquivalentTo(_templateType);
    }

    [Test, Order(2)]
    public void GetAll()
    {
      var result = _templateTypeService.GetAll().Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      Assert.IsTrue(result.IsSuccess);
      result.Data.Should().HaveCount(3);
      result.Data.Where(x => x.Id == 3).SingleOrDefault().Should().BeEquivalentTo(_templateType);
    }

    [Test, Order(3)]
    public void GetOne()
    {
      var result = _templateTypeService.GetOne(3).Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      Assert.IsTrue(result.IsSuccess);
      result.Data.Should().BeEquivalentTo(_templateType);
    }
  }
}
