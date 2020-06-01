using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace hospital
{
public static class Userinfo
{
static string uname;

//класс для фиксирования ФИО пользователя
public static string getusername()
{
return uname;
}

public static void setusername(string un)
{
uname = un;
}
}
}