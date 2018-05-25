using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fucklandlord.engine;

namespace fucklandlord.test
{
    /// <summary>
    /// 测试
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine engine = new GameEngine();

            // 输入手牌，检查牌型
            List<CardType> cards = engine.Check(new List<string> {"K*H", "Q*S", "K*C", "K*D", "Q*C", "Q*D", "K*H", "Q*S", "J*S", "J*H", "BJ", "J*D" });

            if (cards != null)
            {
                cards.ForEach((c) => { System.Console.WriteLine(c.ToString()); });
            }
            else
            {
                System.Console.WriteLine("无效牌型");
            }


            // 洗牌
            List<String> new_cards = engine.Shuffle();
            System.Console.WriteLine("洗牌结果"); 
            new_cards.ForEach((s) => { System.Console.Write(s + " "); });



            // 发牌
            List<String> first = new List<string>();  //第一个人的牌
            List<String> second = new List<string>();  //第二个人的牌
            List<String> third = new List<string>();  //第三个人的牌
            List<String> last_cards = new List<string>();  //三张底牌

            engine.Deal(new_cards, first, second, third, last_cards);

            System.Console.WriteLine("发牌结果"); 
            System.Console.WriteLine("第一个人的牌："); 
            first.ForEach((s) => { System.Console.Write(s + " "); });


            System.Console.WriteLine(""); 
            System.Console.WriteLine("第二个人的牌：");
            second.ForEach((s) => { System.Console.Write(s + " "); });

            System.Console.WriteLine(""); 
            System.Console.WriteLine("第三个人的牌：");
            third.ForEach((s) => { System.Console.Write(s + " "); });

            System.Console.WriteLine(""); 
            System.Console.WriteLine("三张底牌：");
            last_cards.ForEach((s) => { System.Console.Write(s + " "); });

            System.Console.Read();
        }
    }
}
