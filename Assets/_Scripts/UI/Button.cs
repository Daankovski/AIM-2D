using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public bool clicked = false;
	// Use this for initialization
	void Start () {
	    
	}
	void OnMouseDown()
    {
        if(clicked)
        {
            clicked = false;
        }
        else
        {
            clicked = true;
        }
        
    }
	// Update is called once per frame
	void Update () {
	
	}
}
