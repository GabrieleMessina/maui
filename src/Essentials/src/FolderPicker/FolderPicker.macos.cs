using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppKit;
using MobileCoreServices;

namespace Microsoft.Maui.Essentials
{
	public static partial class FolderPicker
	{
		static Task<IEnumerable<FileResult>> PlatformPickAsync(PickOptions options, bool allowMultiple = false)
		{
			throw new NotImplementedException();
		}
	}
}
