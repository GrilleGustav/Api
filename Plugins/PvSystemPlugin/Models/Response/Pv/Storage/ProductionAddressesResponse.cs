// <copyright file="ProductionAddressesResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.Response;
using PvSystemPlugin.Models.View.Pv.Storage;
using System.Collections.Generic;

namespace PvSystemPlugin.Models.Response.Pv.Storage
{
  /// <summary>
  /// Production addresses response.
  /// </summary>
  public class ProductionAddressesResponse : ErrorResponse
  {
    /// <summary>
    /// Production addresses response.
    /// </summary>
    public ProductionAddressesResponse()
    { }

    /// <summary>
    /// Production addresses response.
    /// </summary>
    /// <param name="productionAddresses">List of production addresses.</param>
    public ProductionAddressesResponse(IList<ProductionAddressViewModel> productionAddresses)
    {
      this.ProductionAddresses = productionAddresses;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set production addresses.
    /// </summary>
    public IList<ProductionAddressViewModel> ProductionAddresses { get; set; }
  }
}
