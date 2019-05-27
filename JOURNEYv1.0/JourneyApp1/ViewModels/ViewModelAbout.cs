using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyApp1.ViewModels
{
    public class ViewModelAbout : ViewModelBase
    {
        public ViewModelAbout()
        {
            title = "Journey App | About";
        }
        public ViewModelAbout(ViewModelBase input)
        {
            first = input.first;
            last = input.last;
            name = input.name;
            pass = input.pass;
            user = input.user;
            title = "Journey App | About";
            editUserButton = input.editUserButton;
            editUserText = input.editUserText;
        }
    }
}
