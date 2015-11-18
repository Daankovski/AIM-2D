using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject grid;
    [SerializeField]
    private GameObject turretButton;



    // Use this for initialization
    void Start () {
        grid = GameObject.Find("Grid");
        turretButton = GameObject.Find("buildbutton");
    }
	
	// Update is called once per frame
	void Update () {
	    if(turretButton.GetComponent<Button>().clicked)
        {
            Debug.Log("fdgd");
            grid.GetComponent<NodeGrid>().BuildMode = true;
        }
        else
        {
            grid.GetComponent<NodeGrid>().BuildMode = false;
        }
	}
}
