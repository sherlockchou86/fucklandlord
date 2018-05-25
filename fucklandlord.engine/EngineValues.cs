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
        /// diamonds, clubs, hearts, spades
        /// </summary>
        public static List<String> CardColors = new List<string> {"D", "C", "H", "S" };

        /// <summary>
        /// 15 kinds of card without color
        /// 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace, 2, Little joker, Big joker
        /// </summary>
        public static List<String> CardValues = new List<string> {"3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A", "2", "LJ", "BJ" };

        /// <summary>
        /// return all cards with color in the game
        /// 3*D 3*C 3*H 3*S 4*D 4*C 4*H 4*S 5*D 5*C 5*H 5*S  ... 2*D 2*C 2*H 2*S LJ BJ 
        /// </summary>
        public static List<String> Cards
        {
            get
            {
                List<String> cards = new List<string>();

                // 13*4==52
                for (int index = 0; index < 13; index++ )
                {
                    foreach (String card_color in CardColors)
                    {
                        cards.Add(CardValues[index] + "*" + card_color);  //  value*color
                    }
                }

                // 52+2 == 54
                cards.Add(CardValues[13]);
                cards.Add(CardValues[14]);

                return cards;
            }
        }


        /*----------------------------------------------------------------------------*/
        /* all types you can use in the game */
        /* ignore the color and sequence*/
        /* use chinese below since it will be more clear*/

        private static Dictionary<String, List<CardType>> dange = null;
        /// <summary>
        /// 单个 (牌型key - 牌型entity)  共15种
        /// </summary>
        public static Dictionary<String, List<CardType>> DanGe
        {
            get
            {
                if (dange == null)
                {
                    dange = new Dictionary<String, List<CardType>>();
                    int weight = 1;

                    foreach (String c in CardValues)
                    {
                        dange.Add(c, new List<CardType> { new CardType() { CardKey = c, Weight = weight++, Name = CardTypeName.DanGe, IsBomb = false } });
                    }
                }
                return dange;
            }
        }

        private static Dictionary<String, List<CardType>> wulianshun = null;
        /// <summary>
        /// 五连顺（牌型key - 牌型entity） 共8种
        /// 3-4-5-6-7 4-5-6-7-8 ... 10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, List<CardType>> WuLianShun
        {
            get
            {
                if (wulianshun == null)
                {
                    wulianshun = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 8; index++)
                    {
                        key = CardValues[index + 4] 
                            + "-" + CardValues[index + 3] 
                            + "-" + CardValues[index + 2] 
                            + "-" + CardValues[index + 1] 
                            + "-" + CardValues[index];

                        wulianshun.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.WuLianShun, IsBomb = false}});
                    }
                }

                return wulianshun;
            }
        }

        private static Dictionary<String, List<CardType>> liulianshun = null;
        /// <summary>
        /// 六连顺（牌型key - 牌型entity） 共7种
        /// 3-4-5-6-7-8 4-5-6-7-8-9 ... 9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, List<CardType>> LiuLianShun
        {
            get
            {
                if (liulianshun == null)
                {
                    liulianshun = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 7; index++)
                    {
                        key = CardValues[index + 5] 
                            + "-" + CardValues[index + 4] 
                            + "-" + CardValues[index + 3] 
                            + "-" + CardValues[index + 2] 
                            + "-" + CardValues[index + 1] 
                            + "-" + CardValues[index];

                        liulianshun.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.LiuLianShun, IsBomb = false}});
                    }
                }

                return liulianshun;
            }
        }

        private static Dictionary<String, List<CardType>> qilianshun = null;
        /// <summary>
        /// 七连顺（牌型key - 牌型entity） 共6种
        /// 3-4-5-6-7-8-9 4-5-6-7-8-9-10 ... 8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, List<CardType>> QiLianShun
        {
            get
            {
                if (qilianshun == null)
                {
                    qilianshun = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 6; index++)
                    {
                        key = CardValues[index + 6]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index];
                        qilianshun.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.QiLianShun, IsBomb = false}});
                    }
                }

                return qilianshun;
            }
        }

        private static Dictionary<String, List<CardType>> balianshun = null;
        /// <summary>
        /// 八连顺（牌型key - 牌型entity） 共5种
        /// 3-4-5-6-7-8-9-10 4-5-6-7-8-9-10-J ... 7-8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, List<CardType>> BaLianShun
        {
            get
            {
                if (balianshun == null)
                {
                    balianshun = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 5; index++)
                    {
                        key = CardValues[index + 7]
                            + "-" + CardValues[index + 6]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index];
                        balianshun.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.BaLianShun, IsBomb = false}});
                    }
                }

                return balianshun;
            }
        }

        private static Dictionary<String, List<CardType>> jiulianshun = null;
        /// <summary>
        /// 九连顺（牌型key - 牌型entity） 共4种
        /// 3-4-5-6-7-8-9-10-J 4-5-6-7-8-9-10-J-Q ... 6-7-8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, List<CardType>> JiuLianShun
        {
            get
            {
                if (jiulianshun == null)
                {
                    jiulianshun = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 4; index++)
                    {
                        key = CardValues[index + 8]
                            + "-" + CardValues[index + 7]
                            + "-" + CardValues[index + 6]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index];
                        jiulianshun.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.JiuLianShun, IsBomb = false}});
                    }
                }

                return jiulianshun;
            }
        }

        private static Dictionary<String, List<CardType>> shilianshun = null;
        /// <summary>
        /// 十连顺（牌型key - 牌型entity） 共3种
        /// 3-4-5-6-7-8-9-10-J-Q 4-5-6-7-8-9-10-J-Q-K ... 5-6-7-8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, List<CardType>> ShiLianShun
        {
            get
            {
                if (shilianshun == null)
                {
                    shilianshun = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 3; index++)
                    {
                        key = CardValues[index + 9]
                            + "-" + CardValues[index + 8]
                            + "-" + CardValues[index + 7]
                            + "-" + CardValues[index + 6]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index];
                        shilianshun.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.ShiLianShun, IsBomb = false}});
                    }
                }

                return shilianshun;
            }
        }

        private static Dictionary<String, List<CardType>> shiyilianshun = null;
        /// <summary>
        /// 十一连顺（牌型key - 牌型entity） 共2种
        /// 3-4-5-6-7-8-9-10-J-Q-K 4-5-6-7-8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, List<CardType>> ShiYiLianShun
        {
            get
            {
                if (shiyilianshun == null)
                {
                    shiyilianshun = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 2; index++)
                    {
                        key = CardValues[index + 10]
                            + "-" + CardValues[index + 9]
                            + "-" + CardValues[index + 8]
                            + "-" + CardValues[index + 7]
                            + "-" + CardValues[index + 6]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index];
                        shiyilianshun.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.ShiYiLianShun, IsBomb = false}});
                    }
                }

                return shiyilianshun;
            }
        }

        private static Dictionary<String, List<CardType>> shierlianshun = null;
        /// <summary>
        /// 十二连顺（牌型 - 权重值） 共1种
        /// 3-4-5-6-7-8-9-10-J-Q-K-A
        /// </summary>
        public static Dictionary<String, List<CardType>> ShiErLianShun
        {
            get
            {
                if (shierlianshun == null)
                {
                    shierlianshun = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    string key = null;

                    for (int index = 0; index < 1; index++)
                    {
                        key = CardValues[index + 11]
                            + "-" + CardValues[index + 10]
                            + "-" + CardValues[index + 9]
                            + "-" + CardValues[index + 8]
                            + "-" + CardValues[index + 7]
                            + "-" + CardValues[index + 6]
                            + "-" + CardValues[index + 5]
                            + "-" + CardValues[index + 4]
                            + "-" + CardValues[index + 3]
                            + "-" + CardValues[index + 2]
                            + "-" + CardValues[index + 1]
                            + "-" + CardValues[index];
                        shierlianshun.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.ShiErLianShun, IsBomb = false}});
                    }
                }

                return shierlianshun;
            }
        }


        private static Dictionary<String, List<CardType>> duizi = null;
        /// <summary>
        /// 对子（牌型key - 牌型entity） 共13种
        /// 3-3 4-4 5-5 ... A-A 2-2  （两个王不算对子）
        /// </summary>
        public static Dictionary<String, List<CardType>> DuiZi
        {
            get
            {
                if (duizi == null)
                {
                    duizi = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 13; index++)
                    {
                        key = EngineTool.RepeatCard(index, 2);
                        duizi.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.DuiZi, IsBomb = false}});
                    }
                }

                return duizi;
            }
        }

        private static Dictionary<String, List<CardType>> sanliandui = null;
        /// <summary>
        /// 三连对（牌型key - 牌型entity） 共10种
        /// 3-3-4-4-5-5 4-4-5-5-6-6 ... Q-Q-K-K-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> SanLianDui
        {
            get
            {
                if (sanliandui == null)
                {
                    sanliandui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 10; index++)
                    {
                        key = EngineTool.RepeatCard(index + 2, 2) + "-" + 
                              EngineTool.RepeatCard(index + 1, 2) + "-" +
                              EngineTool.RepeatCard(index, 2);
                        sanliandui.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.SanLianDui, IsBomb = false}});
                    }
                }

                return sanliandui;
            }
        }

        private static Dictionary<String, List<CardType>> siliandui = null;
        /// <summary>
        /// 四连对（牌型key - 牌型entity） 共9种
        /// 3-3-4-4-5-5-6-6 4-4-5-5-6-6-7-7 ... J-J-Q-Q-K-K-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> SiLianDui
        {
            get
            {
                if (siliandui == null)
                {
                    siliandui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 9; index++)
                    {
                        key = EngineTool.RepeatCard(index + 3, 2) + "-" +
                              EngineTool.RepeatCard(index + 2, 2) + "-" +
                              EngineTool.RepeatCard(index + 1, 2) + "-" +
                              EngineTool.RepeatCard(index, 2);
                        siliandui.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.SiLianDui, IsBomb = false}});
                    }
                }

                return siliandui;
            }
        }

        private static Dictionary<String, List<CardType>> wuliandui = null;
        /// <summary>
        /// 五连对（牌型key - 牌型entity） 共8种
        /// 3-3-4-4-5-5-6-6-7-7 4-4-5-5-6-6-7-7-8-8 ... 10-10-J-J-Q-Q-K-K-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> WuLianDui
        {
            get
            {
                if (wuliandui == null)
                {
                    wuliandui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 8; index++)
                    {
                        key = EngineTool.RepeatCard(index + 4, 2) + "-" +
                              EngineTool.RepeatCard(index + 3, 2) + "-" +
                              EngineTool.RepeatCard(index + 2, 2) + "-" +
                              EngineTool.RepeatCard(index + 1, 2) + "-" +
                              EngineTool.RepeatCard(index, 2);
                        wuliandui.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.WuLianDui, IsBomb = false}});
                    }
                }

                return wuliandui;
            }
        }

        private static Dictionary<String, List<CardType>> liuliandui = null;
        /// <summary>
        /// 六连对（牌型key - 牌型entity） 共7种
        /// 3-3-4-4-5-5-6-6-7-7-8-8 4-4-5-5-6-6-7-7-8-8-9-9 ... 9-9-10-10-J-J-Q-Q-K-K-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> LiuLianDui
        {
            get
            {
                if (liuliandui == null)
                {
                    liuliandui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 7; index++)
                    {
                        key = EngineTool.RepeatCard(index + 5, 2) + "-" +
                              EngineTool.RepeatCard(index + 4, 2) + "-" +
                              EngineTool.RepeatCard(index + 3, 2) + "-" +
                              EngineTool.RepeatCard(index + 2, 2) + "-" +
                              EngineTool.RepeatCard(index + 1, 2) + "-" +
                              EngineTool.RepeatCard(index, 2);
                        liuliandui.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.LiuLianDui, IsBomb = false}});
                    }
                }

                return liuliandui;
            }
        }

        
        private static Dictionary<String, List<CardType>> qiliandui = null;
        /// <summary>
        /// 七连对（牌型key - 牌型entity） 共6种
        /// 3-3-4-4-5-5-6-6-7-7-8-8-9-9 4-4-5-5-6-6-7-7-8-8-9-9-10-10 ... 8-8-9-9-10-10-J-J-Q-Q-K-K-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> QiLianDui
        {
            get
            {
                if (qiliandui == null)
                {
                    qiliandui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 6; index++)
                    {
                        key = EngineTool.RepeatCard(index + 6, 2) + "-" +
                              EngineTool.RepeatCard(index + 5, 2) + "-" +
                              EngineTool.RepeatCard(index + 4, 2) + "-" +
                              EngineTool.RepeatCard(index + 3, 2) + "-" +
                              EngineTool.RepeatCard(index + 2, 2) + "-" +
                              EngineTool.RepeatCard(index + 1, 2) + "-" +
                              EngineTool.RepeatCard(index, 2);
                        qiliandui.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.QiLianDui, IsBomb = false}});
                    }
                }

                return qiliandui;
            }
        }

        private static Dictionary<String, List<CardType>> baliandui = null;
        /// <summary>
        /// 八连对（牌型key - 牌型entity） 共5种
        /// 3-3-4-4-5-5-6-6-7-7-8-8-9-9-10-10 4-4-5-5-6-6-7-7-8-8-9-9-10-10-J-J ... 7-7-8-8-9-9-10-10-J-J-Q-Q-K-K-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> BaLianDui
        {
            get
            {
                if (baliandui == null)
                {
                    baliandui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 5; index++)
                    {
                        key = EngineTool.RepeatCard(index + 7, 2) + "-" +
                              EngineTool.RepeatCard(index + 6, 2) + "-" +
                              EngineTool.RepeatCard(index + 5, 2) + "-" +
                              EngineTool.RepeatCard(index + 4, 2) + "-" +
                              EngineTool.RepeatCard(index + 3, 2) + "-" +
                              EngineTool.RepeatCard(index + 2, 2) + "-" +
                              EngineTool.RepeatCard(index + 1, 2) + "-" +
                              EngineTool.RepeatCard(index, 2);
                        baliandui.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.BaLianDui, IsBomb = false}});
                    }
                }

                return baliandui;
            }
        }

        private static Dictionary<String, List<CardType>> jiuliandui = null;
        /// <summary>
        /// 九连对（牌型key - 牌型entity） 共4种
        /// 3-3-4-4-5-5-6-6-7-7-8-8-9-9-10-10-J-J 4-4-5-5-6-6-7-7-8-8-9-9-10-10-J-J-Q-Q ... 6-6-7-7-8-8-9-9-10-10-J-J-Q-Q-K-K-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> JiuLianDui
        {
            get
            {
                if (jiuliandui == null)
                {
                    jiuliandui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 4; index++)
                    {
                        key = EngineTool.RepeatCard(index + 8, 2) + "-" +
                              EngineTool.RepeatCard(index + 7, 2) + "-" +
                              EngineTool.RepeatCard(index + 6, 2) + "-" +
                              EngineTool.RepeatCard(index + 5, 2) + "-" +
                              EngineTool.RepeatCard(index + 4, 2) + "-" +
                              EngineTool.RepeatCard(index + 3, 2) + "-" +
                              EngineTool.RepeatCard(index + 2, 2) + "-" +
                              EngineTool.RepeatCard(index + 1, 2) + "-" +
                              EngineTool.RepeatCard(index, 2);
                        jiuliandui.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.JiuLianDui, IsBomb = false}});
                    }
                }

                return jiuliandui;
            }
        }

        
        private static Dictionary<String, List<CardType>> shiliandui = null;
        /// <summary>
        /// 十连对（牌型 - 权重值） 共3种
        /// 3-3-4-4-5-5-6-6-7-7-8-8-9-9-10-10-J-J-Q-Q 4-4-5-5-6-6-7-7-8-8-9-9-10-10-J-J-Q-Q-K-K 5-5-6-6-7-7-8-8-9-9-10-10-J-J-Q-Q-K-K-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> ShiLianDui
        {
            get
            {
                if (shiliandui == null)
                {
                    shiliandui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 3; index++)
                    {
                        key = EngineTool.RepeatCard(index + 9, 2) + "-" +
                              EngineTool.RepeatCard(index + 8, 2) + "-" +
                              EngineTool.RepeatCard(index + 7, 2) + "-" +
                              EngineTool.RepeatCard(index + 6, 2) + "-" +
                              EngineTool.RepeatCard(index + 5, 2) + "-" +
                              EngineTool.RepeatCard(index + 4, 2) + "-" +
                              EngineTool.RepeatCard(index + 3, 2) + "-" +
                              EngineTool.RepeatCard(index + 2, 2) + "-" +
                              EngineTool.RepeatCard(index + 1, 2) + "-" +
                              EngineTool.RepeatCard(index, 2);
                        shiliandui.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.ShiLianDui, IsBomb = false}});
                    }
                }

                return shiliandui;
            }
        }

        private static Dictionary<String, List<CardType>> sanzhang = null;
        /// <summary>
        /// 三张（牌型key - 牌型entity） 共13种
        /// 3-3-3 4-4-4 ... A-A-A 2-2-2 
        /// </summary>
        public static Dictionary<String, List<CardType>> SanZhang
        {
            get
            {
                if (sanzhang == null)
                {
                    sanzhang = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 13; index++)
                    {
                        key = EngineTool.RepeatCard(index, 3);
                        sanzhang.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.SanZhang, IsBomb = false}});
                    }
                }

                return sanzhang;
            }
        }

        
        private static Dictionary<String, List<CardType>> feiji = null;
        /// <summary>
        /// 飞机（牌型key - 牌型entity） 共11种
        /// 3-3-3-4-4-4 ... K-K-K-A-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> FeiJi
        {
            get
            {
                if (feiji == null)
                {
                    feiji = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 11; index++)
                    {
                        key = EngineTool.RepeatCard(index + 1, 3) + "-" +
                              EngineTool.RepeatCard(index, 3);
                        feiji.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.FeiJi, IsBomb = false}});
                    }
                }

                return feiji;
            }
        }

        private static Dictionary<String, List<CardType>> sanlianfeiji = null;
        /// <summary>
        /// 三连飞机（牌型 - 权重值） 共10种
        /// 3-3-3-4-4-4-5-5-5 ... Q-Q-Q-K-K-K-A-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> SanLianFeiJi
        {
            get
            {
                if (sanlianfeiji == null)
                {
                    sanlianfeiji = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 10; index++)
                    {
                        key = EngineTool.RepeatCard(index + 2, 3) + "-" +
                              EngineTool.RepeatCard(index + 1, 3) + "-" +
                              EngineTool.RepeatCard(index, 3);
                        sanlianfeiji.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.SanLianFeiJi, IsBomb = false}});
                    }
                }

                return sanlianfeiji;
            }
        }

        
        private static Dictionary<String, List<CardType>> silianfeiji = null;
        /// <summary>
        /// 四连飞机（牌型key - 牌型entity） 共9种
        /// 3-3-3-4-4-4-5-5-5-6-6-6 ... J-J-J-Q-Q-Q-K-K-K-A-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> SiLianFeiJi
        {
            get
            {
                if (silianfeiji == null)
                {
                    silianfeiji = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 9; index++)
                    {
                        key = EngineTool.RepeatCard(index + 3, 3) + "-" +
                              EngineTool.RepeatCard(index + 2, 3) + "-" +
                              EngineTool.RepeatCard(index + 1, 3) + "-" +
                              EngineTool.RepeatCard(index, 3);
                        silianfeiji.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.SiLianFeiJi, IsBomb = false}});
                    }
                }

                return silianfeiji;
            }
        }

        
        private static Dictionary<String, List<CardType>> wulianfeiji = null;
        /// <summary>
        /// 五连飞机（牌型key - 牌型entity） 共8种
        /// 3-3-3-4-4-4-5-5-5-6-6-6-7-7-7 ... 10-10-10-J-J-J-Q-Q-Q-K-K-K-A-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> WuLianFeiJi
        {
            get
            {
                if (wulianfeiji == null)
                {
                    wulianfeiji = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 8; index++)
                    {
                        key = EngineTool.RepeatCard(index + 4, 3) + "-" +
                              EngineTool.RepeatCard(index + 3, 3) + "-" +
                              EngineTool.RepeatCard(index + 2, 3) + "-" +
                              EngineTool.RepeatCard(index + 1, 3) + "-" +
                              EngineTool.RepeatCard(index, 3);
                        wulianfeiji.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.WuLianFeiJi, IsBomb = false}});
                    }
                }

                return wulianfeiji;
            }
        }

        private static Dictionary<String, List<CardType>> liulianfeiji = null;
        /// <summary>
        /// 六连飞机（牌型key - 牌型entity） 共7种
        /// 3-3-3-4-4-4-5-5-5-6-6-6-7-7-7-8-8-8 ... 9-9-9-10-10-10-J-J-J-Q-Q-Q-K-K-K-A-A-A 
        /// </summary>
        public static Dictionary<String, List<CardType>> LiuLianFeiJi
        {
            get
            {
                if (liulianfeiji == null)
                {
                    liulianfeiji = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 7; index++)
                    {
                        key = EngineTool.RepeatCard(index + 5, 3) + "-" +
                              EngineTool.RepeatCard(index + 4, 3) + "-" +
                              EngineTool.RepeatCard(index + 3, 3) + "-" +
                              EngineTool.RepeatCard(index + 2, 3) + "-" +
                              EngineTool.RepeatCard(index + 1, 3) + "-" +
                              EngineTool.RepeatCard(index, 3);
                        liulianfeiji.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.LiuLianFeiJi, IsBomb = false}});
                    }
                }

                return liulianfeiji;
            }
        }

        private static Dictionary<String, List<CardType>> sandaiyige = null;
        /// <summary>
        /// 三带一个（牌型key - 牌型entity） 共182种
        /// 3-3-3-4 4-4-4-A ... A-A-A-BJ ... 10-10-10-2
        /// </summary>
        public static Dictionary<String, List<CardType>> SanDaiYiGe
        {
            get
            {
                if (sandaiyige == null)
                {
                    sandaiyige = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;
                    String input_key = null;

                    for (int index = 0; index < 13; index++)
                    {
                        for (int step = 0; step < 15; step++)
                        {
                            if (index != step)
                            {
                                key = EngineTool.RepeatCard(index, 3) + "-"
                                    + CardValues[step];

                                input_key = EngineTool.SuperSort(new List<string> { EngineTool.RepeatCard(index, 3), CardValues[step]});

                                sandaiyige.Add(input_key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.SanDaiYiGe, IsBomb = false}});
                            }
                        }
                    }
                }
                return sandaiyige;
            }
        }

        private static Dictionary<String, List<CardType>> feijidailiangge = null;
        /// <summary>
        /// 飞机带两个（牌型key - 牌型entity）
        /// 3-3-3-4-4-4-8-9 8-8-8-9-9-9-J-K ... K-K-K-A-A-A-BJ-8 ... 
        /// </summary>
        public static Dictionary<String, List<CardType>> FeiJiDaiLianGe
        {
            get
            {
                if (feijidailiangge == null)
                {
                    feijidailiangge = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;
                    string input_key = null;

                    bool invalid = false;

                    for (int index = 0; index < 11; index++)
                    {
                        for (int step = 0; step < 15; step++)
                        {
                            for (int step2 = step; step2 < 15; step2++)
                            {
                                invalid = false;

                                key = EngineTool.RepeatCard(index + 1, 3) + "-" +
                                      EngineTool.RepeatCard(index, 3) + "-" +
                                      CardValues[step2] + "-" + CardValues[step];

                                // 任何非大小王的卡牌不超4张
                                for (int i = 0; i < 13; i++)
                                {
                                    if (EngineTool.CountInCardStr(key, CardValues[i]) > 4)
                                    {
                                        invalid = true;
                                        break;
                                    }
                                }

                                if (invalid)
                                {
                                    continue;
                                }

                                // 大小王最多各一张
                                if (EngineTool.CountInCardStr(key, CardValues[13]) > 1)
                                {
                                    continue;
                                }

                                if (EngineTool.CountInCardStr(key, CardValues[14]) > 1)
                                {
                                    continue;
                                }

                                input_key = EngineTool.SuperSort(new List<string> { 
                                    EngineTool.RepeatCard(index + 1, 3), EngineTool.RepeatCard(index, 3), CardValues[step2], CardValues[step]
                                });

                                feijidailiangge.Add(input_key, new List<CardType>{new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.FeiJiDaiLiangGe, IsBomb = false }});
                            }
                        }

                        weight++;
                    }
                }
                return feijidailiangge;
            }
        }


        private static Dictionary<String, List<CardType>> sanlianfeijidaisange = null;
        /// <summary>
        /// 三连飞机带三个（牌型key - 牌型entity）
        /// 3-3-3-4-4-4-5-5-5-8-9-10 8-8-8-9-9-9-10-10-10-BJ-LJ-2 ... Q-Q-Q-K-K-K-A-A-A-Q-K-A ... 
        /// </summary>
        public static Dictionary<String, List<CardType>> SanLianFeiJiDaiSanGe
        {
            get
            {
                if (sanlianfeijidaisange == null)
                {
                    sanlianfeijidaisange = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;
                    String input_key = null;

                    bool invalid = false;

                    for (int index = 0; index < 10; index++)
                    {
                        for (int step = 0; step < 15; step++)
                        {
                            for (int step2 = step; step2 < 15; step2++)
                            {
                                for (int step3 = step2; step3 < 15; step3++)
                                {
                                    invalid = false;

                                    key = EngineTool.RepeatCard(index + 2, 3) + "-" +
                                          EngineTool.RepeatCard(index + 1, 3) + "-" +
                                          EngineTool.RepeatCard(index, 3) + "-" +
                                          CardValues[step3] + "-" + CardValues[step2] + "-" + CardValues[step];

                                    for (int i = 0; i < 13; i++)
                                    {
                                        if (EngineTool.CountInCardStr(key, CardValues[i]) > 4)
                                        {
                                            invalid = true;
                                            break;
                                        }
                                    }

                                    if (invalid)
                                    {
                                        continue;
                                    }

                                    if (EngineTool.CountInCardStr(key, CardValues[13]) > 1)
                                    {
                                        continue;
                                    }

                                    if (EngineTool.CountInCardStr(key,CardValues[14]) > 1)
                                    {
                                        continue;
                                    }

                                    input_key = EngineTool.SuperSort(new List<string> {
                                        EngineTool.RepeatCard(index + 2, 3), EngineTool.RepeatCard(index + 1, 3), EngineTool.RepeatCard(index, 3),
                                        CardValues[step3], CardValues[step2], CardValues[step]
                                    });

                                    if (sanlianfeijidaisange.ContainsKey(input_key))
                                    {
                                        sanlianfeijidaisange[input_key].Add(new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.SanLianFeiJiDaiSanGe, IsBomb = false });
                                    }
                                    else
                                    {
                                        sanlianfeijidaisange.Add(input_key, new List<CardType> { new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.SanLianFeiJiDaiSanGe, IsBomb = false } });
                                    }
                                }
                            }
                        }

                        weight++;
                    }
                }
                return sanlianfeijidaisange;
            }
        }

        private static Dictionary<String, List<CardType>> silianfeijidaisige = null;
        /// <summary>
        /// 四连飞机带四个（牌型key - 牌型entity）
        /// 3-3-3-4-4-4-5-5-5-6-6-6-8-9-10-J ... J-J-J-Q-Q-Q-K-K-K-A-A-A-J-Q-K-A ... 
        /// </summary>
        public static Dictionary<String, List<CardType>> SiLianFeiJiDaiSiGe
        {
            get
            {
                if (silianfeijidaisige == null)
                {
                    silianfeijidaisige = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;
                    String input_key = null;

                    bool invalid = false;

                    for (int index = 0; index < 9; index++)
                    {
                        for (int step = 0; step < 15; step++)
                        {
                            for (int step2 = step; step2 < 15; step2++)
                            {
                                for (int step3 = step2; step3 < 15; step3++)
                                {
                                    for (int step4 = step3; step4 < 15; step4++)
                                    {
                                        invalid = false;

                                        key = EngineTool.RepeatCard(index + 3, 3) + "-" +
                                              EngineTool.RepeatCard(index + 2, 3) + "-" +
                                              EngineTool.RepeatCard(index + 1, 3) + "-" +
                                              EngineTool.RepeatCard(index, 3) + "-" +
                                              CardValues[step4] + "-" + CardValues[step3] + "-" + CardValues[step2] + "-" + CardValues[step];

                                        for (int i = 0; i < 13; i++)
                                        {
                                            if (EngineTool.CountInCardStr(key, CardValues[i]) > 4)
                                            {
                                                invalid = true;
                                                break;
                                            }
                                        }

                                        if (invalid)
                                        {
                                            continue;
                                        }

                                        if (EngineTool.CountInCardStr(key, CardValues[13]) > 1)
                                        {
                                            continue;
                                        }

                                        if (EngineTool.CountInCardStr(key, CardValues[14]) > 1)
                                        {
                                            continue;
                                        }

                                        input_key = EngineTool.SuperSort(new List<string> { 
                                            EngineTool.RepeatCard(index + 3, 3), EngineTool.RepeatCard(index + 2, 3), EngineTool.RepeatCard(index + 1, 3), EngineTool.RepeatCard(index, 3),
                                            CardValues[step4], CardValues[step3], CardValues[step2], CardValues[step]
                                        });

                                        if (silianfeijidaisige.ContainsKey(input_key))
                                        {
                                            silianfeijidaisige[input_key].Add(new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.SiLianFeiJiDaiSiGe, IsBomb = false });
                                        }
                                        else
                                        {
                                            silianfeijidaisige.Add(input_key, new List<CardType> { new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.SiLianFeiJiDaiSiGe, IsBomb = false } });
                                        }
                                    }
                                }
                            }
                        }

                        weight++;
                    }
                }
                return silianfeijidaisige;
            }
        }

        private static Dictionary<String, List<CardType>> wulianfeijidaiwuge = null;
        /// <summary>
        /// 五连飞机带五个（牌型key - 牌型entity）
        /// 3-3-3-4-4-4-5-5-5-6-6-6-7-7-7-8-9-10-J-Q ... 10-10-10-J-J-J-Q-Q-Q-K-K-K-A-A-A-10-J-Q-K-A ... 
        /// </summary>
        public static Dictionary<String, List<CardType>> WuLianFeiJiDaiWuGe
        {
            get
            {
                if (wulianfeijidaiwuge == null)
                {
                    wulianfeijidaiwuge = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;
                    String input_key = null;

                    bool invalid = false;

                    for (int index = 0; index < 8; index++)
                    {
                        for (int step = 0; step < 15; step++)
                        {
                            for (int step2 = step; step2 < 15; step2++)
                            {
                                for (int step3 = step2; step3 < 15; step3++)
                                {
                                    for (int step4 = step3; step4 < 15; step4++)
                                    {
                                        for (int step5 = step4; step5 < 15; step5++)
                                        {
                                            invalid = false;

                                            key = EngineTool.RepeatCard(index + 4, 3) + "-" +
                                                  EngineTool.RepeatCard(index + 3, 3) + "-" +
                                                  EngineTool.RepeatCard(index + 2, 3) + "-" +
                                                  EngineTool.RepeatCard(index + 1, 3) + "-" +
                                                  EngineTool.RepeatCard(index, 3) + "-" +
                                                  CardValues[step5] + "-" + CardValues[step4] + "-" + CardValues[step3] + "-" + CardValues[step2] + "-" + CardValues[step];

                                            for (int i = 0; i < 13; i++)
                                            {
                                                if (EngineTool.CountInCardStr(key, CardValues[i]) > 4)
                                                {
                                                    invalid = true;
                                                    break;
                                                }
                                            }

                                            if (invalid)
                                            {
                                                continue;
                                            }

                                            if (EngineTool.CountInCardStr(key, CardValues[13]) > 1)
                                            {
                                                continue;
                                            }

                                            if (EngineTool.CountInCardStr(key, CardValues[14]) > 1)
                                            {
                                                continue;
                                            }

                                            input_key = EngineTool.SuperSort(new List<string> { 
                                                EngineTool.RepeatCard(index + 4, 3), EngineTool.RepeatCard(index + 3, 3), EngineTool.RepeatCard(index + 2, 3), EngineTool.RepeatCard(index + 1, 3),EngineTool.RepeatCard(index, 3),
                                                CardValues[step5], CardValues[step4], CardValues[step3], CardValues[step2], CardValues[step]
                                            });

                                            if (wulianfeijidaiwuge.ContainsKey(input_key))
                                            {
                                                wulianfeijidaiwuge[input_key].Add(new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.WuLianFeiJiDaiWuGe, IsBomb = false });
                                            }
                                            else
                                            {
                                                wulianfeijidaiwuge.Add(input_key, new List<CardType> { new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.WuLianFeiJiDaiWuGe, IsBomb = false } });
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        weight++;
                    }
                }
                return wulianfeijidaiwuge;
            }
        }


        private static Dictionary<String, List<CardType>> sandaiyidui = null;
        /// <summary>
        /// 三带一对（牌型key - 牌型entity）
        /// 3-3-3-4-4 ... A-A-A-2-2 ... 10-10-10-A-A ...
        /// </summary>
        public static Dictionary<String, List<CardType>> SanDaiYiDui
        {
            get
            {
                if (sandaiyidui == null)
                {
                    sandaiyidui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;
                    String input_key = null;

                    for (int index = 0; index < 13; index++)
                    {
                        for (int step = 0; step < 13; step++)
                        {
                            if (index != step)
                            {
                                key = EngineTool.RepeatCard(index, 3) + "-" +
                                      EngineTool.RepeatCard(step, 2);

                                input_key = EngineTool.SuperSort(new List<string> { EngineTool.RepeatCard(index, 3), EngineTool.RepeatCard(step, 2) });

                                sandaiyidui.Add(input_key, new List<CardType>{new CardType() { CardKey = key, Weight = weight++, Name = CardTypeName.SanDaiYiDui, IsBomb = false }});
                            }
                        }
                    }
                }
                return sandaiyidui;
            }
        }

        private static Dictionary<String, List<CardType>> feijidailiangdui = null;
        /// <summary>
        /// 飞机带两对（牌型key - 牌型entity）
        /// 3-3-3-4-4-4-8-8-9-9 ... K-K-K-A-A-A-3-3-2-2 ... 
        /// </summary>
        public static Dictionary<String, List<CardType>> FeiJiDaiLianDui
        {
            get
            {
                if (feijidailiangdui == null)
                {
                    feijidailiangdui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;
                    String input_key = null;

                    bool invalid = false;

                    for (int index = 0; index < 11; index++)
                    {
                        for (int step = 0; step < 13; step++)
                        {
                            for (int step2 = step; step2 < 13; step2++)
                            {
                                invalid = false;

                                key = EngineTool.RepeatCard(index + 1, 3) + "-" +
                                      EngineTool.RepeatCard(index, 3) + "-" +
                                      EngineTool.RepeatCard(step2, 2) + "-" + EngineTool.RepeatCard(step, 2);

                                // 任何非大小王的卡牌不超4张
                                for (int i = 0; i < 13; i++)
                                {
                                    if (EngineTool.CountInCardStr(key, CardValues[i]) > 4)
                                    {
                                        invalid = true;
                                        break;
                                    }
                                }

                                if (invalid)
                                {
                                    continue;
                                }

                                input_key = EngineTool.SuperSort(new List<string> { EngineTool.RepeatCard(index + 1, 3), EngineTool.RepeatCard(index, 3),
                                    EngineTool.RepeatCard(step2, 2), EngineTool.RepeatCard(step, 2)
                                });

                                feijidailiangdui.Add(input_key, new List<CardType>{new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.FeiJiDaiLiangDui, IsBomb = false }});
                            }
                        }

                        weight++;
                    }
                }
                return feijidailiangdui;
            }
        }

        private static Dictionary<String, List<CardType>> sanlianfeijidaisandui = null;
        /// <summary>
        /// 三连飞机带三对（牌型key - 牌型entity）
        /// 3-3-3-4-4-4-5-5-5-8-8-9-9-10-10 ... Q-Q-Q-K-K-K-A-A-A-J-J-3-3-2-2 ... 
        /// </summary>
        public static Dictionary<String, List<CardType>> SanLianFeiJiDaiSanDui
        {
            get
            {
                if (sanlianfeijidaisandui == null)
                {
                    sanlianfeijidaisandui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;
                    String input_key = null;

                    bool invalid = false;

                    for (int index = 0; index < 10; index++)
                    {
                        for (int step = 0; step < 13; step++)
                        {
                            for (int step2 = step; step2 < 13; step2++)
                            {
                                for (int step3 = step2; step3 < 13; step3++)
                                {
                                    invalid = false;

                                    key = EngineTool.RepeatCard(index + 2, 3) + "-" +
                                          EngineTool.RepeatCard(index + 1, 3) + "-" +
                                          EngineTool.RepeatCard(index, 3) + "-" +
                                          EngineTool.RepeatCard(step3, 2) + "-" + EngineTool.RepeatCard(step2, 2) + "-" + EngineTool.RepeatCard(step, 2);

                                    for (int i = 0; i < 13; i++)
                                    {
                                        if (EngineTool.CountInCardStr(key, CardValues[i]) > 4)
                                        {
                                            invalid = true;
                                            break;
                                        }
                                    }

                                    if (invalid)
                                    {
                                        continue;
                                    }

                                    input_key = EngineTool.SuperSort(new List<string> { EngineTool.RepeatCard(index + 2, 3), EngineTool.RepeatCard(index + 1, 3), EngineTool.RepeatCard(index, 3),
                                        EngineTool.RepeatCard(step3, 2), EngineTool.RepeatCard(step2, 2), EngineTool.RepeatCard(step, 2)
                                    });

                                    sanlianfeijidaisandui.Add(input_key, new List<CardType>{new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.SanLianFeiJiDaiSanDui, IsBomb = false }});
                                }
                            }
                        }

                        weight++;
                    }
                }
                return sanlianfeijidaisandui;
            }
        }

        private static Dictionary<String, List<CardType>> silianfeijidaisidui = null;
        /// <summary>
        /// 四连飞机带四对（牌型key - 牌型entity）
        /// 3-3-3-4-4-4-5-5-5-6-6-6-8-8-9-9-10-10-J-J ... J-J-J-Q-Q-Q-K-K-K-A-A-A-10-10-6-6-3-3-2-2 ... 
        /// </summary>
        public static Dictionary<String, List<CardType>> SiLianFeiJiDaiSiDui
        {
            get
            {
                if (silianfeijidaisidui == null)
                {
                    silianfeijidaisidui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;
                    String input_key = null;

                    bool invalid = false;

                    for (int index = 0; index < 9; index++)
                    {
                        for (int step = 0; step < 13; step++)
                        {
                            for (int step2 = step; step2 < 13; step2++)
                            {
                                for (int step3 = step2; step3 < 13; step3++)
                                {
                                    for (int step4 = step3; step4 < 13; step4++)
                                    {
                                        invalid = false;

                                        key = EngineTool.RepeatCard(index + 3, 3) + "-" +
                                              EngineTool.RepeatCard(index + 2, 3) + "-" +
                                              EngineTool.RepeatCard(index + 1, 3) + "-" +
                                              EngineTool.RepeatCard(index, 3) + "-" +
                                              EngineTool.RepeatCard(step4, 2) + "-" + EngineTool.RepeatCard(step3, 2) + "-" + EngineTool.RepeatCard(step2, 2) + "-" + EngineTool.RepeatCard(step, 2);

                                        for (int i = 0; i < 13; i++)
                                        {
                                            if (EngineTool.CountInCardStr(key, CardValues[i]) > 4)
                                            {
                                                invalid = true;
                                                break;
                                            }
                                        }

                                        if (invalid)
                                        {
                                            continue;
                                        }

                                        input_key = EngineTool.SuperSort(new List<string> { EngineTool.RepeatCard(index + 3, 3), EngineTool.RepeatCard(index + 2, 3), EngineTool.RepeatCard(index + 1, 3), EngineTool.RepeatCard(index, 3),
                                            EngineTool.RepeatCard(step4, 2), EngineTool.RepeatCard(step3, 2), EngineTool.RepeatCard(step2, 2), EngineTool.RepeatCard(step, 2)
                                        });

                                        silianfeijidaisidui.Add(input_key, new List<CardType>{new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.SiLianFeiJiDaiSiDui, IsBomb = false }});
                                    }
                                }
                            }
                        }

                        weight++;
                    }
                }
                return silianfeijidaisidui;
            }
        }

        private static Dictionary<String, List<CardType>> sidailiangge = null;
        /// <summary>
        /// 四带两个（牌型key - 牌型entity） 共1339种
        /// 3-3-3-3-4-4 5-5-5-5-A-Q ... 6-6-6-6-BJ-LJ ... 
        /// </summary>
        public static Dictionary<String, List<CardType>> SiDaiLiangGe
        {
            get
            {
                if (sidailiangge == null)
                {
                    sidailiangge = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;
                    String input_key = null;

                    bool invalid = false;

                    for (int index = 0; index < 13; index++)
                    {
                        for (int step = 0; step < 15; step++)
                        {
                            for(int step2 = step; step2 < 15; step2++)
                            {
                                invalid = false;

                                key = EngineTool.RepeatCard(index, 4) + "-" +
                                      CardValues[step2] + "-" + CardValues[step];

                                for (int i = 0; i < 13; i++)
                                {
                                    if (EngineTool.CountInCardStr(key, CardValues[i]) > 4)
                                    {
                                        invalid = true;
                                        break;
                                    }
                                }

                                if (invalid)
                                {
                                    continue;
                                }

                                if (EngineTool.CountInCardStr(key, CardValues[13]) > 1)
                                {
                                    continue;
                                }

                                if (EngineTool.CountInCardStr(key, CardValues[14]) > 1)
                                {
                                    continue;
                                }

                                input_key = EngineTool.SuperSort(new List<string> { EngineTool.RepeatCard(index, 4), CardValues[step2], CardValues[step] });

                                sidailiangge.Add(input_key, new List<CardType>{new CardType() {CardKey = key, Weight = weight, Name = CardTypeName.SiDaiLiangGe, IsBomb = false }});
                            }
                        }
                        weight++;  //只以四个比较大小，带的两张随便
                    }
                }
                return sidailiangge;
            }
        }

        private static Dictionary<String, List<CardType>> sidailiangdui = null;
        /// <summary>
        /// 四带两对（牌型key - 牌型entity） 共1014种
        /// 3-3-3-3-4-4-5-5 5-5-5-5-A-A-Q-Q ... 6-6-6-6-10-10-3-3 ... 
        /// </summary>
        public static Dictionary<String, List<CardType>> SiDaiLiangDui
        {
            get
            {
                if (sidailiangdui == null)
                {
                    sidailiangdui = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;
                    String input_key = null;

                    bool invalid = false;

                    for (int index = 0; index < 13; index++)
                    {
                        for (int step = 0; step < 13; step++)
                        {
                            for (int step2 = step; step2 < 13; step2++) 
                            {
                                invalid = false;

                                key = EngineTool.RepeatCard(index, 4) + "-" +
                                      EngineTool.RepeatCard(step2, 2) + "-" +
                                      EngineTool.RepeatCard(step, 2);

                                for (int i = 0; i < 13; i++)
                                {
                                    if (EngineTool.CountInCardStr(key, CardValues[i]) > 4)
                                    {
                                        invalid = true;
                                        break;
                                    }
                                }

                                if (invalid)
                                {
                                    continue;
                                }

                                input_key = EngineTool.SuperSort(new List<string> { EngineTool.RepeatCard(index, 4), EngineTool.RepeatCard(step2, 2), EngineTool.RepeatCard(step, 2) });

                                if (sidailiangdui.ContainsKey(input_key))
                                {
                                    sidailiangdui[input_key].Add(new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.SiDaiLiangDui, IsBomb = false });
                                }
                                else
                                {
                                    sidailiangdui.Add(input_key, new List<CardType> { new CardType() { CardKey = key, Weight = weight, Name = CardTypeName.SiDaiLiangDui, IsBomb = false } });
                                }
                            }
                        }
                        weight++; //只以四个比较大小，带的两对随便
                    }
                }
                return sidailiangdui;
            }
        }

        private static Dictionary<String, List<CardType>> zhadan = null;
        /// <summary>
        /// 普通炸弹（牌型key - 牌型entity） 共13种
        /// 3-3-3-3 4-4-4-4 ... 2-2-2-2
        /// </summary>
        public static Dictionary<String, List<CardType>> ZhaDan
        {
            get
            {
                if (zhadan == null)
                {
                    zhadan = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = null;

                    for (int index = 0; index < 13; index++)
                    {
                        key = CardValues[index] + "-" + CardValues[index] + "-" + CardValues[index] + "-" + CardValues[index];
                        zhadan.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.ZhaDan, IsBomb = true}});
                    }
                }
                return zhadan;
            }
        }

        private static Dictionary<String, List<CardType>> wangzha = null;
        /// <summary>
        /// 王炸（牌型 - 权重值） 共1种
        /// LJ-BJ
        /// </summary>
        public static Dictionary<String, List<CardType>> WangZha
        {
            get
            {
                if (wangzha == null)
                {
                    wangzha = new Dictionary<String, List<CardType>>();
                    int weight = 1;
                    String key = CardValues[14] + "-" + CardValues[13];

                    wangzha.Add(key, new List<CardType>{new CardType() {CardKey = key, Weight = weight++, Name = CardTypeName.WangZha, IsBomb = true}});
                }
                return wangzha;
            }
        }
    }
}
