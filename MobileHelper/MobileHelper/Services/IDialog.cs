using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelper.Services
{
    public interface IDialog
    {
        Task ShowAsync(string title, string message);
    }
}
