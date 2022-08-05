// <copyright file="ProductionAddressResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.View.Pv.Storage;

namespace Models.Response.Pv.Storage
{
  /// <summary>
  /// Production address response.
  /// </summary>
  public class ProductionAddressResponse : ErrorResponse
  {
    /// <summary>
    /// Production address response.
    /// </summary>
    public ProductionAddressResponse()
    { }

    /// <summary>
    /// Production address response.
    /// </summary>
    /// <param name="productionAddress">Production address.</param>
    public ProductionAddressResponse(ProductionAddressViewModel productionAddress)
    {
      this.ProductionAddress = productionAddress;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set production address.
    /// </summary>
    public ProductionAddressViewModel ProductionAddress { get; set; }
  }
}
