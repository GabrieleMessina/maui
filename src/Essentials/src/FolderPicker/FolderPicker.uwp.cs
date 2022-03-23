using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;

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
