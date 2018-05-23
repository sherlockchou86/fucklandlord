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
            #region 输出37种牌型
            DateTime start = DateTime.Now;
            //// 单张
            //EngineValues.DanGe.Values.ToList().ForEach((c) => 
            //    {
            //        System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //    });
            //System.Console.WriteLine();


            //// 五连顺
            //EngineValues.WuLianShun.Values.ToList().ForEach((c) =>
            //    {
            //        System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //    });
            //System.Console.WriteLine();


            //// 六连顺
            //EngineValues.LiuLianShun.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 七连顺
            //EngineValues.QiLianShun.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 八连顺
            //EngineValues.BaLianShun.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 九连顺
            //EngineValues.JiuLianShun.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 十连顺
            //EngineValues.ShiLianShun.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 十一连顺
            //EngineValues.ShiYiLianShun.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 十二连顺
            //EngineValues.ShiErLianShun.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();



            //// 对子
            //EngineValues.DuiZi.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 三连对
            //EngineValues.SanLianDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 四连对
            //EngineValues.SiLianDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 五连对
            //EngineValues.WuLianDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 六连对
            //EngineValues.LiuLianDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 七连对
            //EngineValues.QiLianDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 八连对
            //EngineValues.BaLianDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 九连对
            //EngineValues.JiuLianDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 十连对
            //EngineValues.ShiLianDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 三张
            //EngineValues.SanZhang.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 飞机
            //EngineValues.FeiJi.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 三连飞机 
            //EngineValues.SanLianFeiJi.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 四连飞机
            //EngineValues.SiLianFeiJi.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 五连飞机
            //EngineValues.WuLianFeiJi.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 六连飞机
            //EngineValues.LiuLianFeiJi.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 三带一个
            //EngineValues.SanDaiYiGe.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 飞机带两个
            //EngineValues.FeiJiDaiLianGe.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 三连飞机带三个
            //EngineValues.SanLianFeiJiDaiSanGe.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 四连飞机带四个
            //EngineValues.SiLianFeiJiDaiSiGe.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            // 五连飞机带五个
            EngineValues.WuLianFeiJiDaiWuGe.Values.ToList().ForEach((c) =>
            {
                System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            });
            System.Console.WriteLine();


            //// 三带一对
            //EngineValues.SanDaiYiGe.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 飞机带两对
            //EngineValues.FeiJiDaiLianDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 三连飞机带三对
            //EngineValues.SanLianFeiJiDaiSanDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 四连飞机带四对
            //EngineValues.SiLianFeiJiDaiSiDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 四带两个
            //EngineValues.SiDaiLiangGe.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 四带两对
            //EngineValues.SiDaiLiangDui.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 炸弹
            //EngineValues.ZhaDan.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();


            //// 王炸
            //EngineValues.WangZha.Values.ToList().ForEach((c) =>
            //{
            //    System.Console.WriteLine("牌型=>" + c.CardKey + " 权重值=>" + c.Weight + " 名称=>" + c.Name);
            //});
            //System.Console.WriteLine();

            System.Console.WriteLine("耗时：" + (DateTime.Now - start).TotalSeconds + "秒");
            #endregion

            System.Console.Read();
        }
    }
}
