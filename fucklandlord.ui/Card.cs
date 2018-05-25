using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using fucklandlord.engine;

namespace fucklandlord.ui
{
    class Card
    {
        public static int LeftShow = 18;

        public static int Width = 110;

        public static int Height = 150;

        public static int SelectedShow = 15;

        private static List<Bitmap> all_images = new List<Bitmap> {
            Properties.Resources._3_of_diamonds, Properties.Resources._3_of_clubs, Properties.Resources._3_of_hearts, Properties.Resources._3_of_spades,
            Properties.Resources._4_of_diamonds, Properties.Resources._4_of_clubs, Properties.Resources._4_of_hearts, Properties.Resources._4_of_spades,
            Properties.Resources._5_of_diamonds, Properties.Resources._5_of_clubs, Properties.Resources._5_of_hearts, Properties.Resources._5_of_spades,
            Properties.Resources._6_of_diamonds, Properties.Resources._6_of_clubs, Properties.Resources._6_of_hearts, Properties.Resources._6_of_spades,
            Properties.Resources._7_of_diamonds, Properties.Resources._7_of_clubs, Properties.Resources._7_of_hearts, Properties.Resources._7_of_spades,
            Properties.Resources._8_of_diamonds, Properties.Resources._8_of_clubs, Properties.Resources._8_of_hearts, Properties.Resources._8_of_spades,
            Properties.Resources._9_of_diamonds, Properties.Resources._9_of_clubs, Properties.Resources._9_of_hearts, Properties.Resources._9_of_spades,
            Properties.Resources._10_of_diamonds, Properties.Resources._10_of_clubs, Properties.Resources._10_of_hearts, Properties.Resources._10_of_spades,
            Properties.Resources.jack_of_diamonds, Properties.Resources.jack_of_clubs, Properties.Resources.jack_of_hearts, Properties.Resources.jack_of_spades,
            Properties.Resources.queen_of_diamonds, Properties.Resources.queen_of_clubs, Properties.Resources.queen_of_hearts, Properties.Resources.queen_of_spades,
            Properties.Resources.king_of_diamonds, Properties.Resources.king_of_clubs, Properties.Resources.king_of_hearts, Properties.Resources.king_of_spades,
            Properties.Resources.ace_of_diamonds, Properties.Resources.ace_of_clubs, Properties.Resources.ace_of_hearts, Properties.Resources.ace_of_spades,
            Properties.Resources._2_of_diamonds, Properties.Resources._2_of_clubs, Properties.Resources._2_of_hearts, Properties.Resources._2_of_spades,
            Properties.Resources.black_joker, Properties.Resources.red_joker
        };

        private String card_value;
        /// <summary>
        /// 卡牌值  带花色 如红桃A（A*H）
        /// </summary>
        public String CardValue
        {
            get
            {
                return card_value;
            }
            set
            {
                card_value = value;

                Image = all_images[EngineTool.IndexOfCard(card_value, true)];
            }
        }

        /// <summary>
        /// 该张卡牌对应的图片
        /// </summary>
        public Bitmap Image
        {
            get;
            set;
        }

        /// <summary>
        /// 左上角X坐标
        /// </summary>
        public int X
        {
            get;
            set;
        }

        /// <summary>
        /// 左上角Y坐标
        /// </summary>
        public int Y
        {
            get;
            set;
        }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Selected
        {
            get;
            set;
        }

        /// <summary>
        /// 区域
        /// </summary>
        public Rectangle Region
        {
            get
            {
                return new Rectangle(X, Y, Width, Height);
            }
        }

        /// <summary>
        /// 卡牌绘制
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public void Draw(Graphics g)
        {
            if (Selected)
            {
                g.DrawImage(Image, new Rectangle(X, Y - SelectedShow, Width, Height));
            }
            else
            {
                g.DrawImage(Image, new Rectangle(X, Y, Width, Height));
            }
        }
    }
}
