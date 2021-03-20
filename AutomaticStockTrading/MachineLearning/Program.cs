using IronPython.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using MachineLearning.Script.ModelBuild;

namespace MachineLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            var myModel = new LiniarRegression();
            myModel.Run();

        }
        
        
    }
}