using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Q1.Models;
namespace Q1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			load();
		}
		private void load()
		{
			using (var context = new DUONGPV14_PRNContext())
			{
				lvStudent.ItemsSource = context.Students
					.Include(s => s.Lecture)
					.Select(e => new
					{
						StudentId = e.Id,
						StudentName = e.FullName,
						Gender = e.Male ? "Male" : "Female",
						Male = e.Male,
						Female = !e.Male,
						Lecture = e.Lecture,
						DateOfBirth = e.Dob.ToString(),
						Note = e.Note,
					}).ToList();
				cbLecturer.ItemsSource = context.Lecturers.ToList();
			}
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				using (var context = new DUONGPV14_PRNContext())
				{
					var student = new Student
					{
						FullName = txtStudentFullName.Text,
						Male = rbMale.IsChecked == true,
						LectureId = (int)cbLecturer.SelectedValue,
						Dob = (DateTime)dpDateOfBirth.SelectedDate,
						Note = txtNote.Text
					};

					context.Students.Add(student);
					context.SaveChanges();
					load();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error adding student: {ex.Message}");
			}
		}

		private void btnEdit_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				using (var context = new DUONGPV14_PRNContext())
				{
					Student s = context.Students.FirstOrDefault(p => p.Id == int.Parse(txtStudentID.Text));
					if(s != null)
					{
						s.FullName = txtStudentFullName.Text;
						s.Male = (rbMale.IsChecked == true);
						s.Dob = dpDateOfBirth.DisplayDate;
						s.LectureId = (int)cbLecturer.SelectedValue;
						s.Note = txtNote.Text;
					context.Update(s);
					context.SaveChanges();
					}
					load();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error adding student: {ex.Message}");
			}
		}
	}
}
