using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoserToDazShapesExporter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnClickConvertPZ2(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Poser File |*.pz2";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!System.IO.File.Exists(dialog.FileName))
                {
                    return;
                }

                Pz2ToDufConverter converter = new Pz2ToDufConverter();
                converter.Convert(dialog.FileName);
            }
        }
    }
}
