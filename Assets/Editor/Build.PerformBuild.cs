#if UNITY_EDITOR
using UnityEditor;
#endif

class Build {

	static void PerformBuild ()
	{
		string[] scenes = { "Assets/Scenes/MiniGame.unity" };
		BuildPipeline.BuildPlayer(scenes, "Builds/PlayerBuild.app", BuildTarget.StandaloneOSXUniversal, BuildOptions.None); 
	}
}
