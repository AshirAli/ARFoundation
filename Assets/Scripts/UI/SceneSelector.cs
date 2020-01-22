using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
public class SceneSelector : MonoBehaviour
{
#if UNITY_EDITOR
    void Start(){
        EditorBuildSettingsScene[] allScenes = EditorBuildSettings.scenes;
        Debug.Log ("All Scenes : Length : " + allScenes.Length);
        string path;
        for (int i = 0; i < allScenes.Length; i++) {
            Debug.Log ("All Path : Scene : " + allScenes[i].path);
            path = Path.GetFileNameWithoutExtension (allScenes[i].path);
            Debug.Log ("Clear Path : Scene : "+path);
        }
    }
#endif
}
