using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyApp1.ViewModels
{
    public class ViewModelBase : ViewModelEvents
    {
        #region Private Variables
        /// <summary>
        /// Page Title ( Top Text )
        /// </summary>
        private string _title;
        /// <summary>
        /// User's First Name String
        /// </summary>
        private string _first;
        /// <summary>
        /// User's Last Name String
        /// </summary>
        private string _last;
        /// <summary>
        /// User's Full Name String
        /// </summary>
        private string _name;
        /// <summary>
        /// User's Password String
        /// </summary>
        private string _pass;
        /// <summary>
        /// User's Login String
        /// </summary>
        private string _user;
        /// <summary>
        /// Visibility of User Login Buttons
        /// </summary>
        private Visibility _editUserButton;
        /// <summary>
        /// Visibility of User Login Textboxes
        /// </summary>
        private Visibility _editUserText;
        #endregion
        #region Public Variables
        /// <summary>
        /// Contains the properly capitalized First Name String
        /// </summary>
        public string first
        {
            get => CheckCaps(_first);
            set => SetProperty(ref _first, value);
        }
        /// <summary>
        /// Contains the properly capitalized Last Name String
        /// </summary>
        public string last
        {
            get => CheckCaps(_last);
            set => SetProperty(ref _last, value);
        }
        /// <summary>
        /// Contains the properly capitalized Full Name String
        /// </summary>
        public string name
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(first))
                    {
                        _name = first;
                        if (!string.IsNullOrEmpty(last))
                            _name += " " + last;
                    }
                    else if (!string.IsNullOrEmpty(last))
                        _name = last;
                    else
                        return "";
                    return _name;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    string output = value;
                    if (!string.IsNullOrEmpty(output))
                    {
                        if (output.Contains(" "))
                        {
                            first = output.Split(' ')[0];
                            last = output.Split(' ')[1];
                            if (!string.IsNullOrEmpty(first))
                            {
                                output = first;
                                if (!string.IsNullOrEmpty(last))
                                    output = first + " " + last;
                            }
                            else if (!string.IsNullOrEmpty(last))
                            {
                                output = last;
                            }
                        }
                        else
                        {
                            first = output;
                            last = "";
                        }
                    }
                    SetProperty(ref _name, output);
                }
                catch
                {
                    first = null;
                    last = null;
                    SetProperty(ref _name, "");
                }
            }
        }
        /// <summary>
        /// Contains the Password String
        /// </summary>
        public string pass
        {
            get => _pass;
            set => SetProperty(ref _pass, value);
        }
        /// <summary>
        /// Contains the User Login String
        /// </summary>
        public string user
        {
            get
            {
                try
                {
                    _user = name + "," + pass;
                    return _user;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    name = value.Split(',')[0];
                    pass = value.Split(',')[1];
                    SetProperty(ref _user, name + "," + pass);
                }
                catch
                {
                    name = null;
                    pass = null;
                    SetProperty(ref _user, null);
                }
            }
        }
        /// <summary>
        /// Contains the Page Title String
        /// </summary>
        public string title
        {
            get
            {
                try
                {
                    return _title;
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    SetProperty(ref _title, value);
                }
                catch
                {
                    SetProperty(ref _title, null);
                }
            }
        }
        /// <summary>
        /// Contains the User Login Buttons
        /// </summary>
        public Visibility editUserButton
        {
            get
            {
                try
                {
                    return _editUserButton;
                }
                catch
                {
                    return Visibility.Collapsed;
                }
            }
            set
            {
                try
                {
                    SetProperty(ref _editUserButton, value);
                }
                catch
                {
                    SetProperty(ref _editUserButton, Visibility.Collapsed);
                }
            }
        }
        /// <summary>
        /// Contains the User Login TextBoxes
        /// </summary>
        public Visibility editUserText
        {
            get
            {
                try
                {
                    return _editUserText;
                }
                catch
                {
                    return Visibility.Collapsed;
                }
            }
            set
            {
                try
                {
                    SetProperty(ref _editUserText, value);
                }
                catch
                {
                    SetProperty(ref _editUserText, Visibility.Collapsed);
                }
            }
        }
        #endregion
        public ViewModelBase(ViewModelBase input)
        {
            first = input.first;
            last = input.last;
            name = input.name;
            pass = input.pass;
            user = input.user;
            title = "Journey App";
            editUserButton = input.editUserButton;
            editUserText = input.editUserText;
        }
        public ViewModelBase()
        {
            first = "";
            last = "";
            name = "";
            pass = "";
            user = "";
            title = "";
            editUserButton = Visibility.Visible;
            editUserText = Visibility.Collapsed;
        }
        /// <summary>
        /// Capitalizes first character of string input
        /// </summary>
        /// <param name="input"></param>
        /// <returns>String with the first character capitalized and the rest lowercased</returns>
        /// <example>First or Last Name Capitalization "John Smith, Carol Smith"</example>
        private string CheckCaps(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    return null;
                }
                return char.ToUpper(input[0]) + input.Substring(1).ToLower();

            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Validates Input String Against User Login String
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Status of User Login Validation</returns>
        public bool ValidateUser(string input)
        {
            if (input.Equals(user))
                return true;
            else
                return false;
        }
        /// <summary>
        /// Toggles Validate User State
        /// </summary>
        public void ToggleValidateUserVisibility()
        {
            if (editUserButton == Visibility.Collapsed)
            {
                editUserButton = Visibility.Visible;
                editUserText = Visibility.Collapsed;
            }
            else
            {
                editUserButton = Visibility.Collapsed;
                editUserText = Visibility.Visible;
            }
        }
    }
}
