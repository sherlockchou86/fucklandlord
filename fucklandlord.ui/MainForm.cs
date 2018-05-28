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
        public static GameEngine engine;
        public MainForm()
        {
            InitializeComponent();


            new Thread(() => {

                engine = new GameEngine();
                List<String> cards = engine.Shuffle();  //洗牌

                List<String> first = new List<string>();
                List<String> second = new List<string>();
                List<String> third = new List<string>();

                List<String> last_cards = new List<string>();

                engine.Deal(cards, first, second, third, last_cards);  //发牌

                foreach (string c in third)  // third为我的牌
                {
                    ucMyBoard1.CreateNewCard(c);
                    Thread.Sleep(100);
                }
            }).Start();
        }
    }
}
