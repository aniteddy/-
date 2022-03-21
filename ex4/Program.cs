using System;
using System.Collections.Generic;
using System.Linq;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeraspr = Console.ReadLine();
            double summa = Convert.ToDouble(Console.ReadLine());
            double[] numbers = Console.ReadLine().Split(';').Select(double.Parse).ToArray();

            //общая сумма сумм
            double total = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                //сумма сумм
                total = total + numbers[i];
            }
            //лист для записи результатов
            List <double> result = new List <double>();

            switch (typeraspr)
            {
                case "ПРОП":

                    //обрабатывается каждый элемент массива введённых сумм
                    for (int i=0; i < numbers.Length; i++)
                    {
                        double ostatok = summa - result.Sum();
                        //коэффициент на который надо умножить элемент из введённых сумм
                        double koef = summa / total;
                        double sumres = Math.Round(koef * numbers[i], 2);

                        //если остаток больше чем пропорция от общей суммы
                        if (ostatok > sumres)
                        {
                            //добавить в лист сумму
                            result.Add(sumres);
                        }

                        //если элемент последний обработан и есть остаток, то добавить его к последнему элементу
                        if ((ostatok < sumres) || (i==numbers.Length-1))
                        {
                            double ostatoklast = summa - result.Sum();
                            result[result.Count-1] = Math.Round(result[result.Count-1] + ostatoklast, 2);
                        }
                        
                    }
                    Console.WriteLine("Выход: "+ String.Join(";", result.ToArray()));
                    
                    break;

                case "ПЕРВ":

                    //обрабатывается каждый элемент массива введённых сумм
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        //остаток от суммы
                        double ostatok = summa - result.Sum();
                        //если есть остаток и он больше или равен элементу суммы,
                        //то добавить в результат полную сумму этого элемента
                        //иначе добавить в результат остаток
                        if ((ostatok > 0) && (ostatok >= numbers[i]))
                        {
                            result.Add(Math.Round(numbers[i],2));
                        }
                        else
                        {
                            result.Add(Math.Round(ostatok, 2));
                        }
                    }
                    Console.WriteLine("Выход: " + String.Join(";", result.ToArray()));

                    break;
                case "ПОСЛ":
                    //изменить порядок элементов массива на обратный
                    Array.Reverse(numbers);
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        //остаток от суммы
                        double ostatok = summa - result.Sum();
                        //если есть остаток и он больше или равен элементу суммы,
                        //то добавить в результат полную сумму этого элемента
                        //иначе добавить в результат остаток
                        if ((ostatok > 0) && (ostatok >= numbers[i]))
                        {
                            result.Add(Math.Round(numbers[i], 2));
                        }
                        else
                        {
                            result.Add(Math.Round(ostatok, 2));
                        }
                    }

                    //изменить порядок элементов коллекции на обратный
                    result.Reverse();
                    Console.WriteLine("Выход: " + String.Join(";", result.ToArray()));

                    break;
                default:
                    Console.WriteLine("Неверный тип распределения");
                    break;
            }
            
        }
    }
}
