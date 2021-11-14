using Models.Response.Settings.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  public interface IEmailMessageService
  {
    /// <summary>
    /// Get all email messages.
    /// </summary>
    /// <returns>List of messages.</returns>
    Task<EmailMessageResponse> GetAll();
  }
}
