using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Provider;

namespace Microsoft.Maui.Essentials
{
	public static partial class FolderPicker
	{
		static async Task<string> PlatformPickAsync(FolderPickerOptions options)
		{
			// Essentials supports >= API 19 but this action is available only on >= API 21
			if (!OperatingSystem.IsAndroidVersionAtLeast(21))
				return null;
			
			var action = Intent.ActionOpenDocumentTree;

			var intent = new Intent(action);
			intent.PutExtra(DocumentsContract.Document.ColumnMimeType, DocumentsContract.Document.MimeTypeDir);
			intent.PutExtra(DocumentsContract.Document.ColumnFlags, (int)DocumentContractFlags.DirSupportsCreate);

			var pickerIntent = Intent.CreateChooser(intent, options?.PickerTitle ?? "Select folder");

			try
			{
				var result = string.Empty;
				void OnResult(Intent intent)
				{
					if (intent.Data != null)
					{
						result = intent.Data.Path;
					}
				}
				await IntermediateActivity.StartAsync(pickerIntent, Platform.requestCodeFolderPicker, onResult: OnResult);

				return result;
			}
			catch (OperationCanceledException)
			{
				return null;
			}
		}
	}
}
