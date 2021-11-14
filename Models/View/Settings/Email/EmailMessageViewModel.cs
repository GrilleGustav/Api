using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View.Settings.Email
{
  public class EmailMessageViewModel
  {
    /// <summary>
    /// Get or set date email was send.
    /// </summary>
    public DateTime SendOn { get; set; }

    /// <summary>
    /// Get or set list of receiver separated by simicolon.
    /// </summary>
    public string Receiver { get; set; }

    /// <summary>
    /// Get or set sender.
    /// </summary>
    public string From { get; set; }

    /// <summary>
    /// Get or set subject.
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Get or set content.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Get or set if email already send.
    /// </summary>
    public bool IsSend { get; set; }

    EmailMessageViewModel()
    { }
  }
}
