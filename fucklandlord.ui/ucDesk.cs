using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fucklandlord.engine;

namespace fucklandlord.ui
{
    public partial class ucDesk : UserControl
    {
        private List<String> cards_str = new List<string>();

        public ucDesk()
        {
            InitializeComponent();

            SetStyle(
                 ControlStyles.OptimizedDoubleBuffer
                 | ControlStyles.ResizeRedraw
                 | ControlStyles.AllPaintingInWmPaint
                 | ControlStyles.UserPaint,
                 true);  
        }

        public void updateDesk(List<String> new_cards_str, String new_card_type_name)
        {
            cards_str.Clear();
            cards_str.AddRange(new_cards_str);

            label1.Text = new_card_type_name;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (cards_str.Count == 0)
            {
                return;
            }

            int total_card_width = (cards_str.Count - 1) * Card.LeftShow + Card.Width;

            int start_x = (this.Width - total_card_width) / 2;
            int start_y = (this.Height - Card.Height) / 2 - 20;


            for (int i = 0; i < cards_str.Count; ++i)
            {
                e.Graphics.DrawImage(Card.all_images[EngineTool.IndexOfCard(cards_str[i], true)], start_x + Card.LeftShow * i, start_y, (int)(Card.Width * 0.9), (int)(Card.Height * 0.9));
            }


        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Invalidate();
        }
    }
}
