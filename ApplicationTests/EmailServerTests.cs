using Entities.Context;
using Entities.Models.Settings.Email;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Models.Request.Settings.Email;
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
  public class EmailServerTests : ServiceFixture<IEmailServerService>
  {
    private static IEmailServerService _emailServerService { get; set; }
    private static EmailServer _emailServer;

    [OneTimeSetUp]
    public void EmailServerTestOneTimeSetUp()
    {
      ServiceCollection.AddScoped<IEmailServerService, EmailServerService>();
      ServiceProvider = ServiceCollection.BuildServiceProvider();
      RepositoryContext = (RepositoryContext)ServiceProvider.GetService(typeof(RepositoryContext));
      RepositoryContext.Database.EnsureDeleted();
      RepositoryContext.Database.EnsureCreated();

      _emailServer = new EmailServer
      {
        Id = 2,
        Default = false,
        ServerIp = "mail.example.de",
        ServerPort = "25",
        ServerUsername = "test@example.de",
        ServerPassword = "ggrwhgrsde5465",
        Description = "Used for UnitTests.",
      };
    }

    [SetUp]
    public void EmailServerSetUp()
    {
      _emailServerService = _service;
    }

    [TearDown]
    public void EmailServerTearDown()
    { }

    [Test, Order(1)]
    public void Create()
    {
      var result = _emailServerService.Create(_emailServer).Result;
      Assert.IsTrue(result.IsSuccess);
      var result2 = _emailServerService.GetOne(2).Result;
      result2.Data.Should().BeEquivalentTo(_emailServer);
    }

    [Test, Order(2)]
    public void GetAll()
    {
      var result = _emailServerService.GetAll().Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      result.Data.Should().HaveCount(2);
      result.Data.Where(x => x.Id == 2).SingleOrDefault().Should().BeEquivalentTo(_emailServer, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp));
    }

    [Test, Order(3)]
    public void GetOne()
    {
      var result = _emailServerService.GetOne(2).Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      Assert.IsTrue(result.IsSuccess);
      result.Data.Should().BeEquivalentTo(_emailServer, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp));
    }

    [Test, Order(4)]
    public void GetDefault()
    {
      var result = _emailServerService.GetDefault().Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      Assert.IsTrue(result.IsSuccess);
      result.Data.Should().BeEquivalentTo(new EmailServer
      {
        Id = 1,
        Default = true,
        ServerIp = "mail.grillegustav.de",
        ServerPort = "25",
        ServerUsername = "developper@grillegustav.de",
        ServerPassword = "mobuapXikC",
        Description = "Testbenutzer"
      }, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp));
      Assert.IsTrue(result.Data.Default, "The expected default server was not the default.");
    }

    [Test, Order(5)]
    public void Update()
    {
      var emailserver = _emailServerService.GetOne(2).Result.Data;
      emailserver.ServerUsername = "test@musterman.net";
      var result = _emailServerService.Update(emailserver).Result;
      Assert.IsTrue(result.IsSuccess);
      emailserver.Should().BeEquivalentTo(_emailServerService.GetOne(2).Result.Data, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp));
    }

    [Test, Order(6)]
    public void Cocurrency()
    {
      var emailserver = _emailServerService.GetOne(2).Result.Data;
      emailserver.ServerPort = "35";
      var result = _emailServerService.Update(emailserver).Result;
      Assert.IsTrue(result.IsSuccess);
      emailserver.ServerPort = "20";
      emailserver.ConcurrencyStamp = DateTime.Now;
      var result2 = _emailServerService.Update(emailserver).Result;
      Assert.IsFalse(result2.IsSuccess);
      "2001".Should().BeEquivalentTo(result2.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(7)]
    public void SetDefaultToFalse()
    {
      var result = _emailServerService.GetDefault().Result;
      Assert.IsTrue(result.IsSuccess);
      Assert.IsTrue(result.Data.Default);
      result.Data.Default = false;
      var result2 = _emailServerService.Update(result.Data).Result;
      Assert.IsFalse(result2.IsSuccess);
      "4".Should().BeEquivalentTo(result2.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(8)]
    public void SetDefault()
    {
      var result = _emailServerService.GetOne(2).Result;
      Assert.IsTrue(result.IsSuccess);
      Assert.IsFalse(result.Data.Default);
      result.Data.Default = true;
      var result2 = _emailServerService.Update(result.Data).Result;
      Assert.IsTrue(result2.IsSuccess);
      var result3 = _emailServerService.GetOne(1).Result;
      Assert.IsTrue(result3.IsSuccess);
      Assert.IsFalse(result3.Data.Default);
    }

    [Test, Order(9)]
    public void DeleteDefault()
    {
      var result = _emailServerService.Delete(2).Result;
      Assert.IsFalse(result.IsSuccess);
      "7".Should().BeEquivalentTo(result.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(10)]
    public void Delete()
    {
      var result = _emailServerService.Delete(1).Result;
      Assert.IsTrue(result.IsSuccess);
    }

    [Test, Order(11)]
    public void ServerExist()
    {
      EmailServerExistRequest emailServerExistRequest = new EmailServerExistRequest();
      emailServerExistRequest.Id = 1;
      emailServerExistRequest.ServerIp = "192.145.23.2";
      emailServerExistRequest.ServerPort = "34";
      var result = _emailServerService.EmailServerExist(emailServerExistRequest).Result;
      result.IsSuccess.Should().BeTrue();
      result.Exist.Should().BeFalse();
    }
  }
}
