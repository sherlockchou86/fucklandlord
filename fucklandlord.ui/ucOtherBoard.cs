using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fucklandlord.ui
{
    public partial class ucOtherBoard : UserControl
    {
        private int rest_time = 30;

        private List<String> cards = new List<string>();

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

        public ucOtherBoard()
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
        /// 
        /// </summary>
        /// <param name="new_cards"></param>
        public void UpdateCards(List<String> new_cards)
        {
            cards.Clear();
            cards.AddRange(new_cards);

            Invalidate();
        }

        public void Reset()
        {
            IsMyTurn = false;
            IsLandLord = false;

            cards.Clear();

            Invalidate();
        }

        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawBacks(e.Graphics);
        }


        private void DrawBacks(Graphics g)
        {
            int count = cards.Count;
            if (count == 0)
            {
                return;
            }

            if (count > 2)
            {
                count = 5;
            }

            int total_height = (count - 1) * Card.BackTopShow + Card.Height;
            int start_x = (this.Width - Card.Width) / 2;
            int start_y = (this.Height - total_height) / 2;

            for (int i = 0; i < count; ++i)
            {
                g.DrawImage(Properties.Resources.back, new Rectangle(start_x, start_y + i * Card.BackTopShow, Card.Width, Card.Height));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsMyTurn)
            {
                label1.Visible = true;
                label1.Text = (rest_time--).ToString();
                Invalidate();
            }
            else
            {
                label1.Visible = false;
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
    }
}
