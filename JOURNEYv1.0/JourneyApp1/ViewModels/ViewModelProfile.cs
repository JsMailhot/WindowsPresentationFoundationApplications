using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyApp1.ViewModels
{
    public class ViewModelProfile : ViewModelBase
    {
        #region private variables
        #endregion
        #region public variables
        #endregion
        public ViewModelProfile()
        {
            title = "Journey App | Profile";
        }
        public ViewModelProfile(ViewModelBase input)
        {
            first = input.first;
            last = input.last;
            name = input.name;
            pass = input.pass;
            user = input.user;
            title = "Journey App | Profile";
            editUserButton = input.editUserButton;
            editUserText = input.editUserText;
        }
        public ViewModelProfile(ViewModelProfile input)
        {
            first = input.first;
            last = input.last;
            name = input.name;
            pass = input.pass;
            user = input.user;
            title = "Journey App | Profile";
            editUserButton = input.editUserButton;
            editUserText = input.editUserText;
        }
    }
}
