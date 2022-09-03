using Contracts.Pv.Storage;
using System.Threading.Tasks;

namespace PvSystemPlugin.Contracts
{
  public interface IRepositoryPvManager
  {
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
