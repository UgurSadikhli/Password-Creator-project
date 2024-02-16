using System;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PasswordCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string name = "";
        string surname = "";
        string age = "";
        string sign = "";
        string fav_num = "";
        string[] words = { "Alpha", "Zenith", "Nova", "Blaze", "Quantum", "Echo", "Stellar", "Falcon", "Seraph", "Cipher", "Phoenix", "Orion", "Thunder", "Spectre", "Pinnacle", "Avalanche", "Celestial", "Nexus", "Vertex", "Eclipse", "Apex", "Mirage", "Catalyst", "Quantum", "Radiance", "Echo", "Celestial", "Nexus", "Zenith", "Astral", "Harmony", "Pulsar", "Solitude", "Scepter", "Utopia", "Solaris", "Zen", "Epoch", "Zephyr", "Lyric", "Aurora", "Odyssey", "Serenity", "Radiant", "Equilibrium", "Vortex", "Genesis", "Quasar", "Infinity", "Ethereal" };


        // check boxs
        bool sign_flag = false;
        bool fav_num_flag = false;
        bool age_flag = false;
        bool name_flag = true;
        bool surname_flag = true;
        bool birth_year_flag = false;
        bool rand_words_flag = false;

        int fav_num_flag_n = 0;
        int age_flag_n = 0;
        int name_flag_n = 0;
        int surname_flag_n = 0;
        int rand_words_flag_n = 0;
        int birth_year_flag_n = 0;
        //
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }


        private string return_sign()
        {
            //password
            if (radioButton1.Checked) return "-";
            if (radioButton2.Checked) return "_";
            if (radioButton3.Checked) return "/";
            if (radioButton4.Checked) return "*";
            if (radioButton5.Checked) return "@";
            if (radioButton6.Checked) return "~";
            if (radioButton7.Checked) return "%";
            if (radioButton8.Checked)
            {
                int rand2 = rand(7);
                if (rand2 == 0) { return "-"; }
                else if (rand2 == 1) { return "_"; }
                else if (rand2 == 2) { return "/"; }
                else if (rand2 == 3) { return "*"; }
                else if (rand2 == 4) { return "@"; }
                else if (rand2 == 5) { return "~"; }
                else if (rand2 == 6) { return "%"; }

            }
            //nick
            if (radioButton16.Checked) return "-";
            if (radioButton15.Checked) return "_";
            if (radioButton14.Checked) return "/";
            if (radioButton13.Checked) return "*";
            if (radioButton12.Checked) return "@";
            if (radioButton10.Checked) return "~";
            if (radioButton11.Checked) return "%";
            if (radioButton9.Checked)
            {
                int rand3 = rand(7);
                if (rand3 == 0) { return "-"; }
                else if (rand3 == 1) { return "_"; }
                else if (rand3 == 2) { return "/"; }
                else if (rand3 == 3) { return "*"; }
                else if (rand3 == 4) { return "@"; }
                else if (rand3 == 5) { return "~"; }
                else if (rand3 == 6) { return "%"; }

            }
            return "";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            bool checkSign = false;
            if (return_sign().Equals(""))
            {
                checkSign = false;
            }
            else { checkSign = true; }
            if (name_box.Text != "" & age_box.Text != "" & surname_box.Text != "" & fav_num_box.Text != "")
            {
                if (checkSign)
                {
                    name = name_box.Text.ToLower(); 
                    age = age_box.Text;
                    surname = surname_box.Text.ToLower(); 
                    fav_num = fav_num_box.Text;

                    sign = return_sign();



                    textBox4.Text = name;
                    textBox3.Text = surname;
                    textBox2.Text = age;
                    textBox1.Text = fav_num;
                    textBox5.Text = sign;

                    panel2.Visible = false;
                    panel3.Visible = true;
                }
                else { MessageBox.Show("pick sign"); }
            }
            else
            {
                MessageBox.Show("fill all textbox");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            panel3.Enabled = false;
            progressBar1.Visible = true;
            textBox8.Visible = false;
            label14.Visible = true;
            timer1.Start();



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string rr = Generate();
            progressBar1.Value += 10;
            if (progressBar1.Value == 100) { timer1.Stop(); panel3.Enabled = true; button5.Visible = true; progressBar1.Value = 0; textBox8.Visible = true; textBox8.Text = rr; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
            label14.Visible = false;

            textBox8.Visible = false;
        }

        int rand(int num)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int num3 = rnd.Next(0, num);

            return num3;
        }
        private string Generate()
        {
            int i = 0;
            int sign_place = rand(2);
            string finall_digit = "";
            string year_dig = "";
            int sur_name = rand(2);
            string finall_surname = "";
            string digit = ((DateTime.Now.Year) - Int32.Parse(age)).ToString();
            char[] digit_arr = digit.ToCharArray();
            char[] surname_arr = surname.ToCharArray();
            int ran = rand(surname.Length - 1);
            int ran_dig = rand(2);
            while (i <= ran)
            {
                finall_surname += surname_arr[i];
                i++;
            }
            year_dig = digit_arr[2].ToString() + digit_arr[3].ToString();
            if (ran_dig == 0)
            {
                finall_digit += year_dig + fav_num;
            }
            if (ran_dig == 1)
            {
                finall_digit += fav_num + year_dig;
            }
            if (sign_place == 1)
            {
                if (sur_name == 1)
                {
                    string finall = finall_surname + sign + name + finall_digit;
                    return finall;

                }
                if (sur_name == 0)
                {
                    string finall = name + sign + finall_surname + finall_digit;
                    return finall;
                }

            }
            if (sign_place == 0)
            {
                if (sur_name == 1)
                {
                    string finall = finall_surname + name + sign + finall_digit;
                    return finall;

                }
                if (sur_name == 0)
                {
                    string finall = name + finall_surname + sign + finall_digit;
                    return finall;
                }

            }
            return "retry";
        }
        private string GenerateNick()
        {
            int i = 0;
            string final_result = "";
            string date_of_birh = ((DateTime.Now.Year) - Int32.Parse(age)).ToString();
            char[] date_of_birh_arr = date_of_birh.ToCharArray();
            char[] surname_arr = surname.ToCharArray();
            char[] name_arr = name.ToCharArray();
            string final_sign = "";

            if (sign_flag)
            {
                final_sign = sign;
            }
            if (surname_flag)
            {
                string finall_surname = "";
                int surname_lenth = rand(surname.Length - 1);
                while (i <= surname_lenth)
                {
                    finall_surname += surname_arr[i];
                    i++;
                }
                final_result += finall_surname;
            }
            if (name_flag)
            {
                string finall_name = "";
                int name_lenth = rand(name.Length - 1);
                while (i <= name_lenth)
                {
                    finall_name += name_arr[i];
                    i++;
                }
                final_result += finall_name;
            }
            if (rand_words_flag)
            {
                int num = rand(50);
                final_result += words[num];
            }
            if (fav_num_flag)
            {
                if (birth_year_flag || age_flag)
                {
                    final_result += final_sign + fav_num;
                    final_sign = "";
                }
                else
                {
                    final_result += final_sign + fav_num;

                }
            }
            if (birth_year_flag)
            {
                if (fav_num_flag || age_flag)
                {
                    string year_dig = date_of_birh_arr[2].ToString() + date_of_birh_arr[3].ToString();
                    final_result += final_sign + year_dig;
                    final_sign = "";

                }
                else
                {
                    string year_dig = date_of_birh_arr[2].ToString() + date_of_birh_arr[3].ToString();
                    final_result += final_sign + year_dig;
                }
            }
            if (age_flag)
            {
                if (fav_num_flag || birth_year_flag)
                {
                    final_result += final_sign + age;
                    final_sign = "";

                }
                else
                {
                    final_result += final_sign + age;
                }

            }


            return final_result;
        }

        int rans = 0;
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (rans == 0)
            {
                rans = 1;
                pictureBox4.Visible = true;
            }
            else if (rans == 1)
            {              
                rans = 0;
                pictureBox4.Visible = false;

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            name_box.Text = "";
            age_box.Text = "";
            surname_box.Text = "";
            fav_num_box.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
        }


        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            string a = return_sign();
            textBox5.Text = a;
            sign = a;
        }




        private void button1_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel1.Visible = true;
            panel2.Visible = false;
            textBox10.Text = "";
            textBox9.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            checkBox3.Checked = false;
            checkBox1.Checked = false;
            checkBox8.Checked = false;
            checkBox4.Checked = false;
            checkBox7.Checked = false;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
            textBox11.Visible = false;
            radioButton16.Checked = false;
            radioButton15.Checked = false;
            radioButton14.Checked = false;
            radioButton13.Checked = false;
            radioButton12.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton9.Checked = false;

        }

        int chec0 = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (chec0 == 0)
            {
                groupBox3.Visible = true;
                sign_flag = true;

                chec0 = 1;
            }
            else if (chec0 == 1)
            {
                sign_flag = false;

                groupBox3.Visible = false;
                chec0 = 0;

            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (fav_num_flag_n == 0)
            {
                fav_num_flag = true;
                fav_num_flag_n = 1;
            }
            else if (fav_num_flag_n == 1)
            {
                fav_num_flag = false;
                fav_num_flag_n = 0;
            }
        }



        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (age_flag_n == 0)
            {
                age_flag = true;
                age_flag_n = 1;
            }
            else if (age_flag_n == 1)
            {
                age_flag = false;
                age_flag_n = 0;

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (name_flag_n == 0)
            {
                name_flag = false;
                name_flag_n = 1;
            }
            else if (name_flag_n == 1)
            {
                name_flag = true;
                name_flag_n = 0;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (surname_flag_n == 0)
            {
                surname_flag = false;
                surname_flag_n = 1;
            }
            else if (surname_flag_n == 1)
            {
                surname_flag = true;
                surname_flag_n = 0;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (rand_words_flag_n == 0)
            {
                rand_words_flag = true;
                rand_words_flag_n = 1;
            }
            else if (rand_words_flag_n == 1)
            {
                rand_words_flag = false;
                rand_words_flag_n = 0;

            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            bool checkSign = false;
            if (checkBox1.Checked & return_sign().Equals(""))
            {
                checkSign = false;
            }
            else { checkSign = true; }
            if (textBox10.Text != "" & textBox9.Text != "" & textBox7.Text != "" & textBox6.Text != "")
            {
                if (checkSign)
                {
                    name = textBox10.Text.ToLower();
                    surname = textBox9.Text.ToLower(); ;
                    age = textBox7.Text;
                    fav_num = textBox6.Text;
                    sign = return_sign();
                    textBox11.Visible = true;
                    textBox11.Text = GenerateNick();
                }
                else { MessageBox.Show("pick sign"); }
            }
            else
            {
                MessageBox.Show("fill all textbox");
            }
           
        }


        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (birth_year_flag_n == 0)
            {
                birth_year_flag = true;
                birth_year_flag_n = 1;
            }
            else if (birth_year_flag_n == 1)
            {
                birth_year_flag = false;
                birth_year_flag_n = 0;

            }
        }

       
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                
                e.Handled = true;
            }

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void name_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void surname_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void age_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void fav_num_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {

                e.Handled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox10.Text="";
            textBox9.Text="";
            textBox7.Text="";
            textBox6.Text="";
            checkBox3.Checked=false;
            checkBox1.Checked=false;
            checkBox8.Checked=false;
            checkBox4.Checked=false;
            checkBox7.Checked=false;
            checkBox5.Checked=true;
            checkBox6.Checked=true;
            textBox11.Visible=false;
            radioButton16.Checked=false;
            radioButton15.Checked=false;
            radioButton14.Checked=false;
            radioButton13.Checked=false;
            radioButton12.Checked=false;
            radioButton10.Checked=false;
            radioButton11.Checked=false;
            radioButton9.Checked =false;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            name_box.Text="";
            age_box.Text="";
            surname_box.Text="";
            fav_num_box.Text="";
            radioButton1.Checked=false;
            radioButton2.Checked=false;
            radioButton3.Checked=false;
            radioButton4.Checked=false;
            radioButton5.Checked=false;
            radioButton6.Checked=false;
            radioButton7.Checked=false;
            radioButton8.Checked=false;
        }
    }
}
