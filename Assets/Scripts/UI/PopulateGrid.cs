using UnityEngine;
using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;

    Button sceneButton;
	Image image;
	Text text;
	GameObject imageObject;
    string path;

    private void Start()
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
        string folderName = Application.dataPath + "/Scenes";
        var dirInfo = new DirectoryInfo(folderName);
        var allFileInfos = dirInfo.GetFiles("*.unity", SearchOption.AllDirectories);
        foreach (var fileInfo in allFileInfos)
        {
            //Debug.Log("Found a scene file: " + @fileInfo.Name);
        }
        int i;
        for (i = 1; i <= 30; i++)
        {
            SetPath(i);
            if(path != "null")
            {
                Debug.Log("Path : " + path);
                //Create new instances of our prefab until we've created as many as we specified
                imageObject = (GameObject)Instantiate(prefab, transform);
                // Randomize the color of our image
                image = imageObject.GetComponent<Image>();
                text = imageObject.GetComponentInChildren<Text>();
                sceneButton = imageObject.GetComponentInChildren<Button>();
                int x = new int();
                x = i;
                sceneButton.onClick.AddListener(delegate { Test(x); });
                //path = Path.GetFileNameWithoutExtension(allScenes[i].path);
                text.text = path;
                image.color = Color.black;//Random.ColorHSV();
            }
        }
    }

    void TempStorage()
    {
        int i;
        string folderName = Application.dataPath + "/Scenes";
        var dirInfo = new DirectoryInfo(folderName);
        var allFileInfos = dirInfo.GetFiles("*.unity", SearchOption.AllDirectories);
        foreach (var fileInfo in allFileInfos)
        {
            i = 1;
            //Debug.Log("Found a scene file: " + @fileInfo.Name);
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
            //Debug.Log(path);
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

    private void SetPath(int id)
    {
        switch (id)
        {
            case 1: path = "ARCollaborationDataExample";
                break;
            case 2:
                path = "ARKitCoachingOverlay";
                break;
            case 3:
                path = "ARWorldMap";
                break;
            case 4:
                path = "Anchors";
                break;
            case 5:
                path = "CameraImage";
                break;
            case 6:
                path = "Check Support";
                break;
            case 7:
                path = "EnvironmentProbes";
                break;
            case 8:
                path = "ARCoreFaceRegions";
                break;
            case 9:
                path = "ARKitFaceBlendShapes";
                break;
            case 10:
                path = "EyeLasers";
                break;
            case 11:
                path = "EyePoses";
                break;
            case 12:
                path = "FaceMesh";
                break;
            case 13:
                path = "FacePose";
                break;
            case 14:
                path = "FixationPoint";
                break;
            case 15:
                path = "RearCameraWithFrontCameraFaceMesh";
                break;
            case 16:
                path = "HumanBodyTracking2D";
                break;
            case 17:
                path = "HumanBodyTracking3D";
                break;
            case 18:
                path = "HumanSegmentationImages";
                break;
            case 19:
                path = "ImageTracking";
                break;
            case 20:
                path = "LightEstimation";
                break;
            case 21:
                path = "ObjectTracking";
                break;
            case 22:
                path = "FeatheredPlanes";
                break;
            case 23:
                path = "PlaneClassification";
                break;
            case 24:
                path = "TogglePlaneDetection";
                break;
            case 25:
                path = "PlaneOcclusion";
                break;
            case 26:
                path = "AllPointCloudPoints";
                break;
            case 27:
                path = "Scale";
                break;
            case 28:
                path = "SimpleAR";
                break;
            case 29:
                path = "SampleUXScene";
                break;
            case 30:
                path = "ARKitHDRLightEstimation";
                break;
            default:
                path = "null";
                break;
        }
    }
}