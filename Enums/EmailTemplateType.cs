// <copyright file="EmailTemplate.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

namespace Enums
{
  /// <summary>
  /// Type of email to be sent. Is used to provide the correct set of variables.
  /// </summary>
  public enum EmailTemplateType
  {
    /// <summary>
    /// Register confirm email.
    /// </summary>
    Register = 0,

    /// <summary>
    /// Passwort reset email.
    /// </summary>
    PasswortReset = 1
  }
}
