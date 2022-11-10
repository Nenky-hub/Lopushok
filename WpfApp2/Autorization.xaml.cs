using System;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {
        public string Access;
        public Autorization()
        {
            InitializeComponent();
        }
        //Модуль шифрования пароля
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        //Кнопка авторизации
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //шИВРАТОР ПАРОЛЕЙ
            //var aaa = GetHash(Password_Box.Text);
            //Username_Box.Text = aaa.ToString();

            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Username_Box.Text))
            {
                errors.AppendLine("Укажите логин");
            }

            if (string.IsNullOrWhiteSpace(Password_Box.Text))
            {
                errors.AppendLine("Укажите пароль");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка входа.");
                return;
            }


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"SELECT Access FROM Users where login ='{Username_Box.Text}' and password = '{GetHash(Password_Box.Text)}'";

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = JARWIS\SQLEXPRESS; Initial Catalog=lapushok; Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand(querystring, sqlConnection);

            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                // MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Access = table.Rows[0][0].ToString();
                if (Access == "Master")
                {
                    Manager.MainFrame.Navigate(new Working_shift());
                    sqlConnection.Close();
                }
                else if (Access == "Admin")
                {
                    Manager.MainFrame.Navigate(new knopki());
                    sqlConnection.Close();
                }
                else if (Access == "Manager")
                {
                    Manager.MainFrame.Navigate(new Materials());
                    sqlConnection.Close();
                }
                else if (Access == "Agent")
                {
                    Manager.MainFrame.Navigate(new Product());
                    sqlConnection.Close();
                }
            }
            else
                MessageBox.Show("Логин или пароль неверный. Если Вы забыли пароль - обратитесь к администратору", "Аккаунт не обнаружен!", MessageBoxButton.OK);

        }
    }
}
