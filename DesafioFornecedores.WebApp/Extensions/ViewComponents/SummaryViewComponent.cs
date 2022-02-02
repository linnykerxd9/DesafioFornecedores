using System.Linq;
using DesafioFornecedores.Domain.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFornecedores.WebApp.Extensions.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public SummaryViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke(){
           var result = _notificationService.AllError().Select(x => x.Erro).ToList();
            result.ForEach(x => ModelState.AddModelError(string.Empty, x));
            return View(result);
        }
    }
}