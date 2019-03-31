using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Kaleb Gebrekirstos
 * Carrik McNerlin
 */
namespace Connect4GUI
{
    //View Class
    public partial class Form1 : Form
    {
        Controller ctrl = null;

        public Form1()
        {
            InitializeComponent();
            ////passing widgets to be controlled into the controller
            ctrl = new Controller(strtNew, svrstrGame, submitBtn, fileLocLbl, fileLocTxtB,
                blackRadBtn, redRadBtn, displayLbl, flNotFndLbl, errorLbl, numRow, numCol);
        }

        ///////////////Events from the GUI////////////////////////
        private void submitBtn_Click(object sender, EventArgs e)
        {
            ctrl.SubChoiceEvent();
        }

        private void blackRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            ctrl.AlternateEvent();
        }

        private void redRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            ctrl.AlternateEvent();
        }

        private void strtNewBtn_Click(object sender, EventArgs e)
        {
            ctrl.StrtNewGameEvent();
        }

        private void svrstrGameBtn_Click(object sender, EventArgs e)
        {
            ctrl.SvRstrGameEvent();
        }
    }
}