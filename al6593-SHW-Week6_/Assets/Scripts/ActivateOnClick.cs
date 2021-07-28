using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnClick : MonoBehaviour
{
    Rigidbody rigidbody; //variable for the rigidobdy
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); //you are getting the rigidbody component
        rigidbody.isKinematic = true; //don't use physics on it  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        rigidbody.isKinematic = false; //yes to the physics wooooooo
    }
    
}
