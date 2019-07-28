using System;
using System.Collections.Generic;
using System.Text;
using App.Services.Test1.DTO;

namespace App.Services.Test1
{
    public class Test1Service : ITest1Serivice
    {
        public void AddTest1(Test1DTO test1)
        {
            
        }

        public string GetValue(int id)
        {
            return "value " + id.ToString();
        }
    }
}
