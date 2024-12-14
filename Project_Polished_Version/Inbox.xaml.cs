﻿using MySql.Data.MySqlClient;
using Project_Polished_Version.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Project_Polished_Version
{
    /// <summary>
    /// Interaction logic for Inbox.xaml
    /// </summary>
    public partial class Inbox : Window
    {
        private string _connection = "Server=localhost;Database=project_database;UserName=root;Password=Cedric1234%%";
        public Inbox()
        {
            InitializeComponent();
            LoadEmailsFromDatabase();
        }
        private List<Email> emails = new List<Email>();

        private void LoadEmailsFromDatabase()
        {
            string query = "SELECT * FROM the_emails_db";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connection))
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Email email = new Email
                        {
                            Id = Convert.ToInt32(row["emailNumber"]),
                            Sender = row["Sender"].ToString(),
                            Subject = row["Subject"].ToString(),
                            Content = row["Message"].ToString()
                        };
                        emails.Add(email);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            LoadEmails(emails);
        }

        // Method to load emails into ListView
        private void LoadEmails(List<Email> emailsToDisplay)
        {
            MessagesListView.Items.Clear();

            foreach (var email in emailsToDisplay)
            {
                ListViewItem item = new ListViewItem();
                StackPanel stackPanel = new StackPanel { Orientation = Orientation.Horizontal };

                CheckBox checkBox = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
                TextBlock senderText = new TextBlock { Text = email.Sender, FontWeight = FontWeights.Bold, Margin = new Thickness(5, 0, 0, 0) };
                TextBlock subjectText = new TextBlock { Text = email.Subject, Margin = new Thickness(5, 0, 0, 0) };

                stackPanel.Children.Add(checkBox);
                stackPanel.Children.Add(senderText);
                stackPanel.Children.Add(subjectText);

                item.Content = stackPanel;
                item.MouseLeftButtonUp += Email_Selected;

                MessagesListView.Items.Add(item);
            }
        }

        // Method to handle selecting an email
        private void Email_Selected(object sender, RoutedEventArgs e)
        {
            if (sender is ListViewItem item && item.Content is StackPanel stackPanel)
            {
                var index = MessagesListView.Items.IndexOf(item);
                if (index >= 0 && index < emails.Count)
                {
                    var email = emails[index];
                    if (MessageContentTextBlock != null)
                    {
                        MessageContentTextBlock.Text = email.Content;
                    }
                }
            }
        }

        // Search Button Click Event Handler
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text.ToLower();
            var filteredEmails = emails.Where(email =>
                email.Sender.ToLower().StartsWith(searchTerm) ||
                email.Subject.ToLower().StartsWith(searchTerm) ||
                email.Content.ToLower().StartsWith(searchTerm)).ToList();

            LoadEmails(filteredEmails);
        }



        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Compose_Email_Click(object sender, RoutedEventArgs e)
        {
            ComposeEmail ce = new ComposeEmail();
            ce.Show();
        }
    }
}

