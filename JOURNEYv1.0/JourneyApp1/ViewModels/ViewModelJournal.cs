using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyApp1.ViewModels
{
    public class ViewModelJournal : ViewModelBase
    {
        #region private variables
        private string _journalName;
        private string _journalTextString;
        #endregion
        #region public variables
        public string journalName { get { return _journalName; } set { SetProperty(ref _journalName, value); } }
        public string journalTextString { get { return _journalTextString; } set { SetProperty(ref _journalTextString, value); } }
        #endregion
        public ViewModelJournal()
        {
            title = "Journey App | Journal";
        }
        public ViewModelJournal(ViewModelBase input)
        {
            first = input.first;
            last = input.last;
            name = input.name;
            pass = input.pass;
            user = input.user;
            title = "Journey App | Journal";
            editUserButton = input.editUserButton;
            editUserText = input.editUserText;
        }
        public ViewModelJournal(ViewModelJournal input)
        {
            first = input.first;
            last = input.last;
            name = input.name;
            pass = input.pass;
            user = input.user;
            title = "Journey App | Journal";
            editUserButton = input.editUserButton;
            editUserText = input.editUserText;
            journalName = input.journalName;
            journalTextString = input.journalTextString;
        }
    }
}
