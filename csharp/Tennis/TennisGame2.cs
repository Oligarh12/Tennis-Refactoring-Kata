namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Points;
        private int player2Points;

        private string player1Result = "";
        private string player2Result = "";
        private string player1Name;
        private string player2Name;

        private enum Score
        {
            Love = 0,
            Fifteen = 1,
            Thirty = 2,
            Forty = 3
        }

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            if (player1Points == player2Points && player1Points < 3)
            {
                if (player1Points == 0)
                    score = Score.Love;
                if (player1Points == 1)
                    score = Score.Fifteen;
                if (player1Points == 2)
                    score = Score.Thirty;
                score += "-All";
            }
            if (player1Points == player2Points && player1Points > 2)
                score = "Deuce";

            if (player1Points > 0 && player2Points == 0)
            {
                if (player1Points == 1)
                    player1Result = Score.Fifteen;
                if (player1Points == 2)
                    player1Result = Score.Thirty;
                if (player1Points == 3)
                    player1Result = Score.Forty;

                player2Result = Score.Love;
                score = player1Result + "-" + player2Result;
            }
            if (player2Points > 0 && player1Points == 0)
            {
                if (player2Points == 1)
                    player2Result = Score.Fifteen;
                if (player2Points == 2)
                    player2Result = Score.Thirty;
                if (player2Points == 3)
                    player2Result = Score.Forty;

                player1Result = Score.Love;
                score = player1Result + "-" + player2Result;
            }

            if (player1Points > player2Points && player1Points < 4)
            {
                if (player1Points == 2)
                    player1Result = Score.Thirty;
                if (player1Points == 3)
                    player1Result = Score.Forty;
                if (player2Points == 1)
                    player2Result = Score.Fifteen;
                if (player2Points == 2)
                    player2Result = Score.Thirty;
                score = player1Result + "-" + player2Result;
            }
            if (player2Points > player1Points && player2Points < 4)
            {
                if (player2Points == 2)
                    player2Result = Score.Thirty;
                if (player2Points == 3)
                    player2Result = Score.Forty;
                if (player1Points == 1)
                    player1Result = Score.Fifteen;
                if (player1Points == 2)
                    player1Result = Score.Thirty;
                score = player1Result + "-" + player2Result;
            }

            if (player1Points > player2Points && player2Points >= 3)
            {
                score = "Advantage player1";
            }

            if (player2Points > player1Points && player1Points >= 3)
            {
                score = "Advantage player2";
            }

            if (player1Points >= 4 && player2Points >= 0 && (player1Points - player2Points) >= 2)
            {
                score = "Win for player1";
            }
            if (player2Points >= 4 && player1Points >= 0 && (player2Points - player1Points) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            player1Points++;
        }

        private void P2Score()
        {
            player2Points++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

