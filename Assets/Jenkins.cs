using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Jenkins
{
    /// 

    /// Single command to trigger the full build for iOS
    /// 
    static void CommandLineBuildiOS()
    {
        Build(BuildTarget.iOS, "build/iOS");
    }
    /// 

    /// Single command to trigger the full build for Android
    /// 
    static void CommandLineBuildAndroid()
    {
        Build(BuildTarget.Android, "build/Android");
    }
    /// 

    /// Find all enabled scenes and start a build for the given platform
    /// 
    /// Unity target platform
    /// Path in which to do the build
    static void Build(UnityEditor.BuildTarget targetPlatform, string path)
    {
        // Path must be specified
        if (path == null)
        {
            Debug.Log("ERROR: No build path specified");
            return;
        }
        // Find all enabled scenes in the project and put them into a string array
        Boo.Lang.List sceneList = new Boo.Lang.List();
        foreach (EditorBuildSettingsScene ebs in EditorBuildSettings.scenes)
        {
            if (ebs.enabled)
                sceneList.Add(ebs.path);
        }
        // If we have nothing to build then exit
        var scenes = sceneList.ToArray();
        if (scenes == null || scenes.Length == 0)
        {
            Debug.Log("ERROR: No scenes enabled so there's nothing to build");
            return;
        }
        // Start the build
        BuildPipeline.BuildPlayer((UnityEditor.EditorBuildSettingsScene[])scenes, path, targetPlatform, BuildOptions.None);
    }
}