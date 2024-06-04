using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonWebApp.Infrastructure.Services
{
    public interface IMailService
    {
        Task<bool> SendAsync(string to  , string subject , string body , bool isHTML = true);
    }
}
