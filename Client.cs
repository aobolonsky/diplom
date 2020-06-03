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
        private MetroFramework.Controls.MetroButton Add;
        private MetroFramework.Controls.MetroButton Delete;
        private MetroFramework.Controls.MetroButton Update;
        private MetroFramework.Controls.MetroButton Export;
        private MetroFramework.Controls.MetroButton Home;
        private MetroFramework.Controls.MetroButton Zaprosdate;
        private MetroFramework.Controls.MetroButton Find;
        public MetroFramework.Controls.MetroButton time;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel11;
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
            string Query = "insert into pers(Фамилия, Имя, Отчество, Пол, `Дата рождения`, КСГ, Серия, Номер, СНИЛС, Адрес, `Место рождения`, `Дата добавления`) values('" + metroTextBox12.Text + "','" + metroTextBox2.Text + "','" + metroTextBox3.Text + "','" + metroTextBox4.Text + "','" + metroTextBox5.Text + "','" + metroTextBox6.Text + "','" + metroTextBox7.Text + "','" + metroTextBox8.Text + "','" + metroTextBox9.Text + "','" + metroTextBox10.Text + "','" + metroTextBox11.Text + "','" + bam + "')";
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
        private void Export_Click(object sender, EventArgs e)
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
            this.sotBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pacDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pacDataSet = new diplom.pacDataSet();
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
            this.Add = new MetroFramework.Controls.MetroButton();
            this.Delete = new MetroFramework.Controls.MetroButton();
            this.Update = new MetroFramework.Controls.MetroButton();
            this.Export = new MetroFramework.Controls.MetroButton();
            this.Home = new MetroFramework.Controls.MetroButton();
            this.Zaprosdate = new MetroFramework.Controls.MetroButton();
            this.Find = new MetroFramework.Controls.MetroButton();
            this.time = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(917, 190);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(105, 23);
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
            // sotBindingSource
            // 
            this.sotBindingSource.DataMember = "sot";
            this.sotBindingSource.DataSource = this.pacDataSetBindingSource;
            // 
            // pacDataSetBindingSource
            // 
            this.pacDataSetBindingSource.DataSource = this.pacDataSet;
            this.pacDataSetBindingSource.Position = 0;
            // 
            // pacDataSet
            // 
            this.pacDataSet.DataSetName = "pacDataSet";
            this.pacDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.metroTextBox12.Lines = new string[0];
            this.metroTextBox12.Location = new System.Drawing.Point(113, 67);
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
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(206, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Lines = new string[0];
            this.metroTextBox2.Location = new System.Drawing.Point(113, 104);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(228, 23);
            this.metroTextBox2.TabIndex = 4;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox2.Click += new System.EventHandler(this.metroTextBox2_Click);
            // 
            // metroTextBox3
            // 
            // 
            // 
            // 
            this.metroTextBox3.CustomButton.Image = null;
            this.metroTextBox3.CustomButton.Location = new System.Drawing.Point(206, 1);
            this.metroTextBox3.CustomButton.Name = "";
            this.metroTextBox3.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox3.CustomButton.TabIndex = 1;
            this.metroTextBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox3.CustomButton.UseSelectable = true;
            this.metroTextBox3.CustomButton.Visible = false;
            this.metroTextBox3.Lines = new string[0];
            this.metroTextBox3.Location = new System.Drawing.Point(113, 137);
            this.metroTextBox3.MaxLength = 32767;
            this.metroTextBox3.Name = "metroTextBox3";
            this.metroTextBox3.PasswordChar = '\0';
            this.metroTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox3.SelectedText = "";
            this.metroTextBox3.SelectionLength = 0;
            this.metroTextBox3.SelectionStart = 0;
            this.metroTextBox3.ShortcutsEnabled = true;
            this.metroTextBox3.Size = new System.Drawing.Size(228, 23);
            this.metroTextBox3.TabIndex = 5;
            this.metroTextBox3.UseSelectable = true;
            this.metroTextBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox3.Click += new System.EventHandler(this.metroTextBox3_Click);
            // 
            // metroTextBox4
            // 
            // 
            // 
            // 
            this.metroTextBox4.CustomButton.Image = null;
            this.metroTextBox4.CustomButton.Location = new System.Drawing.Point(206, 1);
            this.metroTextBox4.CustomButton.Name = "";
            this.metroTextBox4.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox4.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox4.CustomButton.TabIndex = 1;
            this.metroTextBox4.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox4.CustomButton.UseSelectable = true;
            this.metroTextBox4.CustomButton.Visible = false;
            this.metroTextBox4.Lines = new string[0];
            this.metroTextBox4.Location = new System.Drawing.Point(113, 180);
            this.metroTextBox4.MaxLength = 32767;
            this.metroTextBox4.Name = "metroTextBox4";
            this.metroTextBox4.PasswordChar = '\0';
            this.metroTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox4.SelectedText = "";
            this.metroTextBox4.SelectionLength = 0;
            this.metroTextBox4.SelectionStart = 0;
            this.metroTextBox4.ShortcutsEnabled = true;
            this.metroTextBox4.Size = new System.Drawing.Size(228, 23);
            this.metroTextBox4.TabIndex = 6;
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
            this.metroTextBox5.CustomButton.Location = new System.Drawing.Point(206, 1);
            this.metroTextBox5.CustomButton.Name = "";
            this.metroTextBox5.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox5.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox5.CustomButton.TabIndex = 1;
            this.metroTextBox5.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox5.CustomButton.UseSelectable = true;
            this.metroTextBox5.CustomButton.Visible = false;
            this.metroTextBox5.Lines = new string[0];
            this.metroTextBox5.Location = new System.Drawing.Point(113, 220);
            this.metroTextBox5.MaxLength = 32767;
            this.metroTextBox5.Name = "metroTextBox5";
            this.metroTextBox5.PasswordChar = '\0';
            this.metroTextBox5.PromptText = "дд.мм.гггг";
            this.metroTextBox5.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox5.SelectedText = "";
            this.metroTextBox5.SelectionLength = 0;
            this.metroTextBox5.SelectionStart = 0;
            this.metroTextBox5.ShortcutsEnabled = true;
            this.metroTextBox5.Size = new System.Drawing.Size(228, 23);
            this.metroTextBox5.TabIndex = 7;
            this.metroTextBox5.UseSelectable = true;
            this.metroTextBox5.WaterMark = "дд.мм.гггг";
            this.metroTextBox5.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox5.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox6
            // 
            // 
            // 
            // 
            this.metroTextBox6.CustomButton.Image = null;
            this.metroTextBox6.CustomButton.Location = new System.Drawing.Point(206, 1);
            this.metroTextBox6.CustomButton.Name = "";
            this.metroTextBox6.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox6.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox6.CustomButton.TabIndex = 1;
            this.metroTextBox6.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox6.CustomButton.UseSelectable = true;
            this.metroTextBox6.CustomButton.Visible = false;
            this.metroTextBox6.Lines = new string[0];
            this.metroTextBox6.Location = new System.Drawing.Point(113, 266);
            this.metroTextBox6.MaxLength = 32767;
            this.metroTextBox6.Name = "metroTextBox6";
            this.metroTextBox6.PasswordChar = '\0';
            this.metroTextBox6.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox6.SelectedText = "";
            this.metroTextBox6.SelectionLength = 0;
            this.metroTextBox6.SelectionStart = 0;
            this.metroTextBox6.ShortcutsEnabled = true;
            this.metroTextBox6.Size = new System.Drawing.Size(228, 23);
            this.metroTextBox6.TabIndex = 8;
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
            this.metroTextBox7.CustomButton.Location = new System.Drawing.Point(202, 1);
            this.metroTextBox7.CustomButton.Name = "";
            this.metroTextBox7.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox7.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox7.CustomButton.TabIndex = 1;
            this.metroTextBox7.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox7.CustomButton.UseSelectable = true;
            this.metroTextBox7.CustomButton.Visible = false;
            this.metroTextBox7.Lines = new string[0];
            this.metroTextBox7.Location = new System.Drawing.Point(625, 67);
            this.metroTextBox7.MaxLength = 32767;
            this.metroTextBox7.Name = "metroTextBox7";
            this.metroTextBox7.PasswordChar = '\0';
            this.metroTextBox7.PromptText = "0000";
            this.metroTextBox7.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox7.SelectedText = "";
            this.metroTextBox7.SelectionLength = 0;
            this.metroTextBox7.SelectionStart = 0;
            this.metroTextBox7.ShortcutsEnabled = true;
            this.metroTextBox7.Size = new System.Drawing.Size(224, 23);
            this.metroTextBox7.TabIndex = 9;
            this.metroTextBox7.UseSelectable = true;
            this.metroTextBox7.WaterMark = "0000";
            this.metroTextBox7.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox7.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox8
            // 
            // 
            // 
            // 
            this.metroTextBox8.CustomButton.Image = null;
            this.metroTextBox8.CustomButton.Location = new System.Drawing.Point(202, 1);
            this.metroTextBox8.CustomButton.Name = "";
            this.metroTextBox8.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox8.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox8.CustomButton.TabIndex = 1;
            this.metroTextBox8.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox8.CustomButton.UseSelectable = true;
            this.metroTextBox8.CustomButton.Visible = false;
            this.metroTextBox8.Lines = new string[0];
            this.metroTextBox8.Location = new System.Drawing.Point(625, 100);
            this.metroTextBox8.MaxLength = 32767;
            this.metroTextBox8.Name = "metroTextBox8";
            this.metroTextBox8.PasswordChar = '\0';
            this.metroTextBox8.PromptText = "000000";
            this.metroTextBox8.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox8.SelectedText = "";
            this.metroTextBox8.SelectionLength = 0;
            this.metroTextBox8.SelectionStart = 0;
            this.metroTextBox8.ShortcutsEnabled = true;
            this.metroTextBox8.Size = new System.Drawing.Size(224, 23);
            this.metroTextBox8.TabIndex = 10;
            this.metroTextBox8.UseSelectable = true;
            this.metroTextBox8.WaterMark = "000000";
            this.metroTextBox8.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox8.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBox9
            // 
            // 
            // 
            // 
            this.metroTextBox9.CustomButton.Image = null;
            this.metroTextBox9.CustomButton.Location = new System.Drawing.Point(202, 1);
            this.metroTextBox9.CustomButton.Name = "";
            this.metroTextBox9.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox9.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox9.CustomButton.TabIndex = 1;
            this.metroTextBox9.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox9.CustomButton.UseSelectable = true;
            this.metroTextBox9.CustomButton.Visible = false;
            this.metroTextBox9.Lines = new string[0];
            this.metroTextBox9.Location = new System.Drawing.Point(625, 137);
            this.metroTextBox9.MaxLength = 32767;
            this.metroTextBox9.Name = "metroTextBox9";
            this.metroTextBox9.PasswordChar = '\0';
            this.metroTextBox9.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox9.SelectedText = "";
            this.metroTextBox9.SelectionLength = 0;
            this.metroTextBox9.SelectionStart = 0;
            this.metroTextBox9.ShortcutsEnabled = true;
            this.metroTextBox9.Size = new System.Drawing.Size(224, 23);
            this.metroTextBox9.TabIndex = 11;
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
            this.metroTextBox10.CustomButton.Location = new System.Drawing.Point(202, 1);
            this.metroTextBox10.CustomButton.Name = "";
            this.metroTextBox10.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox10.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox10.CustomButton.TabIndex = 1;
            this.metroTextBox10.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox10.CustomButton.UseSelectable = true;
            this.metroTextBox10.CustomButton.Visible = false;
            this.metroTextBox10.Lines = new string[0];
            this.metroTextBox10.Location = new System.Drawing.Point(625, 180);
            this.metroTextBox10.MaxLength = 32767;
            this.metroTextBox10.Name = "metroTextBox10";
            this.metroTextBox10.PasswordChar = '\0';
            this.metroTextBox10.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox10.SelectedText = "";
            this.metroTextBox10.SelectionLength = 0;
            this.metroTextBox10.SelectionStart = 0;
            this.metroTextBox10.ShortcutsEnabled = true;
            this.metroTextBox10.Size = new System.Drawing.Size(224, 23);
            this.metroTextBox10.TabIndex = 12;
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
            this.metroTextBox11.CustomButton.Location = new System.Drawing.Point(202, 1);
            this.metroTextBox11.CustomButton.Name = "";
            this.metroTextBox11.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox11.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox11.CustomButton.TabIndex = 1;
            this.metroTextBox11.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox11.CustomButton.UseSelectable = true;
            this.metroTextBox11.CustomButton.Visible = false;
            this.metroTextBox11.Lines = new string[0];
            this.metroTextBox11.Location = new System.Drawing.Point(625, 220);
            this.metroTextBox11.MaxLength = 32767;
            this.metroTextBox11.Name = "metroTextBox11";
            this.metroTextBox11.PasswordChar = '\0';
            this.metroTextBox11.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox11.SelectedText = "";
            this.metroTextBox11.SelectionLength = 0;
            this.metroTextBox11.SelectionStart = 0;
            this.metroTextBox11.ShortcutsEnabled = true;
            this.metroTextBox11.Size = new System.Drawing.Size(224, 23);
            this.metroTextBox11.TabIndex = 13;
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
            this.metroTextBox13.CustomButton.Location = new System.Drawing.Point(86, 1);
            this.metroTextBox13.CustomButton.Name = "";
            this.metroTextBox13.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox13.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox13.CustomButton.TabIndex = 1;
            this.metroTextBox13.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox13.CustomButton.UseSelectable = true;
            this.metroTextBox13.CustomButton.Visible = false;
            this.metroTextBox13.Lines = new string[0];
            this.metroTextBox13.Location = new System.Drawing.Point(606, 16);
            this.metroTextBox13.MaxLength = 32767;
            this.metroTextBox13.Name = "metroTextBox13";
            this.metroTextBox13.PasswordChar = '\0';
            this.metroTextBox13.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox13.SelectedText = "";
            this.metroTextBox13.SelectionLength = 0;
            this.metroTextBox13.SelectionStart = 0;
            this.metroTextBox13.ShortcutsEnabled = true;
            this.metroTextBox13.Size = new System.Drawing.Size(108, 23);
            this.metroTextBox13.TabIndex = 14;
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
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(837, 16);
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
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 318);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1096, 230);
            this.dataGridView1.TabIndex = 16;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(23, 16);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 17;
            this.Add.Text = "Добавить";
            this.Add.UseSelectable = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(104, 16);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 18;
            this.Delete.Text = "Удалить";
            this.Delete.UseSelectable = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(185, 16);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 23);
            this.Update.TabIndex = 19;
            this.Update.Text = "Изменить";
            this.Update.UseSelectable = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Export
            // 
            this.Export.Location = new System.Drawing.Point(266, 16);
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(75, 23);
            this.Export.TabIndex = 20;
            this.Export.Text = "Экспорт";
            this.Export.UseSelectable = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(347, 16);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(75, 23);
            this.Home.TabIndex = 21;
            this.Home.Text = "Пациенты";
            this.Home.UseSelectable = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // Zaprosdate
            // 
            this.Zaprosdate.Location = new System.Drawing.Point(720, 16);
            this.Zaprosdate.Name = "Zaprosdate";
            this.Zaprosdate.Size = new System.Drawing.Size(111, 23);
            this.Zaprosdate.TabIndex = 22;
            this.Zaprosdate.Text = "Запрос по дате";
            this.Zaprosdate.UseSelectable = true;
            this.Zaprosdate.Click += new System.EventHandler(this.Zaprosdate_Click);
            // 
            // Find
            // 
            this.Find.Location = new System.Drawing.Point(1044, 16);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(75, 23);
            this.Find.TabIndex = 23;
            this.Find.Text = "Найти";
            this.Find.UseSelectable = true;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(428, 16);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(75, 23);
            this.time.TabIndex = 24;
            this.time.Text = "Персонал";
            this.time.UseSelectable = true;
            this.time.Visible = false;
            this.time.Click += new System.EventHandler(this.Time_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(35, 67);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(65, 19);
            this.metroLabel1.TabIndex = 25;
            this.metroLabel1.Text = "Фамилия";
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(35, 104);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(35, 19);
            this.metroLabel3.TabIndex = 27;
            this.metroLabel3.Text = "Имя";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(35, 137);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(65, 19);
            this.metroLabel2.TabIndex = 28;
            this.metroLabel2.Text = "Отчество";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(35, 180);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(33, 19);
            this.metroLabel4.TabIndex = 29;
            this.metroLabel4.Text = "Пол";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(35, 220);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(37, 19);
            this.metroLabel5.TabIndex = 30;
            this.metroLabel5.Text = "Дата";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(37, 266);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(31, 19);
            this.metroLabel6.TabIndex = 31;
            this.metroLabel6.Text = "КСГ";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(412, 67);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(48, 19);
            this.metroLabel7.TabIndex = 32;
            this.metroLabel7.Text = "Серия";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(412, 104);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(50, 19);
            this.metroLabel8.TabIndex = 33;
            this.metroLabel8.Text = "Номер";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(412, 137);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(55, 19);
            this.metroLabel9.TabIndex = 34;
            this.metroLabel9.Text = "СНИЛС";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(412, 180);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(128, 19);
            this.metroLabel10.TabIndex = 35;
            this.metroLabel10.Text = "Адрес проживания";
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(412, 220);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(113, 19);
            this.metroLabel11.TabIndex = 36;
            this.metroLabel11.Text = "Место рождения";
            // 
            // Client
            // 
            this.ClientSize = new System.Drawing.Size(1142, 575);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.time);
            this.Controls.Add(this.Find);
            this.Controls.Add(this.Zaprosdate);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.Export);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Add);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.Load += new System.EventHandler(this.Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pacDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sotBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Client_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pacDataSet.sot". При необходимости она может быть перемещена или удалена.
            //this.sotTableAdapter.Fill(this.pacDataSet.sot);

        }

        private void metroTextBox12_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {

        }
    }
}