using Contracts;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NUnit.Framework;
using Repository;
using System;

namespace ApplicationTests
{
  public class ServiceFixture<T>
  {
    public IServiceCollection ServiceCollection { get; private set; }
    public RepositoryContext RepositoryContext { get; set; }

    public IServiceProvider ServiceProvider { get; set; }

    public T _service
    {
      get
      {
        return (T)ServiceProvider.CreateScope().ServiceProvider.GetService(typeof(T));
      }
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      ServiceCollection = new ServiceCollection();
      ServiceCollection.AddDbContext<RepositoryContext>(opt =>
                        opt.UseMySql("Server=127.0.0.1;port=3306;database=apiTest;uid=root;pwd=123;charset=latin1",
                                      new MySqlServerVersion(new System.Version(10, 5, 8)), b => b.MigrationsAssembly("Entities")), ServiceLifetime.Transient);

      ServiceCollection.AddLogging(l =>
      {
        l.ClearProviders();
        l.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
        l.AddNLog();
      });

      ServiceCollection.AddScoped<IRepositoryManager, RepositoryManager>();
      //serviceCollection.AddScoped<IEmailServerService, EmailServerService>();
      //serviceCollection.AddScoped<IEmailTemplateService, EmailTemplateService>();

      //ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
      RepositoryContext.Database.EnsureDeleted();
    }


  }
}
