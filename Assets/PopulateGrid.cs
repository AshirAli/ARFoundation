using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab; //This is our prefab object that will be exposed in the inspector
	public int numberToCreate; // number of objects to create. Exposed in inspector
	Image image; // Create GameObject instance
	Text text;
	GameObject imageObject;
	void Start()
	{
		Populate();
	}
	void Populate()
	{
		for (int i = 0; i < numberToCreate; i++)
		{
			//Create new instances of our prefab until we've created as many as we specified
			imageObject = (GameObject)Instantiate(prefab, transform);
			// Randomize the color of our image
			image = imageObject.GetComponent<Image>();
			//text = imageObject.

			image.color = Color.black;//Random.ColorHSV();
			
		}
	}
}