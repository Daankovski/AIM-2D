using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    public bool taken = false;
    public bool clicked = false;
    private Ray ray;
    public bool hover = false;


	void Start () {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.0f);
        
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
        if(taken)
        {
            clicked = false;
            gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(hover && clicked ==false)
            {
                clicked = true;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            }
            else
            {
                clicked = false;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.0f);
            }
        }
    }

    void OnMouseExit()
    {
        hover = false;
        if(!clicked)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.0f);
        }
    }

    void OnMouseEnter()
    {
        hover = true;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.2f);
    }
}
