using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MauiEx2.Models
{
	public class User : ObservableObject
	{
		private static bool IsValid(string email)
		{
			string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

			return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
		}

		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged(); OnPropertyChanged(nameof(NameValidationIcon)); OnPropertyChanged(nameof(NameValidationIconColor)); }
		}
		public bool IsNameValid { get { return name.Length > 5; } }
		public string NameValidationIcon { get { return name.Length > 5 ? "\ue876" : "\ue645"; } }
		public string NameValidationIconColor { get { return name.Length > 5 ? "Green" : "Red"; } }
		private string userName = string.Empty;

		public string UserName
		{
			get { return userName; }
			set { userName = value; OnPropertyChanged(); OnPropertyChanged(nameof(UserNameValidationIcon)); OnPropertyChanged(nameof(UserNameValidationIconColor)); }
		}
		public string UserNameValidationIcon { get { return userName.Length > 5 ? "\ue876" : "\ue645"; } }
		public string UserNameValidationIconColor { get { return userName.Length > 5 ? "Green" : "Red"; } }

		private string address = string.Empty;

		public string Address
		{
			get { return address; }
			set { address = value; OnPropertyChanged(); OnPropertyChanged(nameof(AddressValidationIcon)); OnPropertyChanged(nameof(AddressValidationIconColor)); }
		}

		public string AddressValidationIcon { get { return address.Length > 5 ? "\ue876" : "\ue645"; } }
		public string AddressValidationIconColor { get { return address.Length > 5 ? "Green" : "Red"; } }

		private string email = string.Empty;

		public string Email
		{
			get { return email; }
			set { email = value; OnPropertyChanged(); OnPropertyChanged(nameof(EmailValidationIcon)); OnPropertyChanged(nameof(EmailValidationIconColor)); }
		}
		public string EmailValidationIcon { get { return IsValid(email) ? "\ue876" : "\ue645"; } }
		public string EmailValidationIconColor { get { return IsValid(email) ? "Green" : "Red"; } }

		private DateTime dateOfBirth;

		public DateTime DateOfBirth
		{
			get { return dateOfBirth; }
			set { dateOfBirth = value; OnPropertyChanged(); OnPropertyChanged(nameof(Age)); OnPropertyChanged(nameof(DateOfBirthValidationIcon)); OnPropertyChanged(DateOfBirthValidationIconColor); }
		}

		public string DateOfBirthValidationIcon { get { return Age > 18 ? "\ue876" : "\ue645"; } }
		public string DateOfBirthValidationIconColor { get { return Age > 18 ? "Green" : "Red"; } }

		private string password = string.Empty;

		public string Password
		{
			get { return password; }
			set { password = value; OnPropertyChanged(); OnPropertyChanged(nameof(PasswordValidationIcon)); OnPropertyChanged(nameof(PasswordValidationIconColor)); }
		}

		public string PasswordValidationIcon { get { return password.Length > 5 ? "\ue876" : "\ue645"; } }
		public string PasswordValidationIconColor { get { return password.Length > 5 ? "Green" : "Red"; } }

		public int Age
		{
			get
			{
				var today = DateTime.Today;

				var a = (today.Year * 100 + today.Month) * 100 + today.Day;
				var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;

				return (a - b) / 10000;
			}
		}
	}
}
