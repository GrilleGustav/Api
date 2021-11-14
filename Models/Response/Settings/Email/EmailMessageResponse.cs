using Entities.Models.Email;
using Models.View.Settings.Email;
using System.Collections.Generic;

namespace Models.Response.Settings.Email
{
  public class EmailMessageResponse : ErrorResponse
  {
    /// <summary>
    /// Email message response.
    /// </summary>
    public EmailMessageResponse()
    { }

    /// <summary>
    /// Set email messages.
    /// </summary>
    /// <param name="emailMessages">List of email messages.</param>
    public EmailMessageResponse(List<EmailMessageViewModel> emailMessages)
    {
      this.EmailMessages = emailMessages;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Set errors.
    /// </summary>
    /// <param name="errors"></param>
    public EmailMessageResponse(List<Error> errors)
    {
      this.Errors = errors;
    }

    /// <summary>
    /// Get or set emial messages.
    /// </summary>
    public List<EmailMessageViewModel> EmailMessages { get; set; }
  }
}
