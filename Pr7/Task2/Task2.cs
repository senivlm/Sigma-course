using System;
using System.Collections.Generic;
using System.Text;

namespace Pr7
{
    class Task2
    {
        public static List<string> GetList(Menu menu, PriceList priceList)
        {
            var resultList = new List<string>();
            var kvp = new KeyValuePair<string, double>();
            var repetitionTimes = 1;

            //TODO Think how to change kvp

            for (var i = 0; i < menu._components.Capacity - 1; i++)
            {
                if (!resultList.Contains(menu._components[i].Name))
                {
                    resultList.Add(menu._components[i].Name + " " + menu._components[i].Weight + " " +
                                   kvp.Value * menu._components[i].Weight + "\n");
                }
                else
                {
                    repetitionTimes++;
                    var repeatedName = resultList.Find(x => x.Contains(menu._components[i].Name));
                    repeatedName.Replace(repeatedName,
                        menu._components[i].Name + " " + menu._components[i].Weight * repetitionTimes + " " +
                        kvp.Value * menu._components[i].Weight * repetitionTimes + "\n");
                }
            }

            return resultList;
        }
    }
}
