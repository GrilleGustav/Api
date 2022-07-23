using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
  /// <summary>
  /// Operation result object.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class Result<T>
  {
    /// <summary>
    /// Operation result object.
    /// </summary>
    public Result()
    {}

    /// <summary>
    /// Operation result object
    /// </summary>
    /// <param name="errors">List of errors.</param>
    public Result(List<Error> errors)
    {
      this.Errors = errors;
    }

    /// <summary>
    /// Operation result object.
    /// </summary>
    /// <param name="error">Error.</param>
    public Result(Error error)
    {
      this.AddError(error);
    }

    /// <summary>
    /// Operation result object.
    /// </summary>
    /// <param name="data">Data.</param>
    public Result(T data)
    {
      this.Data = data;
      this.IsSuccess = true;
    }

    /// <summary>
    /// Operation result object.
    /// </summary>
    /// <param name="isSuccess">Operation Succesfull.</param>
    public Result(bool isSuccess)
    {
      this.IsSuccess = isSuccess;
    }

    /// <summary>
    /// Get or set errors.
    /// </summary>
    public List<Error> Errors { get; private set; } = new List<Error>();
    
    /// <summary>
    /// Get or set operation succesfull.
    /// </summary>
    public bool IsSuccess { get; set; } = false;

    /// <summary>
    /// Result data.
    /// </summary>
    public T Data { get; private set; }

    /// <summary>
    /// Add error to list of errors.
    /// </summary>
    /// <param name="error">New error.</param>
    public void AddError(Error error)
    {
      this.Errors.Add(error);
    }

    /// <summary>
    /// Add error with error code, without message.
    /// </summary>
    /// <param name="errorCode">Error code.</param>
    public void AddError(string errorCode)
    {

      this.Errors.Add(new Error(errorCode: errorCode));
    }

    /// <summary>
    /// Add error with error code and message.
    /// </summary>
    /// <param name="errorCode">Error code.</param>
    /// <param name="errorMessage">Error message.</param>
    public void AddError(string errorCode, string errorMessage)
    {

      this.Errors.Add(new Error(errorCode: errorCode, errorMessage: errorMessage));
    }

    /// <summary>
    /// If some data needs to return, placed here.
    /// </summary>
    /// <param name="data">Data to return.</param>
    public void AddData(T data)
    {
      this.Data = data;
      this.IsSuccess = true;
    }

  }
}
