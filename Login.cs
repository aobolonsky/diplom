using System; //область имен с системными базовыми классами
using System.Data; //классы для взаимодействия с базами данных
using System.Windows.Forms; //классы для операции с формами
using MySql.Data.MySqlClient; //классы для работы с MySql базами
namespace hospital
{
    public partial class Login : MetroFramework.Forms.MetroForm

    {
        private MetroFramework.Controls.MetroTextBox passwordbox;
        private MetroFramework.Controls.MetroButton Loginbutton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox loginbox;

        public Login()
        {
            InitializeComponent();
        }
        //при изменении текста в поле с паролем скрываем его звездочкой
        private void MetroTextBox2_TextChanged(object sender, EventArgs e)
        {
            passwordbox.PasswordChar = '*';
        }

        private void Loginbutton_Click_1(object sender, EventArgs e)
        {
            enter();
        }
        //проверка на то есть ли введенные данные(логин и пароль) в базе
        public bool tryLogin(string uname, string pword)

        {
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = Monolite_12; database = pac");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM sot WHERE Логин = '" + uname + "' AND Пароль ='" + pword + "' ");
            cmd.Connection = con;
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() != false)
            {
                if (reader.IsDBNull(0) == true)
                {
                    cmd.Connection.Close();
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
                else
                {
                    cmd.Connection.Close();
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public void enter()
        {
            //MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=pac;password=Monolit_12");
            MySqlConnection connection = new MySqlConnection("Database=pac;Data Source=localhost;User Id=root;Password=Monolite_12");
            MySqlCommand mySql = new MySqlCommand("SELECT * FROM sot WHERE Логин = '" + loginbox.Text + "' AND Пароль = '" + passwordbox.Text + "'", connection);
            try
            {
                //фиксируем имя пользователя в классе userinfo
                MySqlDataAdapter adapter;
                DataTable table = new DataTable();
                adapter = new MySqlDataAdapter("SELECT * FROM sot WHERE Логин = '" + loginbox.Text + "' AND Пароль = '" + passwordbox.Text + "'", connection);
                adapter.Fill(table);
                Userinfo.setusername(table.Rows[0][1].ToString());
            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            connection.Open();
            //если пользователь есть в базе
            if (tryLogin(loginbox.Text, passwordbox.Text) == true)
            {
                //то проверяем его уровень допуска
                using (MySqlDataReader reader = mySql.ExecuteReader())
                {
                    if (reader.Read())

                    {
                        var accessLevel = reader.GetString("Допуск");
                        switch (accessLevel)
                        {
                            case "Работник регистратуры":
                                vhod();
                                MessageBox.Show("Добро пожаловать " +
                                Userinfo.getusername(), "Вход выполнен");
                                this.Hide();
                                Client cl = new Client();
                                cl.Show();
                                break;
                            case "Админ":
                                vhod();
                                MessageBox.Show("Добро пожаловать " +
                                Userinfo.getusername(), "Вход выполнен");
                                Client cl2 = new Client();
                                this.Hide();
                                cl2.Show();
                                //cl2.time.Visible = true;
                                break;
                            default:
                                MessageBox.Show("Допуск не установлен");
                                break;
                        }
                    }
                }
            }
        }
        //функция для фиксирования входа пользователя в программу
        private void vhod()
        {
            //переменная для указания действия(вход или выход)
            string dey = "Вход";
            //переменная с текущей датой
            string bam = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // строка подключения к БД
            string connStr =
            "server=localhost;user=root;database=pac;password=Monolit_12;";
            // SQL запрос
            string Query = "insert into time(`ФИО`,`Время`,`Действие`) VALUES ('" + Userinfo.getusername() + "', '" + bam + "', '" + dey + "')";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = Monolite_12; database = pac");
            // устанавливаем соединение с БД
            conn.Open();
            // объект для выполнения SQL-запроса
            MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
            // если запрос выполнен то показываем сообщение о том что данные внесены
            if (MyCommand2.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы вошли в " + bam, "Время входа");
            }
            // или выдаем сообщение о ошибку
            else
            {
                MessageBox.Show("Ошибка. Время входа не установлено.");
            }
            // закрываем соединение с БД

            conn.Close();
        }

        private void Passwordbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enter();
            }
        }

        private void InitializeComponent()
        {
            this.loginbox = new MetroFramework.Controls.MetroTextBox();
            this.passwordbox = new MetroFramework.Controls.MetroTextBox();
            this.Loginbutton = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // loginbox
            // 
            // 
            // 
            // 
            this.loginbox.CustomButton.Image = null;
            this.loginbox.CustomButton.Location = new System.Drawing.Point(110, 1);
            this.loginbox.CustomButton.Name = "";
            this.loginbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.loginbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.loginbox.CustomButton.TabIndex = 1;
            this.loginbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.loginbox.CustomButton.UseSelectable = true;
            this.loginbox.CustomButton.Visible = false;
            this.loginbox.Lines = new string[0];
            this.loginbox.Location = new System.Drawing.Point(130, 79);
            this.loginbox.MaxLength = 32767;
            this.loginbox.Name = "loginbox";
            this.loginbox.PasswordChar = '\0';
            this.loginbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.loginbox.SelectedText = "";
            this.loginbox.SelectionLength = 0;
            this.loginbox.SelectionStart = 0;
            this.loginbox.ShortcutsEnabled = true;
            this.loginbox.Size = new System.Drawing.Size(114, 23);
            this.loginbox.TabIndex = 0;
            this.loginbox.UseSelectable = true;
            this.loginbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.loginbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // passwordbox
            // 
            // 
            // 
            // 
            this.passwordbox.CustomButton.Image = null;
            this.passwordbox.CustomButton.Location = new System.Drawing.Point(110, 1);
            this.passwordbox.CustomButton.Name = "";
            this.passwordbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordbox.CustomButton.TabIndex = 1;
            this.passwordbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordbox.CustomButton.UseSelectable = true;
            this.passwordbox.CustomButton.Visible = false;
            this.passwordbox.Lines = new string[0];
            this.passwordbox.Location = new System.Drawing.Point(130, 136);
            this.passwordbox.MaxLength = 32767;
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.PasswordChar = '*';
            this.passwordbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordbox.SelectedText = "";
            this.passwordbox.SelectionLength = 0;
            this.passwordbox.SelectionStart = 0;
            this.passwordbox.ShortcutsEnabled = true;
            this.passwordbox.Size = new System.Drawing.Size(114, 23);
            this.passwordbox.TabIndex = 1;
            this.passwordbox.UseSelectable = true;
            this.passwordbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Loginbutton
            // 
            this.Loginbutton.Location = new System.Drawing.Point(82, 194);
            this.Loginbutton.Name = "Loginbutton";
            this.Loginbutton.Size = new System.Drawing.Size(124, 40);
            this.Loginbutton.TabIndex = 2;
            this.Loginbutton.Text = "Вход";
            this.Loginbutton.UseSelectable = true;
            this.Loginbutton.Click += new System.EventHandler(this.Loginbutton_Click_1);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(39, 79);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(47, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Логин";
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(39, 136);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(54, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Пароль";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(113, 30);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(45, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "ВХОД";
            // 
            // Login
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.Loginbutton);
            this.Controls.Add(this.passwordbox);
            this.Controls.Add(this.loginbox);
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}