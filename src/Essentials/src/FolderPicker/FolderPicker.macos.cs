using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppKit;
using MobileCoreServices;

namespace Microsoft.Maui.Essentials
{
	public static partial class FolderPicker
	{
		static async Task<string> PlatformPickAsync(FolderPickerOptions options)
		{
			var openPanel = new NSOpenPanel
			{
				CanChooseFiles = false,
				AllowsMultipleSelection = false,
				CanChooseDirectories = true
			};

			openPanel.AllowedFileTypes = new List<string>() { "*" };

			if (options.PickerTitle != null)
				openPanel.Title = options.PickerTitle;

			SetFileTypes(options, openPanel);

			var result = string.Empty;
			var panelResult = openPanel.RunModal();
			if (panelResult == (nint)(long)NSModalResponse.OK)
			{
				result = panelResult?.Urls[0]?.Path;
			}

			return Task.FromResult<string>(result);
		}
	}
}
