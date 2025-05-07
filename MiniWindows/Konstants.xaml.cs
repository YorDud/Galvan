using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
	/// Логика взаимодействия для Konstants.xaml
	/// </summary>
	public partial class Konstants : Window
	{
		private Dictionary<string, string> originalValues = new Dictionary<string, string>();

		public Konstants()
		{
			InitializeComponent();
			SetupTextBoxInputValidation();
		}

		private void SetupTextBoxInputValidation()
		{
			// List of all TextBoxes
			TextBox[] textBoxes = { icu1, icu2, icu3, icu4, icu5, icu6, icu7, isn1, isn2, spl, spl2 };

			foreach (var textBox in textBoxes)
			{
				// Handle text input
				textBox.PreviewTextInput += TextBox_PreviewTextInput;
				// Handle paste command
				DataObject.AddPastingHandler(textBox, TextBox_PasteHandler);
			}
		}

		private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			// Allow digits, period, and comma
			Regex regex = new Regex(@"^[0-9,.]+$");
			e.Handled = !regex.IsMatch(e.Text);
		}

		private void TextBox_PasteHandler(object sender, DataObjectPastingEventArgs e)
		{
			if (e.DataObject.GetDataPresent(typeof(string)))
			{
				string text = (string)e.DataObject.GetData(typeof(string));
				// Allow only digits, period, and comma in pasted text
				Regex regex = new Regex(@"^[0-9,.]+$");
				if (!regex.IsMatch(text))
				{
					e.CancelCommand();
				}
			}
			else
			{
				e.CancelCommand();
			}
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			LoadDataFromDatabase();
		}

		private void LoadDataFromDatabase()
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
				{
					connection.Open();
					string query = "SELECT TOP 1 icu1, icu2, icu3, icu4, icu5, icu6, icu7, isn1, isn2, spl, spl2 " +
								 "FROM Konstants ORDER BY ID DESC";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								// Load data into TextBoxes and store original values
								icu1.Text = originalValues["icu1"] = reader["icu1"]?.ToString() ?? "";
								icu2.Text = originalValues["icu2"] = reader["icu2"]?.ToString() ?? "";
								icu3.Text = originalValues["icu3"] = reader["icu3"]?.ToString() ?? "";
								icu4.Text = originalValues["icu4"] = reader["icu4"]?.ToString() ?? "";
								icu5.Text = originalValues["icu5"] = reader["icu5"]?.ToString() ?? "";
								icu6.Text = originalValues["icu6"] = reader["icu6"]?.ToString() ?? "";
								icu7.Text = originalValues["icu7"] = reader["icu7"]?.ToString() ?? "";
								isn1.Text = originalValues["isn1"] = reader["isn1"]?.ToString() ?? "";
								isn2.Text = originalValues["isn2"] = reader["isn2"]?.ToString() ?? "";
								spl.Text = originalValues["spl"] = reader["spl"]?.ToString() ?? "";
								spl2.Text = originalValues["spl2"] = reader["spl2"]?.ToString() ?? "";
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void SaveNewKonstants(object sender, RoutedEventArgs e)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
				{
					connection.Open();

					// Check if any values have changed
					bool hasChanges = false;
					var parameters = new List<SqlParameter>();
					string updateClause = "";

					void CheckAndAddParameter(string field, string textBoxValue, string dictionaryKey)
					{
						string originalValue;
						originalValues.TryGetValue(dictionaryKey, out originalValue);
						originalValue = originalValue ?? "";

						if (textBoxValue != originalValue)
						{
							hasChanges = true;
							if (parameters.Count > 0)
								updateClause += ", ";
							updateClause += $"{field} = @{field}";
							parameters.Add(new SqlParameter($"@{field}", string.IsNullOrEmpty(textBoxValue) ? (object)DBNull.Value : textBoxValue));
						}
					}

					CheckAndAddParameter("icu1", icu1.Text, "icu1");
					CheckAndAddParameter("icu2", icu2.Text, "icu2");
					CheckAndAddParameter("icu3", icu3.Text, "icu3");
					CheckAndAddParameter("icu4", icu4.Text, "icu4");
					CheckAndAddParameter("icu5", icu5.Text, "icu5");
					CheckAndAddParameter("icu6", icu6.Text, "icu6");
					CheckAndAddParameter("icu7", icu7.Text, "icu7");
					CheckAndAddParameter("isn1", isn1.Text, "isn1");
					CheckAndAddParameter("isn2", isn2.Text, "isn2");
					CheckAndAddParameter("spl", spl.Text, "spl");
					CheckAndAddParameter("spl2", spl2.Text, "spl2");

					if (hasChanges)
					{
						// Update the most recent record
						string query = $"UPDATE Konstants SET {updateClause} WHERE ID = (SELECT MAX(ID) FROM Konstants)";

						using (SqlCommand command = new SqlCommand(query, connection))
						{
							command.Parameters.AddRange(parameters.ToArray());
							int rowsAffected = command.ExecuteNonQuery();

							if (rowsAffected > 0)
							{
								MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
								// Update original values after successful save
								LoadDataFromDatabase();
							}
							else
							{
								MessageBox.Show("Не удалось обновить данные.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
							}
						}
					}
					else
					{
						MessageBox.Show("Изменений не обнаружено.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void ClearTextBoxes()
		{
			icu1.Text = string.Empty;
			icu2.Text = string.Empty;
			icu3.Text = string.Empty;
			icu4.Text = string.Empty;
			icu5.Text = string.Empty;
			icu6.Text = string.Empty;
			icu7.Text = string.Empty;
			isn1.Text = string.Empty;
			isn2.Text = string.Empty;
			spl.Text = string.Empty;
			spl2.Text = string.Empty;
		}
	}
}
