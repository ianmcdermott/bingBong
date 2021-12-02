using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSphere : MonoBehaviour
{
	public int rows = 36;
	public int cols = 36;
	public int paralells = 5;
	public int meridians = 5;
	public int radius = 10;
	public GameObject musicObject;
	public float rootScale = 0.7f;
	public GameObject ballObject;

	public void genSphere(){
  	 	for(int i = 0; i < paralells; i++){
			float parallel =  Mathf.PI * (i+1) / paralells * radius;
			   	for(int j = 0; j < meridians; j++){
	   				float meridian = (float) 2.0 * Mathf.PI * j / meridians * radius;
	                Instantiate(musicObject, new Vector3(meridian, parallel, 0), Quaternion.identity);
		   	}
	    }
   	}

public void genSphere2(){
	 // add top vertex
   // Instantiate(musicObject, new Vector3(0, radius, 0), Quaternion.identity);

  // generate vertices per stack / slice
	for (int i = 0; i < paralells - 1; i++)
	{
		float phi = Mathf.PI * (i + 1) / paralells;
		for (int j = 0; j < meridians; j++)
		{
			float theta = (float) 2.0 * Mathf.PI * j / meridians;
			float x = Mathf.Sin(phi) * Mathf.Cos(theta)*radius;
			float y = Mathf.Cos(phi) * radius;
			float z = Mathf.Sin(phi) * Mathf.Sin(theta)*radius;
		  // Instantiate(musicObject, new Vector3(x, y, z), Quaternion.identity);
	     	GameObject mo = Instantiate(musicObject, new Vector3(x, y, z), transform.rotation * Quaternion.Euler (0f, j*360/meridians, 0f));
	     	GameObject ballObj = Instantiate(ballObject, new Vector3(x, y, z), transform.rotation * Quaternion.Euler (0f, j*360/meridians, 0f));

	     	mo.transform.localScale = new Vector3(rootScale-Mathf.Sin(i)*rootScale, Mathf.Cos(rootScale-i)*rootScale, rootScale*rootScale);

     	  	mo.transform.parent = gameObject.transform;
     	  	ballObj.transform.parent = gameObject.transform;

   //   	  	 	  	    mo.transform.Find("Cube").GetComponent<RectTransform>().anchorMin = new Vector2(1, 0);
			// mo.transform.Find("Cube").GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
			// mo.transform.Find("Cube").GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
		}
	}

  // add bottom vertex
     // Instantiate(musicObject, new Vector3(0, radius, 0), Quaternion.identity);
	}

    // Start is called before the first frame update
    void Start()
    {
        genSphere2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
