using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			TxtMain.Focus();
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog Load = new OpenFileDialog();

			Load.Filter = "All Files|*.*|cSharp files|*.cs|Text files|*.txt|Rich Text files|*.rtf";
			Load.FilterIndex = 1;
			if (Load.ShowDialog() == true)
			{
				try
				{
					TxtMain.Text = File.ReadAllText(Load.FileName);
					TxtPath.Text = Load.FileName;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			TxtMain.Focus();

		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			SaveFileDialog Save = new SaveFileDialog();

			Save.Filter = "Rich Text files|*.rtf";
			Save.FilterIndex = 1;
			if (string.IsNullOrWhiteSpace(TxtPath.Text))
			{
				if (Save.ShowDialog() == true)
				{
					File.WriteAllText(Save.FileName, TxtMain.Text);
					TxtPath.Text = Save.FileName;
				}

			}
			else
			{
				File.WriteAllText(TxtPath.Text, TxtMain.Text);

			}
			TxtMain.Focus();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			TxtMain.Cut();
			TxtMain.Focus();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			TxtMain.Copy();
			TxtMain.Focus();
		}

		private void Button_Click_4(object sender, RoutedEventArgs e)
		{
			TxtMain.Paste();
			TxtMain.Focus();
		}

		private void Button_Click_5(object sender, RoutedEventArgs e)
		{
			TxtMain.SelectAll();
			TxtMain.Focus();
		}
		public bool AutoSave { get; set; }
		private void ToggleButtonClicked(object sender, RoutedEventArgs e)
		{
			if (sender is ToggleButton tgBtn)
				if (tgBtn.IsChecked == true)
					if (!string.IsNullOrWhiteSpace(TxtPath.Text))
						AutoSave = true;
					else
					{
						MessageBox.Show("Path Is Empty");
						tgBtn.IsChecked = false;
						AutoSave = false;
					}
			TxtMain.Focus();
		}

		private void TxtMain_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (AutoSave)
				Button_Click_1(null, null);
		}
	}
}
