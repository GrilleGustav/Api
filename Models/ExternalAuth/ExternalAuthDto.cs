// <copyright file="ExternalAuthDto.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>

namespace Models.ExternalAuth
{
  public class ExternalAuthDto
  {
    public string Provider { get; set; }

    public string IdToken { get; set; }
  }
}
