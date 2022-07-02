using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace adonet_hw1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionstr = "Data Source=HOMEPC-81EK\\SQLEXPRESS; Database=CompanyDB;Trusted_Connection=true";
            SqlConnection conn = new SqlConnection(connectionstr);
            conn.Open();
            string sqlcommand = "";
            SqlCommand cmd;
            SqlDataReader dataReader;

            WriteLine("Меню домашнего задания");
            WriteLine("1. Сортировка по фамилиям \n" +
                "2. Сортировка по возрасту \n" +
                "3. Вывести всех сотрудников старше 2000 г.р");
            Write("Введите номер запроса : ");
            int c = Convert.ToInt32(ReadLine());
            switch (c)
            {
                case 1:
                    sqlcommand = "SELECT * FROM[CompanyDB].[dbo].[Employee] ORDER BY LastName";
                    cmd = new SqlCommand(sqlcommand, conn); // Command create
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var f1 = dataReader[0];
                        var f2 = dataReader[1];
                        var f3 = dataReader[2];
                        var f4 = dataReader[3];
                        WriteLine($"{f1}\t{f2}\t{f3}\t\t{f4}");
                    }
                    break;
                case 2:
                    sqlcommand = "SELECT * FROM[CompanyDB].[dbo].[Employee] ORDER BY BirthDate";
                    cmd = new SqlCommand(sqlcommand, conn); // Command create
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var f1 = dataReader[0];
                        var f2 = dataReader[1];
                        var f3 = dataReader[2];
                        var f4 = dataReader[3];
                        WriteLine($"{f1}\t{f2}\t{f3}\t{f4}");
                    }
                    break;
                case 3:
                    sqlcommand = "SELECT * FROM[CompanyDB].[dbo].[Employee] WHERE YEAR(BirthDate) < '2000' ORDER BY BirthDate";
                    cmd = new SqlCommand(sqlcommand, conn); // Command create
                    dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        var f1 = dataReader[0];
                        var f2 = dataReader[1];
                        var f3 = dataReader[2];
                        var f4 = dataReader[3];
                        WriteLine($"{f1}\t{f2}\t{f3}\t{f4}");
                    }
                        break;
                default:
                    break;
            }
        }
    }
}
