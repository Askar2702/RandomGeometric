using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class CreateAssetBundle : MonoBehaviour
{
    [MenuItem("Assets/Build AssetBudles")]
    static void biuldBudle()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundle", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }
    
}
