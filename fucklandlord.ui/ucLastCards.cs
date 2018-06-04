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
    public partial class ucLastCards : UserControl
    {
        private List<String> cards = new List<string>();

        public ucLastCards()
        {
            InitializeComponent();
            SetStyle(
                 ControlStyles.OptimizedDoubleBuffer
                 | ControlStyles.ResizeRedraw
                 | ControlStyles.AllPaintingInWmPaint
                 | ControlStyles.UserPaint,
                 true);  
        }

        public void UpdateLastCards(List<String> new_last_cards)
        {
            cards.Clear();
            cards.AddRange(new_last_cards);

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(Pens.Azure, new Rectangle(0,0,this.Width, this.Height));

            int width = 50;
            int height = 70;

            int space = 5;

            int total_width = width * 3 + space * 2;

            int start_x = (this.Width - total_width) / 2;
            int start_y = (this.Height - height) / 2;

            for (int i = 0; i < cards.Count; ++i)
            {
                e.Graphics.DrawImage(Card.all_images[EngineTool.IndexOfCard(cards[i], true)], start_x + i * (space + width), start_y, width, height);
            }
        }
    }
}
