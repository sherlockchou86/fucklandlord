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

        public bool IsLandLord { get; set; }

        private bool isMyTurn = false;
        public bool IsMyTurn 
        {
            get
            {
                return isMyTurn;
            }
            set
            {
                isMyTurn = value;
                rest_time = 30;
            }
        }

        public event PlayCardEventHandler PlayCard;

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
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            IsMyTurn = false;
            IsLandLord = false;
            cards.Clear();

            updateCardsLocation();
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

            // 选牌
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

            // 出牌
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (PlayCard != null && IsMyTurn)
                {
                    List<String> ls = new List<string>();
                    foreach (Card c in cards)
                    {
                        if (c.Selected)
                        {
                            ls.Add(c.CardValue);
                        }
                    }

                    // 检查牌型
                    List<CardType> types = MainForm.engine.Check(ls);

                    // 有效牌型
                    if (types != null)
                    {
                        if (types.Count == 1)
                        {
                            PlayCard(ls, types[0]);
                        }
                        else
                        {
                            using (CardTypeChoose ctc = new CardTypeChoose(types))
                            {
                                if (ctc.ShowDialog() == DialogResult.OK)
                                {
                                    PlayCard(ls, ctc.Type);
                                }
                            }
                        }

                        cards.RemoveAll((c) => { return ls.Contains(c.CardValue); });

                        updateCardsLocation();
                    }
                }
            }
        }


        Card current_card = null;
        /// <summary>
        /// 鼠标移动，批量选牌
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                for (int i = cards.Count - 1; i >= 0; --i )
                {
                    if (cards[i].Region.Contains(e.Location) && current_card != cards[i])
                    {
                        current_card = cards[i];
                        cards[i].Selected = !cards[i].Selected;
                        Invalidate();
                        break;
                    }

                    if (cards[i].Region.Contains(e.Location))
                    {
                        break;
                    }
                }

                Application.DoEvents();
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

            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() => { Invalidate(); }));
            }
            else
            {
                Invalidate();
            }
        }

        /// <summary>
        /// 计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsMyTurn)
            {
                label1.Visible = true;
                button1.Visible = true;
                label1.Text = (rest_time--).ToString();
                Invalidate();
            }
            else
            {
                label1.Visible = false;
                button1.Visible = false;
            }

            if (rest_time == 0)
            {
                // 自动出牌
                if (PlayCard != null)
                {
                    PlayCard(null, null);
                }
            }
        }

        /// <summary>
        /// 过牌  或者 要不起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (PlayCard != null)
            {
                PlayCard(null, null);
            }
        }
    }
}
