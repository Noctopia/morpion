using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        private String currentPlayer = "X"; //Joueur actuel
        private Button[] buttons; //Tableau des boutons

        public MainPage()
        {
            InitializeComponent();
            buttons = new Button[] { B0, B1, B2, B3, B4, B5, B6, B7, B8 };
        }

        private bool CheckWin()
        {
            int[][] winningCombinations = new int[][]
            {
                new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6, 7, 8},
                new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8}, new int[] { 2, 4, 6 }
            };

            foreach (var combo in winningCombinations)
            {
                if (buttons[combo[0]].Text == currentPlayer &&
                    buttons[combo[1]].Text == currentPlayer &&
                    buttons[combo[2]].Text == currentPlayer)
                {
                    return true;
                }
            }
            return false;
        }

        private void DisableAllButtons()
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = false;
            }
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            foreach (var button in buttons)
            {
                button.Text = "";
                button.IsEnabled = true;
            }
            currentPlayer = "X";
            StatusLabel.Text = "Joueur X commence !";
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button && string.IsNullOrEmpty(button.Text))
            {
                button.Text = currentPlayer;
                button.IsEnabled = false;

                if (CheckWin())
                {
                    StatusLabel.Text = $"🎉 Joueur (currentPlayer) a gagné !";
                    DisableAllButtons();
                    return;
                }

                if (buttons.All (b => !string.IsNullOrEmpty(b.Text)))
                {
                    StatusLabel.Text = "🤝 Match nul !";
                    return;
                }

                currentPlayer = (currentPlayer == "X") ? "O" : "X";
                StatusLabel.Text = $"Tour du joueur (currentPlayer)";
            }
        
        }

    }

}
