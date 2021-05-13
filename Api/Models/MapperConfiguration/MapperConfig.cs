using AutoMapper;
using Entities.Models.Account;
using Entities.Models.Settings.Email;
using Models.Request;
using Models.Request.Settings.Email;
using Models.Request.Settings.Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
  }
}
