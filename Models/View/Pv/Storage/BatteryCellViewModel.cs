// <copyright file="BatteryCellViewModel.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System;

namespace Models.View.Pv.Storage
{
  /// <summary>
  /// Battery cell view model.
  /// </summary>
  public class BatteryCellViewModel
  {
    /// <summary>
    /// Get or set Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Production date.
    /// </summary>
    public DateTime ProductionDate { get; set; }

    /// <summary>
    /// Get or set voltage input measurement.
    /// </summary>
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

    /// <summary>
    /// A DateTime value that should change whenever a role is persisted to the store.
    /// </summary>
    public DateTime ConcurrencyStamp { get; set; }

    /// <summary>
    /// A DateTime value that shows when record changed.
    /// </summary>
    public DateTime UpdatedOn { get; set; }

    /// <summary>
    /// A DateTime value that shows when record was created.
    /// </summary>
    public DateTime CreatedOn { get; set; }
  }
}
