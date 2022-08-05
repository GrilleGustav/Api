// <copyright file="ProductionTypeResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>


using Models.View.Pv.Storage;

namespace Models.Response.Pv.Storage
{
  /// <summary>
  /// Production type response.
  /// </summary>
  public class ProductionTypeResponse : ErrorResponse
  {
    /// <summary>
    /// Production type response.
    /// </summary>
    public ProductionTypeResponse()
    { }

    /// <summary>
    /// Production type response.
    /// </summary>
    /// <param name="productionType">Production type.</param>
    public ProductionTypeResponse(ProductionTypeViewModel productionType)
    {
      this.ProductionType = productionType;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set production type.
    /// </summary>
    public ProductionTypeViewModel ProductionType { get; set; }
  }
}
