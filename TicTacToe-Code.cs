class program
{

    //new game class
    class ticTacToe
    {
        bool endOfGame;
        char[] gamePosition;
        char turn;
        int turnsPlayed;



        //start a constructor method determining whether the game is still in progress, populate the position array and start the turn
        public ticTacToe()
        {
            endOfGame = false;
            gamePosition = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', };

            turn = 'X';
            turnsPlayed = 0;

        }


        //call game functions if the game is still running
        public void Start()
        {
            while (endOfGame == false)
            {
                renderTable();
                readUsersChoice();
                renderTable();
                verifyEndOfGame();
                changeTurn();
            }
        }

        //clear screen and display game layout
        private void renderTable()
        {
            Console.Clear();
            Console.WriteLine(tableLayout());
        }

        //create game layout
        private string tableLayout()
        {
            return $"__{gamePosition[0]}__|__{gamePosition[1]}__|__{gamePosition[2]}__\n" +
                   $"__{gamePosition[3]}__|__{gamePosition[4]}__|__{gamePosition[5]}__\n" +
                   $"  {gamePosition[6]}  |  {gamePosition[7]}  |  {gamePosition[8]}  \n";
        }

        //prompt user to chose position
        private void readUsersChoice()
        {
            Console.Write("{0}, select the number of the position you want to play: ", turn);
            int answer = int.Parse(Console.ReadLine());

            while (answer < 1 || answer > 9 || validateUsersChoice(answer) == true)
            {
                Console.Write("Please choose a valid position: ");
                answer = int.Parse(Console.ReadLine());
            }

            changeChosenPosition(answer);

        }

        //validate if the position hasn't been selected
        private bool validateUsersChoice(int positionChosen)
        {
            int index = positionChosen - 1;
            if (gamePosition[index] == 'O' || gamePosition[index] == 'X')
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //change the chosen position to symbol
        private void changeChosenPosition(int positionChosen)
        {
            int index = positionChosen - 1;
            gamePosition[index] = turn;
            turnsPlayed++;
        }


        //verify if there is a winner
        private void verifyEndOfGame()
        {
            if (turnsPlayed < 5)
            {
                return;
            }

            if (victoryDiagonal() || victoryHorizontal() || victoryVertical())
            {
                endOfGame = true;
                Console.WriteLine("End of game! {0} wins", turn);
            }
            else
            if (turnsPlayed == 9)
            {
                endOfGame = true;
                Console.WriteLine("End of game! Tie.");
            }
        }

        //verify horizontal win
        private bool victoryHorizontal()
        {
            if (gamePosition[0] == gamePosition[1] && gamePosition[0] == gamePosition[2])
            {
                return true;
            }
            else if (gamePosition[3] == gamePosition[4] && gamePosition[3] == gamePosition[5])
            {
                return true;
            }
            else if (gamePosition[6] == gamePosition[7] && gamePosition[6] == gamePosition[8])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //verify vertical win
        private bool victoryVertical()
        {
            if (gamePosition[0] == gamePosition[3] && gamePosition[0] == gamePosition[6])
            {
                return true;
            }
            else if (gamePosition[1] == gamePosition[4] && gamePosition[1] == gamePosition[7])
            {
                return true;
            }
            else if (gamePosition[2] == gamePosition[5] && gamePosition[2] == gamePosition[8])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //verify diagonal win
        private bool victoryDiagonal()
        {
            if (gamePosition[0] == gamePosition[4] && gamePosition[0] == gamePosition[8])
            {
                return true;
            }
            else if (gamePosition[2] == gamePosition[4] && gamePosition[2] == gamePosition[6])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //change player
        private void changeTurn()
        {
            turn = turn == 'X' ? 'O' : 'X';

        }


    }

    //instantiate class
    static void Main(string[] args)
    {
        new ticTacToe().Start();
    }
}
