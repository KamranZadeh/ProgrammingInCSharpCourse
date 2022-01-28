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

            dataGridViewTeacher.DataSource = TeacherManager.GetTeachers();
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
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnsettings.Height;
            pnlNav.Top = btnsettings.Top;
            btnsettings.BackColor = Color.FromArgb(46, 51, 73);
        }


        private void buttonLesson_Click(object sender, EventArgs e)
        {
            pnlNav.Height = buttonLesson.Height;
            pnlNav.Top = buttonLesson.Top;
            buttonLesson.BackColor = Color.FromArgb(46, 51, 73);

            panelLesson.BringToFront();
            panelLessonBottom.BringToFront();
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



        private void btnsettings_Leave(object sender, EventArgs e)
        {
            btnsettings.BackColor = Color.FromArgb(24, 30, 54);
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
            if (dataGridViewStudent.SelectedRows.Count > 0)
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
            if (dataGridViewTeacher.SelectedRows.Count > 0)
            {
                string Id = dataGridViewTeacher.SelectedRows[0].Cells[0].Value + string.Empty;
                string name = dataGridViewTeacher.SelectedRows[0].Cells[1].Value + string.Empty;
                string surname = dataGridViewTeacher.SelectedRows[0].Cells[2].Value + string.Empty;

                dateTimePickerTeacher.Value = (DateTime)dataGridViewTeacher.SelectedRows[0].Cells[3].Value;

                string profession = dataGridViewTeacher.SelectedRows[0].Cells[4].Value + string.Empty;

                textBoxTeacherId.Text = Id;
                textBoxTeacherName.Text = name;
                textBoxTeacherSurname.Text = surname;
                textBoxTeacherProfession.Text = profession;
            }
        }

        public void AddStudent()
        {
            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
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
            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @"insert into tableTeacher values(@Name, @Surname, @BirthDate, @Profession)";

                if (textBoxTeacherName.Text != "" && textBoxTeacherSurname.Text != "" && textBoxTeacherProfession.Text != "")
                {
                    cmd.Parameters.AddWithValue("Name", textBoxTeacherName.Text);
                    cmd.Parameters.AddWithValue("Surname", textBoxTeacherSurname.Text);
                    cmd.Parameters.AddWithValue("BirthDate", dateTimePickerTeacher.Value);
                    cmd.Parameters.AddWithValue("Profession", textBoxTeacherProfession.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Teacher added successfully");

                    ClearTeacher();

                    dataGridViewTeacher.DataSource = TeacherManager.GetTeachers();
                }
                else
                {
                    MessageBox.Show("Name,Surname and Profession are required");
                }

            }

        }

        void ClearTeacher()
        {
            textBoxTeacherId.Text = textBoxTeacherId.PlaceholderText;
            textBoxTeacherName.Text = "";
            textBoxTeacherSurname.Text = "";
            dateTimePickerTeacher.Value = dateTimePickerStudentBirthDate.MaxDate;
            textBoxTeacherProfession.Text = "";
        }

        public void AddCourse()
        {
            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
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
            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
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
            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
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
            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                var command = connection.CreateCommand();
                connection.Open();

                if (textBoxTeacherName.Text != "" && textBoxTeacherSurname.Text != "" && textBoxTeacherProfession.Text != "")
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
                                               Profession = @Profession
                                               where Id = {teacherId}";

                        command.Parameters.AddWithValue("Name", textBoxTeacherName.Text);
                        command.Parameters.AddWithValue("Surname", textBoxTeacherSurname.Text);
                        command.Parameters.AddWithValue("BirthDate", dateTimePickerTeacher.Value);
                        command.Parameters.AddWithValue("Profession", textBoxTeacherProfession.Text);
                        command.ExecuteNonQuery();

                        MessageBox.Show($"Teacher with {teacherId} ID UPDATED successfully");
                    }
                }
                else
                {
                    MessageBox.Show("All inputs are required");
                }

                dataGridViewTeacher.DataSource = TeacherManager.GetTeachers();
            }
        }

        void DeleteTeacher()
        {
            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
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
                dataGridViewTeacher.DataSource = TeacherManager.GetTeachers();
            }
        }

        public void UpdateCourse()
        {
            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
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
            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
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
            if (dataGridViewCourse.SelectedRows.Count > 0)
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

        bool isInPlannedCourses = false;
        private void buttonPlannedCourses_Click(object sender, EventArgs e)
        {
            dataGridViewPlanStart.DataSource = PlannedCourseManager.GetAll();
            isInPlannedCourses = true;
            buttonPlannedCourses.BackColor = Color.FromArgb(255, 255, 128);
            buttonOngoingCourses.BackColor = DefaultBackColor;
        }

        private void buttonOngoingCourses_Click(object sender, EventArgs e)
        {
            dataGridViewPlanStart.DataSource = OngoingCourseManager.GetAll();
            isInPlannedCourses = false;
            buttonOngoingCourses.BackColor = Color.FromArgb(255, 255, 128);
            buttonPlannedCourses.BackColor = DefaultBackColor;
        }

        public void PlanCourse()
        {
            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @$"insert into tablePlannedCourses 
                                    values(@StudentId, @TeacherId, @CourseId, @StartDate, @EndDate)";

                var isInt = true;

                try
                {
                    int.Parse(textBoxPlanStartCourseStudentID.Text);
                    int.Parse(textBoxPlanStartCourseTeacherID.Text);
                    int.Parse(textBoxPlanStartCourseCourseID.Text);
                }
                catch (Exception)
                {
                    isInt = false;
                }

                if (dateTimePickerStartDate.Value.AddMonths(3) > dateTimePickerEndDate.Value)
                {
                    MessageBox.Show("Course period cannot be less than 3 month");
                }
                else if (textBoxPlanStartCourseStudentID.Text != "" && textBoxPlanStartCourseTeacherID.Text != "" && textBoxPlanStartCourseCourseID.Text !="" && isInt)
                {
                    cmd.Parameters.AddWithValue("StudentId", textBoxPlanStartCourseStudentID.Text);
                    cmd.Parameters.AddWithValue("TeacherId", textBoxPlanStartCourseTeacherID.Text);
                    cmd.Parameters.AddWithValue("CourseId", textBoxPlanStartCourseCourseID.Text);
                    cmd.Parameters.AddWithValue("StartDate", dateTimePickerStartDate.Value);
                    cmd.Parameters.AddWithValue("EndDate", dateTimePickerEndDate.Value);

                    cmd.ExecuteNonQuery();

                    ClearPlanStart();

                    MessageBox.Show("Planned successfully");

                }
                else if(!isInt) 
                {
                    MessageBox.Show("All ID's should have numeric values");
                }
                else
                {
                    MessageBox.Show("All ID should be filled");
                }
            }
        }

        public void StartCourse()
        {
            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @$"insert into tableOngoingCourses 
                                    values(@StudentId, @TeacherId, @CourseId, @StartDate, @EndDate)";

                var isInt = true;

                try
                {
                    int.Parse(textBoxPlanStartCourseStudentID.Text);
                    int.Parse(textBoxPlanStartCourseTeacherID.Text);
                    int.Parse(textBoxPlanStartCourseCourseID.Text);
                }
                catch (Exception)
                {
                    isInt = false;
                }

                if (dateTimePickerStartDate.Value.AddMonths(3) > dateTimePickerEndDate.Value)
                {
                    MessageBox.Show("Course period cannot be less than 3 month");
                }
                else if (textBoxPlanStartCourseStudentID.Text != "" && textBoxPlanStartCourseTeacherID.Text != "" && textBoxPlanStartCourseCourseID.Text != "" && isInt)
                {
                    cmd.Parameters.AddWithValue("StudentId", textBoxPlanStartCourseStudentID.Text);
                    cmd.Parameters.AddWithValue("TeacherId", textBoxPlanStartCourseTeacherID.Text);
                    cmd.Parameters.AddWithValue("CourseId", textBoxPlanStartCourseCourseID.Text);
                    cmd.Parameters.AddWithValue("StartDate", dateTimePickerStartDate.Value);
                    cmd.Parameters.AddWithValue("EndDate", dateTimePickerEndDate.Value);

                    cmd.ExecuteNonQuery();

                    ClearPlanStart();

                    MessageBox.Show("Started successfully");

                }
                else if (!isInt)
                {
                    MessageBox.Show("All ID's should have numeric values");
                }
                else
                {
                    MessageBox.Show("All ID should be filled");
                }
            }
        }

        void ClearPlanStart()
        {
            textBoxPlanStartCourseStudentID.Text = "";
            textBoxPlanStartCourseTeacherID.Text = "";
            textBoxPlanStartCourseCourseID.Text = "";
            dateTimePickerStartDate.Value = DateTime.Today;
            dateTimePickerEndDate.Value = DateTime.Today;
        }

        private void buttonPlanCourse_Click(object sender, EventArgs e)
        {
            PlanCourse();
            buttonPlannedCourses_Click(this, default);
        }

        private void buttonStartCourse_Click(object sender, EventArgs e)
        {
            StartCourse();
            buttonOngoingCourses_Click(this, default);
        }

        private void dataGridViewPlanStart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPlanStart.SelectedRows.Count > 0)
            {
                string studentId = dataGridViewPlanStart.SelectedRows[0].Cells[0].Value + string.Empty;
                string teacherId = dataGridViewPlanStart.SelectedRows[0].Cells[1].Value + string.Empty;
                string courseId = dataGridViewPlanStart.SelectedRows[0].Cells[2].Value + string.Empty;

                dateTimePickerStartDate.Value = (DateTime)dataGridViewPlanStart.SelectedRows[0].Cells[3].Value;
                dateTimePickerEndDate.Value = (DateTime)dataGridViewPlanStart.SelectedRows[0].Cells[4].Value;

                textBoxPlanStartCourseStudentID.Text = studentId;
                textBoxPlanStartCourseTeacherID.Text = teacherId;
                textBoxPlanStartCourseCourseID.Text = courseId;

                textBoxPlanStartCourseStudentID.Enabled = false;
                textBoxPlanStartCourseTeacherID.Enabled = false;
                textBoxPlanStartCourseCourseID.Enabled = false;

            }
        }

        private void dataGridViewPlanStart_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            textBoxPlanStartCourseStudentID.Enabled = true;
            textBoxPlanStartCourseTeacherID.Enabled = true;
            textBoxPlanStartCourseCourseID.Enabled = true;
        }

        private void buttonPlanStartClear_Click(object sender, EventArgs e)
        {
            ClearPlanStart();
        }

        void DeletePlannedOngoingCourse()
        {
            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                var command = connection.CreateCommand();
                connection.Open();

                var studentId = textBoxPlanStartCourseStudentID.Text;
                var teacherId = textBoxPlanStartCourseTeacherID.Text;
                var courseId = textBoxPlanStartCourseCourseID.Text;

                if (isInPlannedCourses)
                {
                    var answer = MessageBox.Show($"Are you sure to DELETE this PLANNED COURSE?", "Delete Planned course", MessageBoxButtons.YesNo);

                    if (answer == DialogResult.Yes)
                    {
                        command.CommandText = @$"delete from tablePlannedCourses
                                                where StudentId = {studentId} 
                                                and TeacherId = {teacherId} 
                                                and CourseId = {courseId}";

                        
                        command.ExecuteNonQuery();
                        


                        MessageBox.Show($"Planned Course DELETED successfully");
                        buttonPlannedCourses_Click(this, default);
                    }

                }
                else
                {
                    var answer = MessageBox.Show($"Are you sure to DELETE this ONGOING COURSE?", "Delete Ongoing course", MessageBoxButtons.YesNo);

                    if (answer == DialogResult.Yes)
                    {
                        command.CommandText = @$"delete from tableOngoingCourses
                                                where StudentId = {studentId} 
                                                and TeacherId = {teacherId} 
                                                and CourseId = {courseId}";

                        command.ExecuteNonQuery();
                        
                        MessageBox.Show($"Ongoing Course DELETED successfully");
                        buttonOngoingCourses_Click(this, default);
                    }
                }
                ClearPlanStart();
            }
        }

        private void buttonPlanStartDelete_Click(object sender, EventArgs e)
        {
            DeletePlannedOngoingCourse();
        }

        private static DataTable GetData(string sqlCommand)
        {

            using (SqlConnection connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
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
                    int.Parse(textBoxLessonTeacherID.Text);
                }
                catch (Exception)
                {
                    isInt = false;
                }


                if (isInt)
                {
                    BindingSource bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = GetData(@$"select t.Name + ' ' + t.Surname as Teacher, 
                                                    s.Name + ' ' + s.Surname as Student, s.Id as StudentId, 
                                                    c.Name as Course from tableStudent s
                                                    left join tableOngoingCourses oc on oc.StudentId = s.Id
                                                    join tableCourse c on oc.CourseId = c.Id
                                                    left join tableTeacher t on oc.TeacherId = t.Id where t.Id = {textBoxLessonTeacherID.Text}");
                    dataGridViewTeacher_s_Student.DataSource = bindingSource1;
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

        void SeeAllStudentInfo()
        {
            try
            {
                var isInt = true;
                try
                {
                    int.Parse(textBoxLessonStudentId.Text);
                }
                catch (Exception)
                {
                    isInt = false;
                }


                if (isInt)
                {
                    BindingSource bindingSource1 = new BindingSource();
                    bindingSource1.DataSource = GetData(@$"select s.Name + ' ' + s.Surname as Student, 
                                                        t.Name + ' ' + t.Surname as Teacher, 
                                                        li.LessonDate, li.comment from tableLessonInfo li
                                                        left join tableStudent s on li.studentId = s.Id
                                                        left join tableTeacher t on li.teacherId = t.Id
                                                        where s.Id={textBoxLessonStudentId.Text}");
                    dataGridViewTeacher_s_Student.DataSource = bindingSource1;
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

        string GetAtLessonOrNot()
        {
            string atLessonOrNot;
            if (checkBoxLesson.Checked)
            {
                atLessonOrNot = "at lesson";
            }
            else
            {
                atLessonOrNot = "not at lesson";
            }

            return atLessonOrNot;
        }

        void AddLessonInfo()
        {
            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                cmd.CommandText = @$"insert into tableLessonInfo values
                                    (@teacherId, @studentId, @lessonDate, @atLesson, @comment)";

                var isInt = true;

                try
                {
                    int.Parse(textBoxLessonTeacherID.Text);
                    int.Parse(textBoxLessonStudentId.Text);
                }
                catch (Exception)
                {
                    isInt = false;
                }

                if (textBoxLessonTeacherID.Text != "" && textBoxLessonStudentId.Text != "" && richTextBoxLesson.Text != "" && isInt)
                {
                    cmd.Parameters.AddWithValue("teacherId", textBoxLessonTeacherID.Text);
                    cmd.Parameters.AddWithValue("studentId", textBoxLessonStudentId.Text);
                    cmd.Parameters.AddWithValue("lessonDate", dateTimePickerLessonDate.Value);
                    cmd.Parameters.AddWithValue("atLesson", GetAtLessonOrNot());
                    cmd.Parameters.AddWithValue("comment", richTextBoxLesson.Text);

                    cmd.ExecuteNonQuery();

                    richTextBoxLesson.Text = "";

                    MessageBox.Show("Lesson info added successfully");

                }
                else if (!isInt)
                {
                    MessageBox.Show("All ID's should have numeric values");
                }
                else
                {
                    MessageBox.Show("All infos should be filled");
                }
            }
        }

        private void buttonLessonAddComment_Click(object sender, EventArgs e)
        {
            AddLessonInfo();
        }

        private void buttonLessonStudentInfo_Click(object sender, EventArgs e)
        {
            SeeAllStudentInfo();
        }

        void SearchCourse()
        {
            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
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
            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
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
            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=CourseManagementPortalData;Trusted_Connection=True; TrustServerCertificate=True"))
            {
                connection.Open();
                var cmd = connection.CreateCommand();

                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = GetData(@$"declare @name varchar(50) = '%{textBoxStudentSearch.Text}%'

                                                    select * from tableStudent
                                                    where Name like @name");
                dataGridViewStudent.DataSource = bindingSource1;

            }
        }

        private void textBoxStudentSearch_TextChanged(object sender, EventArgs e)
        {
            SearchStudent();
        }

    }
}
