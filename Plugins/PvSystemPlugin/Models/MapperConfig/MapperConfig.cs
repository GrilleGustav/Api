using AutoMapper;
using PvSystemPlugin.Entities.Models.Pv.Storage;
using PvSystemPlugin.Models.Request.Pv.Storage;
using PvSystemPlugin.Models.View.Pv.Storage;

namespace PvSystemPlugin.Models.MapperConfig
{
  public class MapperConfig : Profile
  {
    public MapperConfig()
    {
      //
      // PV mappings.
      //
      // PV mappings vendor.
      CreateMap<Vendor, VendorViewModel>();
      CreateMap<VendorAddRequest, Vendor>();
      CreateMap<VendorUpdateRequest, Vendor>();

      // PV mappings production type.
      CreateMap<ProductionType, ProductionTypeViewModel>();
      CreateMap<ProductionTypeViewModel, ProductionType>();
      CreateMap<ProductionTypeAddRequest, ProductionType>();
      CreateMap<ProductionTypeUpdateRequest, ProductionType>();

      // PV mappings pv storage.
      CreateMap<PvStorage, PvStorageViewModel>();
      CreateMap<PvStorageViewModel, PvStorage>();
      CreateMap<PvStorageAddRequest, PvStorage>();
      CreateMap<PvStorageUpdateRequest, PvStorage>();

      // PV mappings production address.
      CreateMap<ProductionAddress, ProductionAddressViewModel>();
      CreateMap<ProductionAddressViewModel, ProductionAddress>();
      CreateMap<ProductionAddressAddRequest, ProductionAddress>();
      CreateMap<ProductionAddressUpdateRequest, ProductionAddress>();

      // PV mappings cell type.
      CreateMap<CellType, CellTypeViewModel>();
      CreateMap<CellTypeViewModel, CellType>();
      CreateMap<CellTypeAddRequest, CellType>();
      CreateMap<CellTypeUpdateRequest, CellType>();

      // PV mappings cell specification.
      CreateMap<CellSpecification, CellSpecificationViewModel>();
      CreateMap<CellSpecificationViewModel, CellSpecification>();
      CreateMap<CellSpecificationAddRequest, CellSpecification>();
      CreateMap<CellSpecificationUpdateRequest, CellSpecification>();

      // PV mappings battery cell.
      CreateMap<BatteryCell, BatteryCellViewModel>();
      CreateMap<BatteryCellViewModel, BatteryCell>();
      CreateMap<BatteryCellAddRequest, BatteryCell>();
      CreateMap<BatteryCellUpdateRequest, BatteryCell>();

      // PV mappings battery block.
      CreateMap<BatteryBlock, BatteryBlockViewModel>();
      CreateMap<BatteryBlockViewModel, BatteryBlock>();
      CreateMap<BatteryBlockAddRequest, BatteryBlock>();
      CreateMap<BatteryBlockUpdateRequest, BatteryBlock>();
    }
  }
}
