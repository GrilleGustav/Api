// <copyright file="PvStorageResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.View.Pv.Storage;

namespace Models.Response.Pv.Storage
{
  /// <summary>
  /// Pv storage response.
  /// </summary>
  public class PvStorageResponse : ErrorResponse
  {
    /// <summary>
    /// Pv storage response.
    /// </summary>
    public PvStorageResponse()
    { }

    /// <summary>
    /// Pv storage response.
    /// </summary>
    /// <param name="pvStorage">Pv storage.</param>
    public PvStorageResponse(PvStorageViewModel pvStorage)
    {
      this.PvStorage = pvStorage;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set pv storage.
    /// </summary>
    public PvStorageViewModel PvStorage { get; set; }
  }
}
