using System.Threading.Tasks;
using Luna.Commons.Communication.Models;

namespace Luna.Commons.Communication.Interfaces
{
    public interface IMailService
    {
        Task Send(Mail mail);
    }
}