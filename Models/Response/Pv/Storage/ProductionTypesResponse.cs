// <copyright file="ProductionTypesResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.View.Pv.Storage;
using System.Collections.Generic;

namespace Models.Response.Pv.Storage
{
  public class ProductionTypesResponse : ErrorResponse
  {
    /// <summary>
    /// Production types response.
    /// </summary>
    public ProductionTypesResponse()
    { }

    /// <summary>
    /// Production types response.
    /// </summary>
    /// <param name="productionType">Production type.</param>
    public ProductionTypesResponse(IList<ProductionTypeViewModel> productionTypes)
    {
      this.ProductionTypes = productionTypes;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set production types.
    /// </summary>
    public IList<ProductionTypeViewModel> ProductionTypes { get; set; }
  }
}
