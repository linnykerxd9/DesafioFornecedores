using System.Collections.Generic;
using AutoMapper;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Notifier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFornecedores.WebApp.Extensions
{
    [Authorize]
    public class MainController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly INotificationService _notificationService;

        public MainController(IMapper mapper, INotificationService notificationService)
        {
            _mapper = mapper;
            _notificationService = notificationService;
        }

        protected bool OperationValid(){
            return _notificationService.HAsError();
        }
    }
}