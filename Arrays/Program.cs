﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
            static void Main(string[] args)
            {
                //создание и вывод массива
                Console.WriteLine("Массив целых чисел, выбранных рандомно:");
                int[] Array = new int[6];                                  //Инициализация массива
                Random RandArr = new Random();                             //Массив будет создан благодаря рандомному набору чисел


                for (int i = 0; i < Array.Length; i++)                     //Цикл, первая итерация 0. Итераций нужно не более длины массива. Приращение на 1
                {
                    Array[i] = RandArr.Next(1, 50);                        //Определяем диапазон значений для рандома, вносим случайное значение в массив за 1 итерацию
                    Console.Write(Array[i] + " ");                         //Выводим значения массива в строку на экран
                }
            
                //сортировки массива
                SortByDesc(Array);                                          //Вызываем сортировку массива по убыванию
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Отсортированный массив чисел по убыванию:");

                for (int i = 0; i < Array.Length; i++)                     //Цикл, первая итерация 0. Итераций нужно не более длины массива. Приращение на 1    
                    Console.Write(Array[i] + " ");                         //Выводим значения массива в строку на экран


                SortByAsc(Array);                                          //Вызываем сортировку массива по возрастанию
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Отсортированный массив чисел по возрастанию:");

                for (int i = 0; i < Array.Length; i++)                     //Цикл, первая итерация 0. Итераций нужно не более длины массива. Приращение на 1
                    Console.Write(Array[i] + " ");                         //Выводим значения массива в строку на экран

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Для завершения работы нажмите любую клавишу:");
                Console.ReadKey();
            }           
            
        //сортировка массива по убыванию
            static int[] SortByDesc(int[] Array)
             {         
                for (int i = 0; i < Array.Length; i++)                      //Цикл, первая итерация 0. Итераций нужно не более длины массива. Приращение на 1
                { 
                    for (int j = 0; j < Array.Length - 1; j++)              //Цикл,первая итерация j = 0. Итераций нужно не более длины массива - 1 (последнее число не придется проверять). Приращение на 1
                    {
                        if (Array[j] < Array[j + 1])                        //Если значение элемента массива под индексом j меньше значения элемента массива под индексом j+1 (следующего), то...
                        {
                            int b = Array[j];                               //b будет хранить полученное значение элемента массива под индексом j 
                            Array[j] = Array[j + 1];                        //Значение элемента массива под индексом j займет место значение элемента массива под индексом j+1 (следующее)
                            Array[j + 1] = b;                               //b получает значение элемента массива под индексом j+1 и продолжается сравнение с рядом стоящим числом
                        }
                    }
                }
                return Array;
            }

            //сортировка массива по возрастанию
            static int[] SortByAsc(int[] Array)
            {
                for (int i = 0; i < Array.Length; i++)                      //Цикл, первая итерация 0. Итераций нужно не более длины массива. Приращение на 1
                {
                    for (int j = 0; j < Array.Length - 1; j++)              //Цикл,первая итерация j = 0. Итераций нужно не более длины массива - 1 (последнее число не придется проверять). Приращение на 1
                    {
                        if (Array[j] > Array[j + 1])                        //Если значение элемента массива под индексом j больше значения элемента массива под индексом j+1 (следующего), то...
                        {
                            int b = Array[j];                               //b будет хранить полученное значение элемента массива под индексом j 
                            Array[j] = Array[j + 1];                        //Значение элемента массива под индексом j займет место значение элемента массива под индексом j+1 (следующее)
                            Array[j + 1] = b;                               //b получает значение элемента массива под индексом j+1 и продолжается сравнение с рядом стоящим числом
                        }
                    }
                }
                return Array;
            }
            
        }
    }