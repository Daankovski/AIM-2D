using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public bool clicked = false;

    void OnMouseEnter()
    {
        this.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }
    void OnMouseExit()
    {
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
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
}
