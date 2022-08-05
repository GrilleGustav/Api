// <copyright file="RepositoryManager.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts;
using Contracts.Pv.Storage;
using Entities.Context;
using Repository.Pv.Storage;
using System.Threading.Tasks;

namespace Repository
{
  /// <summary>
  /// Manage database backend.
  /// </summary>
  public class RepositoryManager : IRepositoryManager
  {
    private RepositoryContext _repositoryContext;
    private IEmailServerRepository _emailServerRepository;
    private IEmailSenderRepository _emailSenderRepository;
    private IEmailTemplateRepository _emailTemplateRepository;
    private IEmailMessageRepository _emailMessageRepository;
    private IRefreshTokenRepository _refreshTokenRepository;
    private ITemplateTypeRepository _templateTypeRepository;
    private IVendorRepository _vendorRepository;
    private IPvStorageRepository _pvStorageRepository;
    private IProductionTypeRepository _productionTypeRepository;
    private IProductionAddressRepository _productionAddressRepository;
    private ICellTypeRepository _cellTypeRepository;
    private ICellSpecificationRepository _cellSpecificationRepository;
    private IBatteryCellRepository _batteryCellRepository;
    private IBatteryBlockRepository _batteryBlockRepository;

    /// <summary>
    /// Manage database backend.
    /// </summary>
    /// <param name="repositoryContext">Connection to database backend.</param>
    public RepositoryManager(RepositoryContext repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }

    /// <summary>
    /// Initiate email server repository and make it accessible.
    /// </summary>
    public IEmailServerRepository EmailServer
    {
      get
      {
        if (_emailServerRepository == null)
          _emailServerRepository = new EmailServerRepository(_repositoryContext);

        return _emailServerRepository;
      }
    }

    /// <summary>
    /// Initiate email sender repository and make it accessible.
    /// </summary>
    public IEmailSenderRepository EmailSender
    {
      get
      {
        if (_emailServerRepository == null)
          _emailSenderRepository = new EmailSenderRepository(_repositoryContext);

        return _emailSenderRepository;
      }
    }

    /// <summary>
    /// Initiate email template repository and make it accessible.
    /// </summary>
    public IEmailTemplateRepository EmailTemplate
    {
      get
      {
        if (_emailTemplateRepository == null)
          _emailTemplateRepository = new EmailTemplateRepository(_repositoryContext);

        return _emailTemplateRepository;
      }
    }

    /// <summary>
    /// Initiate email message repository and make it accessible.
    /// </summary>
    public IEmailMessageRepository EmailMessage
    {
      get
      {
        if (_emailMessageRepository == null)
          _emailMessageRepository = new EmailMessageRepository(_repositoryContext);

        return _emailMessageRepository;
      }
    }

    /// <summary>
    /// Initiate refresh token repository and make it accessible.
    /// </summary>
    public IRefreshTokenRepository RefreshToken
    {
      get
      {
        if (_refreshTokenRepository == null)
          _refreshTokenRepository = new RefreshTokenRepository(_repositoryContext);

        return _refreshTokenRepository;
      }
    }

    /// <summary>
    /// Initiate template type repository and make it accessible.
    /// </summary>
    public ITemplateTypeRepository TemplateType
    {
      get
      {
        if (_templateTypeRepository == null)
          _templateTypeRepository = new TemplateTypeRepository(_repositoryContext);

        return _templateTypeRepository;
      }
    }

    /// <summary>
    /// Initiate vendor repository and make it accessible.
    /// </summary>
    public IVendorRepository Vendor
    {
      get
      {
        if (_vendorRepository == null)
          _vendorRepository = new VendorRepository(_repositoryContext);

        return _vendorRepository;
      }
    }

    /// <summary>
    /// Initiate pvStorage repository and make it accessible.
    /// </summary>
    public IPvStorageRepository PvStorage
    {
      get
      {
        if (_pvStorageRepository == null)
          _pvStorageRepository = new PvStorageRepository(_repositoryContext);

        return _pvStorageRepository;
      }
    }

    /// <summary>
    /// Initiate productionType repository and make it accessible.
    /// </summary>
    public IProductionTypeRepository ProductionType
    {
      get
      {
        if (_productionTypeRepository == null)
          _productionTypeRepository = new ProductionTypeRepository(_repositoryContext);

        return _productionTypeRepository;
      }
    }

    /// <summary>
    /// Initiate productionAddress repository and make it accessible.
    /// </summary>
    public IProductionAddressRepository ProductionAddress
    {
      get
      {
        if (_productionAddressRepository == null)
          _productionAddressRepository = new ProductionAddressRepository(_repositoryContext);

        return _productionAddressRepository;
      }
    }

    /// <summary>
    /// Initiate cellType repository and make it accessible.
    /// </summary>
    public ICellTypeRepository CellType
    {
      get
      {
        if (_cellTypeRepository == null)
          _cellTypeRepository = new CellTypeRepository(_repositoryContext);

        return _cellTypeRepository;
      }
    }

    /// <summary>
    /// Initiate cellSpecification repository and make it accessible.
    /// </summary>
    public ICellSpecificationRepository CellSpecification
    {
      get
      {
        if (_cellSpecificationRepository == null)
          _cellSpecificationRepository = new CellSpecificationRepository(_repositoryContext);

        return _cellSpecificationRepository;
      }
    }

    /// <summary>
    /// Initiate batteryCell repository and make it accessible.
    /// </summary>
    public IBatteryCellRepository BatteryCell
    {
      get
      {
        if (_batteryCellRepository == null)
          _batteryCellRepository = new BatteryCellRepository(_repositoryContext);

        return _batteryCellRepository;
      }
    }

    /// <summary>
    /// Initiate batteryBlock repository and make it accessible.
    /// </summary>
    public IBatteryBlockRepository BatteryBlock
    {
      get
      {
        if (_batteryBlockRepository == null)
          _batteryBlockRepository = new BatteryBlockRepository(_repositoryContext);

        return _batteryBlockRepository;
      }
    }

    /// <summary>
    /// Save database actions.
    /// </summary>
    public void Save() => _repositoryContext.SaveChanges();

    /// <summary>
    /// Save asynchronous database actions.
    /// </summary>
    /// <returns>Returns number of entities changed or add or delete.</returns>
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateException"></exception>
    /// <exception cref="Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException"></exception>
    public Task<int> SaveAsync() => _repositoryContext.SaveChangesAsync();
  }
}
