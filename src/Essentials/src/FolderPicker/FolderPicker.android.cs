using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Android.Content;

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
