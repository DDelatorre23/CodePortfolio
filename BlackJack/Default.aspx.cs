using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //instance variables
    private Dealer dealer;
    private Player player;
    const int MAXCARDS = 8;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //object instanttations for dealer and player if its the first 
            //page load
            dealer = new Dealer();
            player = new Player();

            StartGame();

            Session["dealer"] = dealer;
            Session["player"] = player;

            UpdateForm();
        }
        else
        {
            dealer = (Dealer)Session["dealer"];
            player = (Player)Session["player"];

            UpdateForm();
        }
    }

    private void StartGame()
    {
        dealer.Hit(dealer.Deal());
        dealer.Hit(dealer.Deal());
        player.Hit(dealer.Deal());
        player.Hit(dealer.Deal());
    }

    //This method returns a image control at a selected index depending on the player
    private Image GetImage (string player, int imageIndex)
    {
        Image img = (Image)this.FindControl(player + "Image" + imageIndex);
        return img;
    }

    private void UpdateForm()
    {
        //This part of the method is for reseting the table to show only 2 starting cards
        if(dealer.NumCards == 2)
        {
            if(player.NumCards == 2)
            {
                for(int i = 2; i < MAXCARDS; i++)
                {
                    GetImage("player", i + 1).Visible = false;
                    GetImage("dealer", i + 1).Visible = false;
                }
            }
        }
        //the following loops set the images to the correct image control
        for (int d = 0; d < dealer.NumCards; d++)
        {
            Image dealerImg = GetImage("dealer", d + 1);
            if (dealer.NumCards == 2 && d == 1 && !dealer.IsStand)
            {
                dealerImg.ImageUrl = "Images/Cards/black_back.jpg";
            }
            else
            {
                dealerImg.ImageUrl = "Images/Cards/" + dealer.GetCard(d).FileName;
                dealerImg.Visible = true;
            }
        }

        for(int p = 0; p < player.NumCards; p++)
        {
            Image playerImg = GetImage("player", p + 1);
            playerImg.ImageUrl = "Images/Cards/" + player.GetCard(p).FileName;
            playerImg.Visible = true;
        }
    }

    //shows who won the game
    private void DisplayWinner()
    {
        if (player.IsStand || player.IsBusted)
        {
            if (dealer.IsWinner(player))
            {
                results.Text = "The house wins!";
            }
            else
            {
                results.Text = "Player wins!";
            }
        }
    }

    //Button click event to hit
    protected void hitButton_Click(object sender, EventArgs e)
    {
        if (player.CanHit())
        {
            player.Hit(dealer.Deal());
            UpdateForm();
            playerScore.Text = player.Score.ToString();
            DisplayWinner();

            if (player.IsBusted)
            {
                playerScore.Text = player.Score.ToString();
                standButton.Enabled = false;
                hitButton.Enabled = false;
                DisplayWinner();
            }
        }
    }

    protected void standButton_Click(object sender, EventArgs e)
    {
        player.Stand();
        hitButton.Enabled = false;
        standButton.Enabled = false;

        playerScore.Text = player.Score.ToString();

        dealer.Play();
        dealerScore.Text = dealer.Score.ToString();
 
        UpdateForm();

        DisplayWinner();
    }

    protected void newGameButton_Click(object sender, EventArgs e)
    {
        player.Reset();
        dealer.Reset();
        hitButton.Enabled = true;
        standButton.Enabled = true;
        results.Text = "";
        playerScore.Text = "00";
        dealerScore.Text = "00";
        StartGame();

        UpdateForm();

    }
}