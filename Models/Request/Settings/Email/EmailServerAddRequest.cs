// <copyright file="EmailServerAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace Models.Request.Settings.Email
{
  /// <summary>
  /// Required data to create emial server entity.
  /// </summary>
  public class EmailServerAddRequest
  {
    /// <summary>
    /// Get or set Server ip.
    /// </summary>
    [Required]
    public string ServerIp { get; set; }

    /// <summary>
    /// Get or set Server port.
    /// </summary>
    [Required]
    public string ServerPort { get; set; }

    /// <summary>
    /// Get or set Server credential User.
    /// </summary>
    [Required]
    public string ServerUsername { get; set; }

    /// <summary>
    /// Get or set Server credential Password.
    /// </summary>
    [Required]
    public string ServerPassword { get; set; }

    /// <summary>
    /// Server description.
    /// </summary>
    [Required]
    public string Description { get; set; }

    /// <summary>
    /// Default Server.
    /// </summary>
    [Required]
    public bool Default { get; set; }
  }
}
