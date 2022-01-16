// <copyright file="ApplicationClaimsService.cs" company="GrilleGustav">
// Copyright (c) GrilleGustav. All rights reserved.
// </copyright>
using Models;
using Models.Response.Role;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  /// <summary>
  /// Application claims service.
  /// </summary>
  public class ApplicationClaimsService : IApplicationClaimsService
  {

    public ApplicationClaimsService()
    {
      this.InitialAddClaims();
    }
    /// <summary>
    /// Get or set application claims.
    /// </summary>
    private List<ApplicationClaim> ApplicationClaims { get; set; } = new List<ApplicationClaim>();

    /// <summary>
    /// Add application claim.
    /// </summary>
    /// <param name="applicationClaim">Application claim.</param>
    public void AddClaim(ApplicationClaim applicationClaim)
    {
      ApplicationClaims.Add(applicationClaim);
    }

    /// <summary>
    /// Add application claim.
    /// </summary>
    /// <param name="claimValue">Claim value.</param>
    /// <param name="displayGroup">Display group.</param>
    public void AddClaim(string claimValue, string displayGroup)
    {
      ApplicationClaims.Add(new ApplicationClaim() { ClaimValue = claimValue, DisplayGroup = displayGroup });
    }

    /// <summary>
    /// Get application claims.
    /// </summary>
    /// <returns>Application claims.</returns>
    public List<ApplicationClaim> GetClaims()
    {
      return this.ApplicationClaims;
    }

    /// <summary>
    /// Get application claims grouped by display group.
    /// </summary>
    /// <returns>Application claims grouped by display group.</returns>
    public ApplicationClaimsResponse GetClaimsGroupedBy()
    {
      return new ApplicationClaimsResponse(this.ApplicationClaims.GroupBy(x => x.DisplayGroup).ToDictionary(x => x.Key));
    }

    private void InitialAddClaims()
    {
      this.AddClaim("View", "General");
      this.AddClaim("Create", "General");
      this.AddClaim("Update", "General");
      this.AddClaim("Delete", "General");
      this.AddClaim("Administrator", "General");
      this.AddClaim("User", "General");
      this.AddClaim("EmailServerView", "Email");
      this.AddClaim("EmailServerCreate", "Email");
      this.AddClaim("EmailServerUpdate", "Email");
      this.AddClaim("EmailServerDelete", "Email");
      this.AddClaim("EmailTemplateView", "Email");
      this.AddClaim("EmailTemplateUpdate", "Email");
      this.AddClaim("EmailTemplateDelete", "Email");
      this.AddClaim("EmailMessagesView", "Email");
      this.AddClaim("UserView", "UserSettings");
      this.AddClaim("UserCreate", "UserSettings");
      this.AddClaim("UserUpdate", "UserSettings");
      this.AddClaim("UserDelete", "UserSettings");
      this.AddClaim("UserRoleAdd", "UserSettings");
      this.AddClaim("UserRoleUpdate", "UserSettings");
      this.AddClaim("UserClaimUpdate", "UserSettings");
      this.AddClaim("RoleView", "RoleSettings");
      this.AddClaim("RoleCreate", "RoleSettings");
      this.AddClaim("RoleUpdate", "RoleSettings");
      this.AddClaim("RoleDelete", "RoleSettings");
    }
  }
}
