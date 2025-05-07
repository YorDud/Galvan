using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using static MaterialDesignThemes.Wpf.Theme;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;
using Prog3.MiniWindows;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;

namespace Prog3
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{


		
			private DataTable dataTable; // Сделаем поле класса для доступа к DataTable

			public MainWindow()
			{
				InitializeComponent();
				LoadData_Galvan_Jurnal(); // Загружаем данные при инициализации окна

			LabelFIO.Content = WC.fio;
			}

		//public void LoadData_Galvan_Jurnal()
		//{
		//	using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//	{
		//		string query = @"
		//             SELECT [ID], [N_Shtang], [N_Vann], [N_Zaves], [N_Zakaz], [Uslovie], 
		//                    [S_A], [S_B], [S_A_Sum], [S_B_Sum], [I_A_Sn], [I_B_Sn], 
		//                    [I_A_Cu], [I_B_Cu], [Zanos_v_BD], [Zagruz_v_Line], [Exit_s_Line], 
		//                    [Date], [FIO], [Comment]
		//             FROM [Galvan].[dbo].[Galvan_Jurnal]
		//             ORDER BY [ID] DESC";

		//		SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
		//		dataTable = new DataTable();

		//		try
		//		{
		//			connection.Open();
		//			adapter.Fill(dataTable);

		//			// Преобразуем значения bit в bool
		//			foreach (DataRow row in dataTable.Rows)
		//			{
		//				row["Zanos_v_BD"] = row["Zanos_v_BD"] == DBNull.Value ? false : Convert.ToInt32(row["Zanos_v_BD"]) == 1;
		//				row["Zagruz_v_Line"] = row["Zagruz_v_Line"] == DBNull.Value ? false : Convert.ToInt32(row["Zagruz_v_Line"]) == 1;
		//				row["Exit_s_Line"] = row["Exit_s_Line"] == DBNull.Value ? false : Convert.ToInt32(row["Exit_s_Line"]) == 1;
		//			}

		//			// Подписываемся на изменения
		//			dataTable.RowChanged += DataTable_RowChanged;
		//		}
		//		catch (Exception ex)
		//		{
		//			MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		//		}
		//		finally
		//		{
		//			connection.Close();
		//		}

		//		dataGridMonitorJurnal.ItemsSource = dataTable.DefaultView;
		//	}
		//}
		public void LoadData_Galvan_Jurnal()
		{
			using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
			{
				string query = @"
    SELECT [ID], [N_Shtang], [N_Vann], [N_Zaves], [N_Zakaz], [Uslovie], 
           [S_A], [S_B], [S_A_Sum], [S_B_Sum], [I_A_Sn], [I_B_Sn], 
           [I_A_Cu], [I_B_Cu], [Zanos_v_BD], [Zagruz_v_Line], [Exit_s_Line], 
           [Date], [FIO], [Comment] 
    FROM [Galvan].[dbo].[Galvan_Jurnal]
    ORDER BY [ID] DESC";

				SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
				dataTable = new DataTable();

				try
				{
					connection.Open();
					adapter.Fill(dataTable);

					// Преобразуем значения bit в bool
					foreach (DataRow row in dataTable.Rows)
					{
						row["Zanos_v_BD"] = row["Zanos_v_BD"] == DBNull.Value ? false : Convert.ToInt32(row["Zanos_v_BD"]) == 1;
						row["Zagruz_v_Line"] = row["Zagruz_v_Line"] == DBNull.Value ? false : Convert.ToInt32(row["Zagruz_v_Line"]) == 1;
						row["Exit_s_Line"] = row["Exit_s_Line"] == DBNull.Value ? false : Convert.ToInt32(row["Exit_s_Line"]) == 1;
					}

					// Подписываемся на изменения
					dataTable.RowChanged += DataTable_RowChanged;

					// Устанавливаем источник данных
					dataGridMonitorJurnal.ItemsSource = dataTable.DefaultView;

					// Добавляем обработчик для раскраски строк
					dataGridMonitorJurnal.LoadingRow += DataGridMonitorJurnal_LoadingRow;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				finally
				{
					connection.Close();
				}
			}
		}

		private void DataGridMonitorJurnal_LoadingRow(object sender, DataGridRowEventArgs e)
		{
			var row = e.Row;
			var dataRowView = row.Item as DataRowView;

			if (dataRowView != null)
			{
				// Получаем значение N_Zaves
				if (int.TryParse(dataRowView["N_Zaves"]?.ToString(), out int nZaves))
				{
					// Определяем цвет в зависимости от четности/нечетности N_Zaves
					row.Background = nZaves % 2 == 0
						? new SolidColorBrush(Color.FromRgb(213, 235, 242))  // Светло-голубой для четных
						: new SolidColorBrush(Color.FromRgb(255, 213, 238)); // Светло-розовый для нечетных
				}
			}
		}


		private void DataTable_RowChanged(object sender, DataRowChangeEventArgs e)
			{
				if (e.Action == DataRowAction.Change && e.Row.RowState != DataRowState.Detached && e.Row["N_Zaves"] != DBNull.Value)
				{
					try
					{
						int nZaves = Convert.ToInt32(e.Row["N_Zaves"]);
						UpdateDatabase(nZaves, new Dictionary<string, bool>
				{
					{ "Zanos_v_BD", Convert.ToBoolean(e.Row["Zanos_v_BD"]) },
					{ "Zagruz_v_Line", Convert.ToBoolean(e.Row["Zagruz_v_Line"]) },
					{ "Exit_s_Line", Convert.ToBoolean(e.Row["Exit_s_Line"]) }
				});
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Ошибка при обновлении строки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
			}

		private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			DependencyObject dep = (DependencyObject)e.OriginalSource;
			while (dep != null && !(dep is DataGridCell))
			{
				dep = VisualTreeHelper.GetParent(dep);
			}

			if (dep is DataGridCell cell)
			{
				DataGridColumn column = cell.Column;
				if (column != null && dataGridMonitorJurnal.SelectedItem is DataRowView selectedRow)
				{
					string columnName = null;
					if (column.Header.ToString() == "Занесение в базу")
					{
						columnName = "Zanos_v_BD";
					}
					else if (column.Header.ToString() == "Загружен на линию")
					{
						columnName = "Zagruz_v_Line";
					}
					else if (column.Header.ToString() == "Выход с линии")
					{
						columnName = "Exit_s_Line";
					}

					if (columnName != null && selectedRow["N_Zaves"] != DBNull.Value)
					{
						if (!int.TryParse(selectedRow["N_Zaves"].ToString(), out int selectedN_Zaves))
						{
							MessageBox.Show("Ошибка приведения N_Zaves!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
							return;
						}

						bool currentValue = Convert.ToBoolean(selectedRow[columnName]);

						// Если текущее значение уже true, не разрешаем его менять
						if (currentValue)
						{
							//MessageBox.Show("Снятие галочки запрещено!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
							return;
						}

						// Если значение false, разрешаем установить true
						bool newValue = true;

						// Отключаем обработчик RowChanged на время массового обновления
						dataTable.RowChanged -= DataTable_RowChanged;

						try
						{
							// Обновляем все строки в DataTable с этим N_Zaves
							foreach (DataRow row in dataTable.Rows)
							{
								if (row["N_Zaves"] != DBNull.Value && Convert.ToInt32(row["N_Zaves"]) == selectedN_Zaves)
								{
									// Устанавливаем true только если текущего значения false
									if (!Convert.ToBoolean(row[columnName]))
									{
										row[columnName] = newValue;
									}
								}
							}

							// Обновляем базу данных одним запросом
							UpdateDatabase(selectedN_Zaves, new Dictionary<string, bool> { { columnName, newValue } });
						}
						finally
						{
							// Восстанавливаем обработчик
							dataTable.RowChanged += DataTable_RowChanged;
						}

						// UI обновится автоматически через привязку данных
						dataGridMonitorJurnal.Items.Refresh();
					}
				}
			}
		}

		private void UpdateDatabase(int nZaves, Dictionary<string, bool> updates)
			{
				using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
				{
					try
					{
						conn.Open();
						string setClause = string.Join(", ", updates.Select(u => $"{u.Key} = @{u.Key}"));
						string updateQuery = $"UPDATE Galvan.dbo.Galvan_Jurnal SET {setClause} WHERE N_Zaves = @N_Zaves";

						using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
						{
							foreach (var update in updates)
							{
								cmd.Parameters.AddWithValue($"@{update.Key}", update.Value ? 1 : 0);
							}
							cmd.Parameters.AddWithValue("@N_Zaves", nZaves);
							int rowsAffected = cmd.ExecuteNonQuery();
							if (rowsAffected == 0)
							{
								MessageBox.Show($"Не найдены записи для N_Zaves = {nZaves}.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Ошибка обновления базы данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
						throw;
					}
				}
			}

















		//public MainWindow()
		//{
		//	InitializeComponent();
		//	LoadData_Galvan_Jurnal(); // Загружаем данные при инициализации окна
		//}

		//public void LoadData_Galvan_Jurnal()
		//{
		//	using (SqlConnection connection = new SqlConnection(WC.ConnectionString))
		//	{
		//		string query = @"
		//          SELECT [ID]
		//                 ,[N_Shtang]
		//                 ,[N_Vann]
		//                 ,[N_Zaves]
		//                 ,[N_Zakaz]
		//                 ,[Uslovie]
		//                 ,[S_A]
		//                 ,[S_B]
		//                 ,[S_A_Sum]
		//                 ,[S_B_Sum]
		//                 ,[I_A_Sn]
		//                 ,[I_B_Sn]
		//                 ,[I_A_Cu]
		//                 ,[I_B_Cu]
		//                 ,[Zanos_v_BD]
		//                 ,[Zagruz_v_Line]
		//                 ,[Exit_s_Line]
		//                 ,[Date]
		//                 ,[FIO]
		//                 ,[Comment]
		//          FROM [Galvan].[dbo].[Galvan_Jurnal]
		//          ORDER BY [ID] DESC";

		//		SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
		//		DataTable dataTable = new DataTable();

		//		try
		//		{
		//			connection.Open();
		//			adapter.Fill(dataTable);

		//			// Преобразуем значения bit в bool для всех трёх столбцов
		//			foreach (DataRow row in dataTable.Rows)
		//			{
		//				row["Zanos_v_BD"] = row["Zanos_v_BD"] == DBNull.Value ? false : Convert.ToInt32(row["Zanos_v_BD"]) == 1;
		//				row["Zagruz_v_Line"] = row["Zagruz_v_Line"] == DBNull.Value ? false : Convert.ToInt32(row["Zagruz_v_Line"]) == 1;
		//				row["Exit_s_Line"] = row["Exit_s_Line"] == DBNull.Value ? false : Convert.ToInt32(row["Exit_s_Line"]) == 1;
		//			}

		//			// Подписываемся на изменения в DataTable
		//			dataTable.RowChanged += DataTable_RowChanged;
		//		}
		//		catch (Exception ex)
		//		{
		//			MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		//		}
		//		finally
		//		{
		//			connection.Close();
		//		}

		//		dataGridMonitorJurnal.ItemsSource = dataTable.DefaultView;
		//		Dispatcher.InvokeAsync(() => RefreshDataGridVisuals(), DispatcherPriority.Loaded);
		//	}
		//}

		//private void DataTable_RowChanged(object sender, DataRowChangeEventArgs e)
		//{
		//	if (e.Action == DataRowAction.Change && e.Row.RowState != DataRowState.Detached && e.Row["N_Zaves"] != DBNull.Value)
		//	{
		//		try
		//		{
		//			int nZaves = Convert.ToInt32(e.Row["N_Zaves"]);

		//			// Обновляем все три столбца в базе данных
		//			UpdateDatabase(nZaves, "Zanos_v_BD", Convert.ToBoolean(e.Row["Zanos_v_BD"]));
		//			UpdateDatabase(nZaves, "Zagruz_v_Line", Convert.ToBoolean(e.Row["Zagruz_v_Line"]));
		//			UpdateDatabase(nZaves, "Exit_s_Line", Convert.ToBoolean(e.Row["Exit_s_Line"]));

		//			// Обновляем визуальное отображение
		//			Dispatcher.Invoke(() => RefreshDataGridVisuals());
		//		}
		//		catch (Exception ex)
		//		{
		//			MessageBox.Show($"Ошибка при обновлении строки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		//		}
		//	}
		//}

		//private void RefreshDataGridVisuals()
		//{
		//	foreach (var item in dataGridMonitorJurnal.Items)
		//	{
		//		DataGridRow row = (DataGridRow)dataGridMonitorJurnal.ItemContainerGenerator.ContainerFromItem(item);
		//		if (row != null)
		//		{
		//			row.InvalidateVisual();
		//		}
		//	}
		//}

		//private void DataGridMonitorJurnal_Loaded(object sender, RoutedEventArgs e)
		//{
		//	// Ничего не делаем, если уже загрузили в конструкторе
		//}

		//private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		//{
		//	// Получаем элемент, по которому кликнули
		//	DependencyObject dep = (DependencyObject)e.OriginalSource;

		//	// Находим ближайшую ячейку DataGridCell
		//	while (dep != null && !(dep is DataGridCell))
		//	{
		//		dep = VisualTreeHelper.GetParent(dep);
		//	}

		//	if (dep is DataGridCell cell)
		//	{
		//		// Получаем столбец, к которому относится ячейка
		//		DataGridColumn column = DataGridColumnHeader.GetColumnFromChild(cell);
		//		if (column != null)
		//		{
		//			// Определяем имя столбца в базе данных по заголовку
		//			string columnName = null;
		//			if (column.Header.ToString() == "Занесение в базу")
		//				columnName = "Zanos_v_BD";
		//			else if (column.Header.ToString() == "Загружен на линию")
		//				columnName = "Zagruz_v_Line";
		//			else if (column.Header.ToString() == "Выход с линии")
		//				columnName = "Exit_s_Line";

		//			// Если кликнули по одному из нужных столбцов
		//			if (columnName != null && dataGridMonitorJurnal.SelectedItem is DataRowView selectedRow)
		//			{
		//				if (selectedRow["N_Zaves"] == DBNull.Value) return;

		//				if (!int.TryParse(selectedRow["N_Zaves"].ToString(), out int selectedN_Zaves))
		//				{
		//					MessageBox.Show("Ошибка приведения N_Zaves!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		//					return;
		//				}

		//				// Получаем текущее значение столбца и инвертируем его
		//				bool newValue = !Convert.ToBoolean(selectedRow[columnName]);

		//				// Обновляем значение в DataTable (это вызовет RowChanged)
		//				selectedRow[columnName] = newValue;
		//			}
		//		}
		//	}
		//}

		//public static class DataGridColumnHeader
		//{
		//	public static DataGridColumn GetColumnFromChild(DependencyObject child)
		//	{
		//		while (child != null && !(child is DataGridCell))
		//		{
		//			child = VisualTreeHelper.GetParent(child);
		//		}

		//		if (child is DataGridCell cell)
		//		{
		//			return cell.Column;
		//		}
		//		return null;
		//	}
		//}

		//private void UpdateDatabase(int nZaves, string columnName, bool isChecked)
		//{
		//	using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
		//	{
		//		try
		//		{
		//			conn.Open();
		//			string updateQuery = $"UPDATE Galvan.dbo.Galvan_Jurnal SET {columnName} = @Value WHERE N_Zaves = @N_Zaves";
		//			using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
		//			{
		//				cmd.Parameters.AddWithValue("@Value", isChecked ? 1 : 0);
		//				cmd.Parameters.AddWithValue("@N_Zaves", nZaves);
		//				int rowsAffected = cmd.ExecuteNonQuery();
		//				if (rowsAffected == 0)
		//				{
		//					MessageBox.Show($"Не удалось обновить {columnName} для N_Zaves = {nZaves}. Запись не найдена.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			MessageBox.Show($"Ошибка обновления базы данных ({columnName}): {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		//			throw; // Повторно выбрасываем исключение, чтобы внешний обработчик мог среагировать
		//		}
		//	}
		//}



		//private void RefreshDataGridVisuals()
		//	{
		//		foreach (var item in dataGridMonitorJurnal.Items)
		//		{
		//			DataGridRow row = (DataGridRow)dataGridMonitorJurnal.ItemContainerGenerator.ContainerFromItem(item);
		//			if (row != null)
		//			{
		//				// Заставляем WPF обновить триггеры
		//				row.InvalidateVisual();
		//			}
		//		}
		//	}




		//private void DataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		//{
		//	// Получаем элемент, по которому кликнули
		//	DependencyObject dep = (DependencyObject)e.OriginalSource;

		//	// Находим ближайшую ячейку DataGridCell
		//	while (dep != null && !(dep is DataGridCell))
		//	{
		//		dep = VisualTreeHelper.GetParent(dep);
		//	}

		//	if (dep is DataGridCell cell)
		//	{
		//		// Получаем столбец, к которому относится ячейка
		//		DataGridColumn column = DataGridColumnHeader.GetColumnFromChild(cell);
		//		if (column != null && column.Header.ToString() == "Занесение в базу")
		//		{
		//			// Это нужный столбец, выполняем логику
		//			if (dataGridMonitorJurnal.SelectedItem is DataRowView selectedRow)
		//			{
		//				if (selectedRow["N_Zaves"] == DBNull.Value) return;

		//				if (!int.TryParse(selectedRow["N_Zaves"].ToString(), out int selectedN_Zaves))
		//				{
		//					MessageBox.Show("Ошибка приведения N_Zaves!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
		//					return;
		//				}

		//				if (bool.TryParse(selectedRow["Zanos_v_BD"].ToString(), out bool isChecked) && isChecked)
		//				{
		//					return; // Уже отмечено, ничего не делаем
		//				}

		//				foreach (DataRowView row in dataGridMonitorJurnal.Items)
		//				{
		//					if (row["N_Zaves"] != DBNull.Value && int.TryParse(row["N_Zaves"].ToString(), out int rowN_Zaves) && rowN_Zaves == selectedN_Zaves)
		//					{
		//						row["Zanos_v_BD"] = true;
		//					}
		//				}

		//				UpdateDatabase(selectedN_Zaves, true);
		//				RefreshDataGridVisuals();
		//			}
		//		}
		//	}
		//	// Если клик не по нужному столбцу, ничего не делаем
		//}


		//private void UpdateDatabase(int nZaves, bool isChecked)
		//	{
		//		using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
		//		{
		//			conn.Open();
		//			string updateQuery = "UPDATE Galvan.dbo.Galvan_Jurnal SET Zanos_v_BD = @Zanos_v_BD WHERE N_Zaves = @N_Zaves";

		//			using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
		//			{
		//				cmd.Parameters.AddWithValue("@Zanos_v_BD", isChecked ? 1 : 0);
		//				cmd.Parameters.AddWithValue("@N_Zaves", nZaves);
		//				cmd.ExecuteNonQuery();
		//			}
		//		}
		//	}




































		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
			Application.Current.Shutdown();
		}




		private void NextButton_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			

		}

		private void View_Visual_Click(object sender, RoutedEventArgs e)
		{

		}

		private void New_Data_Click(object sender, RoutedEventArgs e)
		{
			MiniWindows.New_Data new_Data = new MiniWindows.New_Data(this);
			new_Data.ShowDialog();

		}

		private void DataGridMonitorJurnal_Loaded(object sender, RoutedEventArgs e)
		{

		}

		//private void DataGridMonitorJurnal_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		//{
		//	// Проверяем, что клик был по ячейке
		//	var originalSender = e.OriginalSource as DependencyObject;
		//	if (originalSender == null) return;

		//	// Находим ячейку DataGrid
		//	var cell = originalSender.FindAncestor<DataGridCell>();
		//	if (cell == null) return;

		//	// Проверяем, что клик был по столбцу Comment
		//	if (cell.Column.Header.ToString() == "Комментарий")
		//	{
		//		// Получаем выбранную строку
		//		var selectedItem = dataGridMonitorJurnal.SelectedItem;
		//		if (selectedItem == null) return;

		//		// Предполагаем, что у вас есть класс модели данных, например JournalEntry
		//		var journalEntry = selectedItem as JournalEntry; // Замените JournalEntry на ваш класс модели
		//		if (journalEntry == null) return;

		//		// Создаем и показываем окно редактирования
		//		Edit_Comment editWindow = new Edit_Comment(journalEntry.N_Zaves, journalEntry.Comment);
		//		editWindow.ShowDialog();

		//		// После закрытия окна обновляем DataGrid
		//		if (editWindow.DialogResult == true)
		//		{
		//			LoadData_Galvan_Jurnal(); // Метод для перезагрузки данных в DataGrid
		//		}
		//	}
		//}
		private void DataGridMonitorJurnal_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			Debug.WriteLine("Double click triggered");

			var originalSender = e.OriginalSource as DependencyObject;
			if (originalSender == null)
			{
				Debug.WriteLine("Original source is null");
				return;
			}

			var cell = originalSender.FindAncestor<DataGridCell>();
			if (cell == null)
			{
				Debug.WriteLine("Cell not found");
				return;
			}

			Debug.WriteLine($"Column header: {cell.Column.Header}");
			if (cell.Column.Header.ToString() == "Комментарий")
			{
				var selectedItem = dataGridMonitorJurnal.SelectedItem;
				if (selectedItem == null)
				{
					Debug.WriteLine("No selected item");
					return;
				}

				Debug.WriteLine($"Selected item type: {selectedItem.GetType().FullName}");

				// Работаем с DataRowView
				if (selectedItem is DataRowView rowView)
				{
					string nZaves = rowView["N_Zaves"].ToString();
					string comment = rowView["Comment"].ToString();

					Debug.WriteLine($"Opening edit window for N_Zaves: {nZaves}");
					Edit_Comment editWindow = new Edit_Comment(nZaves, comment);
					editWindow.ShowDialog();

					if (editWindow.DialogResult == true)
					{
						LoadData_Galvan_Jurnal();
						Debug.WriteLine("Data refreshed");
					}
				}
				else
				{
					Debug.WriteLine("Selected item is not DataRowView");
				}
			}
			else
			{
				Debug.WriteLine("Clicked column is not 'Комментарий'");
			}
		}

		private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			var dataView = dataGridMonitorJurnal.ItemsSource as DataView;

			if (dataView != null)
			{
				string filterText = SearchBox.Text;

				if (string.IsNullOrEmpty(filterText))
				{
					dataView.RowFilter = string.Empty; // Показываем все строки
				}
				else
				{
					// Создаем фильтр, приводя числовые данные к строковому типу
					string filter = string.Join(" OR ", dataView.Table.Columns.Cast<DataColumn>()
						.Select(col => col.DataType == typeof(string)
							? $"[{col.ColumnName}] LIKE '%{filterText}%'"
							: $"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{filterText}%'"));

					dataView.RowFilter = filter;
				}
			}
		}

		private void ClearBtn_Click(object sender, RoutedEventArgs e)
		{
			SearchBox.Clear();
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			// Очистить изображение в элементе Image
			DisplayImage1.Source = null;

			labelNZak1.Content = "Номер заготовки 1";
			labelNZak2.Content = "Номер заготовки 2";
			labelNZak3.Content = "Номер заготовки 3";
			labelNZak4.Content = "Номер заготовки 4";
		}





















		//-------------
		//----------------  ФУНКЦИЯ ДЛЯ ПЕРЕДАЧИ ИЗОБРАЖЕНИЯ ЗАГОТОВОК И ИХ НОМЕРА ПО КЛИКУ НА СТРОКЕ DATAGRID
		//--------------

		private void dataGridMonitorJurnal_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (dataGridMonitorJurnal.SelectedItem != null)
			{
				// Предполагаем, что DataGrid привязан к DataTable или коллекции с колонкой N_Zaves
				DataRowView row = dataGridMonitorJurnal.SelectedItem as DataRowView;
				if (row != null && row["N_Zaves"] != DBNull.Value)
				{
					int nZaves = Convert.ToInt32(row["N_Zaves"]);

					// Очищаем метки перед заполнением
					Dispatcher.Invoke(() =>
					{
						labelNZak1.Content = "";
						labelNZak2.Content = "";
						labelNZak3.Content = "";
						labelNZak4.Content = "";
					});

					// Запрашиваем все записи с этим N_Zaves из базы данных
					using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
					{
						conn.Open();
						string query = "SELECT N_Zakaz FROM Galvan.dbo.Galvan_Jurnal WHERE N_Zaves = @N_Zaves ORDER BY N_Zakaz";
						using (SqlCommand cmd = new SqlCommand(query, conn))
						{
							cmd.Parameters.AddWithValue("@N_Zaves", nZaves);
							using (SqlDataReader reader = cmd.ExecuteReader())
							{
								int index = 1;
								int filledRowsCount = 0; // Считаем количество записей N_Zakaz

								while (reader.Read() && index <= 4)
								{
									string nZakaz = reader["N_Zakaz"].ToString();
									// Обновляем соответствующую метку через Dispatcher
									Dispatcher.Invoke(() =>
									{
										switch (index)
										{
											case 1:
												labelNZak1.Content = nZakaz;
												break;
											case 2:
												labelNZak2.Content = nZakaz;
												break;
											case 3:
												labelNZak3.Content = nZakaz;
												break;
											case 4:
												labelNZak4.Content = nZakaz;
												break;
										}
									});
									index++;
									filledRowsCount++; // Увеличиваем счетчик записей
								}

								// Обновление изображения в зависимости от количества записей
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

								if (!string.IsNullOrEmpty(imagePath))
								{
									Dispatcher.Invoke(() =>
									{
										DisplayImage1.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
									});
								}
							}
						}
					}
				}
			}
		}

		private void Konstant_Click(object sender, RoutedEventArgs e)
		{
			MiniWindows.Konstants konstants = new MiniWindows.Konstants();
			konstants.ShowDialog();
		}
	}
}