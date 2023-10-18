using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Xml.Linq;
using System.Collections;
using static RandomSelect.Program;
using System.Reflection.Metadata.Ecma335;

namespace RandomSelect
{
   

    internal class Program
    {
        public class Wordlist
        {
            public string Word { get; set; }
            public override string ToString()
           {
            return $"{Word}";
           }
        }


        public static void Main()
        {

            string json;
            List<Wordlist> allList = new List<Wordlist>() { };
            string option;
            int optionN;
            bool listShow = false;
            string choose;
            // 선택할때 쓰는 변수
            while (true)
            {
                Console.WriteLine("==============================================");
                Console.WriteLine("소재 랜덤 선택기");
                Console.WriteLine("==============================================");

                while (true)
                {
                    Console.WriteLine("단어 선택은 1, 문장 선택은 2, 판타지 단어는 3을 입력해주세요.");
                    Console.WriteLine("4를 입력하시면 단어 목록을 볼수있습니다.");
                    Console.WriteLine("종료하시려면 -1를 입력해주세요.");
                    option = Console.ReadLine();
                    if (!int.TryParse(option, out optionN) || (optionN > 3 && optionN < -1))
                    {
                        Console.WriteLine("잘못 입력 하셨습니다.\n");
                    }

                    else if (optionN == -1)
                    {
                        return;
                    }
                    else if (optionN < 5 && optionN > -1)
                    {

                        if (optionN == 1)
                        {
                            json = File.ReadAllText("word.json");
                            allList = JsonSerializer.Deserialize<List<Wordlist>>(json);
                            choose = "단어";
                            break;
                        }

                        else if (optionN == 2)
                        {

                            json = File.ReadAllText("sentence.json");
                            allList = JsonSerializer.Deserialize<List<Wordlist>>(json);
                            choose = "문장";
                            break;

                        }

                        else if (optionN == 3)
                        {
                            json = File.ReadAllText("fantasy.json");
                            allList = JsonSerializer.Deserialize<List<Wordlist>>(json);
                            choose = "판타지";
                            break;
                        }
                        else if (optionN == 4)
                        {
                            Console.WriteLine("==============================================");
                            Console.WriteLine("목록");
                            Console.WriteLine("==============================================");
                            listShow = true;

                        }

                    }

                }
                if (listShow == true)
                {
                    Console.WriteLine("==============================================");
                    Console.WriteLine(choose + "목록");
                    Console.WriteLine("==============================================");
                    ListShow(allList);
                }
                else
                {
                    Console.WriteLine("==============================================");
                    Console.WriteLine(choose + "랜덤 선택기");
                    Console.WriteLine("==============================================");
                    RandomChoose(allList);
                } 
                Console.WriteLine("다시 하시겠습니까?");
                Console.WriteLine("1.예 또는 아무키 입력시 종료");
               
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                {
                    listShow = false;
                }
                else
                {
                    return;
                }
            }

           

        }

        public static void RandomChoose(List<Wordlist> list)
        {


            //Console.WriteLine($"{Firstword + 1}" + list[Firstword]);
            Console.WriteLine("==============================================");
            Console.WriteLine("총 몇개의 단어를 뽑을지 정해주세요.");
            Console.WriteLine("총 리스트의 갯수는" + list.Count + "개 입니다. 이 숫자보다 작게 입력해주세요");
            Console.WriteLine("==============================================");
            string option = Console.ReadLine();
            if (!int.TryParse(option, out int amount) || (amount < -1)||amount>list.Count)
            {
                Console.WriteLine("잘못 입력 하셨습니다.\n");
            }

            else if (amount == -1)
            {
                return;
            }
            else if (amount > 0)
            {
                int[] WordNumber = RandomDraw(list.Count, amount);

                for (int i = 0; i < WordNumber.Length; i++)
                {

                    Console.WriteLine((WordNumber[i] + 1) + " : " + list[WordNumber[i]]);
                }
            }
        }
        // 숫자 뽑기
        public static int[] RandomDraw(int allAmount, int amount)
        {
            Random rand = new Random();
            int[] result = new int[amount];
            List<int> list = new List<int>();
            for (int i = 0; i < allAmount + 1; ++i)
            {
                list.Add(i);
            }

            for (int i = 0; i < amount; ++i)
            {
                int a = rand.Next(0, allAmount - i);
                result[i] = list[a];
                list.RemoveAt(a);
            }
            return result;
        }
        public static void ListShow(List<Wordlist> list)
        {
            for(int i=0; i < list.Count; i++)
            {
                Console.WriteLine((i+1) + " : " + list[i]);
            }
        }
     }
      
   
     
    }



   

