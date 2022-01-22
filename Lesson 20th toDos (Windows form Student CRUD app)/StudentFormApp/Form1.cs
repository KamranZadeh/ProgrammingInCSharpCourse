using Microsoft.Data.SqlClient;

namespace StudentFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StudentID.PlaceholderText = GetNextId().ToString();
            GetAllStudentsListFromDB();

            if (img == null)
            {
                if (radioMale.Checked)
                {
                    pictureBox1.Image = Properties.Resources.male;
                }
                else if (radioFemale.Checked)
                {
                    pictureBox1.Image = Properties.Resources.female;
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddToDB();
            StudentID.PlaceholderText = GetNextId().ToString();
        }

        private void Add()
        {
            if (StudentName.Text == "" || StudentSurname.Text == "" || dateTimePicker1.Value == default || StudentNationality.Text == "" || StudentAddress.Text == "" || (radioFemale.Checked == false && radioMale.Checked == false))
            {
                MessageBox.Show("All infos should be filled!");
            }
            else
            {
                if (img == null)
                {
                    if (radioMale.Checked)
                    {
                        pictureBox1.Image = Properties.Resources.male;
                        MemoryStream mmst = new MemoryStream();
                        pictureBox1.Image.Save(mmst, pictureBox1.Image.RawFormat);
                        img = mmst.ToArray();
                    }
                    else if (radioFemale.Checked)
                    {
                        pictureBox1.Image = Properties.Resources.female;
                        MemoryStream mmst = new MemoryStream();
                        pictureBox1.Image.Save(mmst, pictureBox1.Image.RawFormat);
                        img = mmst.ToArray();
                    }
                }
                int studentId = GetNextId();
                dataGrid.Rows.Add(img, studentId, StudentName.Text, StudentSurname.Text, dateTimePicker1.Value, StudentNationality.Text, StudentAddress.Text, MaleOrFemale);

                makeDefault();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                var command = connection.CreateCommand();
                connection.Open();

                foreach (DataGridViewRow item in this.dataGrid.SelectedRows)
                {
                    var studentId = StudentID.Text;

                    var answer = MessageBox.Show($"Are you sure to delete this information?\r\nStudent with {studentId} ID will be deleted permanently", "Delete student", MessageBoxButtons.YesNo);

                    if (answer == DialogResult.Yes && item.Index >= 0 && item.IsNewRow == false)
                    {
                        dataGrid.Rows.RemoveAt(item.Index);
                        command.CommandText = @$"delete from tblStudent
                                                where Id = {studentId}";
                        command.ExecuteNonQuery();

                        MessageBox.Show($"Student with {studentId} ID deleted successfully");
                    }
                }
                StudentID.PlaceholderText = GetNextId().ToString();
            }
        }

        public string MaleOrFemale = "";
        private void radioMale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMale.Checked)
            {
                MaleOrFemale = "male";
            }
        }

        private void radioFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFemale.Checked)
            {
                MaleOrFemale = "female";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            makeDefault();
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGrid.SelectedRows)
            {
                StudentID.Text = dataGrid.Rows[item.Index].Cells[1].FormattedValue.ToString();
                StudentName.Text = dataGrid.Rows[item.Index].Cells[2].FormattedValue.ToString();
                StudentSurname.Text = dataGrid.Rows[item.Index].Cells[3].FormattedValue.ToString();
                var value = dataGrid.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();

                if (value != "")
                {
                    var month = int.Parse(value.Split("/")[0]);
                    var day = int.Parse(value.Split("/")[1]);
                    var year = int.Parse(value.Split("/")[2]);
                    dateTimePicker1.Value = new DateTime(year, month, day);
                }

                StudentNationality.Text = dataGrid.Rows[item.Index].Cells[5].FormattedValue.ToString();
                StudentAddress.Text = dataGrid.Rows[item.Index].Cells[6].FormattedValue.ToString();

                if (dataGrid.Rows[item.Index].Cells[7].FormattedValue.ToString() == "male")
                {
                    radioMale.Checked = true;
                }
                else
                {
                    radioFemale.Checked = true;
                }

            }

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                var command = connection.CreateCommand();
                connection.Open();

                foreach (DataGridViewRow item in this.dataGrid.SelectedRows)
                {

                    if (StudentID.Text == "" || StudentName.Text == "" || StudentSurname.Text == "" || dateTimePicker1.Value == DateTime.Today || StudentNationality.Text == "" || StudentAddress.Text == "")
                    {
                        MessageBox.Show("All inputs are required");
                    }
                    else
                    {

                        var studentId = StudentID.Text;

                        var answer = MessageBox.Show($"Are you sure to update this information? Student with {studentId} ID will be UPDATED\r\nIf you want to add new student click CLEAR button and enter informations", "Update student infos", MessageBoxButtons.YesNo);

                        if (answer == DialogResult.Yes && item.Index >= 0 && item.IsNewRow == false)
                        {
                            command.CommandText = @$"update tblStudent
                                                    set Name = @Name,
                                                    Surname = @Surname,
                                                    DateOfBirth = @DateOfBirth,
                                                    Nationality = @Nationality,
                                                    Address = @Address,
                                                    Gender = @Gender
                                                    where Id = {studentId}";
                            command.Parameters.Add(new SqlParameter("Name", StudentName.Text));
                            command.Parameters.Add(new SqlParameter("Surname", StudentSurname.Text));
                            command.Parameters.Add(new SqlParameter("DateOfBirth", dateTimePicker1.Value));
                            command.Parameters.Add(new SqlParameter("Nationality", StudentNationality.Text));
                            command.Parameters.Add(new SqlParameter("Address", StudentAddress.Text));
                            command.Parameters.Add(new SqlParameter("Gender", MaleOrFemale));
                            command.ExecuteNonQuery();

                            MessageBox.Show($"Student with {studentId} ID UPDATED successfully");
                        }
                    }
                }
                StudentID.PlaceholderText = GetNextId().ToString();
                GetAllStudentsListFromDB();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
            }
        }

        byte[] img;
        private void Button2_Click(object sender, EventArgs e)
        {
            MemoryStream mmst = new();
            pictureBox1.Image.Save(mmst, pictureBox1.Image.RawFormat);
            img = mmst.ToArray();
        }

        private void AddToDB()
        {
            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                if (StudentName.Text == "" || StudentSurname.Text == "" || dateTimePicker1.Value == DateTime.Today || StudentNationality.Text == "" || StudentAddress.Text == "" || (radioFemale.Checked == false && radioMale.Checked == false))
                {
                    MessageBox.Show("All informations should be filled!");
                }
                else
                {
                    var command = connection.CreateCommand();
                    var command2 = connection.CreateCommand();
                    connection.Open();

                    command.CommandText = @$"insert into dbo.tblStudent
                                      values(@Name, @Surname, @DateOfBirth, @Nationality, @Address, @Gender)";

                    command2.CommandText = @"select max(Id) from tblStudent";

                    command.Parameters.Add(new SqlParameter("Name", StudentName.Text));
                    command.Parameters.Add(new SqlParameter("Surname", StudentSurname.Text));
                    command.Parameters.Add(new SqlParameter("DateOfBirth", dateTimePicker1.Value));
                    command.Parameters.Add(new SqlParameter("Nationality", StudentNationality.Text));
                    command.Parameters.Add(new SqlParameter("Address", StudentAddress.Text));
                    command.Parameters.Add(new SqlParameter("Gender", MaleOrFemale));


                    var retunedValue = command2.ExecuteScalar();

                    if (StudentID.Text == "")
                    {
                        StudentID.Text = StudentID.PlaceholderText;
                    }

                    if (retunedValue is DBNull)
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Student added successfully");
                        makeDefault();

                        GetAllStudentsListFromDB();
                    }
                    else
                    {
                        var retunedIntValue = (Int32)command2.ExecuteScalar();
                        retunedIntValue++;

                        if (retunedIntValue != int.Parse(StudentID.Text))
                        {
                            MessageBox.Show($"There is a student with same ID ({StudentID.Text}) in Database. But you can UPDATE informations by clicking UPDATE button");
                        }
                        else
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Student added successfully");
                            makeDefault();

                            GetAllStudentsListFromDB();
                        }
                    }
                }
            }
        }

        internal int GetNextId()
        {
            Int32 lastStudentId = 0;

            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                var command = connection.CreateCommand();
                connection.Open();

                command.CommandText = @"select max(Id) from tblStudent";

                var retunedValue = command.ExecuteScalar();

                if (retunedValue is DBNull)
                {
                    return lastStudentId = 1;
                }
                else
                {
                    lastStudentId = (Int32)retunedValue;
                }
            }

            return ++lastStudentId;
        }


        private void makeDefault()
        {
            img = null;
            pictureBox1.Image = Properties.Resources.male;
            StudentName.Text = "";
            StudentID.Text = "";
            StudentSurname.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            StudentAddress.Text = "";
            StudentNationality.Text = "";
            radioMale.Checked = false;
            radioFemale.Checked = false;
            StudentID.PlaceholderText = GetNextId().ToString();
        }


        private List<Student> GetAllStudentsListFromDB()
        {
            var result = new List<Student>();

            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                var command = connection.CreateCommand();

                command.CommandText = @"select * from tblStudent";

                connection.Open();

                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var student = new Student()
                    {
                        ID = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1),
                        Surname = dataReader.GetString(2),
                        DateOfBirth = dataReader.GetDateTime(3).ToString(@"MM/dd/yyyy"),
                        Nationality = dataReader.GetString(4),
                        Address = dataReader.GetString(5),
                        Gender = dataReader.GetString(6)
                    };
                    result.Add(student);
                }
            }

            dataGrid.Rows.Clear();

            foreach (var student in result)
            {
                {
                    dataGrid.Rows.Add(null, student.ID, student.Name, student.Surname, student.DateOfBirth, student.Nationality, student.Address, student.Gender);
                }
            }
            return result;
        }
    }
}