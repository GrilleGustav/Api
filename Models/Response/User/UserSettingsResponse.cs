// <copyright file="UserSettingsResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.View.User;

namespace Models.Response.User
{
  /// <summary>
  /// User response.
  /// </summary>
  public class UserSettingsResponse : ErrorResponse
  {
    /// <summary>
    /// User response.
    /// </summary>
     public UserSettingsResponse()
    { }

    /// <summary>
    /// User response.
    /// </summary>
    /// <param name="user">User.</param>
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
