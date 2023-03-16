﻿using System;
using System.Collections.Generic;
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
using BankApplication.Enums;
using Microsoft.EntityFrameworkCore;

namespace BankApplication
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            var Username = TextBoxLog.Text;
            var Password = TextBoxPass.Text;

            using (SQLite conn = new SQLite())
            {
                bool userexist = conn.Login.Any(user => user.UserName == Username && user.Password == Password);
                if(userexist) 
                {
                    LogIn();
                    var x = new Client(false, "w", ClientType.Teenager, 1, "", 1, "", "");
                    Client.IdUser = ReadId();
                    x = x.LoadData(Client.IdUser);
                    Close();
                }
                else
                {
                    MessageBox.Show("Źle wprowadzone dane");
                }
            }
        }
        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            RegStart();
            Close();
        }
        public void LogIn()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
        public void RegStart()
        {
            Register register = new Register();
            register.Show();
        }
        private int ReadId()
        {
            int x = 0;
            using (SQLite ctx = new SQLite())
            {
                var query = (from c in ctx.Login
                             where c.UserName == TextBoxLog.Text
                             select new
                             {
                                 c.Id_User,
                             }
                             ).FirstOrDefault();

                if (query != null)
                {
                    x = query.Id_User;
                }
            }
            return x;
        }
    }
}
