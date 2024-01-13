using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Final_App
{
    internal class Question
    {
        private string category {  get; set; }
        private string difficulty {  get; set; }
        private string spanish { get; set; }
        private string english { get; set; }
        public Question(string category, string difficulty, 
            string spanish, string english) 
        { 
            this.category = category;
            this.difficulty = difficulty;
            this.spanish = spanish;
            this.english = english;
        }

        public override string ToString() 
        {
            return $"{category} {difficulty} {spanish} {english}";
        }
    }
}
