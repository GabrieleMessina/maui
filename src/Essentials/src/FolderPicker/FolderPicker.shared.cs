using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Maui.Essentials
{
	public static partial class FolderPicker
	{
		public static async Task<FileResult> PickAsync(PickOptions options = null) =>
			(await PlatformPickAsync(options))?.FirstOrDefault();
	}
}
