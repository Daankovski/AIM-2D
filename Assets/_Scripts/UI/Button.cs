using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    [SerializeField]
    private int kindOfObject = 0;
    public bool clicked = false;
    private bool hoover = false;
    [SerializeField]
    private GameObject cam;
    void Update()
    {
        if(clicked)
        {
            this.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        /*if(Input.GetMouseButtonDown(0))
        {
            
            StartCoroutine(a());
        }*/
    }
    /*IEnumerator a()
    {
        
        if (hoover)
        {
            clicked = true;
        }
        else
        {
            yield return new WaitForSeconds(0.1f);
            clicked = false;
        }
    }*/
    void OnMouseEnter()
    {
        hoover = true;
        this.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }
    void OnMouseExit()
    {
        hoover = false;
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    void OnMouseDown()
    {
        if(clicked)
        {
            clicked = false;
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        }
        else
        {
            cam.GetComponent<UIManager>().DifferentBuild(kindOfObject);
            clicked = true;
        }
    }
}
