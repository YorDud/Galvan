using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
	/// Логика взаимодействия для New_Data.xaml
	/// </summary>
	public partial class New_Data : Window
	{
		private MainWindow mainWindow;
		public New_Data(MainWindow mainWindow)
		{
			InitializeComponent();
			InitializeUslovieTextBoxes();
			this.mainWindow = mainWindow;










			zakaz1.TextChanged += Zakaz1_TextChanged;

			// Изначально блокируем текстбокс Uslovie1
			Uslovie1.IsEnabled = !string.IsNullOrEmpty(zakaz1.Text);
			PloshA1.IsEnabled = !string.IsNullOrEmpty(zakaz1.Text);
			PloshB1.IsEnabled = !string.IsNullOrEmpty(zakaz1.Text);
			zakaz2.IsEnabled = !string.IsNullOrEmpty(zakaz1.Text);

			zakaz4.IsEnabled = !string.IsNullOrEmpty(zakaz1.Text);


			zakaz2.TextChanged += Zakaz2_TextChanged;

			
			Uslovie2.IsEnabled = !string.IsNullOrEmpty(zakaz2.Text);
			PloshA2.IsEnabled = !string.IsNullOrEmpty(zakaz2.Text);
			PloshB2.IsEnabled = !string.IsNullOrEmpty(zakaz2.Text);
			zakaz3.IsEnabled = !string.IsNullOrEmpty(zakaz2.Text);

			zakaz3.TextChanged += Zakaz3_TextChanged;


			Uslovie3.IsEnabled = !string.IsNullOrEmpty(zakaz3.Text);
			PloshA3.IsEnabled = !string.IsNullOrEmpty(zakaz3.Text);
			PloshB3.IsEnabled = !string.IsNullOrEmpty(zakaz3.Text);
			zakaz4.IsEnabled = !string.IsNullOrEmpty(zakaz3.Text);


			zakaz4.TextChanged += Zakaz4_TextChanged;


			Uslovie4.IsEnabled = !string.IsNullOrEmpty(zakaz4.Text);
			PloshA4.IsEnabled = !string.IsNullOrEmpty(zakaz4.Text);
			PloshB4.IsEnabled = !string.IsNullOrEmpty(zakaz4.Text);


			// Подписываемся на событие PreviewTextInput для всех текстовых полей
			zakaz1.PreviewTextInput += NumberValidationTextBox;
			zakaz2.PreviewTextInput += NumberValidationTextBox;
			zakaz3.PreviewTextInput += NumberValidationTextBox;
			zakaz4.PreviewTextInput += NumberValidationTextBox;
			

			// Подписываемся на событие PreviewTextInput для текстбоксов PloshA и PloshB
			PloshA1.PreviewTextInput += DecimalValidationTextBox;
			PloshA2.PreviewTextInput += DecimalValidationTextBox;
			PloshA3.PreviewTextInput += DecimalValidationTextBox;
			PloshA4.PreviewTextInput += DecimalValidationTextBox;
			PloshB1.PreviewTextInput += DecimalValidationTextBox;
			PloshB2.PreviewTextInput += DecimalValidationTextBox;
			PloshB3.PreviewTextInput += DecimalValidationTextBox;
			PloshB4.PreviewTextInput += DecimalValidationTextBox;

		}

		private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			// Используем регулярное выражение для проверки, является ли ввод допустимым (цифры, точка, запятая)
			e.Handled = !IsTextDecimal(e.Text);
		}

		private static bool IsTextDecimal(string text)
		{
			// Регулярное выражение для проверки допустимых символов
			Regex regex = new Regex("[^0-9.,]+"); // Разрешаем только цифры, точку и запятую
			return !regex.IsMatch(text);
		}

		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			// Используем регулярное выражение для проверки, является ли ввод число
			e.Handled = !IsTextNumeric(e.Text);
		}

		private static bool IsTextNumeric(string text)
		{
			// Регулярное выражение для проверки числа
			Regex regex = new Regex("[^0-9]+"); // Разрешаем только цифры
			return !regex.IsMatch(text);
		}

		private void Zakaz1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			
			// Проверяем содержимое zakaz1 и блокируем/разблокируем Uslovie1
			Uslovie1.IsEnabled = !string.IsNullOrEmpty(zakaz1.Text);
			PloshA1.IsEnabled = !string.IsNullOrEmpty(zakaz1.Text);
			PloshB1.IsEnabled = !string.IsNullOrEmpty(zakaz1.Text);
			zakaz2.IsEnabled = !string.IsNullOrEmpty(zakaz1.Text);
		}

		private void Zakaz2_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			// Проверяем содержимое zakaz1 и блокируем/разблокируем Uslovie1
			Uslovie2.IsEnabled = !string.IsNullOrEmpty(zakaz2.Text);
			PloshA2.IsEnabled = !string.IsNullOrEmpty(zakaz2.Text);
			PloshB2.IsEnabled = !string.IsNullOrEmpty(zakaz2.Text);
			zakaz3.IsEnabled = !string.IsNullOrEmpty(zakaz2.Text);
		}

		private void Zakaz3_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			// Проверяем содержимое zakaz1 и блокируем/разблокируем Uslovie1
			Uslovie3.IsEnabled = !string.IsNullOrEmpty(zakaz3.Text);
			PloshA3.IsEnabled = !string.IsNullOrEmpty(zakaz3.Text);
			PloshB3.IsEnabled = !string.IsNullOrEmpty(zakaz3.Text);
			zakaz4.IsEnabled = !string.IsNullOrEmpty(zakaz3.Text);
		}
		private void Zakaz4_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			// Проверяем содержимое zakaz1 и блокируем/разблокируем Uslovie1
			Uslovie4.IsEnabled = !string.IsNullOrEmpty(zakaz4.Text);
			PloshA4.IsEnabled = !string.IsNullOrEmpty(zakaz4.Text);
			PloshB4.IsEnabled = !string.IsNullOrEmpty(zakaz4.Text);



			
		}









		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
        }





		private void Dobav_New_Data(object sender, RoutedEventArgs e)
		{
			if (N_Shtang.Text == "")
			{
				MessageBox.Show("Выберите номер штанги");
			}
			else if (N_Vann.Text == "")
			{
				MessageBox.Show("Выберите номер ванны");
			}
			else
			{
				using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
				{
					conn.Open();

					// Получаем максимальное значение N_Zaves и увеличиваем на 1
					int newN_Zaves = 1;
					string getMaxZavesQuery = "SELECT ISNULL(MAX(N_Zaves), 0) + 1 FROM Galvan.dbo.Galvan_Jurnal";
					using (SqlCommand getMaxCmd = new SqlCommand(getMaxZavesQuery, conn))
					{
						object result = getMaxCmd.ExecuteScalar();
						if (result != null)
						{
							newN_Zaves = Convert.ToInt32(result);
						}
					}

					// Список строк с данными
					List<Tuple<TextBox, TextBox, TextBox, TextBox>> rows = new List<Tuple<TextBox, TextBox, TextBox, TextBox>>
			{
				new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz1, Uslovie1, PloshA1, PloshB1),
				new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz2, Uslovie2, PloshA2, PloshB2),
				new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz3, Uslovie3, PloshA3, PloshB3),
				new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz4, Uslovie4, PloshA4, PloshB4)
			};

					// Обновление Label'ов в MainWindow
					mainWindow.Dispatcher.Invoke(() =>
					{
						mainWindow.labelNZak1.Content = string.IsNullOrWhiteSpace(zakaz1.Text) ? "" : zakaz1.Text;
						mainWindow.labelNZak2.Content = string.IsNullOrWhiteSpace(zakaz2.Text) ? "" : zakaz2.Text;
						mainWindow.labelNZak3.Content = string.IsNullOrWhiteSpace(zakaz3.Text) ? "" : zakaz3.Text;
						mainWindow.labelNZak4.Content = string.IsNullOrWhiteSpace(zakaz4.Text) ? "" : zakaz4.Text;
					});

					// Вычисляем суммы
					decimal sASum = 0;
					decimal sBSum = 0;
					List<decimal> sAValues = new List<decimal>();
					List<decimal> sBValues = new List<decimal>();
					int countSAGreaterThanSB = 0;

					// Собираем данные и считаем, сколько раз S_A > S_B
					foreach (var row in rows)
					{
						if (!string.IsNullOrWhiteSpace(row.Item3.Text) && decimal.TryParse(row.Item3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ploshA))
						{
							sAValues.Add(ploshA);
						}
						if (!string.IsNullOrWhiteSpace(row.Item4.Text) && decimal.TryParse(row.Item4.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ploshB))
						{
							sBValues.Add(ploshB);
						}

						// Сравнение S_A и S_B для каждой строки
						if (!string.IsNullOrWhiteSpace(row.Item3.Text) && !string.IsNullOrWhiteSpace(row.Item4.Text))
						{
							if (decimal.TryParse(row.Item3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal a) &&
								decimal.TryParse(row.Item4.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal b))
							{
								if (a > b)
								{
									countSAGreaterThanSB++;
								}
							}
						}
					}

					// Вычисляем S_A_Sum и S_B_Sum в зависимости от условия
					if (countSAGreaterThanSB >= 3) // Если в 3 или 4 строках S_A > S_B
					{
						for (int i = 0; i < sAValues.Count && i < sBValues.Count; i++)
						{
							decimal maxValue = Math.Max(sAValues[i], sBValues[i]);
							decimal minValue = Math.Min(sAValues[i], sBValues[i]);
							sASum += maxValue; // Большие значения для S_A_Sum
							sBSum += minValue; // Меньшие значения для S_B_Sum
						}
					}
					else // По умолчанию
					{
						for (int i = 0; i < sAValues.Count && i < sBValues.Count; i++)
						{
							decimal minValue = Math.Min(sAValues[i], sBValues[i]);
							decimal maxValue = Math.Max(sAValues[i], sBValues[i]);
							sASum += minValue; // Меньшие значения для S_A_Sum
							sBSum += maxValue; // Большие значения для S_B_Sum
						}
					}

					// Проверка разницы между минимальным и максимальным значениями для S_A и S_B
					bool proceed = true;
					if (sAValues.Count > 1) // Проверяем, если есть хотя бы 2 значения для сравнения
					{
						var sortedSA = sAValues.OrderBy(x => x).ToList();
						if (sortedSA.Max() > sortedSA.Min() * 1.5m)
						{
							var result = MessageBox.Show("Площадь S_A больше чем в 1,5 раза! Вы уверены, что хотите продолжить?",
								"Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
							proceed = (result == MessageBoxResult.OK);
						}
					}
					if (proceed && sBValues.Count > 1) // Проверяем S_B только если продолжаем
					{
						var sortedSB = sBValues.OrderBy(x => x).ToList();
						if (sortedSB.Max() > sortedSB.Min() * 1.5m)
						{
							var result = MessageBox.Show("Площадь S_B больше чем в 1,5 раза! Вы уверены, что хотите продолжить?",
								"Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
							proceed = (result == MessageBoxResult.OK);
						}
					}

					// Если пользователь выбрал "Отмена", прерываем выполнение
					if (!proceed)
					{
						return;
					}

					// Подсчитываем количество заполненных строк
					int filledRowsCount = rows.Count(row => !string.IsNullOrWhiteSpace(row.Item1.Text));

					// Вставка данных в базу
					string insertQuery = @"INSERT INTO Galvan.dbo.Galvan_Jurnal 
    (N_Shtang, N_Vann, N_Zaves, N_Zakaz, Uslovie, S_A, S_B, S_A_Sum, S_B_Sum, FIO, Date, Comment) 
    VALUES (@N_Shtang, @N_Vann, @N_Zaves, @N_Zakaz, @Uslovie, @S_A, @S_B, @S_A_Sum, @S_B_Sum, @FIO, @Date, @Comment)";

					foreach (var row in rows)
					{
						if (!string.IsNullOrWhiteSpace(row.Item1.Text))
						{
							using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
							{
								cmd.Parameters.AddWithValue("@N_Shtang", N_Shtang.Text);
								cmd.Parameters.AddWithValue("@N_Vann", N_Vann.Text);
								cmd.Parameters.AddWithValue("@N_Zaves", newN_Zaves);

								string zakazValue = row.Item1 == zakaz4 && row.Item1.Text.Length > 12
									? row.Item1.Text.Substring(4, row.Item1.Text.Length - 7)
									: row.Item1.Text;
								cmd.Parameters.AddWithValue("@N_Zakaz", zakazValue);

								cmd.Parameters.AddWithValue("@Uslovie", row.Item2.Text);
								cmd.Parameters.AddWithValue("@S_A", row.Item3.Text);
								cmd.Parameters.AddWithValue("@S_B", row.Item4.Text);
								cmd.Parameters.AddWithValue("@S_A_Sum", sASum);
								cmd.Parameters.AddWithValue("@S_B_Sum", sBSum);
								cmd.Parameters.AddWithValue("@FIO", WC.fio);
								cmd.Parameters.AddWithValue("@Date", DateTime.Now);
								cmd.Parameters.AddWithValue("@Comment", Comment.Text);

								cmd.ExecuteNonQuery();
							}
						}
					}

					// Обновление изображения на форме MainWindow
					string imagePath = "";
					switch (filledRowsCount)
					{
						case 1:
							imagePath = "Images/img1.jpg";
							break;
						case 2:
							imagePath = "Images/img2.png";
							break;
						case 3:
							imagePath = "Images/img3.png";
							break;
						case 4:
							imagePath = "Images/img4.png";
							break;
					}

					if (!string.IsNullOrEmpty(imagePath) && mainWindow != null)
					{
						mainWindow.Dispatcher.Invoke(() =>
						{
							mainWindow.DisplayImage1.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
						});
					}
				}
				mainWindow.LoadData_Galvan_Jurnal();
				this.Close();
			}
		}













		//private void Dobav_New_Data(object sender, RoutedEventArgs e)
		//{
		//	if (N_Shtang.Text == "")
		//	{
		//		MessageBox.Show("Выберите номер штанги");
		//	}
		//	else if (N_Vann.Text == "")
		//	{
		//		MessageBox.Show("Выберите номер ванны");
		//	}
		//	else
		//	{
		//		using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
		//		{
		//			conn.Open();

		//			// Получаем максимальное значение N_Zaves и увеличиваем на 1
		//			int newN_Zaves = 1;
		//			string getMaxZavesQuery = "SELECT ISNULL(MAX(N_Zaves), 0) + 1 FROM Galvan.dbo.Galvan_Jurnal";
		//			using (SqlCommand getMaxCmd = new SqlCommand(getMaxZavesQuery, conn))
		//			{
		//				object result = getMaxCmd.ExecuteScalar();
		//				if (result != null)
		//				{
		//					newN_Zaves = Convert.ToInt32(result);
		//				}
		//			}

		//			// Список строк с данными
		//			List<Tuple<TextBox, TextBox, TextBox, TextBox>> rows = new List<Tuple<TextBox, TextBox, TextBox, TextBox>>
		//	{
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz1, Uslovie1, PloshA1, PloshB1),
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz2, Uslovie2, PloshA2, PloshB2),
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz3, Uslovie3, PloshA3, PloshB3),
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz4, Uslovie4, PloshA4, PloshB4)
		//	};

		//			// Вычисляем суммы
		//			decimal sASum = 0;
		//			decimal sBSum = 0;
		//			List<decimal> sAValues = new List<decimal>();
		//			List<decimal> sBValues = new List<decimal>();
		//			int countSAGreaterThanSB = 0;

		//			// Собираем данные и считаем, сколько раз S_A > S_B
		//			foreach (var row in rows)
		//			{
		//				if (!string.IsNullOrWhiteSpace(row.Item3.Text) && decimal.TryParse(row.Item3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ploshA))
		//				{
		//					sAValues.Add(ploshA);
		//				}
		//				if (!string.IsNullOrWhiteSpace(row.Item4.Text) && decimal.TryParse(row.Item4.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ploshB))
		//				{
		//					sBValues.Add(ploshB);
		//				}

		//				// Сравнение S_A и S_B для каждой строки
		//				if (!string.IsNullOrWhiteSpace(row.Item3.Text) && !string.IsNullOrWhiteSpace(row.Item4.Text))
		//				{
		//					if (decimal.TryParse(row.Item3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal a) &&
		//						decimal.TryParse(row.Item4.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal b))
		//					{
		//						if (a > b)
		//						{
		//							countSAGreaterThanSB++;
		//						}
		//					}
		//				}
		//			}

		//			// Вычисляем S_A_Sum и S_B_Sum в зависимости от условия
		//			if (countSAGreaterThanSB >= 3) // Если в 3 или 4 строках S_A > S_B
		//			{
		//				for (int i = 0; i < sAValues.Count && i < sBValues.Count; i++)
		//				{
		//					decimal maxValue = Math.Max(sAValues[i], sBValues[i]);
		//					decimal minValue = Math.Min(sAValues[i], sBValues[i]);
		//					sASum += maxValue; // Большие значения для S_A_Sum
		//					sBSum += minValue; // Меньшие значения для S_B_Sum
		//				}
		//			}
		//			else // По умолчанию
		//			{
		//				for (int i = 0; i < sAValues.Count && i < sBValues.Count; i++)
		//				{
		//					decimal minValue = Math.Min(sAValues[i], sBValues[i]);
		//					decimal maxValue = Math.Max(sAValues[i], sBValues[i]);
		//					sASum += minValue; // Меньшие значения для S_A_Sum
		//					sBSum += maxValue; // Большие значения для S_B_Sum
		//				}
		//			}

		//			// Проверка разницы между минимальным и максимальным значениями для S_A и S_B
		//			bool proceed = true;
		//			if (sAValues.Count > 1) // Проверяем, если есть хотя бы 2 значения для сравнения
		//			{
		//				var sortedSA = sAValues.OrderBy(x => x).ToList();
		//				if (sortedSA.Max() > sortedSA.Min() * 1.5m)
		//				{
		//					var result = MessageBox.Show("Площадь S_A больше чем в 1,5 раза! Вы уверены, что хотите продолжить?",
		//						"Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
		//					proceed = (result == MessageBoxResult.OK);
		//				}
		//			}
		//			if (proceed && sBValues.Count > 1) // Проверяем S_B только если продолжаем
		//			{
		//				var sortedSB = sBValues.OrderBy(x => x).ToList();
		//				if (sortedSB.Max() > sortedSB.Min() * 1.5m)
		//				{
		//					var result = MessageBox.Show("Площадь S_B больше чем в 1,5 раза! Вы уверены, что хотите продолжить?",
		//						"Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
		//					proceed = (result == MessageBoxResult.OK);
		//				}
		//			}

		//			// Если пользователь выбрал "Отмена", прерываем выполнение
		//			if (!proceed)
		//			{
		//				return;
		//			}

		//			// Подсчитываем количество заполненных строк
		//			int filledRowsCount = rows.Count(row => !string.IsNullOrWhiteSpace(row.Item1.Text));

		//			// Вставка данных в базу
		//			string insertQuery = @"INSERT INTO Galvan.dbo.Galvan_Jurnal 
		//          (N_Shtang, N_Vann, N_Zaves, N_Zakaz, Uslovie, S_A, S_B, S_A_Sum, S_B_Sum, FIO, Date, Comment) 
		//          VALUES (@N_Shtang, @N_Vann, @N_Zaves, @N_Zakaz, @Uslovie, @S_A, @S_B, @S_A_Sum, @S_B_Sum, @FIO, @Date, @Comment)";

		//			foreach (var row in rows)
		//			{
		//				if (!string.IsNullOrWhiteSpace(row.Item1.Text))
		//				{
		//					using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
		//					{
		//						cmd.Parameters.AddWithValue("@N_Shtang", N_Shtang.Text);
		//						cmd.Parameters.AddWithValue("@N_Vann", N_Vann.Text);
		//						cmd.Parameters.AddWithValue("@N_Zaves", newN_Zaves);

		//						string zakazValue = row.Item1 == zakaz4 && row.Item1.Text.Length > 12
		//							? row.Item1.Text.Substring(4, row.Item1.Text.Length - 7)
		//							: row.Item1.Text;
		//						cmd.Parameters.AddWithValue("@N_Zakaz", zakazValue);

		//						cmd.Parameters.AddWithValue("@Uslovie", row.Item2.Text);
		//						cmd.Parameters.AddWithValue("@S_A", row.Item3.Text);
		//						cmd.Parameters.AddWithValue("@S_B", row.Item4.Text);
		//						cmd.Parameters.AddWithValue("@S_A_Sum", sASum);
		//						cmd.Parameters.AddWithValue("@S_B_Sum", sBSum);
		//						cmd.Parameters.AddWithValue("@FIO", WC.fio);
		//						cmd.Parameters.AddWithValue("@Date", DateTime.Now);
		//						cmd.Parameters.AddWithValue("@Comment", Comment.Text);

		//						cmd.ExecuteNonQuery();
		//					}
		//				}
		//			}

		//			// Обновление изображения на форме MainWindow
		//			string imagePath = "";
		//			switch (filledRowsCount)
		//			{
		//				case 1:
		//					imagePath = "Images/img1.jpg";
		//					break;
		//				case 2:
		//					imagePath = "Images/img2.png";
		//					break;
		//				case 3:
		//					imagePath = "Images/img3.png";
		//					break;
		//				case 4:
		//					imagePath = "Images/img4.png";
		//					break;
		//			}

		//			if (!string.IsNullOrEmpty(imagePath) && mainWindow != null)
		//			{
		//				mainWindow.Dispatcher.Invoke(() =>
		//				{
		//					mainWindow.DisplayImage1.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
		//				});
		//			}
		//		}
		//		mainWindow.LoadData_Galvan_Jurnal();
		//		this.Close();
		//	}
		//}










		//	private void Dobav_New_Data(object sender, RoutedEventArgs e)
		//	{
		//		if (N_Shtang.Text == "")
		//		{
		//			MessageBox.Show("Выберите номер штанги");
		//		}
		//		else if (N_Vann.Text == "")
		//		{
		//			MessageBox.Show("Выберите номер ванны");
		//		}
		//		else
		//		{
		//			using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
		//			{
		//				conn.Open();

		//				// Получаем максимальное значение N_Zaves и увеличиваем на 1
		//				int newN_Zaves = 1;
		//				string getMaxZavesQuery = "SELECT ISNULL(MAX(N_Zaves), 0) + 1 FROM Galvan.dbo.Galvan_Jurnal";
		//				using (SqlCommand getMaxCmd = new SqlCommand(getMaxZavesQuery, conn))
		//				{
		//					object result = getMaxCmd.ExecuteScalar();
		//					if (result != null)
		//					{
		//						newN_Zaves = Convert.ToInt32(result);
		//					}
		//				}

		//				// Список строк с данными
		//				List<Tuple<TextBox, TextBox, TextBox, TextBox>> rows = new List<Tuple<TextBox, TextBox, TextBox, TextBox>>
		//		{
		//			new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz1, Uslovie1, PloshA1, PloshB1),
		//			new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz2, Uslovie2, PloshA2, PloshB2),
		//			new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz3, Uslovie3, PloshA3, PloshB3),
		//			new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz4, Uslovie4, PloshA4, PloshB4)
		//		};

		//				// Вычисляем суммы
		//				decimal sASum = 0;
		//				decimal sBSum = 0;
		//				List<decimal> sAValues = new List<decimal>();
		//				List<decimal> sBValues = new List<decimal>();
		//				int countSAGreaterThanSB = 0;

		//				// Собираем данные и считаем, сколько раз S_A > S_B
		//				foreach (var row in rows)
		//				{
		//					if (!string.IsNullOrWhiteSpace(row.Item3.Text) && decimal.TryParse(row.Item3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ploshA))
		//					{
		//						sAValues.Add(ploshA);
		//					}
		//					if (!string.IsNullOrWhiteSpace(row.Item4.Text) && decimal.TryParse(row.Item4.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ploshB))
		//					{
		//						sBValues.Add(ploshB);
		//					}

		//					// Сравнение S_A и S_B для каждой строки
		//					if (!string.IsNullOrWhiteSpace(row.Item3.Text) && !string.IsNullOrWhiteSpace(row.Item4.Text))
		//					{
		//						if (decimal.TryParse(row.Item3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal a) &&
		//							decimal.TryParse(row.Item4.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal b))
		//						{
		//							if (a > b)
		//							{
		//								countSAGreaterThanSB++;
		//							}
		//						}
		//					}
		//				}

		//				// Вычисляем S_A_Sum и S_B_Sum в зависимости от условия
		//				if (countSAGreaterThanSB >= 3) // Если в 3 или 4 строках S_A > S_B
		//				{
		//					for (int i = 0; i < sAValues.Count && i < sBValues.Count; i++)
		//					{
		//						decimal maxValue = Math.Max(sAValues[i], sBValues[i]);
		//						decimal minValue = Math.Min(sAValues[i], sBValues[i]);
		//						sASum += maxValue; // Большие значения для S_A_Sum
		//						sBSum += minValue; // Меньшие значения для S_B_Sum
		//					}
		//				}
		//				else // По умолчанию
		//				{
		//					for (int i = 0; i < sAValues.Count && i < sBValues.Count; i++)
		//					{
		//						decimal minValue = Math.Min(sAValues[i], sBValues[i]);
		//						decimal maxValue = Math.Max(sAValues[i], sBValues[i]);
		//						sASum += minValue; // Меньшие значения для S_A_Sum
		//						sBSum += maxValue; // Большие значения для S_B_Sum
		//					}
		//				}

		//				// Проверка разницы между минимальным и максимальным значениями для S_A и S_B
		//				bool proceed = true;
		//				if (sAValues.Count > 1) // Проверяем, если есть хотя бы 2 значения для сравнения
		//				{
		//					var sortedSA = sAValues.OrderBy(x => x).ToList();
		//					if (sortedSA.Max() > sortedSA.Min() * 1.5m)
		//					{
		//						var result = MessageBox.Show("Площадь S_A больше чем в 1,5 раза! Вы уверены, что хотите продолжить?",
		//							"Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
		//						proceed = (result == MessageBoxResult.OK);
		//					}
		//				}
		//				if (proceed && sBValues.Count > 1) // Проверяем S_B только если продолжаем
		//				{
		//					var sortedSB = sBValues.OrderBy(x => x).ToList();
		//					if (sortedSB.Max() > sortedSB.Min() * 1.5m)
		//					{
		//						var result = MessageBox.Show("Площадь S_B больше чем в 1,5 раза! Вы уверены, что хотите продолжить?",
		//							"Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
		//						proceed = (result == MessageBoxResult.OK);
		//					}
		//				}

		//				// Если пользователь выбрал "Отмена", прерываем выполнение
		//				if (!proceed)
		//				{
		//					return;
		//				}

		//				// Вставка данных в базу
		//				string insertQuery = @"INSERT INTO Galvan.dbo.Galvan_Jurnal 
		//               (N_Shtang, N_Vann, N_Zaves, N_Zakaz, Uslovie, S_A, S_B, S_A_Sum, S_B_Sum, FIO, Date, Comment) 
		//               VALUES (@N_Shtang, @N_Vann, @N_Zaves, @N_Zakaz, @Uslovie, @S_A, @S_B, @S_A_Sum, @S_B_Sum, @FIO, @Date, @Comment)";

		//				foreach (var row in rows)
		//				{
		//					if (!string.IsNullOrWhiteSpace(row.Item1.Text))
		//					{
		//						using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
		//						{
		//							cmd.Parameters.AddWithValue("@N_Shtang", N_Shtang.Text);
		//							cmd.Parameters.AddWithValue("@N_Vann", N_Vann.Text);
		//							cmd.Parameters.AddWithValue("@N_Zaves", newN_Zaves);

		//							string zakazValue = row.Item1 == zakaz4 && row.Item1.Text.Length > 12
		//? row.Item1.Text.Substring(4, row.Item1.Text.Length - 7)
		//: row.Item1.Text;
		//							cmd.Parameters.AddWithValue("@N_Zakaz", zakazValue);

		//							//cmd.Parameters.AddWithValue("@N_Zakaz", row.Item1.Text);
		//							cmd.Parameters.AddWithValue("@Uslovie", row.Item2.Text);
		//							cmd.Parameters.AddWithValue("@S_A", row.Item3.Text); // Оставляем оригинальное значение из TextBox
		//							cmd.Parameters.AddWithValue("@S_B", row.Item4.Text); // Оставляем оригинальное значение из TextBox
		//							cmd.Parameters.AddWithValue("@S_A_Sum", sASum);
		//							cmd.Parameters.AddWithValue("@S_B_Sum", sBSum);
		//							cmd.Parameters.AddWithValue("@FIO", WC.fio);
		//							cmd.Parameters.AddWithValue("@Date", DateTime.Now);
		//							cmd.Parameters.AddWithValue("@Comment", Comment.Text);

		//							cmd.ExecuteNonQuery();
		//						}
		//					}
		//				}
		//			}
		//			mainWindow.LoadData_Galvan_Jurnal();
		//			this.Close();
		//		}
		//	}


		//private void Dobav_New_Data(object sender, RoutedEventArgs e)
		//{
		//	if (N_Shtang.Text == "")
		//	{
		//		MessageBox.Show("Выберите номер штанги");
		//	}
		//	else if (N_Vann.Text == "")
		//	{
		//		MessageBox.Show("Выберите номер ванны");
		//	}
		//	else
		//	{
		//		using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
		//		{
		//			conn.Open();

		//			// Получаем максимальное значение N_Zaves и увеличиваем на 1
		//			int newN_Zaves = 1;
		//			string getMaxZavesQuery = "SELECT ISNULL(MAX(N_Zaves), 0) + 1 FROM Galvan.dbo.Galvan_Jurnal";
		//			using (SqlCommand getMaxCmd = new SqlCommand(getMaxZavesQuery, conn))
		//			{
		//				object result = getMaxCmd.ExecuteScalar();
		//				if (result != null)
		//				{
		//					newN_Zaves = Convert.ToInt32(result);
		//				}
		//			}

		//			// Список строк с данными
		//			List<Tuple<TextBox, TextBox, TextBox, TextBox>> rows = new List<Tuple<TextBox, TextBox, TextBox, TextBox>>
		//	{
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz1, Uslovie1, PloshA1, PloshB1),
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz2, Uslovie2, PloshA2, PloshB2),
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz3, Uslovie3, PloshA3, PloshB3),
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz4, Uslovie4, PloshA4, PloshB4)
		//	};

		//			// Вычисляем суммы
		//			decimal sASum = 0;
		//			decimal sBSum = 0;
		//			List<decimal> sAValues = new List<decimal>();
		//			List<decimal> sBValues = new List<decimal>();
		//			int countSAGreaterThanSB = 0;

		//			// Собираем данные и считаем, сколько раз S_A > S_B
		//			foreach (var row in rows)
		//			{
		//				if (!string.IsNullOrWhiteSpace(row.Item3.Text) && decimal.TryParse(row.Item3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ploshA))
		//				{
		//					sAValues.Add(ploshA);
		//				}
		//				if (!string.IsNullOrWhiteSpace(row.Item4.Text) && decimal.TryParse(row.Item4.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ploshB))
		//				{
		//					sBValues.Add(ploshB);
		//				}

		//				// Сравнение S_A и S_B для каждой строки
		//				if (!string.IsNullOrWhiteSpace(row.Item3.Text) && !string.IsNullOrWhiteSpace(row.Item4.Text))
		//				{
		//					if (decimal.TryParse(row.Item3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal a) &&
		//						decimal.TryParse(row.Item4.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal b))
		//					{
		//						if (a > b)
		//						{
		//							countSAGreaterThanSB++;
		//						}
		//					}
		//				}
		//			}

		//			// Вычисляем S_A_Sum и S_B_Sum в зависимости от условия
		//			List<decimal> distributedSA = new List<decimal>();
		//			List<decimal> distributedSB = new List<decimal>();

		//			if (countSAGreaterThanSB >= 3) // Если в 3 или 4 строках S_A > S_B
		//			{
		//				for (int i = 0; i < sAValues.Count && i < sBValues.Count; i++)
		//				{
		//					decimal maxValue = Math.Max(sAValues[i], sBValues[i]);
		//					decimal minValue = Math.Min(sAValues[i], sBValues[i]);
		//					sASum += maxValue; // Большие значения для S_A_Sum
		//					sBSum += minValue; // Меньшие значения для S_B_Sum
		//					distributedSA.Add(maxValue);
		//					distributedSB.Add(minValue);
		//				}
		//			}
		//			else // По умолчанию
		//			{
		//				for (int i = 0; i < sAValues.Count && i < sBValues.Count; i++)
		//				{
		//					decimal minValue = Math.Min(sAValues[i], sBValues[i]);
		//					decimal maxValue = Math.Max(sAValues[i], sBValues[i]);
		//					sASum += minValue; // Меньшие значения для S_A_Sum
		//					sBSum += maxValue; // Большие значения для S_B_Sum
		//					distributedSA.Add(minValue);
		//					distributedSB.Add(maxValue);
		//				}
		//			}

		//			// Проверка разницы между минимальным и максимальным значениями для распределенных S_A и S_B
		//			bool proceed = true;
		//			if (distributedSA.Count > 1) // Проверяем, если есть хотя бы 2 значения для сравнения
		//			{
		//				var sortedSA = distributedSA.OrderBy(x => x).ToList();
		//				if (sortedSA.Max() > sortedSA.Min() * 1.5m)
		//				{
		//					var result = MessageBox.Show("Площадь S_A больше чем в 1,5 раза! Вы уверены, что хотите продолжить?",
		//						"Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
		//					proceed = (result == MessageBoxResult.OK);
		//				}
		//			}
		//			if (proceed && distributedSB.Count > 1) // Проверяем S_B только если продолжаем
		//			{
		//				var sortedSB = distributedSB.OrderBy(x => x).ToList();
		//				if (sortedSB.Max() > sortedSB.Min() * 1.5m)
		//				{
		//					var result = MessageBox.Show("Площадь S_B больше чем в 1,5 раза! Вы уверены, что хотите продолжить?",
		//						"Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
		//					proceed = (result == MessageBoxResult.OK);
		//				}
		//			}

		//			// Если пользователь выбрал "Отмена", прерываем выполнение
		//			if (!proceed)
		//			{
		//				return;
		//			}

		//			// Вставка данных в базу
		//			string insertQuery = @"INSERT INTO Galvan.dbo.Galvan_Jurnal 
		//              (N_Shtang, N_Vann, N_Zaves, N_Zakaz, Uslovie, S_A, S_B, S_A_Sum, S_B_Sum, FIO, Date, Comment) 
		//              VALUES (@N_Shtang, @N_Vann, @N_Zaves, @N_Zakaz, @Uslovie, @S_A, @S_B, @S_A_Sum, @S_B_Sum, @FIO, @Date, @Comment)";

		//			int rowIndex = 0;
		//			foreach (var row in rows)
		//			{
		//				if (!string.IsNullOrWhiteSpace(row.Item1.Text))
		//				{
		//					using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
		//					{
		//						cmd.Parameters.AddWithValue("@N_Shtang", N_Shtang.Text);
		//						cmd.Parameters.AddWithValue("@N_Vann", N_Vann.Text);
		//						cmd.Parameters.AddWithValue("@N_Zaves", newN_Zaves);
		//						cmd.Parameters.AddWithValue("@N_Zakaz", row.Item1.Text);
		//						cmd.Parameters.AddWithValue("@Uslovie", row.Item2.Text);
		//						cmd.Parameters.AddWithValue("@S_A", distributedSA.Count > rowIndex ? distributedSA[rowIndex].ToString(CultureInfo.InvariantCulture) : row.Item3.Text);
		//						cmd.Parameters.AddWithValue("@S_B", distributedSB.Count > rowIndex ? distributedSB[rowIndex].ToString(CultureInfo.InvariantCulture) : row.Item4.Text);
		//						cmd.Parameters.AddWithValue("@S_A_Sum", sASum);
		//						cmd.Parameters.AddWithValue("@S_B_Sum", sBSum);
		//						cmd.Parameters.AddWithValue("@FIO", WC.fio);
		//						cmd.Parameters.AddWithValue("@Date", DateTime.Now);
		//						cmd.Parameters.AddWithValue("@Comment", Comment.Text);

		//						cmd.ExecuteNonQuery();
		//					}
		//					rowIndex++;
		//				}
		//			}
		//		}
		//		mainWindow.LoadData_Galvan_Jurnal();
		//		this.Close();
		//	}
		//}


		//private void Dobav_New_Data(object sender, RoutedEventArgs e)
		//{
		//	if (N_Shtang.Text == "")
		//	{
		//		MessageBox.Show("Выберите номер штанги");
		//	}
		//	else if (N_Vann.Text == "")
		//	{
		//		MessageBox.Show("Выберите номер ванны");
		//	}
		//	else
		//	{
		//		using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
		//		{
		//			conn.Open();

		//			// Получаем максимальное значение N_Zaves и увеличиваем на 1
		//			int newN_Zaves = 1;
		//			string getMaxZavesQuery = "SELECT ISNULL(MAX(N_Zaves), 0) + 1 FROM Galvan.dbo.Galvan_Jurnal";
		//			using (SqlCommand getMaxCmd = new SqlCommand(getMaxZavesQuery, conn))
		//			{
		//				object result = getMaxCmd.ExecuteScalar();
		//				if (result != null)
		//				{
		//					newN_Zaves = Convert.ToInt32(result);
		//				}
		//			}

		//			// Список строк с данными
		//			List<Tuple<TextBox, TextBox, TextBox, TextBox>> rows = new List<Tuple<TextBox, TextBox, TextBox, TextBox>>
		//	{
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz1, Uslovie1, PloshA1, PloshB1),
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz2, Uslovie2, PloshA2, PloshB2),
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz3, Uslovie3, PloshA3, PloshB3),
		//		new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz4, Uslovie4, PloshA4, PloshB4)
		//	};

		//			// Вычисляем суммы
		//			decimal sASum = 0;
		//			decimal sBSum = 0;

		//			foreach (var row in rows)
		//			{
		//				if (!string.IsNullOrWhiteSpace(row.Item3.Text))
		//				{
		//					if (decimal.TryParse(row.Item3.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ploshA))
		//					{
		//						sASum += ploshA;
		//					}
		//				}
		//				if (!string.IsNullOrWhiteSpace(row.Item4.Text))
		//				{
		//					if (decimal.TryParse(row.Item4.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal ploshB))
		//					{
		//						sBSum += ploshB;
		//					}
		//				}
		//			}

		//			string insertQuery = @"INSERT INTO Galvan.dbo.Galvan_Jurnal 
		//              (N_Shtang, N_Vann, N_Zaves, N_Zakaz, Uslovie, S_A, S_B, S_A_Sum, S_B_Sum, FIO, Date, Comment) 
		//              VALUES (@N_Shtang, @N_Vann, @N_Zaves, @N_Zakaz, @Uslovie, @S_A, @S_B, @S_A_Sum, @S_B_Sum, @FIO, @Date, @Comment)";

		//			foreach (var row in rows)
		//			{
		//				if (!string.IsNullOrWhiteSpace(row.Item1.Text))
		//				{
		//					using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
		//					{
		//						cmd.Parameters.AddWithValue("@N_Shtang", N_Shtang.Text);
		//						cmd.Parameters.AddWithValue("@N_Vann", N_Vann.Text);
		//						cmd.Parameters.AddWithValue("@N_Zaves", newN_Zaves);
		//						cmd.Parameters.AddWithValue("@N_Zakaz", row.Item1.Text);
		//						cmd.Parameters.AddWithValue("@Uslovie", row.Item2.Text);
		//						cmd.Parameters.AddWithValue("@S_A", row.Item3.Text);
		//						cmd.Parameters.AddWithValue("@S_B", row.Item4.Text);
		//						cmd.Parameters.AddWithValue("@S_A_Sum", sASum);
		//						cmd.Parameters.AddWithValue("@S_B_Sum", sBSum);

		//						cmd.Parameters.AddWithValue("@FIO", WC.fio);
		//						cmd.Parameters.AddWithValue("@Date", DateTime.Now);
		//						cmd.Parameters.AddWithValue("@Comment", Comment.Text);

		//						cmd.ExecuteNonQuery();
		//					}
		//				}
		//			}
		//		}
		//		mainWindow.LoadData_Galvan_Jurnal();
		//		this.Close();
		//	}
		//}




		//private void Dobav_New_Data(object sender, RoutedEventArgs e)
		//{
		//	if (N_Shtang.Text == "")
		//	{
		//		MessageBox.Show("Выберите номер штанги");
		//	}
		//	else if (N_Vann.Text == "")
		//	{
		//		MessageBox.Show("Выберите номер ванны");
		//	}
		//	else
		//	{
		//		using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
		//		{
		//			conn.Open();

		//			// Получаем максимальное значение N_Zaves и увеличиваем на 1
		//			int newN_Zaves = 1;
		//			string getMaxZavesQuery = "SELECT ISNULL(MAX(N_Zaves), 0) + 1 FROM Galvan.dbo.Galvan_Jurnal";
		//			using (SqlCommand getMaxCmd = new SqlCommand(getMaxZavesQuery, conn))
		//			{
		//				object result = getMaxCmd.ExecuteScalar();
		//				if (result != null)
		//				{
		//					newN_Zaves = Convert.ToInt32(result);
		//				}
		//			}

		//			string insertQuery = @"INSERT INTO Galvan.dbo.Galvan_Jurnal (N_Shtang, N_Vann, N_Zaves, N_Zakaz, Uslovie, S_A, S_B, Date, Comment) 
		//                            VALUES (@N_Shtang, @N_Vann, @N_Zaves, @N_Zakaz, @Uslovie, @S_A, @S_B, @Date, @Comment)";

		//			List<Tuple<TextBox, TextBox, TextBox, TextBox>> rows = new List<Tuple<TextBox, TextBox, TextBox, TextBox>>
		//{
		//	new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz1, Uslovie1, PloshA1, PloshB1),
		//	new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz2, Uslovie2, PloshA2, PloshB2),
		//	new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz3, Uslovie3, PloshA3, PloshB3),
		//	new Tuple<TextBox, TextBox, TextBox, TextBox>(zakaz4, Uslovie4, PloshA4, PloshB4)
		//};

		//			foreach (var row in rows)
		//			{
		//				if (!string.IsNullOrWhiteSpace(row.Item1.Text))
		//				{
		//					using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
		//					{
		//						cmd.Parameters.AddWithValue("@N_Shtang", N_Shtang.Text);
		//						cmd.Parameters.AddWithValue("@N_Vann", N_Vann.Text);
		//						cmd.Parameters.AddWithValue("@N_Zaves", newN_Zaves);
		//						cmd.Parameters.AddWithValue("@N_Zakaz", row.Item1.Text);
		//						cmd.Parameters.AddWithValue("@Uslovie", row.Item2.Text);
		//						cmd.Parameters.AddWithValue("@S_A", row.Item3.Text);
		//						cmd.Parameters.AddWithValue("@S_B", row.Item4.Text);
		//						cmd.Parameters.AddWithValue("@Date", DateTime.Now);
		//						cmd.Parameters.AddWithValue("@Comment", Comment.Text);

		//						cmd.ExecuteNonQuery();
		//						//newN_Zaves++; // Увеличиваем N_Zaves для следующей записи
		//					}
		//				}
		//			}
		//		}
		//		mainWindow.LoadData_Galvan_Jurnal();
		//		this.Close();
		//	}
		//}





		private void Uslovie_TextBox_Click(object sender, RoutedEventArgs e)
		{
			Uslovie_Window uslovieWindow = new Uslovie_Window();
			if (uslovieWindow.ShowDialog() == true)
			{
				if (sender is TextBox clickedTextBox && uslovieWindow.SelectedUslovia.Any())
				{
					clickedTextBox.Text = string.Join(", ", uslovieWindow.SelectedUslovia);
				}
			}
		}

		private void InitializeUslovieTextBoxes()
		{
			Uslovie1.PreviewMouseDown += Uslovie_TextBox_Click;
			Uslovie2.PreviewMouseDown += Uslovie_TextBox_Click;
			Uslovie3.PreviewMouseDown += Uslovie_TextBox_Click;
			Uslovie4.PreviewMouseDown += Uslovie_TextBox_Click;
		}

		
	}
}
