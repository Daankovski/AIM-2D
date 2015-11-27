using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject grid;
    [SerializeField]
    private Text turretPriceText;
    [SerializeField]
    private Text turret2PriceText;
    [SerializeField]
    private Text wallPriceText;
    [SerializeField]
    private Text coinCounterText;

    private float turretPrice = 70;
    private float turret2Price = 120;
    private float wallPrice = 20;
    public float tempPrice;
    public float currentCoins;

    private GameObject turretButton;
    private GameObject turretButton2;
    private GameObject wallButton;

    [SerializeField]
    private GameObject waveManager;

    

    void Start () {
        
        turretPriceText.text = "" + turretPrice;
        turret2PriceText.text = "" + turret2Price;
        wallPriceText.text = "" + wallPrice;

        grid = GameObject.Find("Grid");
        turretButton = GameObject.Find("buildturret");
        turretButton2 = GameObject.Find("buildturret2");
        wallButton = GameObject.Find("buildwall");
    }
	public void DifferentBuild(int value)
    {
        //wordt aan geroepen als de speler een van build knopjes klikt. 
        //de value bepaalt welke prefrab wordt gemaakt op de grid als er op de tile is geklikt.

        turretButton.GetComponent<Button>().clicked = false;
        wallButton.GetComponent<Button>().clicked = false;
        turretButton2.GetComponent<Button>().clicked = false;

        

        if (value == 1)
        {
            tempPrice = wallPrice;
            wallButton.GetComponent<Button>().clicked = true;
            grid.GetComponent<NodeGrid>().currentPref = grid.GetComponent<NodeGrid>().prefWall;
        }
        else if (value == 2)
        {
            tempPrice = turret2Price;
            turretButton.GetComponent<Button>().clicked = true;
            grid.GetComponent<NodeGrid>().currentPref = grid.GetComponent<NodeGrid>().prefTurret;
        }
        else
        {
            tempPrice = turretPrice;
            turretButton2.GetComponent<Button>().clicked = true;
            grid.GetComponent<NodeGrid>().currentPref = grid.GetComponent<NodeGrid>().prefTurret2;
        }
    }

	void Update () {
        //maakt de prijs rood als de speler niet genoeg coins heeft.
        currentCoins = waveManager.GetComponent<WaveManager>().coinCounter;
        if (currentCoins < wallPrice)
        {
            wallPriceText.color = Color.red;
        }
        else
        {
            wallPriceText.color = Color.green;
        }

        if (currentCoins < turretPrice)
        {
            turretPriceText.color = Color.red;
        }
        else
        {
            turretPriceText.color = Color.green;
        }

        if (currentCoins < turret2Price)
        {
            turret2PriceText.color = Color.red;
        }
        else
        {
            turret2PriceText.color = Color.green;
        }

        //als een van de build buttons geklikt wordt, dan gaat de grid in de buildmode.
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
