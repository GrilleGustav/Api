// <copyright file="VendorsResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.View.Pv.Storage;
using System.Collections.Generic;

namespace Models.Response.Pv.Storage
{
  /// <summary>
  /// Venders response.
  /// </summary>
  public class VendorsResponse : ErrorResponse
  {
    /// <summary>
    /// Vendors response.
    /// </summary>
    public VendorsResponse()
    { }

    /// <summary>
    /// Vendors response.
    /// </summary>
    /// <param name="vendors">List of vendors.</param>
    public VendorsResponse(IList<VendorViewModel> vendors)
    {
      this.Vendors = vendors;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or ser vendors.
    /// </summary>
    public IList<VendorViewModel> Vendors { get; set; }
  }
}
