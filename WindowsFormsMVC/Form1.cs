using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMVC
{
    delegate void TextBox_SetText();

    public partial class Form1 : Form
    {
        event TextBox_SetText SetText;

        public Form1()
        {
            SetText += new TextBox_SetText(TextBox_Start_SetText);
            SetText += new TextBox_SetText(TextBox_End_SetText);
            SetText += new TextBox_SetText(TextBox_Length_SetText);

            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32(((TextBox)sender).Tag);
            LengthModel_Ctrl model_Ctrl = 
                LengthModel_Factory.CreateCtrl((LengthType)tag);
            Console.WriteLine(Convert.ToInt32(((TextBox)sender).Text));
            model_Ctrl.SetData(Convert.ToInt32(((TextBox)sender).Text));

            SetText();
        }

        void TextBox_Start_SetText()
        {
            textBoxStart.Text = LengthModel.GetModel(LengthType.start).Value.ToString();
        }

        void TextBox_End_SetText()
        {
            textBoxEnd.Text = LengthModel.GetModel(LengthType.end).Value.ToString();
        }

        void TextBox_Length_SetText()
        {
            textBoxLength.Text = LengthModel.GetModel(LengthType.length).Value.ToString();
        }

    }
}
