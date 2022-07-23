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
  public class EmailSenderTests : ServiceFixture<IEmailSenderService>
  {
    private static IEmailSenderService _emailSenderService { get; set; }
    private static EmailSender _emailSender;

    [OneTimeSetUp]
    public void EmailServerTestOneTimeSetUp()
    {
      ServiceCollection.AddScoped<IEmailSenderService, EmailSenderService>();
      ServiceProvider = ServiceCollection.BuildServiceProvider();
      RepositoryContext = (RepositoryContext)ServiceProvider.GetService(typeof(RepositoryContext));
      RepositoryContext.Database.EnsureDeleted();
      RepositoryContext.Database.EnsureCreated();

      _emailSender = new EmailSender
      {
        Id = 2,
        Sender = "info@grillegistav.de"
      };

    }

    [SetUp]
    public void EmailServerSetUp()
    {
      _emailSenderService = _service;
    }

    [Test, Order(1)]
    public void Create()
    {
      var result = _emailSenderService.Create(_emailSender).Result;
      Assert.IsTrue(result.IsSuccess);
      var result2 = _emailSenderService.GetOne(2).Result;
      result2.Data.Should().BeEquivalentTo(_emailSender);
    }

    [Test, Order(2)]
    public void GetAll()
    {
      var result = _emailSenderService.GetAll().Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      result.Data.Should().HaveCount(2);
      result.Data.Where(x => x.Id == 2).SingleOrDefault().Should().BeEquivalentTo(_emailSender);
    }

    [Test, Order(3)]
    public void GetOne()
    {
      var result = _emailSenderService.GetOne(2).Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      Assert.IsTrue(result.IsSuccess);
      result.Data.Should().BeEquivalentTo(_emailSender);
    }

    [Test, Order(4)]
    public void Delete()
    {
      var result = _emailSenderService.Delete(2).Result;
      Assert.IsTrue(result.IsSuccess);
      var result2 = _emailSenderService.GetOne(2).Result;
      Assert.IsFalse(result2.IsSuccess);
      "3".Should().BeEquivalentTo(result2.Errors[0].ErrorCode);
    }
  }
}
