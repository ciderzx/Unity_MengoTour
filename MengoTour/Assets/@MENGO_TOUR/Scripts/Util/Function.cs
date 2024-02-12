using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Util
{
    public struct Function
    {
        /// <param name="length">배열 총 길이</param>
        /// <param name="min">작은 수!</param>
        /// <param name="max">가장 큰 수!</param>
        public static int[] GetRandomInt(int length, int min, int max)
        {
            int[] randomArray = new int[length];
            bool isSame;

            for (int i = 0; i < length; ++i)
            {
                while (true)
                {
                    randomArray[i] = UnityEngine.Random.Range(min, max);
                    isSame = false;

                    for (int j = 0; j < i; ++j)
                    {
                        if (randomArray[j].Equals(randomArray[i]))
                        {
                            isSame = true;
                            break;
                        }
                    }
                    if (!isSame) break;
                }
            }
            return randomArray;
        }

        /// <param name="_array">정렬 할 정수 배열</param>
        public static int[] BubbleSort(int[] _array)
        {
            int hold = 0;
            int[] array = new int[_array.Length];
            Array.Copy(_array, array, _array.Length);

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        hold = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = hold;
                    }
                }
            }

            return array;
        }

        /// <param name="list">섞을 리스트 변수, ref로 넘겨줄 것</param>
        public static void ShuffleList<T>(ref List<T> list)
        {
            int random1;
            int random2;

            T tmp;

            for (int i = 0; i < list.Count; ++i)
            {
                random1 = UnityEngine.Random.Range(0, list.Count);
                random2 = UnityEngine.Random.Range(0, list.Count);

                tmp = list[random1];
                list[random1] = list[random2];
                list[random2] = tmp;
            }
        }

        /// <param name="array">섞을 배열 변수, ref로 넘겨줄 것</param>
        public static void ShuffleArray<T>(ref T[] array)
        {
            int random1;
            int random2;

            T tmp;

            for (int index = 0; index < array.Length; ++index)
            {
                random1 = UnityEngine.Random.Range(0, array.Length);
                random2 = UnityEngine.Random.Range(0, array.Length);

                tmp = array[random1];
                array[random1] = array[random2];
                array[random2] = tmp;
            }
        }

        /// <summary>
        /// Time Set
        /// </summary>
        /// <param name="second">Input Second</param>
        /// <returns></returns>
        public static string GetTime(int second)
        {
            int MIN = second / 60;
            int SEC = second % 60;

            string timeStr = string.Format("{0:00}:{1:00}", MIN, SEC);
            return timeStr;
        }
    }
}


