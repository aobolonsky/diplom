using System; //область имен с системными базовыми классами
using System.Data; //классы для взаимодействия с базами данных
using System.Text; //для работы с текстом
using System.Windows.Forms; //классы для операции с формами
using MySql.Data.MySqlClient; //классы для работы с MySql базами
using System.IO; //классы ввода и вывода данных
namespace hospital
{
    public partial class Client : MetroFramework.Forms.MetroForm
    {
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private BindingSource pacDataSetBindingSource;
        private System.ComponentModel.IContainer components;
        private diplom.pacDataSet pacDataSet;
        private BindingSource sotBindingSource;
        private diplom.pacDataSetTableAdapters.sotTableAdapter sotTableAdapter;
        private BindingSource sotBindingSource1;
        private MetroFramework.Controls.MetroTextBox metroTextBox12;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroTextBox metroTextBox3;
        private MetroFramework.Controls.MetroTextBox metroTextBox4;
        private MetroFramework.Controls.MetroTextBox metroTextBox5;
        private MetroFramework.Controls.MetroTextBox metroTextBox6;
        private MetroFramework.Controls.MetroTextBox metroTextBox7;
        private MetroFramework.Controls.MetroTextBox metroTextBox8;
        private MetroFramework.Controls.MetroTextBox metroTextBox9;
        private MetroFramework.Controls.MetroTextBox metroTextBox10;
        private MetroFramework.Controls.MetroTextBox metroTextBox11;
        private MetroFramework.Controls.MetroTextBox metroTextBox13;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private DataGridView dataGridView1;
        private MetroFramework.Controls.MetroButton metroButton1;

        public Client()
        {
            InitializeComponent();
            //заполняем таблицу при инициализации программы
            SelectData();
        }

        //функция для заполнения таблицы
        public void SelectData()
        {
            // строка подключения к БД
            string connStr =
            "server = localhost; user id = root; password = Monolite_12; database = pac";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // SQL запрос
            string sql = "SELECT * FROM pers";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            //выполнение и формирование SQL запроса
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            // создание таблицы
            DataTable data = new DataTable();
            // наполнение таблицы данными
            adapter.Fill(data);
            // вносим данны в datagridview
            dataGridView1.DataSource = data;
            // закрываем соединение с БД
            conn.Close();
        }
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            //фиксируем время выхода
            vihod();
            // завершение работы приложения

            Application.Exit();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            //переменная с текущим временем
            string bam = DateTime.Now.ToString("yyyy-MM-dd");
            // строка подключения к БД
            string connStr =
            "Database=pac;Data Source=localhost;User Id=root;Password=Monolite_12";
            // SQL запрос
            string Query = "insert into pac.pers(Фамилия, Имя, Отчество, Пол, `Дата рождения`, КСГ, Серия, Номер, СНИЛС, Адрес, `Место рождения`, `Дата добавления`) values('" + metroTextBox12.Text + "','" + metroTextBox2.Text + "','" + metroTextBox3.Text + "','" + metroTextBox4.Text + "','" + metroTextBox5.Text + "','" + metroTextBox6.Text + "','" + metroTextBox7.Text + "','" + metroTextBox8.Text + "','" + metroTextBox9.Text + "','" + metroTextBox10.Text + "','" + metroTextBox11.Text + "','" + bam + "')";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // объект для выполнения SQL-запроса
            MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
            try
            {
                // если запрос выполнен то показываем сообщение о том что данные внесены
                if (MyCommand2.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные внесены.");

                }
                // или выдаем сообщение о ошибку
                else
                {
                    MessageBox.Show("Ошибка. Внесение данных не удалось.");
                }
            }
            catch
            {
                MessageBox.Show("Неверный формат ввода");
            }
            // закрываем соединение с БД
            conn.Close();
            //обновляем таблицу
            SelectData();
        }

        private void Zaprosdate_Click(object sender, EventArgs e)
        {
            try
            {
                // строка подключения к БД
                string connStr =
                "Database=pac;Data Source=localhost;User Id=root;Password=Monolite_12";
                // создаём объект для подключения к БД
                MySqlConnection conn = new MySqlConnection(connStr);
                // устанавливаем соединение с БД
                conn.Open();
                // SQL запрос

                string sql = "SELECT * FROM pers WHERE `Дата добавления` = '"
                + metroTextBox13.Text + "'";
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(sql, conn);
                //выполнение и формирование SQL запроса
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                // создание таблицы
                DataTable data = new DataTable();
                // наполнение таблицы данными
                adapter.Fill(data);
                // вносим данны в datagridview
                dataGridView1.DataSource = data;
                // закрываем соединение с БД
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Проверьте правильность даты");
            }
        }

        private void Find_Click(object sender, EventArgs e)
        {
            //цикл для поиска информации в таблице
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)

                        if
                        (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(metroTextBox1.Text))
                        {
                            //если есть соотвествия выделяем ячейки с информацией
                            dataGridView1.Rows[i].Cells[j].Selected = true;
                        }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // проверка на то выделена строка или ячейка
            try
            {
                // переменная выделенной строки
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                // достаём id выделенной строки
                int rowID = int.Parse(dataGridView1[0,
                selectedIndex].Value.ToString());
                // строка подключения к БД
                string connStr =
                "Database=pac;Data Source=localhost;User Id=root;Password=Monolite_12";
                // создаём объект для подключения к БД
                MySqlConnection conn = new MySqlConnection(connStr);
                // SQL запрос
                string sql = "DELETE FROM pers WHERE idpers = " + rowID;
                // устанавливаем соединение с БД
                conn.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(sql, conn);

                // если запрос выполнен то показываем сообщение о том что данные удалены
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Удалено");
                }
                // или выдаем сообщение о ошибку
                else
                {
                    MessageBox.Show("Удаление не удалось");
                }
                // закрываем соединение с БД
                conn.Close();
                //обновляем таблицу
                SelectData();
            }
            // если пользователь выделил лишь ячейку то уведомляем его об этом
            catch
            {
                MessageBox.Show("Для удаления выделите всю строку");
            }
        }
        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                // переменная выделенной строки
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                // достаём id выделенной строки

                int rowID = int.Parse(dataGridView1[0,
                selectedIndex].Value.ToString());
                // строка подключения к БД
                string connStr =
                "Database=pac;Data Source=localhost;User Id=root;Password=Monolite_12";
                // SQL запрос
                string Query = "UPDATE pers SET Фамилия = '" +
                metroTextBox12.Text + "', Имя = '" + metroTextBox2.Text + "', Отчество = '" +
                metroTextBox3.Text + "', Пол = '" + metroTextBox4.Text + "', `Дата рождения` = '" +
                metroTextBox5.Text + "', КСГ = '" + metroTextBox6.Text + "', Серия = '" +
                metroTextBox7.Text + "', Номер = '" + metroTextBox8.Text + "', СНИЛС = '" +
                metroTextBox9.Text + "', Адрес = '" + metroTextBox10.Text + "', `Место рождения` = '" + metroTextBox11.Text + "' WHERE idpers =" + rowID;
                // создаём объект для подключения к БД
                MySqlConnection conn = new MySqlConnection(connStr);
                // устанавливаем соединение с БД
                conn.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand MyCommand2 = new MySqlCommand(Query,
                conn);
                // если ошибок нет то показываем сообщение о том что данные изменены
                if (MyCommand2.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные изменены.");
                }
                // или выдаем сообщение о ошибку
                else
                {
                    MessageBox.Show("Ошибка. Изменение данных не удалось.");

                }
                // закрываем соединение с БД
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Неверный формат ввода");
            }
            //обновляем таблицу
            SelectData();
        }
        // присваевание ячеек выделенной строки textbox
        private void DataGridView1_MouseClick(object sender, MouseEventArgs
        e)
        {
            metroTextBox12.Text =
            dataGridView1.CurrentRow.Cells[1].Value.ToString();
            metroTextBox2.Text =
            dataGridView1.CurrentRow.Cells[2].Value.ToString();
            metroTextBox3.Text =
            dataGridView1.CurrentRow.Cells[3].Value.ToString();
            metroTextBox4.Text =
            dataGridView1.CurrentRow.Cells[4].Value.ToString();
            DateTime tmp = new DateTime();
            tmp = (DateTime)dataGridView1.CurrentRow.Cells[5].Value;
            metroTextBox5.Text = tmp.ToShortDateString().ToString();
            metroTextBox6.Text =
            dataGridView1.CurrentRow.Cells[6].Value.ToString();
            metroTextBox7.Text =
            dataGridView1.CurrentRow.Cells[7].Value.ToString();

            metroTextBox8.Text =
            dataGridView1.CurrentRow.Cells[8].Value.ToString();
            metroTextBox9.Text =
            dataGridView1.CurrentRow.Cells[9].Value.ToString();
            metroTextBox10.Text =
            dataGridView1.CurrentRow.Cells[10].Value.ToString();
            metroTextBox11.Text =
            dataGridView1.CurrentRow.Cells[11].Value.ToString();
        }
        //функция для экспорта таблицы для Excel
        private void ToCsV(string filename)
        {
            string stOutput = "";
            // Экспорт заголовков:
            string sHeaders = "";
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                sHeaders = sHeaders.ToString() +
                Convert.ToString(dataGridView1.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Экспорт данных.
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() +
                    Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding wind1251 = Encoding.GetEncoding(1251);
            byte[] output = wind1251.GetBytes(stOutput);

            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //запись в файл
            bw.Flush();
            bw.Close();
            fs.Close();
        }
        private void export_Click(object sender, EventArgs e)
        {
            //сохранение таблицы в файл
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Таблица Excel|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ToCsV(sfd.FileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        private void Home_Click(object sender, EventArgs e)
        {
            //обновляем таблицу
            SelectData();
        }
        private void Time_Click(object sender, EventArgs e)

        {
            // строка подключения к БД
            string connStr =
            "Database=pac;Data Source=localhost;User Id=root;Password=Monolite_12";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // SQL запрос
            string sql = "SELECT * FROM time";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            //выполнение и формирование SQL запроса
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            // создание таблицы
            DataTable data = new DataTable();
            // наполнение таблицы данными
            adapter.Fill(data);
            // вносим данны в datagridview
            dataGridView1.DataSource = data;
            // закрываем соединение с БД
            conn.Close();
        }
        //функция для фиксирования выхода пользователя из программы
        private void vihod()
        {
            //переменная для указания действия(вход или выход)
            string dey = "Выход";
            //переменная с текущей датой
            string bam = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // строка подключения к БД
            string connStr =
            "Database=pac;Data Source=localhost;User Id=root;Password=Monolite_12";
            // SQL запрос
            string Query = "insert into time(`ФИО`,`Время`,`Действие`) VALUES ('" + Userinfo.getusername() + "', '" + bam + "', '" + dey + "')";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // объект для выполнения SQL-запроса
            MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
            // если запрос выполнен то показываем сообщение о том что данные внесены
            if (MyCommand2.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы завершили работу в " + bam, "Время выхода");
            }
            // или выдаем сообщение о ошибку
            else
            {
                MessageBox.Show("Ошибка. Время выхода не установлено.");
            }
            // закрываем соединение с БД
            conn.Close();
        }
        private void DataGridView1_DataBindingComplete(object sender,
        DataGridViewBindingCompleteEventArgs e)
        {

            dataGridView1.ClearSelection();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.pacDataSet = new diplom.pacDataSet();
            this.pacDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sotBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sotTableAdapter = new diplom.pacDataSetTableAdapters.sotTableAdapter();
            this.sotBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.metroTextBox12 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox3 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox4 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox5 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox6 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox7 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox8 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox9 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox10 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox11 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox13 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(678, 336);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "metroButton1";
            this.metroButton1.UseSelectable = true;
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.AutoGenerateColumns = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.DataSource = this.sotBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle8;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Location = new System.Drawing.Point(0, 0);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(240, 69);
            this.metroGrid1.TabIndex = 1;
            // 
            // pacDataSet
            // 
            this.pacDataSet.DataSetName = "pacDataSet";
            this.pacDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pacDataSetBindingSource
            // 
            this.pacDataSetBindingSource.DataSource = this.pacDataSet;
            this.pacDataSetBindingSource.Position = 0;
            // 
            // sotBindingSource
            // 
            this.sotBindingSource.DataMember = "sot";
            this.sotBindingSource.DataSource = this.pacDataSetBindingSource;
            // 
            // sotTableAdapter
            // 
            this.sotTableAdapter.ClearBeforeFill = true;
            // 
            // sotBindingSource1
            // 
            this.sotBindingSource1.DataMember = "sot";
            this.sotBindingSource1.DataSource = this.pacDataSetBindingSource;
            // 
            // metroTextBox12
            // 
            // 
            // 
            // 
            this.metroTextBox12.CustomButton.Image = null;
            this.metroTextBox12.CustomButton.Location = new System.Drawing.Point(206, 1);
            this.metroTextBox12.CustomButton.Name = "";
            this.metroTextBox12.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox12.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox12.CustomButton.TabIndex = 1;
            this.metroTextBox12.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox12.CustomButton.UseSelectable = true;
            this.metroTextBox12.CustomButton.Visible = false;
            this.metroTextBox12.Lines = new string[] {
        "metroTextBox12"};
            this.metroTextBox12.Location = new System.Drawing.Point(93, 29);
            this.metroTextBox12.MaxLength = 32767;
            this.metroTextBox12.Name = "metroTextBox12";
            this.metroTextBox12.PasswordChar = '\0';
            this.metroTextBox12.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox12.SelectedText = "";
            this.metroTextBox12.SelectionLength = 0;
            this.metroTextBox12.SelectionStart = 0;
            this.metroTextBox12.ShortcutsEnabled = true;
            this.metroTextBox12.Size = new System.Drawing.Size(228, 23);
            this.metroTextBox12.TabIndex = 3;
            this.metroTextBox12.Text = "metroTextBox12";
            this.metroTextBox12.UseSelectable = true;
            this.metroTextBox12.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox12.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox12.Click += new System.EventHandler(this.metroTextBox12_Click);
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Lines = new string[] {
        "metroTextBox2"};
            this.metroTextBox2.Location = new System.Drawing.Point(57, 75);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox2.TabIndex = 4;
            this.metroTextBox2.Text = "metroTextBox2";
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox3
            // 
            // 
            // 
            // 
            this.metroTextBox3.CustomButton.Image = null;
            this.metroTextBox3.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox3.CustomButton.Name = "";
            this.metroTextBox3.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox3.CustomButton.TabIndex = 1;
            this.metroTextBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox3.CustomButton.UseSelectable = true;
            this.metroTextBox3.CustomButton.Visible = false;
            this.metroTextBox3.Lines = new string[] {
        "metroTextBox3"};
            this.metroTextBox3.Location = new System.Drawing.Point(68, 104);
            this.metroTextBox3.MaxLength = 32767;
            this.metroTextBox3.Name = "metroTextBox3";
            this.metroTextBox3.PasswordChar = '\0';
            this.metroTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox3.SelectedText = "";
            this.metroTextBox3.SelectionLength = 0;
            this.metroTextBox3.SelectionStart = 0;
            this.metroTextBox3.ShortcutsEnabled = true;
            this.metroTextBox3.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox3.TabIndex = 5;
            this.metroTextBox3.Text = "metroTextBox3";
            this.metroTextBox3.UseSelectable = true;
            this.metroTextBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox4
            // 
            // 
            // 
            // 
            this.metroTextBox4.CustomButton.Image = null;
            this.metroTextBox4.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox4.CustomButton.Name = "";
            this.metroTextBox4.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox4.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox4.CustomButton.TabIndex = 1;
            this.metroTextBox4.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox4.CustomButton.UseSelectable = true;
            this.metroTextBox4.CustomButton.Visible = false;
            this.metroTextBox4.Lines = new string[] {
        "metroTextBox4"};
            this.metroTextBox4.Location = new System.Drawing.Point(68, 133);
            this.metroTextBox4.MaxLength = 32767;
            this.metroTextBox4.Name = "metroTextBox4";
            this.metroTextBox4.PasswordChar = '\0';
            this.metroTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox4.SelectedText = "";
            this.metroTextBox4.SelectionLength = 0;
            this.metroTextBox4.SelectionStart = 0;
            this.metroTextBox4.ShortcutsEnabled = true;
            this.metroTextBox4.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox4.TabIndex = 6;
            this.metroTextBox4.Text = "metroTextBox4";
            this.metroTextBox4.UseSelectable = true;
            this.metroTextBox4.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox4.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox5
            // 
            // 
            // 
            // 
            this.metroTextBox5.CustomButton.Image = null;
            this.metroTextBox5.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox5.CustomButton.Name = "";
            this.metroTextBox5.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox5.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox5.CustomButton.TabIndex = 1;
            this.metroTextBox5.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox5.CustomButton.UseSelectable = true;
            this.metroTextBox5.CustomButton.Visible = false;
            this.metroTextBox5.Lines = new string[] {
        "metroTextBox5"};
            this.metroTextBox5.Location = new System.Drawing.Point(68, 162);
            this.metroTextBox5.MaxLength = 32767;
            this.metroTextBox5.Name = "metroTextBox5";
            this.metroTextBox5.PasswordChar = '\0';
            this.metroTextBox5.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox5.SelectedText = "";
            this.metroTextBox5.SelectionLength = 0;
            this.metroTextBox5.SelectionStart = 0;
            this.metroTextBox5.ShortcutsEnabled = true;
            this.metroTextBox5.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox5.TabIndex = 7;
            this.metroTextBox5.Text = "metroTextBox5";
            this.metroTextBox5.UseSelectable = true;
            this.metroTextBox5.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox5.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox6
            // 
            // 
            // 
            // 
            this.metroTextBox6.CustomButton.Image = null;
            this.metroTextBox6.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox6.CustomButton.Name = "";
            this.metroTextBox6.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox6.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox6.CustomButton.TabIndex = 1;
            this.metroTextBox6.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox6.CustomButton.UseSelectable = true;
            this.metroTextBox6.CustomButton.Visible = false;
            this.metroTextBox6.Lines = new string[] {
        "metroTextBox6"};
            this.metroTextBox6.Location = new System.Drawing.Point(68, 191);
            this.metroTextBox6.MaxLength = 32767;
            this.metroTextBox6.Name = "metroTextBox6";
            this.metroTextBox6.PasswordChar = '\0';
            this.metroTextBox6.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox6.SelectedText = "";
            this.metroTextBox6.SelectionLength = 0;
            this.metroTextBox6.SelectionStart = 0;
            this.metroTextBox6.ShortcutsEnabled = true;
            this.metroTextBox6.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox6.TabIndex = 8;
            this.metroTextBox6.Text = "metroTextBox6";
            this.metroTextBox6.UseSelectable = true;
            this.metroTextBox6.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox6.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox7
            // 
            // 
            // 
            // 
            this.metroTextBox7.CustomButton.Image = null;
            this.metroTextBox7.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox7.CustomButton.Name = "";
            this.metroTextBox7.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox7.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox7.CustomButton.TabIndex = 1;
            this.metroTextBox7.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox7.CustomButton.UseSelectable = true;
            this.metroTextBox7.CustomButton.Visible = false;
            this.metroTextBox7.Lines = new string[] {
        "metroTextBox7"};
            this.metroTextBox7.Location = new System.Drawing.Point(68, 220);
            this.metroTextBox7.MaxLength = 32767;
            this.metroTextBox7.Name = "metroTextBox7";
            this.metroTextBox7.PasswordChar = '\0';
            this.metroTextBox7.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox7.SelectedText = "";
            this.metroTextBox7.SelectionLength = 0;
            this.metroTextBox7.SelectionStart = 0;
            this.metroTextBox7.ShortcutsEnabled = true;
            this.metroTextBox7.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox7.TabIndex = 9;
            this.metroTextBox7.Text = "metroTextBox7";
            this.metroTextBox7.UseSelectable = true;
            this.metroTextBox7.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox7.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox8
            // 
            // 
            // 
            // 
            this.metroTextBox8.CustomButton.Image = null;
            this.metroTextBox8.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox8.CustomButton.Name = "";
            this.metroTextBox8.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox8.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox8.CustomButton.TabIndex = 1;
            this.metroTextBox8.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox8.CustomButton.UseSelectable = true;
            this.metroTextBox8.CustomButton.Visible = false;
            this.metroTextBox8.Lines = new string[] {
        "metroTextBox8"};
            this.metroTextBox8.Location = new System.Drawing.Point(68, 249);
            this.metroTextBox8.MaxLength = 32767;
            this.metroTextBox8.Name = "metroTextBox8";
            this.metroTextBox8.PasswordChar = '\0';
            this.metroTextBox8.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox8.SelectedText = "";
            this.metroTextBox8.SelectionLength = 0;
            this.metroTextBox8.SelectionStart = 0;
            this.metroTextBox8.ShortcutsEnabled = true;
            this.metroTextBox8.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox8.TabIndex = 10;
            this.metroTextBox8.Text = "metroTextBox8";
            this.metroTextBox8.UseSelectable = true;
            this.metroTextBox8.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox8.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox9
            // 
            // 
            // 
            // 
            this.metroTextBox9.CustomButton.Image = null;
            this.metroTextBox9.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox9.CustomButton.Name = "";
            this.metroTextBox9.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox9.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox9.CustomButton.TabIndex = 1;
            this.metroTextBox9.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox9.CustomButton.UseSelectable = true;
            this.metroTextBox9.CustomButton.Visible = false;
            this.metroTextBox9.Lines = new string[] {
        "metroTextBox9"};
            this.metroTextBox9.Location = new System.Drawing.Point(68, 278);
            this.metroTextBox9.MaxLength = 32767;
            this.metroTextBox9.Name = "metroTextBox9";
            this.metroTextBox9.PasswordChar = '\0';
            this.metroTextBox9.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox9.SelectedText = "";
            this.metroTextBox9.SelectionLength = 0;
            this.metroTextBox9.SelectionStart = 0;
            this.metroTextBox9.ShortcutsEnabled = true;
            this.metroTextBox9.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox9.TabIndex = 11;
            this.metroTextBox9.Text = "metroTextBox9";
            this.metroTextBox9.UseSelectable = true;
            this.metroTextBox9.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox9.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox10
            // 
            // 
            // 
            // 
            this.metroTextBox10.CustomButton.Image = null;
            this.metroTextBox10.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox10.CustomButton.Name = "";
            this.metroTextBox10.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox10.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox10.CustomButton.TabIndex = 1;
            this.metroTextBox10.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox10.CustomButton.UseSelectable = true;
            this.metroTextBox10.CustomButton.Visible = false;
            this.metroTextBox10.Lines = new string[] {
        "metroTextBox10"};
            this.metroTextBox10.Location = new System.Drawing.Point(68, 307);
            this.metroTextBox10.MaxLength = 32767;
            this.metroTextBox10.Name = "metroTextBox10";
            this.metroTextBox10.PasswordChar = '\0';
            this.metroTextBox10.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox10.SelectedText = "";
            this.metroTextBox10.SelectionLength = 0;
            this.metroTextBox10.SelectionStart = 0;
            this.metroTextBox10.ShortcutsEnabled = true;
            this.metroTextBox10.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox10.TabIndex = 12;
            this.metroTextBox10.Text = "metroTextBox10";
            this.metroTextBox10.UseSelectable = true;
            this.metroTextBox10.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox10.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox11
            // 
            // 
            // 
            // 
            this.metroTextBox11.CustomButton.Image = null;
            this.metroTextBox11.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox11.CustomButton.Name = "";
            this.metroTextBox11.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox11.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox11.CustomButton.TabIndex = 1;
            this.metroTextBox11.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox11.CustomButton.UseSelectable = true;
            this.metroTextBox11.CustomButton.Visible = false;
            this.metroTextBox11.Lines = new string[] {
        "metroTextBox11"};
            this.metroTextBox11.Location = new System.Drawing.Point(68, 336);
            this.metroTextBox11.MaxLength = 32767;
            this.metroTextBox11.Name = "metroTextBox11";
            this.metroTextBox11.PasswordChar = '\0';
            this.metroTextBox11.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox11.SelectedText = "";
            this.metroTextBox11.SelectionLength = 0;
            this.metroTextBox11.SelectionStart = 0;
            this.metroTextBox11.ShortcutsEnabled = true;
            this.metroTextBox11.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox11.TabIndex = 13;
            this.metroTextBox11.Text = "metroTextBox11";
            this.metroTextBox11.UseSelectable = true;
            this.metroTextBox11.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox11.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox13
            // 
            // 
            // 
            // 
            this.metroTextBox13.CustomButton.Image = null;
            this.metroTextBox13.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox13.CustomButton.Name = "";
            this.metroTextBox13.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox13.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox13.CustomButton.TabIndex = 1;
            this.metroTextBox13.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox13.CustomButton.UseSelectable = true;
            this.metroTextBox13.CustomButton.Visible = false;
            this.metroTextBox13.Lines = new string[] {
        "metroTextBox13"};
            this.metroTextBox13.Location = new System.Drawing.Point(300, 249);
            this.metroTextBox13.MaxLength = 32767;
            this.metroTextBox13.Name = "metroTextBox13";
            this.metroTextBox13.PasswordChar = '\0';
            this.metroTextBox13.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox13.SelectedText = "";
            this.metroTextBox13.SelectionLength = 0;
            this.metroTextBox13.SelectionStart = 0;
            this.metroTextBox13.ShortcutsEnabled = true;
            this.metroTextBox13.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox13.TabIndex = 14;
            this.metroTextBox13.Text = "metroTextBox13";
            this.metroTextBox13.UseSelectable = true;
            this.metroTextBox13.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox13.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(179, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[] {
        "metroTextBox1"};
            this.metroTextBox1.Location = new System.Drawing.Point(300, 207);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(201, 23);
            this.metroTextBox1.TabIndex = 15;
            this.metroTextBox1.Text = "metroTextBox1";
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(367, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(401, 156);
            this.dataGridView1.TabIndex = 16;
            // 
            // Client
            // 
            this.ClientSize = new System.Drawing.Size(834, 382);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroTextBox13);
            this.Controls.Add(this.metroTextBox11);
            this.Controls.Add(this.metroTextBox10);
            this.Controls.Add(this.metroTextBox9);
            this.Controls.Add(this.metroTextBox8);
            this.Controls.Add(this.metroTextBox7);
            this.Controls.Add(this.metroTextBox6);
            this.Controls.Add(this.metroTextBox5);
            this.Controls.Add(this.metroTextBox4);
            this.Controls.Add(this.metroTextBox3);
            this.Controls.Add(this.metroTextBox2);
            this.Controls.Add(this.metroTextBox12);
            this.Controls.Add(this.metroGrid1);
            this.Controls.Add(this.metroButton1);
            this.Name = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Client_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pacDataSet.sot". При необходимости она может быть перемещена или удалена.
            //this.sotTableAdapter.Fill(this.pacDataSet.sot);

        }

        private void metroTextBox12_Click(object sender, EventArgs e)
        {

        }
    }
}