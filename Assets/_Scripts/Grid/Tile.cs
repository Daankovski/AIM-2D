using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    //deze booleans zijn de statusen van de button.
    public bool taken = false;
    public bool clicked = false;
    public bool hover = false;
    public bool visible = false;

	void Start () {

        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.05f);
        
    }
	public void ChangeStatus()
    {
        
        if(taken ==true)
        {
            taken = false;
        }
        else
        {
            taken = true;
        }
    }

    void Update () {
        if(!visible)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.0f);
        }
        if (taken)
        {
            clicked = false;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && visible)
            {
                if (hover && clicked == false)
                {
                    clicked = true;

                    GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
                }
                else
                {
                    clicked = false;
                    GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.05f);
                }
            }
        }
    }

    void OnMouseExit()
    {
        hover = false;
        if(!clicked)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.05f);
        }
    }

    void OnMouseEnter()
    {
        hover = true;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
    }
}
