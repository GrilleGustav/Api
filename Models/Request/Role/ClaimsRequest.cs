// <copyright file="ClaimsRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Models.Request.Role
{
  /// <summary>
  /// Update role claims.
  /// </summary>
  public class ClaimsRequest
  {
    /// <summary>
    /// Get or set role id.
    /// </summary>
    public string RoleId { get; set; }

    /// <summary>
    /// Get or set claims.
    /// </summary>
    public IList<string> Claims { get; set; }
  }
}
