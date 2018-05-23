using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fucklandlord.engine
{
    /// <summary>
    /// 牌型名称  一共37种牌型
    /// </summary>
    public class CardName
    {
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
    }
}