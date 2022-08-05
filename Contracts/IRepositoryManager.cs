// <copyright file="IRepositoryManager.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Contracts.Pv.Storage;
using System.Threading.Tasks;

namespace Contracts
{
  public interface IRepositoryManager
  {
    IEmailServerRepository EmailServer { get; }

    IEmailSenderRepository EmailSender { get; }

    IEmailTemplateRepository EmailTemplate { get; }

    IEmailMessageRepository EmailMessage { get; }

    IRefreshTokenRepository RefreshToken { get; }

    ITemplateTypeRepository TemplateType { get; }

    IVendorRepository Vendor { get; }

    IPvStorageRepository PvStorage { get; }

    IProductionTypeRepository ProductionType { get; }

    IProductionAddressRepository ProductionAddress { get; }

    ICellTypeRepository CellType { get; }

    ICellSpecificationRepository CellSpecification { get; }

    IBatteryCellRepository BatteryCell { get; }

    IBatteryBlockRepository BatteryBlock { get; }

    /// <summary>
    /// Save database actions.
    /// </summary>
    void Save();

    /// <summary>
    /// Save asynchronous database actions.
    /// </summary>
    /// <returns></returns>
    Task<int> SaveAsync();
  }
}
