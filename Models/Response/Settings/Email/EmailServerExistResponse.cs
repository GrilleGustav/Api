// <copyright file="EmailServerExistResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

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
    /// <param name="exist">If server aleready exist true</param>
    public EmailServerExistResponse(bool exist)
    {
      this.Exist = exist;
    }

    /// <summary>
    /// Email server exist response.
    /// </summary>
    /// <param name="exist">If server aleready exist true</param>
    /// <param name="errorCode">If something went wromg set error code. If all ok errrorCode default 0.</param>
    public EmailServerExistResponse(bool exist, string errorCode)
    {
      this.Exist = exist;
      this.ErrorCode = errorCode;
    }

    /// <summary>
    /// Email server exist response.
    /// </summary>
    /// <param name="exist">If server aleready exist true</param>
    /// <param name="errorCode">If something went wromg set error code. If all ok errrorCode default 0.</param>
    /// <param name="errorMessage">If something went wromg set error message.</param>
    public EmailServerExistResponse(bool exist, string errorCode, string errorMessage)
    {
      this.Exist = exist;
      this.ErrorCode = errorCode;
      this.ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Email server exist response.
    /// </summary>
    /// <param name="errorCode">If something went wromg set error code. If all ok errrorCode default 0.</param>
    public EmailServerExistResponse(string errorCode)
    {
      this.ErrorCode = errorCode;
    }

    /// <summary>
    /// Email server exist response.
    /// </summary>
    /// <param name="errorCode">If something went wromg set error code. If all ok errrorCode default 0.</param>
    /// <param name="errorMessage">If something went wromg set error message.</param>
    public EmailServerExistResponse(string errorCode, string errorMessage)
    {
      this.ErrorCode = errorCode;
      this.ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Get or set Exist.
    /// </summary>
    public bool Exist { get; set; }
  }
}
