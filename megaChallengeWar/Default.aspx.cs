using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cards;

namespace megaChallengeWar
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void beginButton_Click(object sender, EventArgs e)
        {
            Game game = new Game("Frank", "Jim");
            resultLabel.Text = game.Play();           
        }
    }
}