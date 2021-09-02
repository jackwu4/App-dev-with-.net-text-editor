using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignement_2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginButton();
            //check user password
            
            //link to form1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newUserButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            exitButton();
        }

        private void loginButton()
        {
            LoginFunction lf1 = new LoginFunction();
            if (lf1.matchDetails(textBox1.Text, textBox2.Text))
            {
                //go next screen
                Form1 textEditor = new Form1(this,lf1.getLoginUser());
                textEditor.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong username/password!", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void exitButton()
        {
            Application.Exit();
        }

        private void newUserButton()
        {
            Register newUser = new Register(this);
            newUser.Show();
            this.Hide();
        }

        private void CheckEnter(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                loginButton();
            }
        }
    }

    public class LoginFunction
    {
        private string[] file;
        private List<User> users = new List<User>();
        private User loginUser;
        public LoginFunction()
        {
            readFile();
            saveUsers();
        }

        private void readFile()
        {
            try
            {
                file = File.ReadAllLines(@"Login.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void saveUsers()
        {
            foreach (string element in file)
            {
                string[] words = element.Split(',');
                users.Add(new User(words[0], words[1], words[2], words[3], words[4], words[5]));
            }
        }

        public bool matchDetails(string username, string password)
        {
            foreach (User user in users)
            {
                if (user.matchDetails(username, password))
                {
                    loginUser = user;
                    return true;
                }

            }

            return false;
        }

        public User getLoginUser()
        {
            return loginUser;
        }

        public void appendFile(string line)
        {
            List<string> list = file.ToList();
            list.Add(line);
            file = list.ToArray();
            writeFile();
        }

        private void writeFile()
        {
            File.WriteAllLines("login.txt",file);
        }

        

    }

    public class User
    {
        string username, password, userType, firstName, lastName, dob;
        public User()
        {

        }

        public User(string username, string password, string userType, string firstName, string lastName, string dob)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.userType = userType;
            this.dob = dob;
        }

        public bool matchDetails(string username, string password)
        {
            if (this.username == username && this.password == password)
                return true;

            return false;
        }

        public string getUserType()
        {
            return userType;
        }

        public string getUsername()
        {
            return username;
        }

        public string generateLine()
        {
            return username + "," + password + "," + userType + "," + firstName + "," + lastName + "," + dob ;
        }
    }


}
