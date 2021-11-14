using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Response.Role
{
  /// <summary>
  /// Response object to return application claims.
  /// </summary>
  public class ApplicationClaimsResponse : ErrorResponse
  {
    /// <summary>
    /// New Instance.
    /// </summary>
    public ApplicationClaimsResponse()
    { }

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="applicationClaims"></param>
    //public ApplicationClaimsResponse(Dictionary<string, IGrouping<string, ApplicationClaim>> applicationClaims)
    //{
    //  this.ApplicationClaims = applicationClaims;
    //  this.IsSuccess = true;
    //}

    //public Dictionary<string, IGrouping<string, ApplicationClaim>> ApplicationClaims { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationClaims"></param>
    public ApplicationClaimsResponse(Dictionary<string, IGrouping<string, ApplicationClaim>> applicationClaims)
    {
      this.ApplicationClaims = applicationClaims;
      this.IsSuccess = true;
    }

    public Dictionary<string, IGrouping<string, ApplicationClaim>> ApplicationClaims { get; set; }
  }
}
