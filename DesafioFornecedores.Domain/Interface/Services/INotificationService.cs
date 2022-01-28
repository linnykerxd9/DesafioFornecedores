using System.Collections.Generic;
using DesafioFornecedores.Domain.Notifier;

namespace DesafioFornecedores.Domain.Interface.Services
{
    public interface INotificationService
    {
        void AddError(string erro);
        bool HAsError();
        IEnumerable<Notification> AllError();
    }
}