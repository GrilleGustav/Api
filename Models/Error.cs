// <copyright file="Error.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>


namespace Models
{
  public class Error
  {
    /// <summary>
    /// Error.
    /// </summary>
    public Error()
    { }

    /// <summary>
    /// Initial create with error code..
    /// </summary>
    /// <param name="errorCode">Unique error code.</param>
    public Error(string errorCode)
    {
      ErrorCode = errorCode;
    }

    /// <summary>
    /// Einitial create with error code and message.
    /// </summary>
    /// <param name="errorCode">Unique error code.</param>
    /// <param name="ErrorMessage">Error message.</param>
    public Error(string errorCode, string errorMessage)
    {
      ErrorCode = errorCode;
      ErrorMessage = errorMessage;
    }


    /// <summary>
    /// Get or set ErrorCode.
    /// Default 0.
    /// </summary>
    public string ErrorCode { get; set; } = "0";

    /// <summary>
    /// Get or set ErrorMessage.
    /// </summary>
    public string ErrorMessage { get; set; }
  }
}
