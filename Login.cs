using System; //область имен с системными базовыми классами
using System.Data; //классы для взаимодействия с базами данных
using System.Windows.Forms; //классы для операции с формами
using MySql.Data.MySqlClient; //классы для работы с MySql базами
namespace hospital
{
public partial class login : MetroFramework.Forms.MetroForm

{
public login()
{
InitializeComponent();
}
//при изменении текста в поле с паролем скрываем его звездочкой
private void MetroTextBox2_TextChanged(object sender, EventArgs e)
{
passwordbox.PasswordChar = '*';
}

private void Loginbutton_Click(object sender, EventArgs e)
{
enter();
}
//проверка на то есть ли введенные данные(логин и пароль) в базе
public bool tryLogin(string uname, string pword)

{
MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=pac;password=Monolit_12");
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
MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=pac;password=Monolit_12");
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
if (tryLogin(loginbox.Text, passwordbox.Text) ==true)
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
client cl = new client();
cl.Show();
break;
case "Админ":
vhod();
MessageBox.Show("Добро пожаловать " +
Userinfo.getusername(), "Вход выполнен");
client cl2 = new client();
this.Hide();
cl2.Show();
cl2.time.Visible = true;
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
string Query = "insert into time(`ФИО`,`Время`,`Действие`) VALUES ('"+Userinfo.getusername()+"', '"+bam+"', '"+dey+"')";
// создаём объект для подключения к БД
MySqlConnection conn = new MySqlConnection(connStr);
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
}
}