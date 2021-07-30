using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class MoneyParts
    {

        private readonly List<double> Denominaciones = new List<double>() { 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200 };

        public List<List<double>> Build(double value)
        {


            List<List<double>> ListResult = new List<List<double>>();

            foreach (double item in Denominaciones)
            {
                List<double> result = new List<double>();
                double num = 0;

                if (value > item)
                {
                    while (value > num)
                    {
                        if (item < (value - num))
                        {
                            num += item;
                            result.Add(item);
                        }
                        else {
                            result.Add(value - num);
                            num += item;
                        }
                    }
                }
                else {
                    result.Add(value);
                    ListResult.Add(result);
                    break;
                }

                if (result.Count > 0)
                {
                    ListResult.Add(result);
                }
            }



            return ListResult;
        }
    }
}
