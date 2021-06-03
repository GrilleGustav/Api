using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Providers
{
  public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
  {
    public EmailConfirmationTokenProviderOptions()
    {
      Name = "EmailDataProtectorTokenProvider";
      TokenLifespan = TimeSpan.FromDays(2);
    }
  }
}
