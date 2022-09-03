using Contracts.Pv.Storage;
using Contracts.Pv;
using PvSystemPlugin.Contracts;
using PvSystemPlugin.Repository.Pv.Storage;
using PvSystemPlugin.Repository.Pv;
using System.Threading.Tasks;
using PvSystemPlugin.Entities.Context;
using Entities.Context;

namespace PvSystemPlugin.Repository
{
  /// <summary>
  /// Manage database pv backend.
  /// </summary>
  public class RepositoryPvManager : IRepositoryPvManager
  {
    private RepositoryPvContext _repositoryContext;
    private IVendorRepository _vendorRepository;
    private IPvStorageRepository _pvStorageRepository;
    private IProductionTypeRepository _productionTypeRepository;
    private IProductionAddressRepository _productionAddressRepository;
    private ICellTypeRepository _cellTypeRepository;
    private ICellSpecificationRepository _cellSpecificationRepository;
    private IBatteryCellRepository _batteryCellRepository;
    private IBatteryBlockRepository _batteryBlockRepository;
    private IPvCommentRepository _pvCommentRepository;

    /// <summary>
    /// Manage database pv backend.
    /// </summary>
    /// <param name="repositoryContext">Connection to database backend.</param>
    public RepositoryPvManager(RepositoryPvContext repositoryContext)
    {
      _repositoryContext = repositoryContext;
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

    public IPvCommentRepository PvComment
    {
      get
      {
        if (_pvCommentRepository == null)
          _pvCommentRepository = new PvCommentsRepository(_repositoryContext);

        return _pvCommentRepository;
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
