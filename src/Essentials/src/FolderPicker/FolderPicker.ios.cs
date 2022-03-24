using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using MobileCoreServices;
using ObjCRuntime;
using UIKit;

namespace Microsoft.Maui.Essentials
{
	public static partial class FolderPicker
	{
		static async Task<string> PlatformPickAsync(FolderPickerOptions options)
		{
			var allowedUtis = new string[]
			{
				UTType.Folder
			};

			var tcs = new TaskCompletionSource<string>();

			using var documentPicker = new UIDocumentPickerViewController(allowedUtis, UIDocumentPickerMode.Open);
			if (OperatingSystem.IsIOSVersionAtLeast(11, 0))
				documentPicker.AllowsMultipleSelection = false;
			documentPicker.Delegate = new PickerDelegate
			{
				PickHandler = urls => GetFileResults(urls, tcs)
			};

			if (documentPicker.PresentationController != null)
			{
				documentPicker.PresentationController.Delegate =
					new Platform.UIPresentationControllerDelegate(() => GetFileResults(null, tcs));
			}

			var parentController = Platform.GetCurrentViewController();

			parentController.PresentViewController(documentPicker, true, null);

			return await tcs.Task;
		}

		class PickerDelegate : UIDocumentPickerDelegate
		{
			public Action<NSUrl[]> PickHandler { get; set; }

			public override void WasCancelled(UIDocumentPickerViewController controller)
				=> PickHandler?.Invoke(null);

			public override void DidPickDocument(UIDocumentPickerViewController controller, NSUrl[] urls)
				=> PickHandler?.Invoke(urls);

			public override void DidPickDocument(UIDocumentPickerViewController controller, NSUrl url)
				=> PickHandler?.Invoke(new NSUrl[] { url });
		}

		static void GetFileResults(NSUrl[] urls, TaskCompletionSource<string> tcs)
		{
			try
			{
				tcs.TrySetResult(urls?[0]?.ToString() ?? "");
			}
			catch (Exception ex)
			{
				tcs.TrySetException(ex);
			}
		}
	}
}
