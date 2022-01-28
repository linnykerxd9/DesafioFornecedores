using System.Collections.Generic;
using System.Linq;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Notifier;

namespace DesafioFornecedores.Infra.Services
{
    public class NotificationService : INotificationService
    {
        private List<Notification> _errors = new List<Notification>();

        public void AddError(string erro)
        {
            _errors.Add(new Notification(erro));
        }

        public IEnumerable<Notification> AllError()
        {
            return _errors;
        }

        public bool HAsError()
        {
            return _errors.Any();
        }
    }
}