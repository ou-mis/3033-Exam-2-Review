/*
 * Exam 2 review solution for the FILE I/O Problem
 * @Author: Professor Ackerman
 */
using System;
using System.Collections.Generic;
using System.IO;
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

namespace File_IO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string PATH = "Employees.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            var file = File.ReadAllLines(PATH);
            List<Employee> employees = new List<Employee>();
            for (int i = 1; i < file.Length; i++) // start at 1 to skip first line
            {
                var line = file[i].Split("|"); //first_name|last_name|email|gender|salary
                employees.Add(new Employee(line[0], line[1], line[2], line[3], line[4]));

            }


            double allSalariesAddedTogether = 0;
            foreach (var employee in employees)
            {
                //  > $70,000
                if (employee.Salary > 70000)
                {
                    lstSalaries.Items.Add(employee);
                }

                // Dropbox Email
                if (employee.Email.ToLower().Contains("dropbox.com"))
                {
                    lstEmails.Items.Add(employee);
                }

                // Avg Salary
                allSalariesAddedTogether += employee.Salary;
            }

            double averageSalary = allSalariesAddedTogether / employees.Count;
            txtAvgSalary.Text = averageSalary.ToString("C2");

        }
    }
}
