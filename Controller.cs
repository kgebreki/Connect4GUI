using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//Added to serialize game so that we could save/restore
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

/* Kaleb Gebrekirstos 
 * Carrik McNerlin
 * CS 305 Software Models
 * Connect Four GUI
 * 03/20/19
 * This assignment is a continuation of the semester long Connect Four game mod project.
 * The aim of this particular assignment was to develop a Connect Four game by 
 * implementing a user interface (GUI). Furhtermore, special emphasis was given to using
 * an MVC design where the Model, View and Controller were clearly separated.
*/

namespace Connect4GUI
{
    /*CONTROLLER CLASS
     *Handles all the states and events for the statechart   
     */
    class Controller
    {
        const string saveFileName = "Connect4.xml";//path to saved serialized data

        //general constants
        const string saveText = "Save Game";
        const string restoreText = "Restore Game";
        const string boardSizeFileName = "Please enter the board size file name: ";
        const string outOfBnds = "You are out of bounds.";
        const string draw = "The game is a draw. You may start a new game by " +
            "clicking the 'Start New Game' button";
        const string win = "Congratulations, you have won! " +
            "You may start a new game by clicking the 'Start New Game' button";
        const string taken = "Spot has already been taken.";
        public int turn = 1;

        string fileLocation; //string object to reference file location for board size
        string inputFile; //string object to read in the text file to set board


        //State names and state chart state variables
        private enum States
        {
            SetUp, Init, CouldRestore, Restore, StartGame, AltTurns, Play,
            Finish, GameOver, SaveGame, NULL
        };
        private States TopLevelState = States.NULL;
        private States SetUpState = States.NULL;
        private States FinishState = States.NULL;

        //GUI elements that were controlled
        private Button strtNewBtn = null;
        private Button svrstrGameBtn = null;
        private Button submitBtn = null;
        private Label fileLocLbl = null;
        private TextBox fileLocTxtB = null;
        private RadioButton blackRadBtn = null;
        private RadioButton redRadBtn = null;
        private Label displayLbl = null;
        private Label flNotFndLbl = null;
        private Label errorLbl = null;
        private NumericUpDown numRow = null;
        private NumericUpDown numCol = null;

        Game game = new Game();//Game object used to access methods and variables

        //Constructor to grab GUI widgets to control
        public Controller(Button b1, Button b2, Button b3, Label l1, TextBox t1,
            RadioButton r1, RadioButton r2, Label l2, Label l3, Label l4,
            NumericUpDown n1, NumericUpDown n2)
        {
            strtNewBtn = b1;
            svrstrGameBtn = b2;
            submitBtn = b3;
            fileLocLbl = l1;
            fileLocTxtB = t1;
            blackRadBtn = r1;
            redRadBtn = r2;
            displayLbl = l2;
            flNotFndLbl = l3;
            errorLbl = l4;
            numRow = n1;
            numCol = n2;

            //enter initial state
            GoSetupState();
            GoInitState();
        }

        ///////////////////////////// S T A T E S ////////////////////////

        /// <summary>
        /// Each state method has the pattern:
        /// PROLOGUE:
        ///     stateVar = state (repeat as necessary)
        ///     call inner statechart entry (as warranted)
        /// A c t i o n s (as warranted)
        /// EPILOGUE:
        ///     non-event transition call (as warranted)
        /// </summary>

        private void GoSetupState()
        {
            TopLevelState = States.SetUp;
        }

        //Initial state where player enters the board size file and program implicitly
        //checks if saved file from previous game exists
        private void GoInitState()
        {
            SetUpState = States.Init;

            svrstrGameBtn.Enabled = true;
            svrstrGameBtn.Text = restoreText;
            fileLocLbl.Text = boardSizeFileName;

            IfSavedFileTransition();
        }

        private void GoCouldRestoreState()
        {
            SetUpState = States.CouldRestore;

            svrstrGameBtn.Enabled = true;
            svrstrGameBtn.Text = restoreText;

            bool flag = false; //bool variable to check whether board size file is found 

            //Read in board size file and assign value to appropriate variables
            try
            {
                flNotFndLbl.Visible = flag;
                fileLocation = fileLocTxtB.Text;
                StreamReader ifile = new StreamReader(fileLocation);
                inputFile = ifile.ReadLine();
                string[] digits = Regex.Split(inputFile, @"\D+"); //Get all digit sequence as strings
                game.SizeRow = int.Parse(digits[0]);
                game.SizeCol = int.Parse(digits[1]);
                ifile.Close();
            }
            catch (Exception e)
            {
                flag = true;
                flNotFndLbl.Visible = true;
                flNotFndLbl.Text = "File not found. Please try again.";
            }

        }
        //Enable red/black choice
        private void GoNewGameState()
        {
            SetUpState = States.StartGame;

            //Double check that old file doesn't exist
            if (File.Exists(saveFileName))
            {
                File.Delete(saveFileName);
            }
            svrstrGameBtn.Text = saveText;
            svrstrGameBtn.Enabled = true;
            blackRadBtn.Enabled = true;
            redRadBtn.Enabled = true;
            submitBtn.Enabled = false;
            errorLbl.Enabled = false;
            errorLbl.Text = null;

            bool flag = false; //bool variable to check whether board size file is found 

            //Read in board size file and assign value to appropriate variables
            try
            {
                flNotFndLbl.Visible = flag;
                fileLocation = fileLocTxtB.Text;
                StreamReader ifile = new StreamReader(fileLocation);
                inputFile = ifile.ReadLine();
                string[] digits = Regex.Split(inputFile, @"\D+"); //Get all digit sequence as strings
                game.SizeRow = int.Parse(digits[0]);
                game.SizeCol = int.Parse(digits[1]);
                ifile.Close();
            }
            catch (Exception e)
            {
                flag = true;
                flNotFndLbl.Visible = true;
                flNotFndLbl.Text = "File not found. Please try again.";
            }
            Game game2 = new Game();
            game = game2;
            turn = 1;
            game.Initialize();
            UpdateGameDisplay();
        }
        private void GoRestoreState()
        {
            SetUpState = States.Restore;

            Stream saveFile = File.OpenRead(saveFileName);
            SoapFormatter deserializer = new SoapFormatter();
            game = (Game)(deserializer.Deserialize(saveFile));
            saveFile.Close();
            File.Delete(saveFileName);
            svrstrGameBtn.Text = saveText;

            UpdateGameDisplay();
        }
        private void GoAlternateState()
        {
            SetUpState = States.AltTurns;
            submitBtn.Enabled = true;

            if (turn == 1)
            {
                if (blackRadBtn.Checked)
                {
                    game.currPlayer = 'B';
                    blackRadBtn.Enabled = false;
                }
                else if (redRadBtn.Checked)
                {
                    game.currPlayer = 'R';
                    redRadBtn.Enabled = false;
                }
            }
            //give user the option of selecting the appropriate color for their turn
            else if (turn > 1)
            {
                if (blackRadBtn.Checked)
                {
                    if (!redRadBtn.Checked && !redRadBtn.Enabled)
                    {
                        blackRadBtn.Enabled = false;
                        redRadBtn.Enabled = true;
                    }
                }
                else if (redRadBtn.Checked)
                {
                    if (!blackRadBtn.Checked && !blackRadBtn.Enabled)
                    {
                        blackRadBtn.Enabled = true;
                        redRadBtn.Enabled = false;
                    }
                }

            }
        }

        //State to describe playing: alternating turns and inputting row & col values
        private void GoPlayState()
        {
            TopLevelState = States.Play;

            fileLocLbl.Enabled = false;
            fileLocTxtB.Enabled = false;

            game.Row = (int)(numRow.Value - 1);
            game.Col = (int)(numCol.Value - 1);


            //Check for out of bounds first
            if (game.Row > game.SizeRow || game.Col > game.SizeCol)
            {
                //Enable label that tells them out of bounds
                errorLbl.Enabled = true;
                errorLbl.Text = outOfBnds;
                GoAlternateState();
            }
            else
            {
                //Check if spot has already been taken
                if (game.board[game.Row, game.Col] == '_')
                {
                    game.board[game.Row, game.Col] = game.currPlayer;
                    //Check for win
                    if (!game.GameWon())
                    {
                        // All spaces have been used without winner
                        if (turn == game.SizeCol * game.SizeRow)
                        {
                            //Enable label that tells them game is draw
                            UpdateGameDisplay();
                        }
                        //There could still exist a win condition
                        else
                        {
                            UpdateGameDisplay();
                            TurnChangeTransition();
                        }
                    }
                    else if (game.GameWon())
                    {
                        //enable label that displays win, give restart option
                        errorLbl.Enabled = true;
                        errorLbl.Text = win;
                        GameOverTransition();
                    }
                }
                else if (game.board[game.Row, game.Col] != '_')
                {
                    //enable label to show that that spot has been taken, retry
                    errorLbl.Enabled = true;
                    errorLbl.Text = taken;
                    //GoAlternateState();
                }
            }
        }
        private void GoFinishState()
        {
            TopLevelState = States.Finish;
        }
        private void GoGameOverState()
        {
            FinishState = States.GameOver;
            UpdateGameDisplay();
            RestartGameTransition();
        }
        private void GoSaveGameState()
        {
            FinishState = States.SaveGame;

            Stream saveFile = File.Create(saveFileName);
            SoapFormatter serializer = new SoapFormatter();
            serializer.Serialize(saveFile, game);
            saveFile.Close();

            UpdateGameDisplay();
            //allow start over
            RestartGameTransition();
        }

        /////////////////////// E V E N T S //////////////////////
        /// <summary>
        /// public event transition methods
        /// 
        /// Each event determines the state context and if valid calls
        /// the appropriate state method(s)
        /// 
        /// Illegal state/event combos are ignored
        /// </summary>
        public void SubChoiceEvent()
        {
            if (TopLevelState == States.SetUp &&
                (SetUpState == States.Restore || SetUpState == States.AltTurns))
            {
                GoPlayState();
            }
        }
        //Event handler for the radio buttons
        public void AlternateEvent()
        {
            if (TopLevelState == States.SetUp && SetUpState == States.StartGame)
            {
                GoAlternateState();
            }
        }
        public void StrtNewGameEvent()
        {
            if (TopLevelState == States.SetUp &&
                (SetUpState == States.Init || SetUpState == States.CouldRestore ||
                SetUpState == States.AltTurns))
            {
                GoNewGameState();
            }
            if (TopLevelState == States.Play || TopLevelState == States.Finish)
            {
                GoNewGameState();
            }
        }
        public void SvRstrGameEvent()
        {
            IfSavedFileTransition();
            if (TopLevelState == States.SetUp && (SetUpState == States.CouldRestore))
            {
                GoRestoreState();
            }
            if (TopLevelState == States.Play ||
                (TopLevelState == States.SetUp && SetUpState == States.AltTurns))
            {
                GoFinishState();
                GoSaveGameState();
            }
        }
        /////////////////// NON - EVENT TRANSITIONS ////////////////////////
        /// <summary>
        /// These methodes enable transitions that are not associated
        /// with events. They are called after the actions of the state
        /// are completed.
        /// 
        /// Guards should include valid current state check and other
        /// context checks.
        /// </summary>
        private void RestartGameTransition()
        {
            if (TopLevelState == States.Finish)
            {
                GoSetupState();
                GoInitState();
            }
        }
        //Transition state that moves to restore state if condition is satisfied
        private void IfSavedFileTransition()
        {
            //if save file exists, move to next state
            if (File.Exists(saveFileName) && SetUpState == States.Init)
            {
                GoCouldRestoreState();
            }
        }
        private void GameOverTransition()
        {
            if (TopLevelState == States.Play)
            {
                GoFinishState();
                GoGameOverState();
            }
        }
        private void TurnChangeTransition()
        {
            if (TopLevelState == States.Play)
            {
                turn++;//increase turn
                //Switch turns: if former was red, now black and vice versa
                if (redRadBtn.Checked)
                {
                    game.currPlayer = 'B';
                }
                else if (blackRadBtn.Checked)
                {
                    game.currPlayer = 'R';
                }
                GoSetupState();
                GoAlternateState();
            }
        }
        //Transition state that updates the board and displays it 
        private void UpdateGameDisplay()
        {
            int index = 1;
            displayLbl.Text = "    ";
            for (int i = 0; i < game.SizeRow; i++)
            {
                displayLbl.Text = displayLbl.Text + index + "    ";
                index++;
            }
            displayLbl.Text = displayLbl.Text + "\n";
            for (int i = 0; i < game.SizeRow; i++)
            {
                displayLbl.Text = displayLbl.Text + (i + 1) + " ";
                for (int j = 0; j < game.SizeCol; j++)
                {
                    displayLbl.Text = displayLbl.Text + "[" + game.board[i, j] + "]  ";
                }
                displayLbl.Text = displayLbl.Text + "\n"; ;
            }
        }
    }
}
