// <copyright file="EmailServerExistResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Models.Response.Settings.Email
{
  /// <summary>
  /// Email server exist response.
  /// </summary>
  public class EmailServerExistResponse : ErrorResponse
  {
    /// <summary>
    /// Email server exist response.
    /// </summary>
    public EmailServerExistResponse()
    { }

    /// <summary>
    /// Email server exist response.
    /// </summary>
    /// <param name="exist">If server aleready exist true</param>
    public EmailServerExistResponse(bool exist)
    {
      this.Exist = exist;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set Exist.
    /// </summary>
    public bool Exist { get; set; }
  }
}
