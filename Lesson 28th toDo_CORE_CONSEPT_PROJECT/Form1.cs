using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;

namespace CourseManagementPortal
{
    public partial class Form1 : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );

        public Form1()
        {
            InitializeComponent();


            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            panelStudent.BringToFront();

            panelStudentBottom.BringToFront();
            btnStudent.BackColor = Color.FromArgb(46, 51, 73);

            dataGridViewStudent.DataSource = StudentManager.GetStudents();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnStudent.Height;
            pnlNav.Top = btnStudent.Top;
            pnlNav.Left = btnStudent.Left;
            btnStudent.BackColor = Color.FromArgb(46, 51, 73);

            panelStudent.BringToFront();

            panelStudentBottom.BringToFront();

            dataGridViewStudent.DataSource = StudentManager.GetStudents();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnTeacher.Height;
            pnlNav.Top = btnTeacher.Top;
            btnTeacher.BackColor = Color.FromArgb(46, 51, 73);
            btnStudent.BackColor = Color.FromArgb(24, 30, 54);

            panelTeacher.BringToFront();
            panelTeacherBottom.BringToFront();

            dataGridViewTeacher.DataSource = GetData("select * from tableTeacher");
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCourse.Height;
            pnlNav.Top = btnCourse.Top;
            btnCourse.BackColor = Color.FromArgb(46, 51, 73);
            btnStudent.BackColor = Color.FromArgb(24, 30, 54);

            panelCourse.BringToFront();
            panelCourseBottom.BringToFront();

            dataGridViewCourse.DataSource = CourseManager.GetCourses();
        }

        private void btnPlanStartCourse_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPlanStartCourse.Height;
            pnlNav.Top = btnPlanStartCourse.Top;
            btnPlanStartCourse.BackColor = Color.FromArgb(46, 51, 73);

            panelPlanStartCourse.BringToFront();
            panelPlanStartBottom.BringToFront();

            dataGridViewGroups.DataSource = GetData("select * from tableGroups");
        }


        private void buttonLesson_Click(object sender, EventArgs e)
        {
            pnlNav.Height = buttonLesson.Height;
            pnlNav.Top = buttonLesson.Top;
            buttonLesson.BackColor = Color.FromArgb(46, 51, 73);

            panelLesson.BringToFront();
            panelLessonBottom.BringToFront();

            dataGridViewLesson.DataSource = GetData("select * from tableLesson");
        }


        private void buttonGroupsStudents_Click(object sender, EventArgs e)
        {
            pnlNav.Height = buttonGroupsStudents.Height;
            pnlNav.Top = buttonGroupsStudents.Top;
            buttonGroupsStudents.BackColor = Color.FromArgb(46, 51, 73);

            panelGroupsStudents.BringToFront();
            panelGroupsStudentsBottom.BringToFront();

            dataGridViewGroupsStudents.DataSource = GetData("select * from tableGroupsStudents");
        }


        private void buttonStudentProgressLeft_Click(object sender, EventArgs e)
        {
            pnlNav.Height = buttonStudentProgressLeft.Height;
            pnlNav.Top = buttonStudentProgressLeft.Top;
            buttonStudentProgressLeft.BackColor = Color.FromArgb(46, 51, 73);

            panelStudentProgress.BringToFront();
            panelStudentProgressBottom.BringToFront();
        }

        private void buttonGroupsStudents_Leave(object sender, EventArgs e)
        {
            buttonGroupsStudents.BackColor = Color.FromArgb(24, 30, 54);
        }


        private void buttonStudentProgressLeft_Leave(object sender, EventArgs e)
        {
            buttonStudentProgressLeft.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnStudent_Leave(object sender, EventArgs e)
        {
            btnStudent.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnTeacher_Leave(object sender, EventArgs e)
        {
            btnTeacher.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCourse_Leave(object sender, EventArgs e)
        {
            btnCourse.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnPlanStartCourse_Leave(object sender, EventArgs e)
        {
            btnPlanStartCourse.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void buttonLesson_Leave(object sender, EventArgs e)
        {
            buttonLesson.BackColor = Color.FromArgb(24, 30, 54);
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonStudentSave_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void buttonTeacherSave_Click(object sender, EventArgs e)
        {
            AddTeacher();
        }

        private void buttonCourseSave_Click(object sender, EventArgs e)
        {
            AddCourse();
        }

        private void dataGridViewStudent_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStudent.SelectedRows.Count > 0 && !dataGridViewStudent.CurrentRow.IsNewRow)
            {
                string Id = dataGridViewStudent.SelectedRows[0].Cells[0].Value + string.Empty;
                string name = dataGridViewStudent.SelectedRows[0].Cells[1].Value + string.Empty;
                string surname = dataGridViewStudent.SelectedRows[0].Cells[2].Value + string.Empty;

                dateTimePickerStudentBirthDate.Value = (DateTime)dataGridViewStudent.SelectedRows[0].Cells[3].Value;

                textBoxStudentId.Text = Id;
                textBoxStudentName.Text = name;
                textBoxStudentSurname.Text = surname;
            }
        }


        private void buttonStudentUpdate_Click(object sender, EventArgs e)
        {
            UpdateStudent();
        }

        private void dataGridViewTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTeacher.SelectedRows.Count > 0 && !dataGridViewTeacher.CurrentRow.IsNewRow)
            {
                string Id = dataGridViewTeacher.SelectedRows[0].Cells[0].Value + string.Empty;
                string name = dataGridViewTeacher.SelectedRows[0].Cells[1].Value + string.Empty;
                string surname = dataGridViewTeacher.SelectedRows[0].Cells[2].Value + string.Empty;

                dateTimePickerTeacher.Value = (DateTime)dataGridViewTeacher.SelectedRows[0].Cells[3].Value;

                string canTeach1 = dataGridViewTeacher.SelectedRows[0].Cells[4].Value + string.Empty;
                string canTeach2 = dataGridViewTeacher.SelectedRows[0].Cells[5].Value + string.Empty;
                string canTeach3 = dataGridViewTeacher.SelectedRows[0].Cells[6].Value + string.Empty;

                textBoxTeacherId.Text = Id;
                textBoxTeacherName.Text = name;
                textBoxTeacherSurname.Text = surname;

                if (canTeach1 != "")
                {
                    comboBoxCanTeach1.Text = canTeach1;
                }
                else
                {
                    comboBoxCanTeach1.Text = default;
                }

                if (canTeach2 != "")
                {
                    comboBoxCanTeach2.Text = canTeach2;
                }
                else
                {
                    comboBoxCanTeach2.Text = default;
                }
                if (canTeach3 != "")
                {
                    comboBoxCanTeach3.Text = canTeach3;
                }
                else
                {
                    comboBoxCanTeach3.Text = default;
                }


            }
        }


        const string connectionString = @"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True";

        public void AddStudent()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @"insert into tableStudent(Name, Surname, BirthDate) values(@Name, @Surname, @BirthDate)";

                if (textBoxStudentName.Text != "" && textBoxStudentSurname.Text != "")
                {
                    cmd.Parameters.AddWithValue("Name", textBoxStudentName.Text);
                    cmd.Parameters.AddWithValue("Surname", textBoxStudentSurname.Text);
                    cmd.Parameters.AddWithValue("BirthDate", dateTimePickerStudentBirthDate.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student added successfully");

                    ClearStudent();

                    dataGridViewStudent.DataSource = StudentManager.GetStudents();
                }
                else
                {
                    MessageBox.Show("Name and Surname are required");
                }
            }
        }

        void ClearStudent()
        {
            textBoxStudentId.Text = textBoxStudentId.PlaceholderText;
            textBoxStudentName.Text = "";
            textBoxStudentSurname.Text = "";
            dateTimePickerStudentBirthDate.Value = dateTimePickerStudentBirthDate.MaxDate;
        }

        public void AddTeacher()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd1 = connection.CreateCommand();
                var cmd2 = connection.CreateCommand();
                var cmd3 = connection.CreateCommand();
                var cmd4 = connection.CreateCommand();

                cmd1.CommandText = @"insert into tableTeacher
                                    (Name, Surname, BirthDate, Canteach1, Canteach2, Canteach3) 
                                    values(@Name, @Surname, @BirthDate, @Canteach1, @Canteach2, @Canteach3)";

                cmd2.CommandText = @"insert into tableTeacher
                                    (Name, Surname, BirthDate, Canteach1, Canteach2) 
                                    values(@Name, @Surname, @BirthDate, @Canteach1, @Canteach2)";

                cmd3.CommandText = @"insert into tableTeacher
                                    (Name, Surname, BirthDate, Canteach1) 
                                    values(@Name, @Surname, @BirthDate, @Canteach1)";

                cmd4.CommandText = @"insert into tableTeacher
                                    (Name, Surname, BirthDate) 
                                    values(@Name, @Surname, @BirthDate)";

                if (textBoxTeacherName.Text != "" && textBoxTeacherSurname.Text != "" && comboBoxCanTeach1.Text != "" && comboBoxCanTeach2.Text != "" && comboBoxCanTeach3.Text != "")
                {
                    cmd1.Parameters.AddWithValue("Name", textBoxTeacherName.Text);
                    cmd1.Parameters.AddWithValue("Surname", textBoxTeacherSurname.Text);
                    cmd1.Parameters.AddWithValue("BirthDate", dateTimePickerTeacher.Value);
                    cmd1.Parameters.AddWithValue("Canteach1", comboBoxCanTeach1.Text);
                    cmd1.Parameters.AddWithValue("Canteach2", comboBoxCanTeach2.Text);
                    cmd1.Parameters.AddWithValue("Canteach3", comboBoxCanTeach3.Text);

                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Teacher added successfully");

                    ClearTeacher();

                    dataGridViewTeacher.DataSource = GetData("select * from tableTeacher");
                }
                else if (textBoxTeacherName.Text != "" && textBoxTeacherSurname.Text != "" && comboBoxCanTeach1.Text != "" && comboBoxCanTeach2.Text != "")
                {
                    cmd2.Parameters.AddWithValue("Name", textBoxTeacherName.Text);
                    cmd2.Parameters.AddWithValue("Surname", textBoxTeacherSurname.Text);
                    cmd2.Parameters.AddWithValue("BirthDate", dateTimePickerTeacher.Value);
                    cmd2.Parameters.AddWithValue("Canteach1", comboBoxCanTeach1.Text);
                    cmd2.Parameters.AddWithValue("Canteach2", comboBoxCanTeach2.Text);

                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Teacher added successfully");

                    ClearTeacher();

                    dataGridViewTeacher.DataSource = GetData("select * from tableTeacher");
                }
                else if (textBoxTeacherName.Text != "" && textBoxTeacherSurname.Text != "" && comboBoxCanTeach1.Text != "")
                {
                    cmd3.Parameters.AddWithValue("Name", textBoxTeacherName.Text);
                    cmd3.Parameters.AddWithValue("Surname", textBoxTeacherSurname.Text);
                    cmd3.Parameters.AddWithValue("BirthDate", dateTimePickerTeacher.Value);
                    cmd3.Parameters.AddWithValue("Canteach1", comboBoxCanTeach1.Text);

                    cmd3.ExecuteNonQuery();

                    MessageBox.Show("Teacher added successfully");

                    ClearTeacher();

                    dataGridViewTeacher.DataSource = GetData("select * from tableTeacher");
                }
                else if (textBoxTeacherName.Text != "" && textBoxTeacherSurname.Text != "")
                {
                    cmd4.Parameters.AddWithValue("Name", textBoxTeacherName.Text);
                    cmd4.Parameters.AddWithValue("Surname", textBoxTeacherSurname.Text);
                    cmd4.Parameters.AddWithValue("BirthDate", dateTimePickerTeacher.Value);

                    cmd4.ExecuteNonQuery();

                    MessageBox.Show("Teacher added successfully");

                    ClearTeacher();

                    dataGridViewTeacher.DataSource = GetData("select * from tableTeacher");
                }
                else
                {
                    MessageBox.Show("Name and Surname are required");
                }

            }

        }

        void ClearTeacher()
        {
            textBoxTeacherId.Text = textBoxTeacherId.PlaceholderText;
            textBoxTeacherName.Text = "";
            textBoxTeacherSurname.Text = "";
            dateTimePickerTeacher.Value = dateTimePickerStudentBirthDate.MaxDate;
            comboBoxCanTeach1.Text = default;
            comboBoxCanTeach2.Text = default;
            comboBoxCanTeach3.Text = default;
        }

        public void AddCourse()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @"insert into tableCourse(Name, Duration, Price) values(@Name, @Duration, @Price)";

                if (textBoxCourseName.Text != "" && textBoxCourseDuration.Text != "" && textBoxCoursePrice.Text != "")
                {
                    var helper = true;

                    try
                    {
                        int.Parse(textBoxCourseDuration.Text);
                        decimal.Parse(textBoxCoursePrice.Text);
                    }
                    catch (Exception)
                    {
                        helper = false;
                    }

                    if (helper)
                    {
                        cmd.Parameters.AddWithValue("Name", textBoxCourseName.Text);
                        cmd.Parameters.AddWithValue("Duration", textBoxCourseDuration.Text);
                        cmd.Parameters.AddWithValue("Price", textBoxCoursePrice.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Course added successfully");

                        ClearCourse();

                        dataGridViewCourse.DataSource = CourseManager.GetCourses();
                    }
                    else
                    {
                        MessageBox.Show("Please add numeric values for Duration(in month) and Price");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Name,Duration and Price are required");
                }
            }
        }

        void ClearCourse()
        {
            textBoxCourseId.Text = textBoxCourseId.PlaceholderText;
            textBoxCourseName.Text = "";
            textBoxCourseDuration.Text = "";
            textBoxCoursePrice.Text = "";
        }

        public void UpdateStudent()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                connection.Open();

                if (textBoxStudentName.Text != "" || textBoxStudentSurname.Text != "")
                {
                    var studentId = textBoxStudentId.Text;

                    var answer = MessageBox.Show($"Student with {studentId} ID will be UPDATED\r\n" +
                        $"If you want to add new student click CLEAR button and enter informations\r\n\r\n" +
                        $"Are you sure to update this information? ", "Update student infos", MessageBoxButtons.YesNo);

                    if (answer == DialogResult.Yes)
                    {
                        command.CommandText = @$"update tableStudent
                                                set Name = @Name,
                                                Surname = @Surname,
                                                BirthDate = @BirthDate,
                                                ModificationTime = getdate()
                                                where Id = {studentId}";

                        command.Parameters.AddWithValue("Name", textBoxStudentName.Text);
                        command.Parameters.AddWithValue("Surname", textBoxStudentSurname.Text);
                        command.Parameters.AddWithValue("BirthDate", dateTimePickerStudentBirthDate.Value);
                        command.ExecuteNonQuery();

                        MessageBox.Show($"Student with {studentId} ID UPDATED successfully");
                    }
                }
                else
                {
                    MessageBox.Show("All inputs are required");
                }

                dataGridViewStudent.DataSource = StudentManager.GetStudents();
            }
        }

        void DeleteStudent()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                connection.Open();

                    var studentId = textBoxStudentId.Text;

                    var answer = MessageBox.Show($"Are you sure to DELETE this Student? Student with {studentId} ID will be Deleted", "Delete student", MessageBoxButtons.YesNo);

                    if (answer == DialogResult.Yes)
                    {
                        command.CommandText = @$"delete from tableStudent
                                                where Id = {studentId}";

                        command.ExecuteNonQuery();

                        MessageBox.Show($"Student with {studentId} ID DELETED successfully");
                    }

                ClearStudent();
                dataGridViewStudent.DataSource = StudentManager.GetStudents();
            }
        }

        public void UpdateTeacher()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                connection.Open();

                if (textBoxTeacherName.Text != "" && textBoxTeacherSurname.Text != "")
                {
                    var teacherId = textBoxTeacherId.Text;

                    var answer = MessageBox.Show($"Teacher with {teacherId} ID will be UPDATED\r\n" +
                        $"If you want to add new teacher click CLEAR button and enter informations\r\n\r\n" +
                        $"Are you sure to update this information? ", "Update teacher infos", MessageBoxButtons.YesNo);

                    if (answer == DialogResult.Yes)
                    {
                        command.CommandText = @$"update tableTeacher
                                               set Name = @Name,
                                               Surname = @Surname,
                                               BirthDate = @BirthDate,
                                               CanTeach1 = @CanTeach1,
                                               CanTeach2 = @CanTeach2,
                                               CanTeach3 = @CanTeach3
                                               where Id = {teacherId}";

                        command.Parameters.AddWithValue("Name", textBoxTeacherName.Text);
                        command.Parameters.AddWithValue("Surname", textBoxTeacherSurname.Text);
                        command.Parameters.AddWithValue("BirthDate", dateTimePickerTeacher.Value);
                        command.Parameters.AddWithValue("CanTeach1", comboBoxCanTeach1.Text);
                        command.Parameters.AddWithValue("CanTeach2", comboBoxCanTeach2.Text);
                        command.Parameters.AddWithValue("CanTeach3", comboBoxCanTeach3.Text);
                        command.ExecuteNonQuery();

                        MessageBox.Show($"Teacher with {teacherId} ID UPDATED successfully");
                    }
                }
                else
                {
                    MessageBox.Show("All inputs are required");
                }

                dataGridViewTeacher.DataSource = GetData("select * from tableTeacher");
            }
        }

        void DeleteTeacher()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                connection.Open();

                var teacherId = textBoxTeacherId.Text;

                var answer = MessageBox.Show($"Are you sure to DELETE this Teacher? Student with {teacherId} ID will be Deleted", "Delete teacher", MessageBoxButtons.YesNo);

                if (answer == DialogResult.Yes)
                {
                    command.CommandText = @$"delete from tableTeacher
                                            where Id = {teacherId}";

                    command.ExecuteNonQuery();

                    MessageBox.Show($"Student with {teacherId} ID DELETED successfully");
                }

                ClearTeacher();
                dataGridViewTeacher.DataSource = GetData("select * from tableTeacher");
            }
        }

        public void UpdateCourse()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                connection.Open();

                if (textBoxCourseName.Text != "" && textBoxCourseDuration.Text != "" && textBoxCoursePrice.Text != "")
                {
                    var courseId = textBoxCourseId.Text;

                    var answer = MessageBox.Show($"Course with {courseId} ID will be UPDATED\r\n" +
                        $"If you want to add new course click CLEAR button and enter informations\r\n\r\nAre you sure to update this information? ", "Update course infos", MessageBoxButtons.YesNo);

                    if (answer == DialogResult.Yes)
                    {
                        command.CommandText = @$"update tableCourse
                                                set Name = @Name,
                                                Duration = @Duration,
                                                Price = @Price,
                                                ModificationTime = getdate()
                                                where Id = {courseId}";

                        command.Parameters.AddWithValue("Name", textBoxCourseName.Text);
                        command.Parameters.AddWithValue("Duration", textBoxCourseDuration.Text);
                        command.Parameters.AddWithValue("Price", textBoxCoursePrice.Text);
                        command.ExecuteNonQuery();

                        MessageBox.Show($"Course with {courseId} ID UPDATED successfully");
                    }

                }
                else
                {
                    MessageBox.Show("All inputs are required");
                }

                dataGridViewCourse.DataSource = CourseManager.GetCourses();
            }
        }

        void DeleteCourse()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var command = connection.CreateCommand();
                connection.Open();

                var courseId = textBoxCourseId.Text;

                var answer = MessageBox.Show($"Are you sure to DELETE this Teacher? Student with {courseId} ID will be Deleted", "Delete teacher", MessageBoxButtons.YesNo);

                if (answer == DialogResult.Yes)
                {
                    command.CommandText = @$"delete from tableCourse
                                                where Id = {courseId}";

                    command.ExecuteNonQuery();

                    MessageBox.Show($"Student with {courseId} ID DELETED successfully");
                }

                ClearCourse();
                dataGridViewCourse.DataSource = CourseManager.GetCourses();
            }
        }

        private void dataGridViewCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCourse.SelectedRows.Count > 0 && !dataGridViewCourse.CurrentRow.IsNewRow)
            {
                string Id = dataGridViewCourse.SelectedRows[0].Cells[0].Value + string.Empty;
                string name = dataGridViewCourse.SelectedRows[0].Cells[1].Value + string.Empty;
                string duration = dataGridViewCourse.SelectedRows[0].Cells[2].Value + string.Empty;
                string price = dataGridViewCourse.SelectedRows[0].Cells[3].Value + string.Empty;

                textBoxCourseId.Text = Id;
                textBoxCourseName.Text = name;
                textBoxCourseDuration.Text = duration;
                textBoxCoursePrice.Text = price;
            }
        }

        private void buttonCourseUpdate_Click(object sender, EventArgs e)
        {
            UpdateCourse();
        }

        private void buttonClear2_Click(object sender, EventArgs e)
        {
            ClearCourse();
        }

        private void buttonClear3_Click(object sender, EventArgs e)
        {
            ClearTeacher();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearStudent();
        }

        private void buttonStudentDelete_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }

        private void buttonTeacherDelete_Click(object sender, EventArgs e)
        {
            DeleteTeacher();
        }

        private void buttonCourseDelete_Click(object sender, EventArgs e)
        {
            DeleteCourse();
        }

        private void buttonTeacherUpdate_Click(object sender, EventArgs e)
        {
            UpdateTeacher();
        }


        public void CreateGroup()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @$"insert into tableGroups values(@GroupName, @TeacherName, @StartDate, @EndDate)";


                if (!checkBoxStartDate.Checked)
                {
                    cmd.Parameters.AddWithValue("StartDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("StartDate", dateTimePickerStartDate.Value);
                }


                if (!checkBoxEndDate.Checked)
                {
                    cmd.Parameters.AddWithValue("EndDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("EndDate", dateTimePickerEndDate.Value);
                }


                if (dateTimePickerStartDate.Value >= dateTimePickerEndDate.Value && checkBoxStartDate.Checked && checkBoxEndDate.Checked)
                {
                    MessageBox.Show("Start date cannot be later than or equal to End date");
                }
                else if (textBoxGroupname.Text != "" && comboBoxGroupTeacher.Text != "")
                {
                    cmd.Parameters.AddWithValue("GroupName", textBoxGroupname.Text);
                    cmd.Parameters.AddWithValue("TeacherName", comboBoxGroupTeacher.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Group created successfully");

                }
                else
                {
                    MessageBox.Show("Group name and teacher name is required");
                }
            }

            dataGridViewGroups.DataSource = GetData("select * from tableGroups");

        }


        private void dataGridViewGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewGroups.SelectedRows.Count > 0 && !dataGridViewGroups.CurrentRow.IsNewRow)
            {
                string groupName = dataGridViewGroups.SelectedRows[0].Cells[1].Value + string.Empty;
                string teacherName = dataGridViewGroups.SelectedRows[0].Cells[2].Value + string.Empty;

                if (dataGridViewGroups.SelectedRows[0].Cells[3].Value != DBNull.Value)
                {
                    dateTimePickerStartDate.Value = (DateTime)dataGridViewGroups.SelectedRows[0].Cells[3].Value;
                }
                if (dataGridViewGroups.SelectedRows[0].Cells[4].Value != DBNull.Value)
                {
                    dateTimePickerEndDate.Value = (DateTime)dataGridViewGroups.SelectedRows[0].Cells[4].Value;
                }

                textBoxGroupname.Text = groupName;
                comboBoxGroupTeacher.Text = teacherName;

            }
        }

        void DeleteGroup()
        {
            if (dataGridViewGroups.SelectedRows.Count > 0 && !dataGridViewGroups.CurrentRow.IsNewRow)
            {
                string groupId = dataGridViewGroups.SelectedRows[0].Cells[0].Value + string.Empty;

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();

                    cmd.CommandText = @$"delete from tableGroups where Id = {groupId}";

                    var answer = MessageBox.Show("Group will be removed permanently\r\n\r\nAre you sure?", "Delete Group", MessageBoxButtons.YesNo);

                    if (answer == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                dataGridViewGroups.DataSource = GetData("select * from tableGroups");
            }
                

        }

        void UpdateGroup()
        {
            string groupId = dataGridViewGroups.SelectedRows[0].Cells[0].Value + string.Empty;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @$"update tableGroups
                                  set GroupName = @GroupName,
                                  TeacherName = @TeacherName,
                                  StartDate = @StartDate,
                                  EndDate = @EndDate
                                  where id = {groupId}";

                if (!checkBoxStartDate.Checked)
                {
                    cmd.Parameters.AddWithValue("StartDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("StartDate", dateTimePickerStartDate.Value);
                }


                if (!checkBoxEndDate.Checked)
                {
                    cmd.Parameters.AddWithValue("EndDate", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("EndDate", dateTimePickerEndDate.Value);
                }


                if (dateTimePickerStartDate.Value >= dateTimePickerEndDate.Value && checkBoxStartDate.Checked && checkBoxEndDate.Checked)
                {
                    MessageBox.Show("Start date cannot be later than or equal to End date");
                }
                else if (textBoxGroupname.Text != "" && comboBoxGroupTeacher.Text != "")
                {
                    cmd.Parameters.AddWithValue("GroupName", textBoxGroupname.Text);
                    cmd.Parameters.AddWithValue("TeacherName", comboBoxGroupTeacher.Text);

                    var answer = MessageBox.Show("Selected group will be updated\r\n\r\nAre you sure?", "Update Group", MessageBoxButtons.YesNo);

                    if (answer == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Group updated successfully");

                }
                else
                {
                    MessageBox.Show("Group name and teacher name is required");
                }


                
            }

            dataGridViewGroups.DataSource = GetData("select * from tableGroups");

        }

        private static DataTable GetData(string sqlCommand)
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var command = connection.CreateCommand();

                    command.CommandText = sqlCommand; //accepts command

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;

                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    adapter.Fill(table);
                    return table;
                }
            }


        void SeeAllStudentOfTheTheacher()
        {
            try
            {
                var isInt = true;
                try
                {
                    int.Parse(textBoxLessonLessonName.Text);
                }
                catch (Exception)
                {
                    isInt = false;
                }


                if (isInt)
                {
                    dataGridViewLesson.DataSource = GetData(@$"select t.Name + ' ' + t.Surname as Teacher, 
                                                    s.Name + ' ' + s.Surname as Student, s.Id as StudentId, 
                                                    c.Name as Course from tableStudent s
                                                    left join tableOngoingCourses oc on oc.StudentId = s.Id
                                                    join tableCourse c on oc.CourseId = c.Id
                                                    left join tableTeacher t on oc.TeacherId = t.Id where t.Id = {textBoxLessonLessonName.Text}");
                }
                else
                {
                    MessageBox.Show("ID should have numeric value");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this sample replace connection.ConnectionString" +
                    " with a valid connection string" +
                    " database accessible to your system", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Thread.CurrentThread.Abort();
            }
        }

        
        private void buttonTeacherS_Students_Click(object sender, EventArgs e)
        {
            SeeAllStudentOfTheTheacher();
        }

        void AddLesson()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @$"insert into tableLesson values
                                    (@GroupName, @LessonName, @StudentName, @lessonDate, @atLesson, @comment)";

                if (textBoxLessonLessonName.Text != "" && comboBoxLessonStudentName.Text != "" && richTextBoxLesson.Text != "")
                {
                    cmd.Parameters.AddWithValue("GroupName", comboBoxLessonGroupName.Text);
                    cmd.Parameters.AddWithValue("LessonName", textBoxLessonLessonName.Text);
                    cmd.Parameters.AddWithValue("StudentName", comboBoxLessonStudentName.Text);
                    cmd.Parameters.AddWithValue("lessonDate", dateTimePickerLessonDate.Value);
                    cmd.Parameters.AddWithValue("atLesson", checkBoxLesson.Checked);
                    cmd.Parameters.AddWithValue("comment", richTextBoxLesson.Text);

                    cmd.ExecuteNonQuery();

                    richTextBoxLesson.Text = "";

                    MessageBox.Show("Lesson info added successfully");

                }
                else
                {
                    MessageBox.Show("All infos should be filled");
                }
            }

            dataGridViewLesson.DataSource = GetData("select * from tableLesson");

        }

        private void buttonLessonAddComment_Click(object sender, EventArgs e)
        {
            AddLesson();
        }


        void SearchCourse()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = GetData(@$"declare @name varchar(50) = '%{textBoxSearchCourse.Text}%'

                                                    select * from tableCourse
                                                    where Name like @name");
                dataGridViewCourse.DataSource = bindingSource1;

            }
        }

        private void textBoxSearchCourse_TextChanged(object sender, EventArgs e)
        {
            SearchCourse();
        }

        void SearchTeacher()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = GetData(@$"declare @name varchar(50) = '%{textBoxSearchTeacher.Text}%'

                                                    select * from tableTeacher
                                                    where Name like @name");
                dataGridViewTeacher.DataSource = bindingSource1;

            }
        }

        private void textBoxSearchTeacher_TextChanged(object sender, EventArgs e)
        {
            SearchTeacher();
        }

        void SearchStudent()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                dataGridViewStudent.DataSource = GetData(@$"declare @name varchar(50) = '%{textBoxStudentSearch.Text}%'

                                                            select * from tableStudent
                                                            where Name like @name");
                cmd.Parameters.AddWithValue("name", textBoxStudentSearch.Text);

            }
        }

        private void textBoxStudentSearch_TextChanged(object sender, EventArgs e)
        {
            SearchStudent();
        }

        void ComboBoxDrop(string query, ComboBox comboBox)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                
                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataReader saReader = cmd.ExecuteReader())
                {
                    while (saReader.Read())
                    {
                        string name = saReader.GetString(0);
                        comboBox.Items.Add(name);
                    }
                }
            }
        }

        bool hasDroppedOnce = false;
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string query = "select name from tableCourse";
            if (!hasDroppedOnce)
            {
                ComboBoxDrop(query, comboBoxCanTeach1);
            }

            hasDroppedOnce = true;

        }

        bool hasDroppedOnce2 = false;
        private void comboBoxCanTeach2_DropDown(object sender, EventArgs e)
        {
            string query = "select name from tableCourse";
            if (!hasDroppedOnce2)
            {
                ComboBoxDrop(query, comboBoxCanTeach2);
            }

            hasDroppedOnce2 = true;
        }

        bool hasDroppedOnce3 = false;
        private void comboBoxCanTeach3_DropDown(object sender, EventArgs e)
        {
            string query = "select name from tableCourse";
            if (!hasDroppedOnce3)
            {
                ComboBoxDrop(query, comboBoxCanTeach3);
            }

            hasDroppedOnce3 = true;
        }

        bool hasDroppedOnce4 = false;
        private void comboBoxGroupTeacher_DropDown(object sender, EventArgs e)
        {
            string query = "select name + ' ' + surname from tableTeacher";
            if (!hasDroppedOnce4)
            {
                ComboBoxDrop(query, comboBoxGroupTeacher);
            }

            hasDroppedOnce4 = true;
        }

        private void buttonCreateGroup_Click(object sender, EventArgs e)
        {
            CreateGroup();
            ClearGroup();
        }

        private void buttonPlanStartDelete_Click(object sender, EventArgs e)
        {
            DeleteGroup();
            ClearGroup();
        }

        private void buttonUpdateGroup_Click(object sender, EventArgs e)
        {
            UpdateGroup();
            ClearGroup();
        }

        void ClearGroup()
        {
            textBoxGroupname.Text = "";
            comboBoxGroupTeacher.Text = "";
            dateTimePickerStartDate.Value = DateTime.Today;
            dateTimePickerEndDate.Value = DateTime.Today;
        }

        private void buttonGroupClear_Click(object sender, EventArgs e)
        {
            ClearGroup();
        }


        bool hasDroppedOnce5 = false;
        private void comboBoxGSgroupName_DropDown(object sender, EventArgs e)
        {
            string query = "select GroupName from tableGroups";
            if (!hasDroppedOnce5)
            {
                ComboBoxDrop(query, comboBoxGSgroupName);
            }

            hasDroppedOnce5 = true;
        }

        bool hasDroppedOnce6 = false;
        private void comboBoxGSstudentName_DropDown(object sender, EventArgs e)
        {
            string query = "select name + ' ' + surname from tableStudent";
            if (!hasDroppedOnce6)
            {
                ComboBoxDrop(query, comboBoxGSstudentName);
            }

            hasDroppedOnce6 = true;
        }


        void AddGroupStudents()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @$"insert into tableGroupsStudents values
                                    (@GroupName, @StudentName)";

                cmd.Parameters.AddWithValue("GroupName", comboBoxGSgroupName.Text);
                cmd.Parameters.AddWithValue("StudentName", comboBoxGSstudentName.Text);

                if (comboBoxGSgroupName.Text != "" && comboBoxGSstudentName.Text != "")
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student added to the group");

                    dataGridViewGroupsStudents.DataSource = GetData("select * from tableGroupsStudents");
                }
                else
                {
                    MessageBox.Show("Cannot add empty information");
                }

            }

        }

        private void buttonGroupsStudentsAdd_Click(object sender, EventArgs e)
        {
            AddGroupStudents();
        }

        void DeleteGroupStudent()
        {
            string id = dataGridViewGroupsStudents.SelectedRows[0].Cells[0].Value + string.Empty;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @$"delete from tableGroupsStudents where Id = {id}";

                var answer = MessageBox.Show("Group's student will be removed permanently\r\n\r\nAre you sure?", "Delete Group's student", MessageBoxButtons.YesNo);

                if (answer == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                }
            }

            dataGridViewGroupsStudents.DataSource = GetData("select * from tableGroupsStudents");
        }

        private void buttonGroupsStudentsDelete_Click(object sender, EventArgs e)
        {
            DeleteGroupStudent();
        }

        bool hasDroppedOnce7 = false;
        private void comboBoxLessonStudentName_DropDown(object sender, EventArgs e)
        {
            string query = "select StudentName from tableGroupsStudents";
            if (!hasDroppedOnce7)
            {
                ComboBoxDrop(query, comboBoxLessonStudentName);
            }

            hasDroppedOnce7 = true;
        }

        bool hasDroppedOnce8 = false;
        private void comboBoxLessonGroupName_DropDown(object sender, EventArgs e)
        {
            string query = "select distinct GroupName from tableGroupsStudents";
            if (!hasDroppedOnce8)
            {
                ComboBoxDrop(query, comboBoxLessonGroupName);
            }

            hasDroppedOnce8 = true;
        }

        bool hasDroppedOnce9 = false;
        private void comboBoxStudentProgress_DropDown(object sender, EventArgs e)
        {
            string query = "select distinct StudentName from tableLesson";
            if (!hasDroppedOnce9)
            {
                ComboBoxDrop(query, comboBoxStudentProgress);
            }

            hasDroppedOnce9 = true;
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonStudentProgress_Click(object sender, EventArgs e)
        {
            dataGridViewStudentProgress.DataSource = GetData($@"select StudentName, GroupName, 
                                                              LessonName, LessonDate,
                                                              atLesson, comment 
                                                              from tableLesson where 
                                                              StudentName = '{comboBoxStudentProgress.Text}'");
            comboBoxStudentProgress.Text = "";
        }

    }
}
