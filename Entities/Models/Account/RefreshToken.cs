// <copyright file="RefreshToken.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Models.Account
{
  /// <summary>
  /// Refresh token, is used to become a new token.
  /// </summary>
  public class RefreshToken
  {
    /// <summary>
    /// Holt oder setzt eindeutige Id.
    /// </summary>
    [Key]
    [JsonIgnore]
    public int Id { get; set; }

    /// <summary>
    /// Holt oder setzt Refresh Token.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Holt oder setzt Datum und Uhrzeit wann das Token abläuft.
    /// </summary>
    public DateTime Expires { get; set; }

    /// <summary>
    /// Holt Zustandt Token abgelaufen.
    /// </summary>
    public bool IsExpired => DateTime.UtcNow >= Expires;

    /// <summary>
    /// Holt oder setzt Entstehungszeit des Tokens.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Holt oder setzt Ip von der das Token angefordert wurde
    /// </summary>
    public string CreatedByIp { get; set; }

    /// <summary>
    /// Holt oder setzt Zeit en der das Token neu angefordert wurde.
    /// </summary>
    public DateTime? Revoked { get; set; }

    /// <summary>
    /// Holt oder setzt Ip von der das Token neu angefordert wurde.
    /// </summary>
    public string RevokedByIp { get; set; }

    /// <summary>
    /// Get or set Replaced by token.
    /// </summary>
    public string ReplacedByToken { get; set; }

    /// <summary>
    /// Holt refresh Token Ist Aktiv oder abgelaufen.
    /// </summary>
    public bool IsActive => Revoked == null && !IsExpired;

    /// <summary>
    /// Get or set user id.
    /// </summary>
    public Guid UserId { get; set; }

    // Navigation Property

    public virtual User User { get; set; }
  }
}
