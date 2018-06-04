using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fucklandlord.engine
{
    /// <summary>
    /// main engine for the card game
    /// </summary>
    public class GameEngine
    {
        public bool IsInitialized
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public GameEngine(bool initLog = false)
        {
            init(initLog);
        }

        /// <summary>
        /// shuffle the cards. 
        /// </summary>
        /// <returns>a list of 54 cards. has color but disordered.</returns>
        public List<String> Shuffle()
        {
            List<String> cards = EngineValues.Cards;

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            List<String> newList = new List<String>();

            foreach (String card in cards)
            {
                newList.Insert(rand.Next(0, newList.Count), card);
            }

            // need reorder the first element
            newList.Remove(cards[0]);
            newList.Insert(rand.Next(0, newList.Count), cards[0]);

            return newList;
        }

        /// <summary>
        /// deal the cards to 3 parts, 17 cards(such as A*H, BJ, 4*D ...) for each part, another 3 cards will be asigned to the guy who is the landlord.
        /// </summary>
        /// <param name="original_cards">the original cards list, returned by Shuffle method.</param>
        /// <param name="first">the first part</param>
        /// <param name="second">the second part</param>
        /// <param name="third">the third part</param>
        /// <param name="last_cards">the last 3 cards</param>
        /// <returns>true if deal successfully</returns>
        public bool Deal(List<String> original_cards, List<String> first, List<String> second, List<String> third, List<String> last_cards)
        {
            // check if the parameters are valid
            if (original_cards == null 
                || original_cards.Count != 54
                || first == null
                || first.Count != 0
                || second == null
                || second.Count != 0
                || third == null
                || third.Count != 0
                || last_cards == null
                || last_cards.Count != 0)
            {
                return false;
            }

            // simulate player catch the card, everyone has 17 times.
            for (int index = 0; index < 17; index++)
            {
                first.Add(original_cards[index * 3]);
                second.Add(original_cards[index * 3 + 1]);
                third.Add(original_cards[index * 3 + 2]);
            }
            
            // the last 3 cards
            last_cards.Add(original_cards[51]);
            last_cards.Add(original_cards[52]);
            last_cards.Add(original_cards[53]);

            return true;
        }

        /// <summary>
        /// check if the cards is valid
        /// </summary>
        /// <param name="input">the input cards string (from user's side)</param>
        /// <returns>return the CardTypes(list) if the input is valid, return null if invalid. the result is a list because it may match multi types.</returns>
        public List<CardType> Check(List<String> input)
        {
            // format the input, remove color if it has, sort the cards
            String formated_input = EngineTool.FormatCardStr(String.Join("-", input));

            List<CardType> result = new List<CardType>();

            if (EngineValues.DanGe.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.DanGe[formated_input]);
            }

            if (EngineValues.WuLianShun.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.WuLianShun[formated_input]);
            }

            if (EngineValues.LiuLianShun.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.LiuLianShun[formated_input]);
            }

            if (EngineValues.QiLianShun.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.QiLianShun[formated_input]);
            }

            if (EngineValues.BaLianShun.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.BaLianShun[formated_input]);
            }

            if (EngineValues.JiuLianShun.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.JiuLianShun[formated_input]);
            }

            if (EngineValues.ShiLianShun.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.ShiLianShun[formated_input]);
            }

            if (EngineValues.ShiYiLianShun.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.ShiYiLianShun[formated_input]);
            }

            if (EngineValues.ShiErLianShun.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.ShiErLianShun[formated_input]);
            }

            if (EngineValues.DuiZi.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.DuiZi[formated_input]);
            }

            if (EngineValues.SanLianDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SanLianDui[formated_input]);
            }

            if (EngineValues.SiLianDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SiLianDui[formated_input]);
            }

            if (EngineValues.WuLianDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.WuLianDui[formated_input]);
            }

            if (EngineValues.LiuLianDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.LiuLianDui[formated_input]);
            }

            if (EngineValues.QiLianDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.QiLianDui[formated_input]);
            }

            if (EngineValues.BaLianDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.BaLianDui[formated_input]);
            }

            if (EngineValues.JiuLianDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.JiuLianDui[formated_input]);
            }

            if (EngineValues.ShiLianDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.ShiLianDui[formated_input]);
            }

            if (EngineValues.SanZhang.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SanZhang[formated_input]);
            }

            if (EngineValues.FeiJi.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.FeiJi[formated_input]);
            }

            if (EngineValues.SanLianFeiJi.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SanLianFeiJi[formated_input]);
            }

            if (EngineValues.SiLianFeiJi.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SiLianFeiJi[formated_input]);
            }


            if (EngineValues.WuLianFeiJi.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.WuLianFeiJi[formated_input]);
            }


            if (EngineValues.LiuLianFeiJi.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.LiuLianFeiJi[formated_input]);
            }


            if (EngineValues.SanDaiYiGe.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SanDaiYiGe[formated_input]);
            }

            if (EngineValues.FeiJiDaiLianGe.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.FeiJiDaiLianGe[formated_input]);
            }


            if (EngineValues.SanLianFeiJiDaiSanGe.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SanLianFeiJiDaiSanGe[formated_input]);
            }

            if (EngineValues.SiLianFeiJiDaiSiGe.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SiLianFeiJiDaiSiGe[formated_input]);
            }

            if (EngineValues.WuLianFeiJiDaiWuGe.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.WuLianFeiJiDaiWuGe[formated_input]);
            }

            if (EngineValues.SanDaiYiDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SanDaiYiDui[formated_input]);
            }

            if (EngineValues.FeiJiDaiLianDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.FeiJiDaiLianDui[formated_input]);
            }

            if (EngineValues.SanLianFeiJiDaiSanDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SanLianFeiJiDaiSanDui[formated_input]);
            }

            if (EngineValues.SiLianFeiJiDaiSiDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SiLianFeiJiDaiSiDui[formated_input]);
            }

            if (EngineValues.SiDaiLiangGe.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SiDaiLiangGe[formated_input]);
            }

            if (EngineValues.SiDaiLiangDui.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.SiDaiLiangDui[formated_input]);
            }

            if (EngineValues.ZhaDan.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.ZhaDan[formated_input]);
            }

            if (EngineValues.WangZha.ContainsKey(formated_input))
            {
                result.AddRange(EngineValues.WangZha[formated_input]);
            }


            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void init(bool print_log)
        {
            if (IsInitialized)
            {
                return;
            }


            System.Console.WriteLine("game engine is intializing...");

            DateTime start = DateTime.Now;
            // 单张
            EngineValues.DanGe.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 五连顺
            EngineValues.WuLianShun.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 六连顺
            EngineValues.LiuLianShun.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 七连顺
            EngineValues.QiLianShun.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 八连顺
            EngineValues.BaLianShun.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 九连顺
            EngineValues.JiuLianShun.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 十连顺
            EngineValues.ShiLianShun.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 十一连顺
            EngineValues.ShiYiLianShun.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 十二连顺
            EngineValues.ShiErLianShun.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();



            // 对子
            EngineValues.DuiZi.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 三连对
            EngineValues.SanLianDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 四连对
            EngineValues.SiLianDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 五连对
            EngineValues.WuLianDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 六连对
            EngineValues.LiuLianDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 七连对
            EngineValues.QiLianDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 八连对
            EngineValues.BaLianDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 九连对
            EngineValues.JiuLianDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 十连对
            EngineValues.ShiLianDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 三张
            EngineValues.SanZhang.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 飞机
            EngineValues.FeiJi.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 三连飞机 
            EngineValues.SanLianFeiJi.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 四连飞机
            EngineValues.SiLianFeiJi.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 五连飞机
            EngineValues.WuLianFeiJi.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 六连飞机
            EngineValues.LiuLianFeiJi.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 三带一个
            EngineValues.SanDaiYiGe.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 飞机带两个
            EngineValues.FeiJiDaiLianGe.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 三连飞机带三个
            EngineValues.SanLianFeiJiDaiSanGe.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 四连飞机带四个
            EngineValues.SiLianFeiJiDaiSiGe.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 五连飞机带五个
            EngineValues.WuLianFeiJiDaiWuGe.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 三带一对
            EngineValues.SanDaiYiGe.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 飞机带两对
            EngineValues.FeiJiDaiLianDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 三连飞机带三对
            EngineValues.SanLianFeiJiDaiSanDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 四连飞机带四对
            EngineValues.SiLianFeiJiDaiSiDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 四带两个
            EngineValues.SiDaiLiangGe.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 四带两对
            EngineValues.SiDaiLiangDui.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 炸弹
            EngineValues.ZhaDan.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();


            // 王炸
            EngineValues.WangZha.Values.ToList().ForEach((c) =>
            {
                if (print_log)
                    c.ForEach((l) => { System.Console.WriteLine(l.ToString()); });
            });
            System.Console.WriteLine();

            System.Console.WriteLine("cost：" + (DateTime.Now - start).TotalSeconds + " seconds");
            System.Console.WriteLine();

            IsInitialized = true;
        }
    }
}
