using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelper.Services
{
    public interface IDialog
    {
        public void ShowAsync(string title, string message);
        public Task<bool> AskAsync(string title, string message, string accept, string cancel);
    }
}
