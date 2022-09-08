// <copyright file="VendorResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.Response;
using PvSystemPlugin.Models.View.Pv.Storage;

namespace PvSystemPlugin.Models.Response.Pv.Storage
{
  /// <summary>
  /// Vender response.
  /// </summary>
  public class VendorResponse : ErrorResponse
  {
    /// <summary>
    /// Vendor response.
    /// </summary>
    public VendorResponse()
    { }

    /// <summary>
    /// Vendor response.
    /// </summary>
    /// <param name="vendors">Vendor.</param>
    public VendorResponse(VendorViewModel vendor)
    {
      this.Vendor = vendor;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or ser vendors.
    /// </summary>
    public VendorViewModel Vendor { get; set; }
  }
}