using App.Services.Test1.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.Test1
{
    public interface ITest1Serivice
    {
        string GetValue(int id);
        void AddTest1(Test1DTO test1);
    }
}
