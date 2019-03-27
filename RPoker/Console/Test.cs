using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Model.Cards;

namespace Console
{
    class Test
    {
        public void Test_1()
        {

            var Player_1 = new List<Card>();
            var Table = new List<Card>();
            var tmpDeck = new List<string>();
            var TableWithOutFlashRoyal = new List<string>();
            Random rnd = new Random();
            bool f = false;
            int k = 0;
            string[] pwdRanc = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] pwdSuit = new string[4] { "C", "D", "H", "S" };
            string[] FlashRoyal = new string[5] { "C10", "CJ", "CQ", "CK", "CA" };

            string str;

            for (var i = 0; i < 4; i++)
                for (var j = 0; j < 13; j++)
                {
                    str = pwdSuit[i] + pwdRanc[j];
                    tmpDeck.Add(str);

                }

            TableWithOutFlashRoyal.AddRange(tmpDeck);

            for (int i = 0; i < 5; i++)
            {
                var find = TableWithOutFlashRoyal.FindIndex(tmp => tmp == FlashRoyal[i]);
                TableWithOutFlashRoyal.RemoveAt(find);
            }
            foreach (var CurCard in FlashRoyal)
                Table.Add(Card.Get(CurCard));

            StreamWriter sw = new StreamWriter("OutPut.txt", false, System.Text.Encoding.Default);

            foreach (var FirstCard in TableWithOutFlashRoyal)
            {
                foreach (var SecondCard in TableWithOutFlashRoyal)
                {
                    if (FirstCard == SecondCard)
                        continue;
                    Player_1.Clear();
                    Player_1.Add(Card.Get(FirstCard));
                    Player_1.Add(Card.Get(SecondCard));

                    Combination combination = CombinationChecker.DetermineCombination(Player_1, Table);

                    {
                        if (combination != Combination.RoyalFlush)
                        {
                            sw.WriteLine(combination);
                            sw.WriteLine("Player card :" + Player_1[0].ToString() + " " + Player_1[1].ToString());
                            sw.WriteLine("Table card :" + Table[0].ToString() + " " + Table[1].ToString() + " " + Table[2].ToString() + " " + Table[3].ToString() + " " + Table[4].ToString());
                        }

                    };
                }
            }
        }

        public void Test_2()
        {
            var myCard = new Card(CardSuit.Club, CardRank.Two);
            using (StreamWriter sw_1 = new StreamWriter("OutPut_2.txt", false, System.Text.Encoding.Default))
            {
                sw_1.WriteLine(myCard.ToString());
            };
        }

        public void swap(List<int> a, int i, int j)
        {
            int s = a[i];
            a[i] = a[j];
            a[j] = s;
        }

        public bool NextSet(List<int> a, int n)
        {

            int j = n - 2;
            while (j != -1 && a[j] >= a[j + 1]) j--;
            if (j == -1)
                return false; // больше перестановок нет
            int k = n - 1;
            while (a[j] >= a[k]) k--;
            swap(a, j, k);
            int l = j + 1, r = n - 1; // сортируем оставшуюся часть последовательности
            while (l < r)
                swap(a, l++, r--);
            return true;
        }

        public void Test_3()
        {
            var Player_1 = new List<Card>();
            var Table = new List<Card>();
            var num = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
            var tmpDeck = new List<string>() { "CJ", "HJ", "SA", "D2", "H7", "C3", "C5" };
            var tmpDeck_1 = new List<string>();
            using (StreamWriter sw_1 = new StreamWriter("OutPut_3.txt", false, System.Text.Encoding.Default))
            {
                while (NextSet(num, num.Count))
                {
                    tmpDeck_1.Clear();
                    Player_1.Clear();
                    Table.Clear();
                    foreach (var item in num)
                    {
                        tmpDeck_1.Add(tmpDeck[item]);
                    }
                    for (int i = 0; i < 2; i++)
                        Player_1.Add(Card.Get(tmpDeck_1[i]));
                    for (int i = 0; i < 5; i++)
                        Table.Add(Card.Get(tmpDeck_1[i + 2]));
                    Combination combination = CombinationChecker.DetermineCombination(Player_1, Table);
                    sw_1.WriteLine(combination);
                    sw_1.WriteLine("Player card :" + Player_1[0].ToString() + " " + Player_1[1].ToString());
                    sw_1.WriteLine("Table card :" + Table[0].ToString() + " " + Table[1].ToString() + " " + Table[2].ToString() + " " + Table[3].ToString() + " " + Table[4].ToString());

                }
            };
        }

        public void Test_4()
        {
            var Player_1 = new List<Card>();
            var Table = new List<Card>();
            var num = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
            var tmpDeck = new List<string>() { "S10", "DK", "SK", "C9", "H10", "D2", "C6" };
            var tmpDeck_1 = new List<string>();
            using (StreamWriter sw_1 = new StreamWriter("OutPut_4.txt", false, System.Text.Encoding.Default))
            {
                while (NextSet(num, num.Count))
                {
                    tmpDeck_1.Clear();
                    Player_1.Clear();
                    Table.Clear();
                    foreach (var item in num)
                    {
                        tmpDeck_1.Add(tmpDeck[item]);
                    }
                    for (int i = 0; i < 2; i++)
                        Player_1.Add(Card.Get(tmpDeck_1[i]));
                    for (int i = 0; i < 5; i++)
                        Table.Add(Card.Get(tmpDeck_1[i + 2]));
                    Combination combination = CombinationChecker.DetermineCombination(Player_1, Table);
                    sw_1.WriteLine(combination);
                    sw_1.WriteLine("Player card :" + Player_1[0].ToString() + " " + Player_1[1].ToString());
                    sw_1.WriteLine("Table card :" + Table[0].ToString() + " " + Table[1].ToString() + " " + Table[2].ToString() + " " + Table[3].ToString() + " " + Table[4].ToString());

                }
            };
        }

        public void Test_5()
        {
            var Player_1 = new List<Card>();
            var Table = new List<Card>();
            var num = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
            var tmpDeck = new List<string>() { "DJ", "CJ", "HJ", "S6", "HA", "C2", "C5" };
            var tmpDeck_1 = new List<string>();
            using (StreamWriter sw_1 = new StreamWriter("OutPut_5.txt", false, System.Text.Encoding.Default))
            {
                while (NextSet(num, num.Count))
                {
                    tmpDeck_1.Clear();
                    Player_1.Clear();
                    Table.Clear();
                    foreach (var item in num)
                    {
                        tmpDeck_1.Add(tmpDeck[item]);
                    }
                    for (int i = 0; i < 2; i++)
                        Player_1.Add(Card.Get(tmpDeck_1[i]));
                    for (int i = 0; i < 5; i++)
                        Table.Add(Card.Get(tmpDeck_1[i + 2]));
                    Combination combination = CombinationChecker.DetermineCombination(Player_1, Table);
                    sw_1.WriteLine(combination);
                    sw_1.WriteLine("Player card :" + Player_1[0].ToString() + " " + Player_1[1].ToString());
                    sw_1.WriteLine("Table card :" + Table[0].ToString() + " " + Table[1].ToString() + " " + Table[2].ToString() + " " + Table[3].ToString() + " " + Table[4].ToString());
                    //sw_1.WriteLine();
                }
            };
        }

        public void Test_6()
        {
            var Player_1 = new List<Card>();
            var Table = new List<Card>();
            var num = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
            var tmpDeck = new List<string>() { "C10", "HQ", "S8", "C9", "DJ", "H7", "S2" };
            var tmpDeck_1 = new List<string>();
            using (StreamWriter sw_1 = new StreamWriter("OutPut_6.txt", false, System.Text.Encoding.Default))
            {
                while (NextSet(num, num.Count))
                {
                    tmpDeck_1.Clear();
                    Player_1.Clear();
                    Table.Clear();
                    foreach (var item in num)
                    {
                        tmpDeck_1.Add(tmpDeck[item]);
                    }
                    for (int i = 0; i < 2; i++)
                        Player_1.Add(Card.Get(tmpDeck_1[i]));
                    for (int i = 0; i < 5; i++)
                        Table.Add(Card.Get(tmpDeck_1[i + 2]));
                    Combination combination = CombinationChecker.DetermineCombination(Player_1, Table);
                    //должна быть Стрит!
                    if (combination == Combination.Straight)
                    {
                        sw_1.WriteLine(combination);
                        sw_1.WriteLine("Player card :" + Player_1[0].ToString() + " " + Player_1[1].ToString());
                        sw_1.WriteLine("Table card :" + Table[0].ToString() + " " + Table[1].ToString() + " " + Table[2].ToString() + " " + Table[3].ToString() + " " + Table[4].ToString());
                    }
                }
            };
        }

        public void Test_7()
        {
            var Player_1 = new List<Card>();
            var Table = new List<Card>();
            var num = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };
            var tmpDeck = new List<string>() { "D3", "S6", "SA", "SK", "S10", "S7", "S5" };
            var tmpDeck_1 = new List<string>();
            using (StreamWriter sw_1 = new StreamWriter("OutPut_7.txt", false, System.Text.Encoding.Default))
            {
                while (NextSet(num, num.Count))
                {
                    tmpDeck_1.Clear();
                    Player_1.Clear();
                    Table.Clear();
                    foreach (var item in num)
                    {
                        tmpDeck_1.Add(tmpDeck[item]);
                    }
                    for (int i = 0; i < 2; i++)
                        Player_1.Add(Card.Get(tmpDeck_1[i]));
                    for (int i = 0; i < 5; i++)
                        Table.Add(Card.Get(tmpDeck_1[i + 2]));
                    Combination combination = CombinationChecker.DetermineCombination(Player_1, Table);

                    // {
                    sw_1.WriteLine(combination);
                    sw_1.WriteLine("Player card :" + Player_1[0].ToString() + " " + Player_1[1].ToString());
                    sw_1.WriteLine("Table card :" + Table[0].ToString() + " " + Table[1].ToString() + " " + Table[2].ToString() + " " + Table[3].ToString() + " " + Table[4].ToString());
                    // }
                }
            };
        }

    }
}
