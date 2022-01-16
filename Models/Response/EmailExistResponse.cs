// <copyright file="EmailExistResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Models.Response
{
  /// <summary>
  /// Email exist response.
  /// </summary>
  public class EmailExistResponse : ErrorResponse
  {
    /// <summary>
    /// Email exist response.
    /// </summary>
    /// <param name="exist">If exist true otherwise false.</param>
    public EmailExistResponse(bool exist)
    {
      this.Exist = exist;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Email exist response.
    /// </summary>
    /// <param name="errors">List of errors.</param>
    public EmailExistResponse(List<Error> errors)
    {
      this.Errors = errors;
    }

    /// <summary>
    /// Email exist response.
    /// </summary>
    /// <param name="exist">If exist true otherwise false.</param>
    /// <param name="errors">List of errors.</param>
    public EmailExistResponse(bool exist, List<Error> errors)
    {
      this.Exist = exist;
      this.Errors = errors;
    }

    /// <summary>
    /// Get or set exist.
    /// Return "true" if email exist.
    /// </summary>
    public bool Exist { get; set; }
  }
}
