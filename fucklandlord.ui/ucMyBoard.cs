using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fucklandlord.engine;
using fucklandlord.ui.Properties;

namespace fucklandlord.ui
{
    public partial class ucMyBoard : UserControl
    {
        private List<Card> cards = new List<Card>();

        private int rest_time = 30;

        private bool is_landlord = false;

        public ucMyBoard()
        {
            InitializeComponent();

            SetStyle(
                     ControlStyles.OptimizedDoubleBuffer
                     | ControlStyles.ResizeRedraw
                     | ControlStyles.AllPaintingInWmPaint
                     | ControlStyles.UserPaint,
                     true);  
        }

        /// <summary>
        /// 抓一张新牌（发牌阶段使用）
        /// </summary>
        /// <param name="card_str"></param>
        public void CreateNewCard(String card_str)
        {
            Card c = new Card() { CardValue = card_str, Selected = false };

            if (cards.Count == 0)
            {
                cards.Add(c);
            }
            else
            {
                bool inserted = false;
                for (int i = 0; i < cards.Count; ++i)
                {
                    if (EngineTool.IndexOfCard(card_str, true) > EngineTool.IndexOfCard(cards[i].CardValue, true))
                    {
                        cards.Insert(i, c);
                        inserted = true;
                        break;
                    }
                }

                if (!inserted)
                {
                    cards.Insert(cards.Count - 1, c);
                }
            }

            updateCardsLocation();

            if (this.InvokeRequired)
            {
                this.Invoke((Action)(()=>{ Invalidate();}));
            }
            else
            {
                Invalidate();
            }
            
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawCards(e.Graphics);
        }

        /// <summary>
        /// 鼠标点击，左键选择卡牌，右键出牌
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                for (int i = cards.Count - 1; i >= 0; i--)
                {
                    if (cards[i].Region.Contains(e.Location))
                    {
                        cards[i].Selected = !cards[i].Selected;
                        Invalidate();
                        break;
                    }
                }
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

            }
        }

        /// <summary>
        /// 界面尺寸改变时，重新计算大小
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            updateCardsLocation();
            base.OnResize(e);
        }

        /// <summary>
        /// 绘制卡牌
        /// </summary>
        /// <param name="g"></param>
        private void DrawCards(Graphics g)
        {
            int count = cards.Count;
            for (int i = 0; i < count; ++i)
            {
                cards[i].Draw(g);
            }
        }

        /// <summary>
        /// 绘制界面其他元素
        /// </summary>
        /// <param name="g"></param>
        private void DrawOthers(Graphics g)
        {

        }

        /// <summary>
        /// 更新界面每张卡牌坐标
        /// </summary>
        private void updateCardsLocation()
        {
            if (cards.Count == 0)
            {
                return;
            }

            int total_card_width = (cards.Count - 1) * Card.LeftShow + Card.Width;

            int start_x = (this.Width - total_card_width) / 2;
            int start_y = (this.Height - Card.Height) / 2;

            for (int i = 0; i < cards.Count; ++i)
            {
                cards[i].Y = start_y;
                cards[i].X = start_x + Card.LeftShow * i;
            }
        }
    }
}
