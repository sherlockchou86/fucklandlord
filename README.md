# fucklandlord
an engine of popular card game in China named doudizhu, contains a win32 GUI besides.

4 colors, 52 cards with color, 2 cards without color:

```
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
```


37 card types:

```
        public static String DanGe = "单张";
        public static String WuLianShun = "五连顺";
        public static String LiuLianShun = "六连顺";
        public static String QiLianShun = "七连顺";
        public static String BaLianShun = "八连顺";
        public static String JiuLianShun = "九连顺";
        public static String ShiLianShun = "十连顺";
        public static String ShiYiLianShun = "十一连顺";
        public static String ShiErLianShun = "十二连顺";

        public static String DuiZi = "对子";
        public static String SanLianDui = "三连对";
        public static String SiLianDui = "四连对";
        public static String WuLianDui = "五连对";
        public static String LiuLianDui = "六连对";
        public static String QiLianDui = "七连对";
        public static String BaLianDui = "八连对";
        public static String JiuLianDui = "九连对";
        public static String ShiLianDui = "十连对";

        public static String SanZhang = "三张";
        public static String FeiJi = "飞机";
        public static String SanLianFeiJi = "三连飞机";
        public static String SiLianFeiJi = "四连飞机";
        public static String WuLianFeiJi = "五连飞机";
        public static String LiuLianFeiJi = "六连飞机";

        public static String SanDaiYiGe = "三带一张";
        public static String FeiJiDaiLiangGe = "飞机带两张";
        public static String SanLianFeiJiDaiSanGe = "三连飞机带三张";
        public static String SiLianFeiJiDaiSiGe = "四连飞机带四张";
        public static String WuLianFeiJiDaiWuGe = "五连飞机带五张";

        public static String SanDaiYiDui = "三带一对";
        public static String FeiJiDaiLiangDui = "飞机带两对";
        public static String SanLianFeiJiDaiSanDui = "三连飞机带三对";
        public static String SiLianFeiJiDaiSiDui = "四连飞机带四对";

        public static String SiDaiLiangGe = "四带两张";
        public static String SiDaiLiangDui = "四带两对";

        public static String ZhaDan = "炸弹";

        public static String WangZha = "王炸";
```

![](https://github.com/sherlockchou86/fucklandlord/blob/master/console_screen.png)

![](https://github.com/sherlockchou86/fucklandlord/blob/master/gui.screen.png)
