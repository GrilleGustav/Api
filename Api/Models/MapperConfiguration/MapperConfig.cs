// <copyright file="MapperConfing.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Entities.Models.Account;
using Entities.Models.Email;
using Entities.Models.Pv.Storage;
using Entities.Models.Settings.Email;
using Models;
using Models.Request;
using Models.Request.Pv.Storage;
using Models.Request.Role;
using Models.Request.Settings.Email;
using Models.Request.Settings.Sender;
using Models.Request.User;
using Models.Response.Role;
using Models.View.Pv.Storage;
using Models.View.Settings.Email;
using Models.View.Settings.Role;
using Models.View.User;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Api.Models.MapperConfiguration
{
  public class MapperConfig : Profile
  {
    public MapperConfig()
    {
      // Base system mappings.
      CreateMap<RegistrationRequest, User>();//.ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

      CreateMap<EmailServer, EmailServerViewModel>().ForMember(x => x.ServerPassword, opt => opt.Ignore());

      CreateMap<EmailServerAddRequest, EmailServer>();

      CreateMap<EmailServerEditRequest, EmailServer>();

      CreateMap<EmailSender, EmailSenderViewModel>();

      CreateMap<EmailSenderViewModel, EmailSender>();

      CreateMap<EmailSenderAddRequest, EmailSender>();

      CreateMap<EmailTemplate, EmailTemplateViewModel>();

      CreateMap<EmailTemplateViewModel, EmailTemplate>();

      CreateMap<UserDetailViewModel, User>();

      CreateMap<User, UserDetailViewModel>();

      CreateMap<List<User>, List<UserDetailViewModel>>();

      CreateMap<UserDetailRequest, User>();

      CreateMap<User, UserDetailRequest>();

      CreateMap<EmailMessage, EmailMessageViewModel>();

      CreateMap<Claim, ClaimViewModel>();

      CreateMap<Result<Dictionary<string, IGrouping<string, ApplicationClaim>>>, ApplicationClaimsResponse>().ForMember(x => x.ApplicationClaims, opt => opt.MapFrom(x => x.Data));

      CreateMap<string, Claim>().ForMember(x => x.Value, opt => opt.MapFrom(x => x));//ForMember(dest => dest.Type, act => act.MapFrom(src => ClaimTypes.Role));

      CreateMap<string, Role>().ForMember(u => u.Name, opt => opt.MapFrom(x => x.ToString()));

      CreateMap<TemplateType, TemplateTypeViewModel>();

      CreateMap<TemplateTypeViewModel, TemplateType>();

      CreateMap<RoleUpdateRequest, Role>();

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
