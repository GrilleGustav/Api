using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Response
{
  public class EditorImageResponse
  {
    public EditorImageResponse(string url)
    {
      Url = url;
    }

    public string Url { get; set; }
  }
}
