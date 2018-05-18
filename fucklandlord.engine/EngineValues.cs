using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fucklandlord.engine
{
    /// <summary>
    /// some constants used in engine
    /// </summary>
    public class EngineValues
    {
        /// <summary>
        /// 4 colors
        /// spades, hearts, diamonds, clubs
        /// </summary>
        public static List<String> CardColors = new List<string> {"S", "H", "D", "C" };

        /// <summary>
        /// 15 kinds of card without color
        /// 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace, 2, Little joker, Big joker
        /// </summary>
        public static List<String> CardValues = new List<string> {"3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A", "2", "LJ", "BJ" };

        /// <summary>
        /// return all cards with color in the game
        /// 3*S 3*H 3*D 3*C 4*S 4*H 4*D 4*C 5*S 5*H 5*D 5*C  ... 2*S 2*H 2*D 2*C LJ BJ 
        /// </summary>
        public static List<String> Cards
        {
            get
            {
                List<String> cards = new List<string>();

                // 13*4==52
                foreach (String card_value in CardValues)
                {
                    if (!card_value.Equals("LJ") && !card_value.Equals("BJ"))
                    {
                        foreach (String card_color in CardColors)
                        {
                            cards.Add(card_value + "*" + card_color);  //  value*color
                        }
                    }
                }
                // 52+2 == 54
                cards.Add("LJ");
                cards.Add("BJ");

                return cards;
            }
        }

        /*----------------------------------------------------------------------------*/
        /* all types you can use in the game */
        /* ignore the color and sequence*/
        /* use chinese below since it will be more clear*/

        private static Dictionary<String, int> dange = null;
        /// <summary>
        /// 单个 (牌型 - 权重值)  共15种
        /// </summary>
        public static Dictionary<String, int> DanGe
        {
            get
            {
                if (dange == null)
                {
                    dange = new Dictionary<string, int>();
                    int weight = 1;

                    foreach (String c in CardValues)
                    {
                        dange.Add(c, weight++);
                    }
                }
                return dange;
            }
        }

        private static Dictionary<String, int> wulianshun = null;
        /// <summary>
        /// 五连顺（牌型 - 权重值） 共8种
        /// 3-4-5-6-7 4-5-6-7-8 ... 10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, int> WuLianShun
        {
            get
            {
                if (wulianshun == null)
                {
                    wulianshun = new Dictionary<string, int>();
                    int weight = 1;

                    for (int index = 0; index < 8; index++)
                    {
                        wulianshun.Add(CardValues[index] 
                            + "-" + CardValues[index + 1] 
                            + "-" + CardValues[index + 2] 
                            + "-" + CardValues[index + 3] 
                            + "-" + CardValues[index + 4], weight++);
                    }
                }

                return wulianshun;
            }
        }

        private static Dictionary<String, int> liulianshun = null;
        /// <summary>
        /// 六连顺（牌型 - 权重值） 共7种
        /// 3-4-5-6-7-8 4-5-6-7-8-9 ... 9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, int> LiuLianShun
        {
            get
            {
                if (liulianshun == null)
                {
                    liulianshun = new Dictionary<string, int>();
                    int weight = 1;

                    for (int index = 0; index < 7; index++)
                    {
                        liulianshun.Add(CardValues[index] 
                            + "-" + CardValues[index + 1] 
                            + "-" + CardValues[index + 2] 
                            + "-" + CardValues[index + 3] 
                            + "-" + CardValues[index + 4] 
                            + "-" + CardValues[index + 5], weight++);
                    }
                }

                return liulianshun;
            }
        }

        private static Dictionary<String, int> qilianshun = null;
        /// <summary>
        /// 七连顺（牌型 - 权重值） 共6种
        /// 3-4-5-6-7-8-9 4-5-6-7-8-9-10 ... 8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, int> QiLianShun
        {
            get
            {
                if (qilianshun == null)
                {
                    qilianshun = new Dictionary<string, int>();
                    int weight = 1;

                    for (int index = 0; index < 6; index++)
                    {
                        qilianshun.Add(CardValues[index]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 6], weight++);
                    }
                }

                return qilianshun;
            }
        }

        private static Dictionary<String, int> balianshun = null;
        /// <summary>
        /// 八连顺（牌型 - 权重值） 共5种
        /// 3-4-5-6-7-8-9-10 4-5-6-7-8-9-10-J ... 7-8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, int> BaLianShun
        {
            get
            {
                if (balianshun == null)
                {
                    balianshun = new Dictionary<string, int>();
                    int weight = 1;

                    for (int index = 0; index < 5; index++)
                    {
                        balianshun.Add(CardValues[index]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 6]
                            + "-" + CardValues[index + 7], weight++);
                    }
                }

                return balianshun;
            }
        }

        private static Dictionary<String, int> jiulianshun = null;
        /// <summary>
        /// 九连顺（牌型 - 权重值） 共4种
        /// 3-4-5-6-7-8-9-10-J 4-5-6-7-8-9-10-J-Q ... 6-7-8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, int> JiuLianShun
        {
            get
            {
                if (jiulianshun == null)
                {
                    jiulianshun = new Dictionary<string, int>();
                    int weight = 1;

                    for (int index = 0; index < 4; index++)
                    {
                        jiulianshun.Add(CardValues[index]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 6]
                            + "-" + CardValues[index + 7]
                            + "-" + CardValues[index + 8], weight++);
                    }
                }

                return jiulianshun;
            }
        }

        private static Dictionary<String, int> shilianshun = null;
        /// <summary>
        /// 十连顺（牌型 - 权重值） 共3种
        /// 3-4-5-6-7-8-9-10-J-Q 4-5-6-7-8-9-10-J-Q-K ... 5-6-7-8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, int> ShiLianShun
        {
            get
            {
                if (shilianshun == null)
                {
                    shilianshun = new Dictionary<string, int>();
                    int weight = 1;

                    for (int index = 0; index < 3; index++)
                    {
                        shilianshun.Add(CardValues[index]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 6]
                            + "-" + CardValues[index + 7]
                            + "-" + CardValues[index + 8]
                            + "-" + CardValues[index + 9], weight++);
                    }
                }

                return shilianshun;
            }
        }

        private static Dictionary<String, int> shiyilianshun = null;
        /// <summary>
        /// 十一连顺（牌型 - 权重值） 共2种
        /// 3-4-5-6-7-8-9-10-J-Q-K 4-5-6-7-8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, int> ShiYiLianShun
        {
            get
            {
                if (shiyilianshun == null)
                {
                    shiyilianshun = new Dictionary<string, int>();
                    int weight = 1;

                    for (int index = 0; index < 2; index++)
                    {
                        shiyilianshun.Add(CardValues[index]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 6]
                            + "-" + CardValues[index + 7]
                            + "-" + CardValues[index + 8]
                            + "-" + CardValues[index + 9]
                            + "-" + CardValues[index + 10], weight++);
                    }
                }

                return shiyilianshun;
            }
        }

        private static Dictionary<String, int> shierlianshun = null;
        /// <summary>
        /// 十二连顺（牌型 - 权重值） 共1种
        /// 3-4-5-6-7-8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, int> ShiErLianShun
        {
            get
            {
                if (shierlianshun == null)
                {
                    shierlianshun = new Dictionary<string, int>();
                    int weight = 1;

                    for (int index = 0; index < 1; index++)
                    {
                        shierlianshun.Add(CardValues[index]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 6]
                            + "-" + CardValues[index + 7]
                            + "-" + CardValues[index + 8]
                            + "-" + CardValues[index + 9]
                            + "-" + CardValues[index + 10]
                            + "-" + CardValues[index + 11], weight++);
                    }
                }

                return shierlianshun;
            }
        }


        private static Dictionary<String, int> duizi = null;
        /// <summary>
        /// 对子（牌型 - 权重值） 共13种
        /// 3-3 4-4 5-5 ... A-A 2-2  （两个王不算对子）
        /// </summary>
        public static Dictionary<String, int> DuiZi
        {
            get
            {
                if (duizi == null)
                {
                    duizi = new Dictionary<string, int>();
                    int weight = 1;

                    for (int index = 0; index < 13; index++)
                    {
                        duizi.Add(CardValues[index] + "-" + CardValues[index], weight++);
                    }
                }

                return duizi;
            }
        }

        private static Dictionary<String, int> duizi = null;
        /// <summary>
        /// 对子（牌型 - 权重值） 共13种
        /// 3-3 4-4 5-5 ... A-A 2-2  （两个王不算对子）
        /// </summary>
        public static Dictionary<String, int> DuiZi
        {
            get
            {
                if (duizi == null)
                {
                    duizi = new Dictionary<string, int>();
                    int weight = 1;

                    for (int index = 0; index < 13; index++)
                    {
                        duizi.Add(CardValues[index] + "-" + CardValues[index], weight++);
                    }
                }

                return duizi;
            }
        }
    }
}
