// <copyright file="UserClaimsUpdateRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Request.User
{
  public class UserClaimsUpdateRequest
  {
    /// <summary>
    /// Get or set user id.
    /// </summary>
    [Required]
    public string UserId { get; set; }

    /// <summary>
    /// Get or set user claims.
    /// </summary>
    public List<string> Claims { get; set; }
  }
}
