// <copyright file="EmailSenderAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

namespace Models.Request.Settings.Sender
{
  /// <summary>
  /// Email sender add requwst.
  /// </summary>
  public class EmailSenderAddRequest
  {
    /// <summary>
    /// Get or set email server id.
    /// </summary>
    public int EmailServerId { get; set; }

    /// <summary>
    /// Get or set sender name.
    /// </summary>
    public string Sender { get; set; }
  }
}
