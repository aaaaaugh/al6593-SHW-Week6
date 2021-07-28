using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    
    string filePath; //make a path to save file
    
    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.dataPath + "/" + name + ".json"; //even gameobjs w/ diff names have a save file

        if (File.Exists(filePath)) //if the file exists
        {
            string jsonStr = File.ReadAllText(filePath); //read in file 

            Vector3 savePosition = JsonUtility.FromJson<Vector3>(jsonStr); //transform file to Vector3 using jsonutility

            transform.position = savePosition; //set pos of the game obj to the pos in the file 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDrag() //if the mouse gets dragged on the game object 
    {
        transform.position = GetMouseWorldPosition(); //set pos to where its getting dragged
    }
    
    void OnApplicationQuit() //when the app quits, ur saving to the file 
    {
        string jsonPosition = //the obj transform.pos turns into Json
            JsonUtility.ToJson(transform.position, true); //true argument makes it LOOK PRETTY UWU 
        
        Debug.Log(jsonPosition); //print this string on console 
        
        File.WriteAllText(filePath, jsonPosition); //writes json string to the filePath file 
    }

    Vector3 GetMouseWorldPosition() //the screen position turns into a world position
    {
        Vector3 mousePosition = Input.mousePosition; //screen pos of mouse

        mousePosition.z = //set z of mouse based on world pos of the game obj 
            Camera.main.WorldToScreenPoint(gameObject.transform.position).z; //this is a Singleton everybody!!!
            //^gets the actual z position of the game object. 

        return Camera.main.ScreenToWorldPoint(mousePosition); //returns 
    }
}
