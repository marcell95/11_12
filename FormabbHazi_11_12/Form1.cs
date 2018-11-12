using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FormabbHazi_11_12 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            var hobbik = new BindingList<string>(); //"oda-vissza lista"
            hobbik.Add("Dummkopf");
            hobbik.Add("Sorozatok");
            hobbik.Add("Filmek");

            listBox1.DataSource = hobbik;
            

            button3.Click += (sender, args) => {
                if (!string.IsNullOrWhiteSpace(textBox3.Text)) {
                    hobbik.Add(textBox3.Text);

                }
            };
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) 
        { 
        
        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text != null && !textBox1.Text.Equals("") && dateTimePicker1 != null && listBox1.SelectedItem != null) 
            {
                StreamWriter fw = new StreamWriter("data.txt");

                fw.WriteLine(textBox1.Text);
                fw.WriteLine(dateTimePicker1.Text);
                fw.WriteLine(listBox1.SelectedItem);

                if (radioButton1.Checked == true) 
                {
                    fw.WriteLine("férfi"); 
                }
                if (radioButton2.Checked == true) 
                {
                    fw.WriteLine("nő");
                }

                fw.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e) {
            try {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("data.txt")) {
                    string line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    textBox1.Text = sr.ReadLine();
                    dateTimePicker1.Text = sr.ReadLine();
                    listBox1.SelectedItem = sr.ReadLine();

                    if (sr.ReadLine().Trim() == "férfi") {
                        radioButton1.Checked = true;
                    }
                    else {
                        radioButton2.Checked = true;
                    }
                    




                }
            }
            catch (Exception ex) {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
