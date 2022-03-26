// <copyright file="EmailServerViewModel.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

namespace Models.View.Settings.Email
{
  public class EmailServerViewModel
  {
    /// <summary>
    /// Get or set Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get or set Server ip.
    /// </summary>
    public string ServerIp { get; set; }

    /// <summary>
    /// Get or set Server port.
    /// </summary>
    public string ServerPort { get; set; }

    /// <summary>
    /// Get or set Server credential User.
    /// </summary>
    public string ServerUsername { get; set; }

    /// <summary>
    /// Get or set Server credential Password.
    /// </summary>
    public string ServerPassword { get; set; }

    /// <summary>
    /// Server description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Default Server.
    /// </summary>
    public bool Default { get; set; }

    /// <summary>
    /// A random value that should change whenever a role is persisted to the store.
    /// </summary>
    public byte[] ConcurrencyStamp { get; set; }

    EmailServerViewModel()
    {}
  }
}
