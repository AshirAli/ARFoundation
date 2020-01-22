using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;
using System;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab; //This is our prefab object that will be exposed in the inspector
    Button sceneButton;
	Image image; // Create GameObject instance
	Text text;
	GameObject imageObject;
    string path;
    void Start()
	{
#if UNITY_EDITOR
        Populate_Editor();
#endif
#if UNITY_ANDROID
        Populate_Android();
#endif
    }

    private void Populate_Android()
    {
        int i;
        string folderName = Application.dataPath + "/Scenes";
        var dirInfo = new DirectoryInfo(folderName);
        var allFileInfos = dirInfo.GetFiles("*.unity", SearchOption.AllDirectories);
        foreach (var fileInfo in allFileInfos)
        {
            i = 1;
            Debug.Log("Found a scene file: " + @fileInfo.Name);
            // Create new instances of our prefab until we've created as many as we specified

            imageObject = (GameObject)Instantiate(prefab, transform);
            // Randomize the color of our image
            image = imageObject.GetComponent<Image>();
            text = imageObject.GetComponentInChildren<Text>();
            sceneButton = imageObject.GetComponentInChildren<Button>();
            int x = new int();

            x = i;
            sceneButton.onClick.AddListener(delegate { Test(x); });
            text.text = @fileInfo.Name;
            image.color = Color.black;//Random.ColorHSV();
            i++;
        }
    }
#if UNITY_EDITOR
    void Populate_Editor()
	{
        EditorBuildSettingsScene[] allScenes = EditorBuildSettings.scenes;
        for (int i = 1; i < allScenes.Length; i++)
		{
			//Create new instances of our prefab until we've created as many as we specified
			imageObject = (GameObject)Instantiate(prefab, transform);
			// Randomize the color of our image
			image = imageObject.GetComponent<Image>();
            text = imageObject.GetComponentInChildren<Text>();
            sceneButton = imageObject.GetComponentInChildren<Button>();
            int x = new int();

            x = i;
            sceneButton.onClick.AddListener(delegate { Test(x); });
            path = Path.GetFileNameWithoutExtension(allScenes[i].path);
            text.text = path;
            image.color = Color.black;//Random.ColorHSV();
		}
	}
#endif
    void Test(int id)
    {
        Debug.Log("Scene Loaded " + id.ToString());
        SceneManager.LoadScene(id);
    }
}