using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
	/// Логика взаимодействия для Edit_Comment.xaml
	/// </summary>
	public partial class Edit_Comment : Window
	{
		private string nZaves;
		public Edit_Comment(string nZaves, string currentComment)
		{
			InitializeComponent();
			this.nZaves = nZaves;
			Comment.Text = currentComment;
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			Close();
		}

		private void Dobav_Comm(object sender, RoutedEventArgs e)
		{
			try
			{
				// Предполагаю использование SQL Server, настройте под вашу БД
				using (SqlConnection conn = new SqlConnection(WC.ConnectionString))
				{
					conn.Open();
					string query = "UPDATE Galvan_Jurnal SET Comment = @Comment WHERE N_Zaves = @NZaves";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@Comment", Comment.Text);
						cmd.Parameters.AddWithValue("@NZaves", nZaves);
						cmd.ExecuteNonQuery();
					}
				}
				DialogResult = true;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
				DialogResult = false;
			}
		}
	}
}
