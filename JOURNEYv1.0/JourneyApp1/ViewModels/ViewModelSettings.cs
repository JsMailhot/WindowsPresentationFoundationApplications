using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyApp1.ViewModels
{
    public class ViewModelSettings : ViewModelBase
    {
        #region private variables
        #endregion
        #region public variables
        #endregion
        public ViewModelSettings()
        {
            title = "Journey App | Settings";
        }
        public ViewModelSettings(ViewModelBase input)
        {
            first = input.first;
            last = input.last;
            name = input.name;
            pass = input.pass;
            user = input.user;
            title = "Journey App | Settings";
            editUserButton = input.editUserButton;
            editUserText = input.editUserText;
        }
        public ViewModelSettings(ViewModelSettings input)
        {
            first = input.first;
            last = input.last;
            name = input.name;
            pass = input.pass;
            user = input.user;
            title = "Journey App | Settings";
            editUserButton = input.editUserButton;
            editUserText = input.editUserText;
        }
    }
}
