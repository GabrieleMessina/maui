using System;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using WindowsFolderPicker = Windows.Storage.Pickers.FolderPicker;

namespace Microsoft.Maui.Essentials
{
	public static partial class FolderPicker
	{
		static async Task<string> PlatformPickAsync(FolderPickerOptions options)
		{
			var folderPicker = new WindowsFolderPicker()
			{
				ViewMode = PickerViewMode.List,
			};
			folderPicker.FileTypeFilter.Add("*");

			var hwnd = Platform.CurrentWindowHandle;
			WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

			var result = await folderPicker.PickSingleFolderAsync();

			return result?.Path;
		}
	}
}
