using System;
using System.Collections.Generic;
using System.Text;
using TestModule1.Interfaces;

namespace TestModule1.Services
{
    public class Service1 : IService1
    {
        public Service1()
        {
        }

        public string GetString()
        {
            return "test";
        }
    }
}
