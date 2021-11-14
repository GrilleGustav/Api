using AutoMapper;
using Contracts;
using Entities.Models.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Response.Settings.Email;
using Models.View.Settings.Email;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class EmailMessageService : IEmailMessageService
  {
    private readonly ILogger<EmailMessageService> _logger;
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public EmailMessageService(IRepositoryManager repository, ILogger<EmailMessageService> logger, IMapper mapper)
    {
      _repository = repository;
      _logger = logger;
      _mapper = mapper;
    }

    /// <summary>
    /// Get all email messages.
    /// </summary>
    /// <returns>List of messages.</returns>
    public async Task<EmailMessageResponse>  GetAll()
    {
      EmailMessageResponse emailMessageResponse = new EmailMessageResponse();
      try
      {
        return new EmailMessageResponse(_mapper.Map<List<EmailMessage>, List<EmailMessageViewModel>>(await _repository.EmailMessage.FindAll(false).ToListAsync()));
      }
      catch(Exception e)
      {
        _logger.LogError(e.Message);
        emailMessageResponse.AddError(errorCode: "1", errorMessage: e.Message);
        return emailMessageResponse;
      }
    }
  }
}
