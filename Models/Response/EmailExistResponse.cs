// <copyright file="EmailExistResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

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
    }

    /// <summary>
    /// Email exist response.
    /// </summary>
    /// <param name="exist">If exist true otherwise false.</param>
    /// <param name="errorCode">Error code.</param>
    public EmailExistResponse(bool exist, string errorCode)
    {
      this.Exist = exist;
      this.ErrorCode = errorCode;
    }

    /// <summary>
    /// Email exist response.
    /// </summary>
    /// <param name="exist">If exist true otherwise false.</param>
    /// <param name="errorCode">Error code.</param>
    /// <param name="errorMessage">Error message.</param>
    public EmailExistResponse(bool exist, string errorCode, string errorMessage)
    {
      this.Exist = exist;
      this.ErrorCode = errorCode;
      this.ErrorMessage = errorMessage;
    }
    /// <summary>
    /// Get or set exist.
    /// Return "true" if email exist.
    /// </summary>
    public bool Exist { get; set; }
  }
}
