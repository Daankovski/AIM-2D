using UnityEngine;
using System.Collections;

public class NodeGrid : MonoBehaviour {
    [SerializeField]
    private GameObject nod;

    public bool BuildMode = false;

    public int currentID;
    private int sizeX = 17;
    private int sizeY = 8;
    [SerializeField]
    private GameObject[] tiles;

    public GameObject prefTurret;
    public GameObject prefTurret2;
    public GameObject prefWall;
    public GameObject currentPref;


    void Start () {
        int z = 0;
        for (int x = 0; x < sizeX; x++)
         {
            for (int y = 0; y < sizeY; y++)
            {
                //maakt de grid van sizeX breed en sizeY hoog bestaande uit tiles.
                Vector3 pos = new Vector3(-8f + x, -2f - y,1f);
                GameObject temp = Instantiate(tiles[z], pos, Quaternion.identity) as GameObject;
                tiles[z] = temp;
                z++;
            }
            
        }
        
    }
    public void ClearTile(int position)
    {
        //tile dat bezet was, wordt weer vrij.
        tiles[position].GetComponent<Tile>().taken = false;
    }

	void Update () {

        //in de buildmode word de grid ge weergeeft.
        //en zo niet, dan wordt ie onzichtbaar en is de click functie uitgeschakelt.
        if (BuildMode)
        {
            
            for (int i = 0; i < tiles.Length - 1; i++)
            {
                tiles[i].GetComponent<BoxCollider2D>().enabled = true;
                tiles[i].GetComponent<SpriteRenderer>().enabled = true;
                tiles[i].GetComponent<Tile>().visible = true;
            }
        }
        else
        {
            for (int i = 0; i < tiles.Length - 1; i++)
            {
                tiles[i].GetComponent<BoxCollider2D>().enabled = false;
                tiles[i].GetComponent<SpriteRenderer>().enabled = false;
                tiles[i].GetComponent<Tile>().visible = false;
            }
        }


        //als er een tile wordt geklikt in de buildmode komt er een object op die plaats (tot nu toe een turret!)
        for(int i = 0; i<tiles.Length -1; i++)
        {
                if (tiles[i].GetComponent<Tile>().clicked && BuildMode)
                {
                    currentID = i;
                    tiles[i].GetComponent<Tile>().ChangeStatus();
                    GameObject temp2 = Instantiate(currentPref, tiles[i].transform.position, Quaternion.identity) as GameObject;
                    
                }
        }
    }

}
