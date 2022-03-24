using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace Samples.ViewModel
{
	public class FolderPickerViewModel : BaseViewModel
	{
		string text;

		public FolderPickerViewModel()
		{
			PickFolderCommand = new Command(() => DoPickFolder());
		}

		public ICommand PickFolderCommand { get; }

		public string Text
		{
			get => text;
			set => SetProperty(ref text, value);
		}


		async void DoPickFolder()
		{
			await PickAndShow(FolderPickerOptions.Default);
		}

		async Task<string> PickAndShow(FolderPickerOptions options)
		{
			try
			{
				var result = await FolderPicker.PickAsync(options);

				if (result != null)
				{

					Text = $"Folder Path: {result}";
				}
				else
				{
					Text = $"Pick cancelled.";
				}

				return result;
			}
			catch (Exception ex)
			{
				Text = ex.ToString();
				return null;
			}
		}
	}
}
