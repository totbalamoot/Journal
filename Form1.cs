using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;
using System.Threading;

namespace Journal
{
    public partial class Form1 : Form
    {
        OleDbConnection sqlConnection;
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=journal.mdb";

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new OleDbConnection(connectionString);
            await sqlConnection.OpenAsync();
            DbDataReader sqlReader = null;
            OleDbCommand command = new OleDbCommand("SELECT * FROM [students]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    studentsListBox.Items.Add(Convert.ToString(sqlReader["Name"]) + " "
                                     + Convert.ToString(sqlReader["Surname"]) + " "
                                     + Convert.ToString(sqlReader["Class"]));
                    numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"])); //для удобства определения индекса
                }
                command = new OleDbCommand("SELECT [ID] FROM [students] ", sqlConnection);
                sqlReader = await command.ExecuteReaderAsync();
                numbersListBox.Items.Clear();
                while (await sqlReader.ReadAsync())
                {
                    numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"]));
                }
                marksListBox.Items.Clear();
                string[] str = new string[5];
                studentsListBox.SetSelected(0, true);
                numbersListBox.SetSelected(0, true);

                command = new OleDbCommand("SELECT * FROM [math] WHERE [ID] = @ID", sqlConnection);
                command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                await command.ExecuteNonQueryAsync();
                sqlReader = await command.ExecuteReaderAsync();

                command = new OleDbCommand("SELECT * FROM [phys] WHERE [ID] = @ID", sqlConnection);
                command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                await command.ExecuteNonQueryAsync();
                sqlReader = await command.ExecuteReaderAsync();

                str = marksListBox.Items[0].ToString().Split(' ');
                controlTextBox1.Text = str[0];
                controlTextBox2.Text = str[1];
                controlTextBox3.Text = str[2];
                controlTextBox4.Text = str[3];
                totalTextBox.Text = str[4];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void showAllButton_Click(object sender, EventArgs e)
        {
            studentsListBox.Items.Clear();
            numbersListBox.Items.Clear();
            sqlConnection = new OleDbConnection(connectionString);
            await sqlConnection.OpenAsync();
            DbDataReader sqlReader = null;
            OleDbCommand command = new OleDbCommand("SELECT * FROM [students]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    studentsListBox.Items.Add(Convert.ToString(sqlReader["Name"]) + " "
                                     + Convert.ToString(sqlReader["Surname"]) + " "
                                     + Convert.ToString(sqlReader["Class"]));
                    numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"])); //для удобства определения индекса
                }
                command = new OleDbCommand("SELECT [ID] FROM [students] ", sqlConnection);
                sqlReader = await command.ExecuteReaderAsync();
                numbersListBox.Items.Clear();
                while (await sqlReader.ReadAsync())
                {
                    numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"]));
                }
                SetSingle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void addStudentButton_Click(object sender, EventArgs e)
        {
            sqlConnection = new OleDbConnection(connectionString);
            await sqlConnection.OpenAsync();
            DbDataReader sqlReader = null;
            int maxid = 0;
            try
            {
                if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                    !string.IsNullOrEmpty(surnameTextBox.Text) && !string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                    !string.IsNullOrEmpty(classTextBox.Text) && !string.IsNullOrWhiteSpace(classTextBox.Text))
                {
                    OleDbCommand command = new OleDbCommand("INSERT INTO [students] ([Name], [Surname], [Class])VALUES(@Name, @Surname, @Class)", sqlConnection);
                    command.Parameters.AddWithValue("Name", nameTextBox.Text);
                    command.Parameters.AddWithValue("Surname", surnameTextBox.Text);
                    command.Parameters.AddWithValue("Class", classTextBox.Text);
                    await command.ExecuteNonQueryAsync();
                    command = new OleDbCommand("SELECT max([ID]) AS [ID] FROM [students]", sqlConnection);
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        maxid = Convert.ToInt32(sqlReader["ID"]);
                    }
                    studentsListBox.Items.Add(nameTextBox.Text + " " + surnameTextBox.Text + " " + classTextBox.Text);
                    numbersListBox.Items.Add(Convert.ToString(maxid));
                    command = new OleDbCommand("INSERT INTO [math] ([ID], [Control1], [Control2], [Control3], [Control4])VALUES(@ID, 0, 0, 0, 0)", sqlConnection);
                    command.Parameters.AddWithValue("ID", maxid);
                    await command.ExecuteNonQueryAsync();
                    command = new OleDbCommand("INSERT INTO [phys] ([ID], [Control1], [Control2], [Control3], [Control4])VALUES(@ID, 0, 0, 0, 0)", sqlConnection);
                    command.Parameters.AddWithValue("ID", maxid);
                    await command.ExecuteNonQueryAsync();
                    command = new OleDbCommand("INSERT INTO [rpks] ([ID], [Control1], [Control2], [Control3], [Control4])VALUES(@ID, 0, 0, 0, 0)", sqlConnection);
                    command.Parameters.AddWithValue("ID", maxid);
                    await command.ExecuteNonQueryAsync();
                    command = new OleDbCommand("INSERT INTO [chem] ([ID], [Control1], [Control2], [Control3], [Control4])VALUES(@ID, 0, 0, 0, 0)", sqlConnection);
                    command.Parameters.AddWithValue("ID", maxid);
                    await command.ExecuteNonQueryAsync();
                    SetSingle();
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void deleteStudentButton_Click(object sender, EventArgs e)
        {
            sqlConnection = new OleDbConnection(connectionString);
            sqlConnection.Open();
            DbDataReader sqlReader = null;
            try
            {
                if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                    !string.IsNullOrEmpty(surnameTextBox.Text) && !string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                    !string.IsNullOrEmpty(classTextBox.Text) && !string.IsNullOrWhiteSpace(classTextBox.Text) &&
                    numbersListBox.SelectedItem != null) {
                    OleDbCommand command = new OleDbCommand("DELETE FROM [students] WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem.ToString());
                    await command.ExecuteNonQueryAsync();
                    command = new OleDbCommand("DELETE FROM[math] WHERE[ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem.ToString());
                    await command.ExecuteNonQueryAsync();
                    command = new OleDbCommand("DELETE FROM[phys] WHERE[ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem.ToString());
                    await command.ExecuteNonQueryAsync();
                    command = new OleDbCommand("DELETE FROM[rpks] WHERE[ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem.ToString());
                    await command.ExecuteNonQueryAsync();
                    command = new OleDbCommand("DELETE FROM[chem] WHERE[ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem.ToString());
                    await command.ExecuteNonQueryAsync();
                    if (studentsListBox.Items.Count > 1)
                    {
                        numbersListBox.Items.RemoveAt(studentsListBox.SelectedIndex);
                        studentsListBox.Items.RemoveAt(studentsListBox.SelectedIndex);
                    }
                    else
                    {
                        studentsListBox.Items.Clear();
                        numbersListBox.Items.Clear();
                        SetSingle();
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void studentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] str = new string[3];
            if (studentsListBox.SelectedItem != null && studentsListBox.SelectedIndex != -1)
            {
                str = studentsListBox.SelectedItem.ToString().Split(' ');
                numbersListBox.SetSelected(studentsListBox.SelectedIndex, true);
                nameTextBox.Text = str[0];
                surnameTextBox.Text = str[1];
                classTextBox.Text = str[2];
                marksListBox.Items.Clear();
                sqlConnection = new OleDbConnection(connectionString);
                await sqlConnection.OpenAsync();
                DbDataReader sqlReader = null;
                try
                {
                    OleDbCommand command = new OleDbCommand("SELECT * FROM [math] WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        marksListBox.Items.Add(Convert.ToString(sqlReader["Control1"]) + " "
                                         + Convert.ToString(sqlReader["Control2"]) + " "
                                         + Convert.ToString(sqlReader["Control3"]) + " "
                                         + Convert.ToString(sqlReader["Control4"]) + " "
                                         + Convert.ToString(sqlReader["Total"]));
                    }
                    command = new OleDbCommand("SELECT * FROM [phys] WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        marksListBox.Items.Add(Convert.ToString(sqlReader["Control1"]) + " "
                                         + Convert.ToString(sqlReader["Control2"]) + " "
                                         + Convert.ToString(sqlReader["Control3"]) + " "
                                         + Convert.ToString(sqlReader["Control4"]) + " "
                                         + Convert.ToString(sqlReader["Total"]));
                    }
                    command = new OleDbCommand("SELECT * FROM [rpks] WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        marksListBox.Items.Add(Convert.ToString(sqlReader["Control1"]) + " "
                                         + Convert.ToString(sqlReader["Control2"]) + " "
                                         + Convert.ToString(sqlReader["Control3"]) + " "
                                         + Convert.ToString(sqlReader["Control4"]) + " "
                                         + Convert.ToString(sqlReader["Total"]));
                    }
                    command = new OleDbCommand("SELECT * FROM [chem] WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        marksListBox.Items.Add(Convert.ToString(sqlReader["Control1"]) + " "
                                         + Convert.ToString(sqlReader["Control2"]) + " "
                                         + Convert.ToString(sqlReader["Control3"]) + " "
                                         + Convert.ToString(sqlReader["Control4"]) + " "
                                         + Convert.ToString(sqlReader["Total"]));
                    }
                    marksListBox.SetSelected(0, true);
                    deleteStudentButton.Enabled = true;
                    str = marksListBox.Items[0].ToString().Split(' ');
                    controlTextBox1.Text = str[0];
                    controlTextBox2.Text = str[1];
                    controlTextBox3.Text = str[2];
                    controlTextBox4.Text = str[3];
                    totalTextBox.Text = str[4];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }
            else if (studentsListBox.SelectedIndex == -1)
            {
                studentsListBox.SetSelected(0, true);
            }
            else
            {
                studentsListBox.SetSelected(numbersListBox.SelectedIndex, true);
            }
        }

        //функция поиска учеников по любым значениям и их сочетаниям
        private async void searchStudentButton_Click(object sender, EventArgs e)
        {
            sqlConnection = new OleDbConnection(connectionString);
            await sqlConnection.OpenAsync();
            DbDataReader sqlReader = null;
            //заполнены имя фамилия класс
            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                !string.IsNullOrEmpty(surnameTextBox.Text) && !string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                !string.IsNullOrEmpty(classTextBox.Text) && !string.IsNullOrWhiteSpace(classTextBox.Text))
            {
                studentsListBox.Items.Clear();
                numbersListBox.Items.Clear();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [students] WHERE [Name] = @Name AND [Surname] = @Surname AND [Class] = @Class", sqlConnection);
                command.Parameters.AddWithValue("Name", nameTextBox.Text);
                command.Parameters.AddWithValue("Surname", surnameTextBox.Text);
                command.Parameters.AddWithValue("Class", classTextBox.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();

                    while (await sqlReader.ReadAsync())
                    {
                        studentsListBox.Items.Add(Convert.ToString(sqlReader["Name"]) + " "
                                         + Convert.ToString(sqlReader["Surname"]) + " "
                                         + Convert.ToString(sqlReader["Class"]));
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"])); //для удобства определения индекса
                    }
                    command = new OleDbCommand("SELECT [ID] FROM [students]WHERE [Name] = @Name AND [Surname] = @Surname AND [Class] = @Class", sqlConnection);
                    command.Parameters.AddWithValue("Name", nameTextBox.Text);
                    command.Parameters.AddWithValue("Surname", surnameTextBox.Text);
                    command.Parameters.AddWithValue("Class", classTextBox.Text);
                    sqlReader = await command.ExecuteReaderAsync();
                    numbersListBox.Items.Clear();
                    while (await sqlReader.ReadAsync())
                    {
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"]));
                    }
                    SetSingle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }
            //заполнен класс
            else
            if (string.IsNullOrEmpty(nameTextBox.Text) && string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                 string.IsNullOrEmpty(surnameTextBox.Text) && string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                !string.IsNullOrEmpty(classTextBox.Text) && !string.IsNullOrWhiteSpace(classTextBox.Text))
            {
                studentsListBox.Items.Clear();
                numbersListBox.Items.Clear();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [students] WHERE [Class] = @Class", sqlConnection);
                command.Parameters.AddWithValue("Class", classTextBox.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        studentsListBox.Items.Add(Convert.ToString(sqlReader["Name"]) + " "
                                         + Convert.ToString(sqlReader["Surname"]) + " "
                                         + Convert.ToString(sqlReader["Class"]));
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"])); //для удобства определения индекса
                    }
                    command = new OleDbCommand("SELECT [ID] FROM [students] WHERE [Class] = @Class", sqlConnection);
                    command.Parameters.AddWithValue("Class", classTextBox.Text);
                    sqlReader = await command.ExecuteReaderAsync();
                    numbersListBox.Items.Clear();
                    while (await sqlReader.ReadAsync())
                    {
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"]));
                    }
                    SetSingle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }
            //заполнена фамилия
            else
            if (string.IsNullOrEmpty(nameTextBox.Text) && string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                !string.IsNullOrEmpty(surnameTextBox.Text) && !string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                 string.IsNullOrEmpty(classTextBox.Text) && string.IsNullOrWhiteSpace(classTextBox.Text))
            {
                studentsListBox.Items.Clear();
                numbersListBox.Items.Clear();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [students] WHERE [Surname] = @Surname", sqlConnection);
                command.Parameters.AddWithValue("Surname", surnameTextBox.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        studentsListBox.Items.Add(Convert.ToString(sqlReader["Name"]) + " "
                                         + Convert.ToString(sqlReader["Surname"]) + " "
                                         + Convert.ToString(sqlReader["Class"]));
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"])); //для удобства определения индекса
                    }
                    command = new OleDbCommand("SELECT [ID] FROM [students] WHERE [Surname] = @Surname", sqlConnection);
                    command.Parameters.AddWithValue("Surname", surnameTextBox.Text);
                    sqlReader = await command.ExecuteReaderAsync();
                    numbersListBox.Items.Clear();
                    while (await sqlReader.ReadAsync())
                    {
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"]));
                    }
                    SetSingle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }
            //заполнены фамилия класс
            else
            if (string.IsNullOrEmpty(nameTextBox.Text) && string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                !string.IsNullOrEmpty(surnameTextBox.Text) && !string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                !string.IsNullOrEmpty(classTextBox.Text) && !string.IsNullOrWhiteSpace(classTextBox.Text))
            {
                studentsListBox.Items.Clear();
                numbersListBox.Items.Clear();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [students] WHERE [Surname] = @Surname AND [Class] = @Class", sqlConnection);
                command.Parameters.AddWithValue("Surname", surnameTextBox.Text);
                command.Parameters.AddWithValue("Class", classTextBox.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();

                    while (await sqlReader.ReadAsync())
                    {
                        studentsListBox.Items.Add(Convert.ToString(sqlReader["Name"]) + " "
                                         + Convert.ToString(sqlReader["Surname"]) + " "
                                         + Convert.ToString(sqlReader["Class"]));
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"])); //для удобства определения индекса
                    }
                    command = new OleDbCommand("SELECT [ID] FROM [students]WHERE[Surname] = @Surname AND [Class] = @Class", sqlConnection);
                    command.Parameters.AddWithValue("Surname", surnameTextBox.Text);
                    command.Parameters.AddWithValue("Class", classTextBox.Text);
                    sqlReader = await command.ExecuteReaderAsync();
                    numbersListBox.Items.Clear();
                    while (await sqlReader.ReadAsync())
                    {
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"]));
                    }
                    SetSingle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }
            //заполнено имя
            else
            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                 string.IsNullOrEmpty(surnameTextBox.Text) && string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                 string.IsNullOrEmpty(classTextBox.Text) && string.IsNullOrWhiteSpace(classTextBox.Text))
            {
                studentsListBox.Items.Clear();
                numbersListBox.Items.Clear();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [students] WHERE [Name] = @Name", sqlConnection);
                command.Parameters.AddWithValue("Name", nameTextBox.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();

                    while (await sqlReader.ReadAsync())
                    {
                        studentsListBox.Items.Add(Convert.ToString(sqlReader["Name"]) + " "
                                         + Convert.ToString(sqlReader["Surname"]) + " "
                                         + Convert.ToString(sqlReader["Class"]));
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"])); //для удобства определения индекса
                    }
                    command = new OleDbCommand("SELECT [ID] FROM [students]WHERE [Name] = @Name", sqlConnection);
                    command.Parameters.AddWithValue("Name", nameTextBox.Text);
                    sqlReader = await command.ExecuteReaderAsync();
                    numbersListBox.Items.Clear();
                    while (await sqlReader.ReadAsync())
                    {
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"]));
                    }
                    SetSingle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }
            //заполнены имя класс
            else
            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                 string.IsNullOrEmpty(surnameTextBox.Text) && string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                !string.IsNullOrEmpty(classTextBox.Text) && !string.IsNullOrWhiteSpace(classTextBox.Text))
            {
                studentsListBox.Items.Clear();
                numbersListBox.Items.Clear();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [students] WHERE [Name] = @Name AND [Class] = @Class", sqlConnection);
                command.Parameters.AddWithValue("Name", nameTextBox.Text);
                command.Parameters.AddWithValue("Class", classTextBox.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        studentsListBox.Items.Add(Convert.ToString(sqlReader["Name"]) + " "
                                         + Convert.ToString(sqlReader["Surname"]) + " "
                                         + Convert.ToString(sqlReader["Class"]));
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"])); //для удобства определения индекса
                    }
                    command = new OleDbCommand("SELECT [ID] FROM [students]WHERE [Name] = @Name AND [Class] = @Class", sqlConnection);
                    command.Parameters.AddWithValue("Name", nameTextBox.Text);
                    command.Parameters.AddWithValue("Class", classTextBox.Text);
                    sqlReader = await command.ExecuteReaderAsync();
                    numbersListBox.Items.Clear();
                    while (await sqlReader.ReadAsync())
                    {
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"]));
                    }
                    SetSingle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }
            //заполнены имя фамилия
            else
            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                !string.IsNullOrEmpty(surnameTextBox.Text) && !string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                 string.IsNullOrEmpty(classTextBox.Text) && string.IsNullOrWhiteSpace(classTextBox.Text))
            {
                studentsListBox.Items.Clear();
                numbersListBox.Items.Clear();
                OleDbCommand command = new OleDbCommand("SELECT * FROM [students] WHERE [Name] = @Name AND [Surname] = @Surname", sqlConnection);
                command.Parameters.AddWithValue("Name", nameTextBox.Text);
                command.Parameters.AddWithValue("Surname", surnameTextBox.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();
                    sqlReader = await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        studentsListBox.Items.Add(Convert.ToString(sqlReader["Name"]) + " "
                                         + Convert.ToString(sqlReader["Surname"]) + " "
                                         + Convert.ToString(sqlReader["Class"]));
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"])); //для удобства определения индекса
                    }
                    command = new OleDbCommand("SELECT [ID] FROM [students]WHERE [Name] = @Name AND [Surname] = @Surname", sqlConnection);
                    command.Parameters.AddWithValue("Name", nameTextBox.Text);
                    command.Parameters.AddWithValue("Surname", surnameTextBox.Text);
                    sqlReader = await command.ExecuteReaderAsync();
                    numbersListBox.Items.Clear();
                    while (await sqlReader.ReadAsync())
                    {
                        numbersListBox.Items.Add(Convert.ToString(sqlReader["ID"]));
                    }
                    SetSingle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните хотя бы одно поле");
            }
        }

        private void marksListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] str = new string[5];
            if (marksListBox.SelectedItem != null)
            {
                str = marksListBox.SelectedItem.ToString().Split(' ');
                controlTextBox1.Text = str[0];
                controlTextBox2.Text = str[1];
                controlTextBox3.Text = str[2];
                controlTextBox4.Text = str[3];
                totalTextBox.Text = str[4];
            }
        }

        //попробовать привести в асинхронный вид
        private void changeMarksButton_Click(object sender, EventArgs e)
        {
            string[] str = new string[5];
            if (!string.IsNullOrEmpty(controlTextBox1.Text) && !string.IsNullOrWhiteSpace(controlTextBox1.Text) &&
                !string.IsNullOrEmpty(controlTextBox2.Text) && !string.IsNullOrWhiteSpace(controlTextBox2.Text) &&
                !string.IsNullOrEmpty(controlTextBox3.Text) && !string.IsNullOrWhiteSpace(controlTextBox3.Text) &&
                !string.IsNullOrEmpty(controlTextBox4.Text) && !string.IsNullOrWhiteSpace(controlTextBox4.Text) &&
                !string.IsNullOrEmpty(totalTextBox.Text) && !string.IsNullOrWhiteSpace(totalTextBox.Text))
            {
                if (marksListBox.SelectedIndex == 0)
                {
                    OleDbCommand command = new OleDbCommand("UPDATE [math] SET [Control1] = @Control1, [Control2] = @Control2, [Control3] = @Control3, [Control4] = @Control4, [Total] = @Total WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("Control1", controlTextBox1.Text);
                    command.Parameters.AddWithValue("Control2", controlTextBox2.Text);
                    command.Parameters.AddWithValue("Control3", controlTextBox3.Text);
                    command.Parameters.AddWithValue("Control4", controlTextBox4.Text);
                    command.Parameters.AddWithValue("Total", totalTextBox.Text);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    command.ExecuteNonQuery();
                }
                else if (marksListBox.SelectedIndex == 1)
                {
                    OleDbCommand command = new OleDbCommand("UPDATE [phys] SET [Control1] = @Control1, [Control2] = @Control2, [Control3] = @Control3, [Control4] = @Control4, [Total] = @Total WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("Control1", controlTextBox1.Text);
                    command.Parameters.AddWithValue("Control2", controlTextBox2.Text);
                    command.Parameters.AddWithValue("Control3", controlTextBox3.Text);
                    command.Parameters.AddWithValue("Control4", controlTextBox4.Text);
                    command.Parameters.AddWithValue("Total", totalTextBox.Text);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    command.ExecuteNonQuery(); }
                else if (marksListBox.SelectedIndex == 2)
                {
                    OleDbCommand command = new OleDbCommand("UPDATE [rpks] SET [Control1] = @Control1, [Control2] = @Control2, [Control3] = @Control3, [Control4] = @Control4, [Total] = @Total WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("Control1", controlTextBox1.Text);
                    command.Parameters.AddWithValue("Control2", controlTextBox2.Text);
                    command.Parameters.AddWithValue("Control3", controlTextBox3.Text);
                    command.Parameters.AddWithValue("Control4", controlTextBox4.Text);
                    command.Parameters.AddWithValue("Total", totalTextBox.Text);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    command.ExecuteNonQuery(); }
                else if (marksListBox.SelectedIndex == 3)
                {
                    OleDbCommand command = new OleDbCommand("UPDATE [chem] SET [Control1] = @Control1, [Control2] = @Control2, [Control3] = @Control3, [Control4] = @Control4, [Total] = @Total WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("Control1", controlTextBox1.Text);
                    command.Parameters.AddWithValue("Control2", controlTextBox2.Text);
                    command.Parameters.AddWithValue("Control3", controlTextBox3.Text);
                    command.Parameters.AddWithValue("Control4", controlTextBox4.Text);
                    command.Parameters.AddWithValue("Total", totalTextBox.Text);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    command.ExecuteNonQuery();
                }
                //обновляем оценки
                changeMarksButton.Enabled = false;
                Thread.Sleep(1000);
                changeMarksButton.Enabled = true;
                marksListBox.Items.Clear();
                sqlConnection = new OleDbConnection(connectionString);
                sqlConnection.Open();
                DbDataReader sqlReader = null;
                try
                {
                    OleDbCommand command = new OleDbCommand("SELECT * FROM [math] WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    command.ExecuteNonQuery();
                    sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        marksListBox.Items.Add(Convert.ToString(sqlReader["Control1"]) + " "
                                         + Convert.ToString(sqlReader["Control2"]) + " "
                                         + Convert.ToString(sqlReader["Control3"]) + " "
                                         + Convert.ToString(sqlReader["Control4"]) + " "
                                         + Convert.ToString(sqlReader["Total"]));
                    }
                    command = new OleDbCommand("SELECT * FROM [phys] WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    command.ExecuteNonQuery();
                    sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        marksListBox.Items.Add(Convert.ToString(sqlReader["Control1"]) + " "
                                         + Convert.ToString(sqlReader["Control2"]) + " "
                                         + Convert.ToString(sqlReader["Control3"]) + " "
                                         + Convert.ToString(sqlReader["Control4"]) + " "
                                         + Convert.ToString(sqlReader["Total"]));
                    }
                    command = new OleDbCommand("SELECT * FROM [rpks] WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    command.ExecuteNonQuery();
                    sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        marksListBox.Items.Add(Convert.ToString(sqlReader["Control1"]) + " "
                                         + Convert.ToString(sqlReader["Control2"]) + " "
                                         + Convert.ToString(sqlReader["Control3"]) + " "
                                         + Convert.ToString(sqlReader["Control4"]) + " "
                                         + Convert.ToString(sqlReader["Total"]));
                    }
                    command = new OleDbCommand("SELECT * FROM [chem] WHERE [ID] = @ID", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    command.ExecuteNonQuery();
                    sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        marksListBox.Items.Add(Convert.ToString(sqlReader["Control1"]) + " "
                                         + Convert.ToString(sqlReader["Control2"]) + " "
                                         + Convert.ToString(sqlReader["Control3"]) + " "
                                         + Convert.ToString(sqlReader["Control4"]) + " "
                                         + Convert.ToString(sqlReader["Total"]));
                    }
                    marksListBox.SetSelected(0, true);
                    str = marksListBox.Items[0].ToString().Split(' ');
                    controlTextBox1.Text = str[0];
                    controlTextBox2.Text = str[1];
                    controlTextBox3.Text = str[2];
                    controlTextBox4.Text = str[3];
                    totalTextBox.Text = str[4];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void changeInfoButton_Click(object sender, EventArgs e)
        {
            string[] str = new string[3];
            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text) &&
                !string.IsNullOrEmpty(surnameTextBox.Text) && !string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                !string.IsNullOrEmpty(classTextBox.Text) && !string.IsNullOrWhiteSpace(classTextBox.Text))
            {
                OleDbCommand command = new OleDbCommand("UPDATE [students] SET [Name] = @Name, [Surname] = @Surname, [Class] = @Class WHERE [ID] = @ID", sqlConnection);
                command.Parameters.AddWithValue("Name", nameTextBox.Text);
                command.Parameters.AddWithValue("Surname", surnameTextBox.Text);
                command.Parameters.AddWithValue("Class", classTextBox.Text);
                command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                command.ExecuteNonQuery();

                //обновить информацию об учениках
                changeInfoButton.Enabled = false;
                Thread.Sleep(1000);
                changeInfoButton.Enabled = true;
                studentsListBox.Items.Clear();
                sqlConnection = new OleDbConnection(connectionString);
                sqlConnection.Open();
                DbDataReader sqlReader = null;
                try
                {
                    command = new OleDbCommand("SELECT * FROM [students]", sqlConnection);
                    command.Parameters.AddWithValue("ID", numbersListBox.SelectedItem);
                    command.ExecuteNonQuery();
                    sqlReader = command.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        studentsListBox.Items.Add(Convert.ToString(sqlReader["Name"]) + " "
                                         + Convert.ToString(sqlReader["Surname"]) + " "
                                         + Convert.ToString(sqlReader["Class"]));
                    }
                    studentsListBox.SetSelected(0, true);
                    str = studentsListBox.Items[0].ToString().Split(' ');
                    nameTextBox.Text = str[0];
                    surnameTextBox.Text = str[1];
                    classTextBox.Text = str[2];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }


        public void SetSingle()
        {
            nameTextBox.Clear();
            surnameTextBox.Clear();
            classTextBox.Clear();
            controlTextBox1.Clear();
            controlTextBox2.Clear();
            controlTextBox3.Clear();
            controlTextBox4.Clear();
            totalTextBox.Clear();
            marksListBox.Items.Clear();
        }
    }   
}
