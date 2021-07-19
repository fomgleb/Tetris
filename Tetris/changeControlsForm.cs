using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class ChangeControlsForm : Form
    {
        TextBox[] textBoxes;

        public ChangeControlsForm()
        {
            InitializeComponent();

            textBoxes = new TextBox[4] { leftTextBox, rightTextBox, downTextBox, rotateTextBox };
        }

        private void Keyboard_KeyDown(object sender, KeyEventArgs e)
        {
            var selectedTextBox = (TextBox)sender;

            switch (selectedTextBox.Name)
            {
                case "leftTextBox": Properties.Settings.Default.leftButton = e.KeyCode.ToString(); break;
                case "rightTextBox": Properties.Settings.Default.rightButton = e.KeyCode.ToString(); break;
                case "downTextBox": Properties.Settings.Default.downButton = e.KeyCode.ToString(); break;
                case "rotateTextBox": Properties.Settings.Default.rotateButton = e.KeyCode.ToString(); break;
            }
            Properties.Settings.Default.Save();

            UpdateTextBoxes();
        }

        private void ChangeControlsForm_Load(object sender, EventArgs e)
        {
            UpdateTextBoxes();
        }

        private void UpdateTextBoxes()
        {
            leftTextBox.Text = Properties.Settings.Default.leftButton;
            rightTextBox.Text = Properties.Settings.Default.rightButton;
            downTextBox.Text = Properties.Settings.Default.downButton;
            rotateTextBox.Text = Properties.Settings.Default.rotateButton;
        }
    }
}
