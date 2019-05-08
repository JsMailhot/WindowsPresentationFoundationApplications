using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AnsweringMachine.Logic
{
    public class Machine : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
        #region private
        private string _screenText;
        private string _answer;
        private string _question;

        private List<string> objectiveAnswers;
        private List<string> subjectiveAnswers;
        private List<string> personalAnswers;
        private List<string> unknownAnswers;
        #endregion
        #region public
        public string screenText { get { return _screenText; } set { SetProperty(ref _screenText, value); } }
        public string answer { get { return _answer; } set { SetProperty(ref _answer, value); } }
        public string question { get { return _question; } set { SetProperty(ref _question, value); } }
        #endregion
        public Machine()
        {
            screenText = "Are you ready to gaze into The Answering Machine?";
            objectiveAnswers = new List<string>()
            {   /* when will this thing happen, where will this thing happen, why will this thing happen, how will this thing happen */
                "The answer is in the future, look forward to it.",
                "It already is, without reason or purpose",
                "It already is, that is all known about it."
            };
            subjectiveAnswers = new List<string>()
            {   /* Who is doing this thing, What is doing this thing, which subject is doing this thing */
                "They are the only one capable of understanding and responding.",
                "It is not them, but thyself."
            };
            personalAnswers = new List<string>()
            {   /* Does subject do this thing, did subject do this thing, do subject do this thing */
                "Doing so would prove affective.",
                "Yes.",
                "No."
            };
            unknownAnswers = new List<string>()
            {   /* No understandable response */
                "This is confusing, but nothing is impossible.",
                "This may be possible, probability is infinite."
            };
        }
        public void GenerateNew()
        {
            string tempA = "So you want to know, ";
            string tempQ = question.ToLower();
            while (tempQ.Contains("?"))
            {
                tempQ = tempQ.Remove(tempQ.IndexOf('?'), 1);
            }
            if (tempQ.Contains(" i ") && !tempQ.Contains("you"))
            {
                tempQ = tempQ.Replace(" i "," you ");
            }
            else if (tempQ.Contains("you") && !tempQ.Contains(" i "))
            {
                tempQ = tempQ.Replace("you", "The Answering Machine");
            }
            else if (tempQ.Contains(" i ") && tempQ.Contains("you"))
            {
                tempQ = tempQ.Replace("you", "T");
                tempQ = tempQ.Replace(" i ", " you ");
                tempQ = tempQ.Replace("T", "The Answering Machine");
            }
            if (tempQ.Contains("when") || tempQ.Contains("where") || tempQ.Contains("why") || tempQ.Contains("how"))
            {
                tempA += tempQ + "? ";
                answer = Response("Objective");
                tempA += answer;
            }
            else if (tempQ.Contains("who") || tempQ.Contains("what") || tempQ.Contains("which"))
            {
                tempA += tempQ + "? ";
                answer = Response("Subjective");
                tempA += answer;
            }
            else if (tempQ.Contains("does") || tempQ.Contains("did") || tempQ.Contains("do"))
            {
                tempQ = tempQ.Remove(0, (tempQ.Split(' ')[0].Length) + 1);
                tempA += "if ";
                if (tempQ.Contains("you") || tempQ.Contains("i") || tempQ.Contains("they") || tempQ.Contains("we"))
                {
                    tempA += tempQ.Split(' ')[0] + " ";
                    tempQ = tempQ.Remove(0, (tempQ.Split(' ')[0].Length) + 1);
                }
                tempA += tempQ + "? ";
                answer = Response("Personal");
                tempA += answer;
            }
            else
            {
                tempA += tempQ + "? ";
                answer = Response("Unknown");
                tempA += answer;
            }
            screenText = tempA;
        }
        private string Response(string type)
        {
            Random rng = new Random();
            string output = "";
            if (type.ToLower() == "personal")
            {
                output = personalAnswers[rng.Next(0,personalAnswers.Count)];
            }
            else if (type.ToLower() == "objective")
            {
                output = objectiveAnswers[rng.Next(0, objectiveAnswers.Count)];
            }
            else if (type.ToLower() == "subjective")
            {
                output = subjectiveAnswers[rng.Next(0, subjectiveAnswers.Count)];
            }
            else if (type.ToLower() == "unknown")
            {
                output = unknownAnswers[rng.Next(0, unknownAnswers.Count)];
            }
            return output;
        }
    }
}
