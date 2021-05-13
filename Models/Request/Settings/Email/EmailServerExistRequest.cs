// <copyright file="EmailServerExistRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request.Settings.Email
{
  /// <summary>
  /// Data to check if email server to create already exist. It´s used by Angular Validator.
  /// </summary>
  public class EmailServerExistRequest
  {
    /// <summary>
    /// Get or set server ip.
    /// </summary>
    [Required]
    public string ServerIp { get; set; }

    /// <summary>
    /// Get or set server port.
    /// </summary>
    [Required]
    public string ServerPort { get; set; }

    /// <summary>
    /// Get or set server id.
    /// </summary>
    public int Id { get; set; }
  }
}
