using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fucklandlord.engine
{
    /// <summary>
    /// 牌型
    /// </summary>
    public class CardType
    {
        // 牌型关键字（无花色无顺序）
        public String CardKey
        {
            get;set;
        }
        // 牌型权重值
        public int Weight
        {
            get;set;
        }
        // 牌型名
        public String Name
        {
            get;set;
        }
        // 该牌型是否属于炸弹，默认情况下，相同牌型才能比较大小。而炸弹牌型大于任何其他牌型。
        public bool IsBomb
        {
            get;set;
        }

        public override string ToString()
        {
            return "CardKey=>" + CardKey + " Name=>" + Name + " Weight=>" + Weight + " IsBomb=>" + IsBomb;
        }
    }
}