using UnityEditor;
using UnityEditor.Callbacks;
/// <summary>
/// ビルドする度にバージョンを上げていくスクリプト
/// </summary>
public class AutoIncrementVersion
{
	[PostProcessBuild]

	public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
	{

		if (target == BuildTarget.iOS)
		{
			//0 -> 1
			var buildNumber = int.Parse(PlayerSettings.iOS.buildNumber) + 1;
			PlayerSettings.iOS.buildNumber = "" + buildNumber;
		}
	}
}