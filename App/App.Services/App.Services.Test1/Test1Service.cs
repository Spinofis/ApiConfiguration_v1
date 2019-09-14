using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Services.Test1.DTO;
using EntityFrameworkModel.Models;

namespace App.Services.Test1
{
    public class Test1Service : ITest1Serivice
    {
        LearningContext context;

        Test1Service(LearningContext context)
        {
            this.context = context;
        }

        public List<CityDTO> GetCities()
        {
            var result = context.City
                .Select(
                    x => new CityDTO()
                    {
                        Id = x.Id,
                        Name = x.CityAscii
                    })
                    .ToList();

            return result;
        }

        public void AddTest1(Test1DTO test1)
        {

        }

        public string GetValue(int id)
        {
            return "value " + id.ToString();
        }
    }
}
