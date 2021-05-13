// <copyright file="ErrorResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

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
    { }

    /// <summary>
    /// Error response.
    /// </summary>
    /// <param name="errorCode">Unique error code.</param>
    public ErrorResponse(string errorCode)
    {
      ErrorCode = errorCode;
    }

    /// <summary>
    /// Error response.
    /// </summary>
    /// <param name="errorCode">Unique error code.</param>
    /// <param name="ErrorMessage">Error message.</param>
    public ErrorResponse(string errorCode, string errorMessage)
    {
      ErrorCode = errorCode;
      ErrorMessage = errorMessage;
    }
    /// <summary>
    /// Get or set ErrorCode.
    /// </summary>
    public string ErrorCode { get; set; } = "0";

    /// <summary>
    /// Get or set ErrorMessage.
    /// </summary>
    public string ErrorMessage { get; set; }
  }
}
