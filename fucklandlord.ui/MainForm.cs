using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using fucklandlord.engine;

namespace fucklandlord.ui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            new Thread(() => {

                GameEngine engine = new GameEngine();
                List<String> cards = engine.Shuffle();

                foreach (string c in cards)
                {
                    ucMyBoard1.CreateNewCard(c);
                    Thread.Sleep(100);
                }
            }).Start();
        }
    }
}
