using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StudentID.PlaceholderText = GetNextId().ToString();
            var students = GetAllStudentsList();

            foreach (var student in students)
            {
                {
                    dataGrid.Rows.Add(null, student.ID, student.Name, student.Surname, student.DateOfBirth, student.Nationality, student.Address, student.Gender);
                }
            }
        }
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add();
            StudentID.PlaceholderText = GetNextId().ToString();
        }

        private void Add()
        {

            if (StudentName.Text == "" || StudentSurname.Text == "" || StudentDOB.Text == "" || StudentNationality.Text == "" || StudentAddress.Text == "" || (radioFemale.Checked == false && radioMale.Checked == false))
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
                dataGrid.Rows.Add(img, studentId, StudentName.Text, StudentSurname.Text, StudentDOB.Text, StudentNationality.Text, StudentAddress.Text, MaleOrFemale);

                AddToFile(GetNextId().ToString());
                makeDefault();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGrid.SelectedRows)
            {
                var answer = MessageBox.Show("Are you sure to delete this information?", "Delete student", MessageBoxButtons.YesNo);

                if (answer == DialogResult.Yes)
                {
                    //some problem here
                    try
                    {
                        dataGrid.Rows.RemoveAt(item.Index);

                        var file = new FileInfo($"{myPath}/{StudentID.Text}.doc");

                        file.Delete();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            StudentID.PlaceholderText = GetNextId().ToString();
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

        int index;
        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //some problem here
            index = e.RowIndex;

            if (index >= 0)
            {
                var row = dataGrid.Rows[index];

                if (row != null && row.Cells[index] != null)
                {
                    StudentID.Text = row.Cells[1].Value.ToString();
                    StudentName.Text = row.Cells[2].Value.ToString();
                    StudentSurname.Text = row.Cells[3].Value.ToString();
                    StudentDOB.Text = row.Cells[4].Value.ToString();
                    StudentNationality.Text = row.Cells[5].Value.ToString();
                    StudentAddress.Text = row.Cells[6].Value.ToString();
                    MaleOrFemale = row.Cells[7].Value.ToString();
                }
            }        
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow datagridRow = dataGrid.Rows[index];

            if (StudentID.Text == "" || StudentName.Text == "" || StudentSurname.Text == "" || StudentDOB.Text == "" || StudentNationality.Text == "" || StudentAddress.Text == "")
            {
                MessageBox.Show("All inputs are required");
            }
            else
            {
                datagridRow.Cells[1].Value = StudentID.Text;
                datagridRow.Cells[2].Value = StudentName.Text;
                datagridRow.Cells[3].Value = StudentSurname.Text;
                datagridRow.Cells[4].Value = StudentDOB.Text;
                datagridRow.Cells[5].Value = StudentNationality.Text;
                datagridRow.Cells[6].Value = StudentAddress.Text;
                datagridRow.Cells[7].Value = MaleOrFemale;
            }

            AddToFile(StudentID.Text.ToString());
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

        const string myPath = @"D:\myFolder\Students";
        private void AddToFile(string fileName)
        {

            string text = $"Student's adding time: {DateTime.Now}\n" +
                    $"Name: {StudentName.Text}\n" +
                    $"Surname: {StudentSurname.Text}\n" +
                    $"Date of Birth: {StudentDOB.Text}\n" +
                    $"Gender: {MaleOrFemale}\n" +
                    $"Nationality: {StudentNationality.Text}\n" +
                    $"Address: {StudentAddress.Text}";

            File.WriteAllText(myPath + "/" + fileName + ".doc", text);
        }


        internal int GetNextId()
        {
            var directory = new DirectoryInfo(myPath);
            var lastFile = directory.GetFiles().OrderByDescending(f => f.Name).Select(n => n.Name).FirstOrDefault();

            int studentId;

            if (lastFile == null)
            {
                studentId = 1;
            }
            else
            {
                studentId = int.Parse(Path.GetFileNameWithoutExtension(lastFile));
                studentId++;
            }

            return studentId;
        }


        private void makeDefault()
        {
            img = null;
            pictureBox1.Image = Properties.Resources.male;
            StudentName.Text = "";
            StudentID.Text = "";
            StudentSurname.Text = "";
            StudentAddress.Text = "";
            StudentNationality.Text = "";
            StudentDOB.Text = "";
            radioMale.Checked = false;
            radioFemale.Checked = false;

            StudentID.PlaceholderText = GetNextId().ToString();
        }

        private List<Student> GetAllStudentsList()
        {

            var result = new List<Student>();

            var directory = new DirectoryInfo(myPath);

            foreach (var file in directory.GetFiles())
            {
                var fileLine = File.ReadAllLines(file.FullName);

                var student = new Student()
                {
                    ID = int.Parse(Path.GetFileNameWithoutExtension(file.Name)),
                    Name = fileLine[1].Split(":")[1].Trim(),
                    Surname = fileLine[2].Split(":")[1].Trim(),
                    DateOfBirth = fileLine[3].Split(":")[1].Trim(),
                    Gender = fileLine[4].Split(":")[1].Trim(),
                    Nationality = fileLine[5].Split(":")[1].Trim(),
                    Address = fileLine[6].Split(":")[1].Trim()
                };
                result.Add(student);
            }

            return result;
        }
        
    }
}
