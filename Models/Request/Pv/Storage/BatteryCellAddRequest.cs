// <copyright file=">BatteryCellAddRequest.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using Entities.Models.Pv.Storage;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Request.Pv.Storage
{
  /// <summary>
  /// Request for adding new battery cell.
  /// </summary>
  public class BatteryCellAddRequest
  {
    /// <summary>
    /// Production date.
    /// </summary>
    [Required]
    public DateTime ProductionDate { get; set; }

    /// <summary>
    /// Get or set voltage input measurement.
    /// </summary>
    [Required]
    public double VoltageInputMeasurement { get; set; }

    /// <summary>
    /// Get or set internal resistance.
    /// </summary>
    public double InternalResistance { get; set; }

    /// <summary>
    /// Get or set description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Traceabillity code.
    /// </summary>
    public string TraceabillityCode { get; set; }

    /// <summary>
    /// Get or set serial number of the same model produced on the same day.
    /// </summary>
    public string SerialNumber { get; set; }

    /// <summary>
    /// Get or set celltype id.
    /// </summary>
    public int CellTypeId { get; set; }

    /// <summary>
    /// Get or set production type id.
    /// </summary>
    public int ProductionTypeId { get; set; }

    /// <summary>
    /// Get or set vendor id.
    /// </summary>
    public int VendorId { get; set; }

    /// <summary>
    /// Get or set cell specification id.
    /// </summary>
    public int CellSpecificationId { get; set; }

    /// <summary>
    /// Get or set battery block id.
    /// </summary>
    public int BatteryBlockId { get; set; }

    /// <summary>
    /// Production address id.
    /// </summary>
    public int ProductionAddressId { get; set; }

  }
}
