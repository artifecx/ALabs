using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALabs.LessonNFA
{
    public class Question
    {
        public string QuestionText { get; }
        public bool CorrectAnswer { get; }


        public Question(string questionText, bool correctAnswer)
        {
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
        }
    }
}
