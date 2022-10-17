using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Fundamentals_Scott_Allen
{
    public class Book : Model //klases .net'e padeda apibrezti naujus referenc tipus
    {
        public string Name { get; set; } //<-- fields
        public int Id { get; set; }
        public Book(string name) //konstruktorius. 
        {
            grades = new List<double>();
            Name = name; //pirmas yra field antras parametr
        }
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break; 

            }
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0) //|| arba viena puse arba kita (and) abi puses and  (&&)
            {
                grades.Add(grade);

            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        
        }
        public Statistics GetStatistics() //noriu grazinti objekta/tipa statistika
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            //var index = 0;
            //while (index < grades.Count) //index bus trys o grades count 4 nes index skaiciuoja nuo 0 
            //{
            //    result.Low = Math.Min(grades[index], result.Low);
            //    result.High = Math.Max(grades[index], result.High);
            //    result.Average += grades[index];
            //    index++;
            //};

            for(var i=0; i< grades.Count; i++) //pirmine reiksme, kriterijus, ka atlikti kiekvienos iteracijos metu
            {
                //if (grades[i] == 42.1)
                //{
                //    break; //panaudojus breake isjungiame iteracijos loopa
                //}
                result.Low = Math.Min(grades[i], result.Low);
                result.High = Math.Max(grades[i], result.High);
                result.Average += grades[i];
               
            };
             
            result.Average /= grades.Count;
            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
          
                default:
                    result.Letter = 'F';
                    break;
            }
            return result;  
     
        }
        private List<double> grades;//field. tam kad butu field ir laikytu savo verte visoje programoje reikia rasyti ne metode
        //public string Name{get;set;} //-propertis

        
    }
}
