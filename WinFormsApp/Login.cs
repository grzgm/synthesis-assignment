using LogicLayer.InterfacesManagers;
using LogicLayer.InterfacesRepository;
using LogicLayer.Managers;
using LogicLayer.Models;
using DataAccessLayer;

namespace WinFormsApp
{
	public partial class Login : Form
	{
		IEmployeeRepository employeeRepository;
		IEmployeeManager employeeManager;

		string email;
		string password;
		Employee employee;
		public Login()
		{
			InitializeComponent();
			tbPassword.PasswordChar = '*';
			employeeRepository = new EmployeeRepository();
			employeeManager = new EmployeeManager(employeeRepository);
		}

		private void btnLogIn_Click(object sender, EventArgs e)
		{
			email = tbEmail.Text;
			password = tbPassword.Text;
			if (email != String.Empty && password != String.Empty)
			{
				employee = employeeManager.ReadEmployee(email, password);
				if (employee != null)
				{
					this.Hide();
					var main = new Main();
					main.Closed += (s, args) => this.Close();
					main.Show();
				}
				else
				{
					lbFeedback.Text = "Wrong credentials";
				}
			}
			else
			{
				lbFeedback.Text = "Fill in all credentials";
			}
		}
	}
}