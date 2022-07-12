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
 public class EmailTemplateTests : ServiceFixture<IEmailTemplateService>
  {
    private static IEmailTemplateService _emailTemplateService { get; set; }
    private static EmailTemplate _emailTemplate1;
    private static EmailTemplate _emailTemplate2;
    private static EmailTemplate _emailTemplate3;

    [OneTimeSetUp]
    public void EmailServerTestOneTimeSetUp()
    {
      ServiceCollection.AddScoped<IEmailTemplateService, EmailTemplateService>();
      ServiceProvider = ServiceCollection.BuildServiceProvider();
      RepositoryContext = (RepositoryContext)ServiceProvider.GetService(typeof(RepositoryContext));
      RepositoryContext.Database.EnsureDeleted();
      RepositoryContext.Database.EnsureCreated();

      _emailTemplate1 = new EmailTemplate
      {
        Id = 2,
        Default = false,
        Name = "UnitTest",
        Content = "UnitTest{{Name}}",
        Description = "Created for testing service funtionality",
        Language = Enums.Language.Germany,
        Predefined = false,
        EmailSenderId = 1,
        TemplateTypeId = 1,
        UpdatedOn = DateTime.Now,
        ConcurrencyStamp = DateTime.Now
      };

      _emailTemplate2 = new EmailTemplate
      {
        Id = 3,
        Default = true,
        Name = "UnitTest2",
        Content = "UnitTest2{{Name}}",
        Description = "Created for testing service funtionality",
        Language = Enums.Language.Germany,
        Predefined = false,
        EmailSenderId = 1,
        TemplateTypeId = 1,
        UpdatedOn = DateTime.Now,
        ConcurrencyStamp = DateTime.Now
      };
      _emailTemplate3 = new EmailTemplate
      {
        Id = 4,
        Default = false,
        Name = "UnitTest3",
        Content = "UnitTest3{{Name}}",
        Description = "Created for testing service funtionality",
        Language = Enums.Language.Germany,
        Predefined = true,
        EmailSenderId = 1,
        TemplateTypeId = 1,
        UpdatedOn = DateTime.Now,
        ConcurrencyStamp = DateTime.Now
      };
    }

    [SetUp]
    public void EmailServerSetUp()
    {
      _emailTemplateService = _service;
    }

    [TearDown]
    public void EmailServerTearDown()
    { }

    [Test, Order(1)]
    public void Create()
    {
      var result = _emailTemplateService.Create(_emailTemplate1).Result;
      Assert.IsTrue(result.IsSuccess);
      var result2 = _emailTemplateService.GetOne(2).Result;
      result2.Data.Should().BeEquivalentTo(_emailTemplate1, options => options.Excluding(o => o.EmailSender).Excluding(o => o.TemplateType));
    }

    [Test, Order(2)]
    public void GetAll()
    {
      var result = _emailTemplateService.GetAll().Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      result.Data.Should().HaveCount(2);
      result.Data.Where(x => x.Id == 2).SingleOrDefault().Should().BeEquivalentTo(_emailTemplate1, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp).Excluding(o => o.EmailSender).Excluding(o => o.TemplateType));
    }

    [Test, Order(3)]
    public void GetOne()
    {
      var result = _emailTemplateService.GetOne(2).Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      result.Data.Should().BeEquivalentTo(_emailTemplate1, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp).Excluding(o => o.EmailSender).Excluding(o => o.TemplateType));
    }

    [Test, Order(4)]
    public void GetDefault()
    {
      var result = _emailTemplateService.GetDefaultTemplateForType(1).Result;
      Assert.IsNotNull(result);
      Assert.IsNotNull(result.Data);
      result.Data.Should().BeEquivalentTo(new EmailTemplate
      {
        Id = 1,
        Name = "Register 1",
        Description = "Predefined template. Is used for the first installation if the administrator does not create one.",
        Content = "<p>Please click on the link below to confirm your registration.</p><p><span class='placeholder'>{ConfirmLink}</span></p>",
        Predefined = true,
        Language = Enums.Language.Germany,
        Default = true,
        EmailSenderId = 1,
        TemplateTypeId = 1
      }, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp).Excluding(o => o.EmailSender).Excluding(o => o.TemplateType));
      Assert.IsTrue(result.Data.Default, "The expected default server was not the default.");
    }

    [Test, Order(5)]
    public void Update()
    {
      var result = _emailTemplateService.GetOne(2).Result;
      Assert.IsTrue(result.IsSuccess);
      result.Data.Content = "UnitTest{{Name}}";
      var result2 = _emailTemplateService.Update(result.Data).Result;
      Assert.IsTrue(result2.IsSuccess);
      result.Data.Should().BeEquivalentTo(_emailTemplateService.GetOne(2).Result.Data, options => options.Excluding(o => o.UpdatedOn).Excluding(o => o.ConcurrencyStamp).Excluding(o => o.EmailSender).Excluding(o => o.TemplateType));
    }

    [Test, Order(6)]
    public void Cocurrency()
    {
      var emailTemplate = _emailTemplateService.GetOne(2).Result.Data;
      emailTemplate.Description = "UnitTest Concurrency";
      var result = _emailTemplateService.Update(emailTemplate).Result;
      Assert.IsTrue(result.IsSuccess);
      emailTemplate.Description = "UnitTest Concurrency UnitTest";
      emailTemplate.ConcurrencyStamp = DateTime.Now;
      var result2 = _emailTemplateService.Update(emailTemplate).Result;
      Assert.IsFalse(result2.IsSuccess);
      "2001".Should().BeEquivalentTo(result2.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(7)]
    public void Test7()
    {
      var result = _emailTemplateService.Create(_emailTemplate2).Result;
      Assert.IsTrue(result.IsSuccess);
      var result2 = _emailTemplateService.GetOne(3).Result;
      result2.Data.Should().BeEquivalentTo(_emailTemplate2, options => options.Excluding(o => o.EmailSender).Excluding(o => o.TemplateType));
    }

    [Test, Order(8)]
    public void Test8()
    {
      var result = _emailTemplateService.Create(_emailTemplate3).Result;
      Assert.IsTrue(result.IsSuccess);
      var result2 = _emailTemplateService.GetOne(4).Result;
      result2.Data.Should().BeEquivalentTo(_emailTemplate3, options => options.Excluding(o => o.EmailSender).Excluding(o => o.TemplateType));
    }

    [Test, Order(9)]
    public void Test9()
    {
      var result = _emailTemplateService.GetDefaultTemplateForType(1).Result;
      Assert.IsTrue(result.IsSuccess);
      Assert.IsTrue(result.Data.Default);
      result.Data.Default = false;
      var result2 = _emailTemplateService.Update(result.Data).Result;
      Assert.IsFalse(result2.IsSuccess);
      "4".Should().BeEquivalentTo(result2.Errors[0].ErrorCode.ToString());
    }
    [Test, Order(10)]
    public void Test91()
    {
      var result = _emailTemplateService.GetOne(2).Result;
      Assert.IsTrue(result.IsSuccess);
      Assert.IsFalse(result.Data.Default);
      result.Data.Default = true;
      var result2 = _emailTemplateService.Update(result.Data).Result;
      Assert.IsTrue(result2.IsSuccess);
      var result3 = _emailTemplateService.GetOne(3).Result;
      Assert.IsTrue(result3.IsSuccess);
      Assert.IsFalse(result3.Data.Default);
    }

    [Test, Order(11)]
    public void Test92()
    {
      var result = _emailTemplateService.Delete(2).Result;
      Assert.IsFalse(result.IsSuccess);
      "5".Should().BeEquivalentTo(result.Errors[0].ErrorCode.ToString());
    }

    [Test, Order(12)]
    public void Test93()
    {
      var result = _emailTemplateService.Delete(3).Result;
      Assert.IsTrue(result.IsSuccess);
    }
  }
}
