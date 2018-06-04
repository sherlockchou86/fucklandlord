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
            ucMyBoard1.PlayCard += new PlayCardEventHandler(ucMyBoard1_PlayCard);
            ucOtherBoard1.PlayCard += new PlayCardEventHandler(ucOtherBoard1_PlayCard);
            ucOtherBoard2.PlayCard += new PlayCardEventHandler(ucOtherBoard2_PlayCard);

            // 
            NewGame();
        }

        /// <summary>
        /// 我出牌
        /// </summary>
        /// <param name="cards_str"></param>
        /// <param name="Card_type"></param>
        void ucMyBoard1_PlayCard(List<string> cards_str, CardType card_type)
        {
            // 不要 或者 要不起
            if (cards_str == null || card_type == null)
            {

            }
            else
            {
                List<String> desk_cards = EngineTool.SortWithCardType(cards_str, card_type);
                ucDesk1.updateDesk(desk_cards, card_type.Name);
            }
            ucMyBoard1.IsMyTurn = false;
            ucOtherBoard2.IsMyTurn = true;  //我出完 下家出
        }

        /// <summary>
        /// 下家出牌
        /// </summary>
        /// <param name="cards_str"></param>
        /// <param name="Card_type"></param>
        void ucOtherBoard2_PlayCard(List<string> cards_str, CardType card_type)
        {
            // 不要 或者 要不起
            if (cards_str == null || card_type == null)
            {

            }
            else  
            {
                List<String> desk_cards = EngineTool.SortWithCardType(cards_str, card_type);
                ucDesk1.updateDesk(desk_cards, card_type.Name);
            }
            ucOtherBoard2.IsMyTurn = false;
            ucOtherBoard1.IsMyTurn = true; // 下家出完 上家出
        }

        /// <summary>
        /// 上家出牌
        /// </summary>
        /// <param name="cards_str"></param>
        /// <param name="Card_type"></param>
        void ucOtherBoard1_PlayCard(List<string> cards_str, CardType card_type)
        {
            // 不要 或者 要不起
            if (cards_str == null || card_type == null)
            {

            }
            else
            {
                List<String> desk_cards = EngineTool.SortWithCardType(cards_str, card_type);
                ucDesk1.updateDesk(desk_cards, card_type.Name);
            }

            ucOtherBoard1.IsMyTurn = false;
            ucMyBoard1.IsMyTurn = true; //上家出完 我出
        }


        private void NewGame()
        {
            new Thread(() =>
            {
                this.Invoke((Action)(() => { button1.Visible = false; }));
                if (engine == null)
                {
                    engine = new GameEngine();
                }
                List<String> cards = engine.Shuffle();  //洗牌

                List<String> first = new List<string>();
                List<String> second = new List<string>();
                List<String> third = new List<string>();

                List<String> last_cards = new List<string>();

                engine.Deal(cards, first, second, third, last_cards);  //发牌

                ucLastCards1.UpdateLastCards(last_cards);  //更新底牌

                foreach (string c in third)  // third为我的牌
                {
                    ucMyBoard1.CreateNewCard(c);
                    Thread.Sleep(100);
                }

                ucOtherBoard1.UpdateCards(second);
                ucOtherBoard2.UpdateCards(first);


                // 默认我地主，拿底牌
                foreach (String c in last_cards)
                {
                    ucMyBoard1.CreateNewCard(c);
                }

                ucMyBoard1.IsLandLord = true;
                ucMyBoard1.IsMyTurn = true;

                this.Invoke((Action)(() => { button1.Visible = true; }));
            }).Start();
        }

        /// <summary>
        /// 开始新局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ucMyBoard1.Reset();

            NewGame();
        }
    }
}
