using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fucklandlord.engine;

namespace fucklandlord.ui
{
    public partial class CardTypeChoose : Form
    {
        public CardType Type { get; set; }
        public CardTypeChoose(List<CardType> types)
        {
            InitializeComponent();

            List<RadioButton> rs = new List<RadioButton> { radioButton1, radioButton2, radioButton3, radioButton4 };
            for (int i = 0; i < types.Count; ++i)
            {
                rs[i].Text = types[i].CardKey;
                rs[i].Tag = types[i];
            }

            foreach (RadioButton r in rs)
            {
                if (r.Tag == null)
                {
                    r.Visible = false;
                }
            }

            rs[0].Checked = true;
            Type = rs[0].Tag as CardType;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Tag != null)
            {
                Type = (sender as RadioButton).Tag as CardType;
            }
        }
    }
}
