using Contracts;
using Entities.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class PlaceholderData
  {
    private readonly UserManager<User> _userManager;
    private readonly IRepositoryManager _repositoryManager;
    private string _clientURI;
    private User _user;

    public PlaceholderData(string userEmail, UserManager<User> userManager, IRepositoryManager repositoryManager)
    {
      _userManager = userManager;
      _repositoryManager = repositoryManager;
      _user = userManager.FindByEmailAsync(userEmail).Result;
    }

    public string EmailConfirmationLink
    {
      get
      {
        var param = new Dictionary<string, string>
        {
          {"token", _userManager.GenerateEmailConfirmationTokenAsync(_user).Result },
          {"email", _user.Email }
        };

        return QueryHelpers.AddQueryString(_clientURI, param);

      }
    }
  }
}
