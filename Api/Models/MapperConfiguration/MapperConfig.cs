// <copyright file="MapperConfing.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using AutoMapper;
using Entities.Models.Account;
using Entities.Models.Email;
using Entities.Models.Settings.Email;
using Models.Request;
using Models.Request.Settings.Email;
using Models.Request.Settings.Sender;
using Models.Request.User;
using Models.View.Settings.Email;
using Models.View.Settings.Role;
using Models.View.User;
using System.Collections.Generic;
using System.Security.Claims;

namespace Api.Models.MapperConfiguration
{
  public class MapperConfig : Profile
  {
    public MapperConfig()
    {
      CreateMap<RegistrationRequest, User>().ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

      CreateMap<EmailServerAddRequest, EmailServer>();

      CreateMap<EmailServerEditRequest, EmailServer>();

      CreateMap<EmailSenderAddRequest, EmailSender>();

      CreateMap<UserDetailViewModel, User>();

      CreateMap<User, UserDetailViewModel>();

      CreateMap<List<User>, List<UserDetailViewModel>>();

      CreateMap<UserDetailRequest, User>();

      CreateMap<User, UserDetailRequest>();

      CreateMap<EmailMessage, EmailMessageViewModel>();

      CreateMap<Claim, ClaimViewModel>();
    }
  }
}
