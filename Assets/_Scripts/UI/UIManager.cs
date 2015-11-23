using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject grid;
    private GameObject turretButton;
    private GameObject turretButton2;
    private GameObject wallButton;



    void Start () {
        grid = GameObject.Find("Grid");
        turretButton = GameObject.Find("buildturret");
        turretButton2 = GameObject.Find("buildturret2");
        wallButton = GameObject.Find("buildwall");
    }
	public void DifferentBuild(int value)
    {
        turretButton.GetComponent<Button>().clicked = false;
        wallButton.GetComponent<Button>().clicked = false;
        turretButton2.GetComponent<Button>().clicked = false;

        if (value == 1)
        {
            wallButton.GetComponent<Button>().clicked = true;
            grid.GetComponent<NodeGrid>().currentPref = grid.GetComponent<NodeGrid>().prefWall;
        }
        else if (value == 2)
        {
            turretButton.GetComponent<Button>().clicked = true;
            grid.GetComponent<NodeGrid>().currentPref = grid.GetComponent<NodeGrid>().prefTurret;
        }
        else
        {
            turretButton2.GetComponent<Button>().clicked = true;
            grid.GetComponent<NodeGrid>().currentPref = grid.GetComponent<NodeGrid>().prefTurret2;
        }
    }

	void Update () {
        if (turretButton.GetComponent<Button>().clicked || turretButton2.GetComponent<Button>().clicked || wallButton.GetComponent<Button>().clicked)
        {
            grid.GetComponent<NodeGrid>().BuildMode = true;
        }
        else
        {
            grid.GetComponent<NodeGrid>().BuildMode = false;
        }
    }
}
