using System.Threading.Tasks;

namespace Microsoft.Maui.Essentials
{
	public static partial class FolderPicker
	{
		public static async Task<string> PickAsync(FolderPickerOptions options = null) =>
			(await PlatformPickAsync(options));
	}

	public class FolderPickerOptions
	{
		public static FolderPickerOptions Default =>
			new FolderPickerOptions();

		public string PickerTitle { get; set; }
	}
}
