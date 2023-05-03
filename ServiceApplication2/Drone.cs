using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.Primitives;

namespace ServiceApplication2
{
    // 6.1	Create a separate class file to hold the data items of the Drone. Use separate getter and setter methods,
    // ensure the attributes are private and the accessor methods are public. Add a display method that returns a string for Client Name and Service Cost.
    // Add suitable code to the Client Name and Service Problem accessor methods so the data is formatted as Title case or Sentence case.
    // Save the class as “Drone.cs”.
    class Drone
    {
        private string name;
        private string model;
        private string problem;
        private double cost;
        private int tag;

        public Drone() { }

        public Drone(string name, string model, string problem, double cost, int tag)
        {
            this.name = name;
            this.model = model;
            this.problem = problem;
            this.cost = cost;
            this.tag = tag;
        }

        public void setName(string name)
        {
            name = new System.Globalization.CultureInfo("en-US").TextInfo.ToTitleCase(name);
            this.name = name; 
        }

        public string getName() { return this.name; }

        public void setModel(string model) { this.model = model; }

        public string getModel() { return this.model;}

        public void setProblem(string problem) 
        {
            // capitalise the first letter of the sentence
            problem = problem.Substring(0, 1).ToUpper() + problem.Substring(1);
            // find the end of the sentence and lowercase the rest
            int end = problem.LastIndexOfAny(new char[] { '.', '!', '?' });
            if (end > -1 && end < problem.Length + 1) 
            {
                problem = problem.Substring(0, end + 1) + problem.Substring(end + 1).ToLower();
            }

            this.problem = problem;
        }

        public string getProblem() { return this.problem;}

        public void setCost(double cost) { this.cost = cost; }

        public double getCost() { return this.cost;}

        public void setTag(int tag) {  this.tag = tag; }

        public int getTag() { return this.tag;}
    }


}
