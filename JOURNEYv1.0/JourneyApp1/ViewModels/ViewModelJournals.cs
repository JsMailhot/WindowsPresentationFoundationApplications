using JourneyApp1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyApp1.ViewModels
{
    public class ViewModelJournals : ViewModelBase
    {
        #region private variables
        private Journal _tempJournal;
        private List<Journal> _journals;
        #endregion
        #region public variables
        public Journal tempJournal { get { return _tempJournal; } set { SetProperty(ref _tempJournal, value); } }
        public List<Journal> journals { get { return _journals; } set { SetProperty(ref _journals, value); } }
        #endregion
        public ViewModelJournals()
        {
            title = "Journey App | Journals";
        }
        public ViewModelJournals(ViewModelBase input)
        {
            first = input.first;
            last = input.last;
            name = input.name;
            pass = input.pass;
            user = input.user;
            title = "Journey App | Journals";
            editUserButton = input.editUserButton;
            editUserText = input.editUserText;
        }
        public ViewModelJournals(ViewModelJournals input)
        {
            first = input.first;
            last = input.last;
            name = input.name;
            pass = input.pass;
            user = input.user;
            title = "Journey App | Journals";
            editUserButton = input.editUserButton;
            editUserText = input.editUserText;
            tempJournal = input.tempJournal;
            journals = input.journals;
        }
    }
}
