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
        private bool is_landlord = false;

        private int rest_time = 30;

        private List<String> cards = new List<string>() { "A*D","A*S","A*C"};

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
    }
}
