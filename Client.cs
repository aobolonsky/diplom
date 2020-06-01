using System; //область имен с системными базовыми классами
using System.Data; //классы для взаимодействия с базами данных
using System.Text; //для работы с текстом
using System.Windows.Forms; //классы для операции с формами
using MySql.Data.MySqlClient; //классы для работы с MySql базами
using System.IO; //классы ввода и вывода данных
namespace hospital
{
public partial class client : MetroFramework.Forms.MetroForm
{
public client()
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
"server=localhost;user=root;database=pac;password=Monolit_12;";
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
"server=localhost;user=root;database=pac;password=Monolit_12;";
// SQL запрос
string Query = "insert into pac.pers(Фамилия, Имя, Отчество, Пол, `Дата рождения`, КСГ, Серия, Номер, СНИЛС, Адрес, `Место рождения`, `Дата добавления`) values('"+metroTextBox12.Text+"','"+metroTextBox2.Text+"','"+metroTextBox3.Text +"','"+metroTextBox4.Text+"','"+metroTextBox5.Text+"','"+metroTextBox6.Text+"','" +metroTextBox7.Text+"','"+metroTextBox8.Text+"','"+metroTextBox9.Text+"','"+metroTextBox10.Text+"','"+ metroTextBox11.Text+ "','" + bam + "')";
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
"server=localhost;user=root;database=pac;password=Monolit_12;";
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
"server=localhost;user=root;database=pac;password=Monolit_12;";
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
"server=localhost;user=root;database=pac;password=Monolit_12;";
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
"server=localhost;user=root;database=pac;password=Monolit_12;";
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
"server=localhost;user=root;database=pac;password=Monolit_12;";
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
}
}