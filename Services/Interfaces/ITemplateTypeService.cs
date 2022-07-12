using Entities.Models.Settings.Email;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
  /// <summary>
  /// Service to manage template types in backend store.
  /// </summary>
  public interface ITemplateTypeService
  {
    /// <summary>
    /// Get all template types.
    /// </summary>
    /// <returns>The Task that represents asynchronous operation, containing list of template types.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<List<TemplateType>>> GetAll();

    /// <summary>
    /// Get one template type.
    /// </summary>
    /// <param name="templateId">Template type id.</param>
    /// <returns>The Task that represents asynchronous operation, containing one template type.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<TemplateType>> GetOne(int templateId);

    /// <summary>
    /// Create template type entity.
    /// </summary>
    /// <param name="templateType">Template type entity.</param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<TemplateType>> Create(TemplateType templateType);

    /// <summary>
    /// Create template type entitys.
    /// </summary>
    /// <param name="templateType"></param>
    /// <returns>The Task that represents asynchronous operation, containing some errors or success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<TemplateType>> CreateRange(List<TemplateType> templateTypes);

    /// <summary>
    /// Delete template type entity.
    /// </summary>
    /// <param name="id">Entity id.</param>
    /// <returns>The Task that represents asynchronous operation, containing task result.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    Task<Result<TemplateType>> Delete(int id);
  }
}
