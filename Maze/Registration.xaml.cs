using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Maze
{

    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        int y;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=J:\=NT=\LogReg\DataBase\LogReg.mdf;Integrated Security=True;Connect Timeout=30");
        private void R_Reg_B_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.R_Log_TB.Text.Length >= 4)
                {
                    if (this.R_Pas_TB.Password.Length >= 6)
                    {
                        if (this.R_Pas_TB.Password == this.R_Pas2_TB.Password)
                        {
                            if (this.R_NAME_TB.Text != string.Empty || this.R_EMAIL_TB.Text != string.Empty)
                            {
                                string q = this.R_EMAIL_TB.Text;
                                if (q.Contains('@'))
                                {
                                    if (q.Contains('.'))
                                    {
                                        string[] dat = q.Split(new char[] { '@', '.' });
                                        if (dat[1] == "gmail" && dat[2] == "com" || dat[1] == "mail" && dat[2] == "ru" || dat[1] == "bk" && dat[2] == "ru" || dat[1] == "yandex" && dat[2] == "ru")
                                        {
                                            SqlCommand command = new SqlCommand(@"select * from [LogRegDate] where Login='" + R_Log_TB.Text + "'", Con);
                                            Con.Open();
                                            SqlDataReader read = command.ExecuteReader();
                                            if (read.HasRows)
                                            {
                                                MessageBox.Show("Логин повторяется!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                                Con.Close();
                                            }
                                            else
                                            {
                                                Con.Close();
                                                SqlCommand cmd = new SqlCommand("insert into [LogRegDate] ([Login], [Password], [Name], [LastName], [MiddleName], [Email]) values('" + R_Log_TB.Text + "','" + R_Pas_TB.Password + "','" + R_NAME_TB.Text + "','" + R_EMAIL_TB.Text + "')", Con);
                                                Con.Open();
                                                cmd.ExecuteNonQuery();
                                                Con.Close();
                                                MessageBox.Show("Регистрация успешна.", "Успех", MessageBoxButton.OK, MessageBoxImage.Error);
                                            }
                                        }
                                        else if (dat[1] == "" || dat[2] == "")
                                        {
                                            MessageBox.Show("Некоректная почта.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                            this.R_EMAIL_TB.Clear();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Некоректная почта.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                            this.R_EMAIL_TB.Clear();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Некоректная почта.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                        this.R_EMAIL_TB.Clear();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Некоректная почта.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    this.R_EMAIL_TB.Clear();
                                }
                            }
                            else
                            {
                                MessageBox.Show("У вас Никнейм имя или почта пустые.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                this.R_NAME_TB.Clear();
                                this.R_EMAIL_TB.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            this.R_Pas_TB.Clear();
                            this.R_Pas2_TB.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль не может быть меньше 6 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.R_Pas_TB.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Логин не может быть меньше 4 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.R_Log_TB.Clear();
                }
            }
            catch
            {
                {
                    MessageBox.Show("Подключение к базе данных не удалось.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void R_NAME_TB_TextChanged(object sender, EventArgs e)
        {
            string r = this.R_NAME_TB.Text;
            bool isNum = int.TryParse(r, out y);
            if (isNum)
            {
                MessageBox.Show("Вы ввели неверные данные в поле.", "Данныe", MessageBoxButton.OK, MessageBoxImage.Error); this.R_NAME_TB.Clear();
            }
        }

        private void R_Back_B_Click(object sender, EventArgs e)
        {
            MainWindow Log = new MainWindow();
            Log.Show();
            this.Close();
        }
    }
}
