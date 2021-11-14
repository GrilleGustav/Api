using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Response.User
{
  /// <summary>
  /// List of osers response.
  /// </summary>
  public class UsersSettingsResponse: ErrorResponse
  {
    /// <summary>
    /// User response.
    /// </summary>
    public UsersSettingsResponse()
    { }

    /// <summary>
    /// List of users response.
    /// </summary>
    /// <param name="users">List of users.</param>
    public UsersSettingsResponse(List<Entities.Models.Account.User> users)
    {
      this.Users = users;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set list of application users.
    /// </summary>
    public List<Entities.Models.Account.User> Users { get; set; }
  }
}
