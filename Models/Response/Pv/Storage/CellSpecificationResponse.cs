// <copyright file="CellSpecificationResponse.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Models.View.Pv.Storage;

namespace Models.Response.Pv.Storage
{
  /// <summary>
  /// Cell specification response.
  /// </summary>
  public class CellSpecificationResponse : ErrorResponse
  {
    /// <summary>
    /// Cell specification response.
    /// </summary>
    public CellSpecificationResponse()
    { }

    /// <summary>
    /// Cell specification response.
    /// </summary>
    /// <param name="cellSpecification">Cell specification.</param>
    public CellSpecificationResponse(CellSpecificationViewModel cellSpecification)
    {
      CellSpecification = cellSpecification;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Get or set cell specification.
    /// </summary>
    public CellSpecificationViewModel CellSpecification { get; set; }
  }
}
