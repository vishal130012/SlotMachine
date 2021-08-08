using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SlotMachine
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                double playersMoney = 100;
                ViewState.Add("money", playersMoney);
                printPlayerCurrentMoney(playersMoney);
                string[] images = getAllImages();
                displayImages(images);
            }
        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            double betMoney = 0;
            double currentRoundResult = 0;
            if (betTextBox.Text.Trim().Length == 0) return;
            if (!double.TryParse(betTextBox.Text, out betMoney)) return;
            string[] images = getAllImages();
            displayImages(images);
            bool isJackPot = isJackpot(images);
            bool isBarThere = isBar(images);
            int cherryCount = checkCherry(images);
            currentRoundResult = calculateRoundresult(isJackPot, isBarThere,
             cherryCount, betMoney);
            displayRoundResult(currentRoundResult, betMoney);
            double playersMoney = (double)ViewState["money"];
            playersMoney = playersMoney + currentRoundResult;
            ViewState.Add("money", playersMoney);
            printPlayerCurrentMoney(playersMoney);
            betTextBox.Text = "";
        }
        public string getRamdonImage()
        {
            string[] images = new string[] {"Bar.png","Bell.png","Cherry.png","Clover.png","Diamond.png",
            "HorseShoe.png","Lemon.png","Orange.png","Plum.png","Seven.png","Strawberry.png","Watermellon.png"};
            string image =  images[random.Next(0, 12)];
            return image;
        }
        public string[] getAllImages()
        {
            string[] images = new string[] { getRamdonImage() ,
                getRamdonImage() , getRamdonImage()};
            return images;
        }
        public void displayImages(string[] images)
        {
            Image1.ImageUrl = "/Images/" + images[0];
            Image2.ImageUrl = "/Images/" + images[1];
            Image3.ImageUrl = "/Images/" + images[2];
        }
        public bool isJackpot(string[] images)
        {
            if (images[0] != "Seven.png") return false;
            if (images[1] != "Seven.png") return false;
            if (images[2] != "Seven.png") return false;
                return true;
        }
        public bool isBar(string[] images)
        {
            if (images[0] == "Bar.png" || images[1] == "Bar.png"
                 || images[2] == "Bar.png")
                return true;
            else return false;
        }
        public int checkCherry(string[] images)
        {
            int[] results = new int[3];
            results[0] = images[0] == "Cherry.png" ? 1 : 0;
            results[1] = images[1] == "Cherry.png" ? 1 : 0;
            results[2] = images[2] == "Cherry.png" ? 1 : 0;
            int result = results.Sum();
            return result;
        }
        public double calculateRoundresult(bool isJackPot, bool isBarThere, 
            int cherryCount, double betMoney)
        {
            if(isJackPot == true)
            {
                return betMoney * 100;
            }
            else if(isBarThere == true)
            {
                return -betMoney;
            }
            else if(cherryCount == 1)
            {
                return betMoney * 2;
            }
            else if (cherryCount == 2)
            {
                return betMoney * 3;
            }
            else if (cherryCount == 3)
            {
                return betMoney * 4;
            }
            else
            {
                return -betMoney;
            }
            
        }
        public void displayRoundResult(double currentRoundResult, double betMoney)
        {
            if(currentRoundResult > 0)
                resultLabel.Text = string.Format("You bet {0:C} and won {1:C}",
                 betMoney, currentRoundResult);
            else
                resultLabel.Text = string.Format("You bet {0:C} and lost {1:C}",
                 betMoney, betMoney);
        }
        public void printPlayerCurrentMoney(double playersMoney)
        {
            playerMoneyLabel.Text = string.Format("Players Money: {0:C}", playersMoney);

        }
     
    }
}