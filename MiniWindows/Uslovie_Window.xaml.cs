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
using System.Windows.Shapes;

namespace Prog3.MiniWindows
{
	/// <summary>
	/// Логика взаимодействия для Uslovie_Window.xaml
	/// </summary>
	/// 

	public partial class Uslovie_Window : Window
	{
		public Uslovie_Window()
		{
			InitializeComponent();
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		public List<string> SelectedUslovia { get; private set; } = new List<string>();

		// Словарь для преобразования полных названий в сокращения
		private readonly Dictionary<string, string> uslovieAbbreviations = new Dictionary<string, string>
		{
			{ "Стандартный расчет", "Ср" },
			{ "5 класс", "5к" },
			{ "Средние заготовки", "Сз" },
			{ "Неравномерный рисунок", "Нр" },
			{ "Разница", "Р" },
			{ "Маленькие площади", "Мп" }
		};

		private string neravnomerCombo1Value = null;
		private string neravnomerCombo2Value = null;

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		{
			if (sender is CheckBox checkBox && checkBox.IsChecked == true)
			{
				string fullName = checkBox.Content.ToString();
				if (uslovieAbbreviations.ContainsKey(fullName) && fullName != "Неравномерный рисунок")
				{
					string abbreviation = uslovieAbbreviations[fullName];
					if (!SelectedUslovia.Contains(abbreviation))
					{
						SelectedUslovia.Add(abbreviation);
					}
				}
			}
		}

		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			if (sender is CheckBox checkBox)
			{
				string fullName = checkBox.Content.ToString();
				if (uslovieAbbreviations.ContainsKey(fullName) && fullName != "Неравномерный рисунок")
				{
					SelectedUslovia.Remove(uslovieAbbreviations[fullName]);
				}
			}
		}

		private void Neravnomer_Checked(object sender, RoutedEventArgs e)
		{
			neravnomerCombo1.Visibility = Visibility.Visible;
		}

		private void Neravnomer_Unchecked(object sender, RoutedEventArgs e)
		{
			neravnomerCombo1.Visibility = Visibility.Collapsed;
			neravnomerCombo2.Visibility = Visibility.Collapsed;
			neravnomerCombo1Value = null;
			neravnomerCombo2Value = null;
			SelectedUslovia.RemoveAll(s => s.StartsWith("Нр"));
		}

		private void NeravnomerCombo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (neravnomerCombo1.SelectedItem is ComboBoxItem selectedItem)
			{
				neravnomerCombo1Value = selectedItem.Content.ToString();
				neravnomerCombo2.Visibility = Visibility.Visible;
			}
			else
			{
				neravnomerCombo2.Visibility = Visibility.Collapsed;
				neravnomerCombo2Value = null;
			}
		}

		private void Dobav_Uslov(object sender, RoutedEventArgs e)
		{
			if (neravnomer_ris_check.IsChecked == true && neravnomerCombo1Value != null && neravnomerCombo2Value != null)
			{
				string neravnomerEntry = $"Нр({neravnomerCombo1Value}, {neravnomerCombo2Value})";
				if (!SelectedUslovia.Contains(neravnomerEntry))
				{
					SelectedUslovia.RemoveAll(s => s.StartsWith("Нр"));
					SelectedUslovia.Add(neravnomerEntry);
				}
			}

			if (SelectedUslovia.Any())
			{
				DialogResult = true;
				Close();
			}
			else
			{
				MessageBox.Show("Выберите хотя бы одно условие!");
			}
		}

		private void neravnomerCombo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (neravnomerCombo2.SelectedItem is ComboBoxItem selectedItem)
			{
				neravnomerCombo2Value = selectedItem.Content.ToString();
			}
			else
			{
				neravnomerCombo2Value = null;
			}
		}
	}





















	//public partial class Uslovie_Window : Window
	//{
	//	public Uslovie_Window()
	//	{
	//		InitializeComponent();
	//	}

	//	private void ExitButton_Click(object sender, RoutedEventArgs e)
	//	{
	//		this.Close();
	//	}


	//	public List<string> SelectedUslovia { get; private set; } = new List<string>();

	//	// Словарь для преобразования полных названий в сокращения
	//	private readonly Dictionary<string, string> uslovieAbbreviations = new Dictionary<string, string>
	//{
	//	{ "Стандартный расчет", "Ср" },
	//	{ "5 класс", "5к" },
	//	{ "Средние заготовки", "Сз" },
	//	{ "Неравномерный рисунок", "Нр" },
	//	{ "Разница", "Р" },
	//	{ "Маленькие площади", "Мп" }
	//};

	//	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	//	{
	//		if (sender is CheckBox checkBox && checkBox.IsChecked == true)
	//		{
	//			string fullName = checkBox.Content.ToString();
	//			if (uslovieAbbreviations.ContainsKey(fullName))
	//			{
	//				string abbreviation = uslovieAbbreviations[fullName];
	//				if (!SelectedUslovia.Contains(abbreviation))
	//				{
	//					SelectedUslovia.Add(abbreviation);
	//				}
	//			}
	//		}
	//	}

	//	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	//	{
	//		if (sender is CheckBox checkBox)
	//		{
	//			string fullName = checkBox.Content.ToString();
	//			if (uslovieAbbreviations.ContainsKey(fullName))
	//			{
	//				SelectedUslovia.Remove(uslovieAbbreviations[fullName]);
	//			}
	//		}
	//	}

	//	private void Dobav_Uslov(object sender, RoutedEventArgs e)
	//	{
	//		if (SelectedUslovia.Any())
	//		{
	//			DialogResult = true;
	//			Close();
	//		}
	//		else
	//		{
	//			MessageBox.Show("Выберите хотя бы одно условие!");
	//		}
	//	}
	//}
}
