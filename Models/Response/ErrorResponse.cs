// <copyright file="ErrorResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace Models.Response
{
  /// <summary>
  /// Error response to retürn error code and message.
  /// </summary>
  public class ErrorResponse
  {
    /// <summary>
    /// Error response.
    /// </summary>
    public ErrorResponse()
    {
      this.Errors = new List<Error>();
    }

    /// <summary>
    /// Error response.
    /// </summary>
    /// <param name="isSuccess">State operation completed.</param>
    public ErrorResponse(bool isSuccess)
    {
      this.IsSuccess = isSuccess;
    }

    /// <summary>
    /// Add one Error object.
    /// </summary>
    /// <param name="error">Error object.</param>
    public ErrorResponse(Error error)
    {
      this.Errors.Add(error);
    }

    /// <summary>
    /// Initiate error response with list of errors.
    /// </summary>
    /// <param name="errors">List of errors.</param>
    public ErrorResponse(List<Error> errors)
    { }

    /// <summary>
    /// Get or set succefull
    /// </summary>
    public bool IsSuccess { get; set; } = false;

    public bool TokenNeedsRefresh { get; set; } = false;

    /// <summary>
    /// Get or set errors.
    /// </summary>
    public List<Error> Errors { get; set; } = new List<Error>();

    /// <summary>
    /// Add error with error code and message.
    /// </summary>
    /// <param name="errorCode">Error code.</param>
    /// <param name="errorMessage">Error message.</param>
    public void AddError(string errorCode, string errorMessage)
    {

      this.Errors.Add(new Error(errorCode: errorCode, errorMessage: errorMessage));
    }

    /// <summary>
    /// Add error with error code, without message.
    /// </summary>
    /// <param name="errorCode">Error code.</param>
    public void AddError(string errorCode)
    {

      this.Errors.Add(new Error(errorCode: errorCode));
    }

    /// <summary>
    /// Add range of errors.
    /// </summary>
    /// <param name="errors"></param>
    public void AddErrors(List<Error> errors)
    {
      this.Errors.AddRange(errors);
    }

    /// <summary>
    /// Add error object with errorcode and or error message.
    /// </summary>
    /// <param name="error">Error object.</param>
    public void AddError(Error error)
    {
      this.Errors.Add(error);
    }
  }
}
