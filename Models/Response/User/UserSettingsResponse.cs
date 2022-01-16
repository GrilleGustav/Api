using Models.View.User;
using System;
using System.Collections.Generic;

namespace Models.Response.User
{
  public class UserSettingsResponse : ErrorResponse
  {
    /// <summary>
    /// User response.
    /// </summary>
     public UserSettingsResponse()
    { }

    /// <summary>
    /// Users response.
    /// </summary>
    /// <param name="users">List of users.</param>
    public UserSettingsResponse(UserDetailViewModel user)
    {
      this.User = user;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set User.
    /// </summary>
    public UserDetailViewModel User { get; set; }
  }
}
