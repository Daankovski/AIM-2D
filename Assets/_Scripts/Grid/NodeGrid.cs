using UnityEngine;
using System.Collections;

public class NodeGrid : MonoBehaviour {
    [SerializeField]
    private GameObject nod;

    private int sizeX = 17;
    private int sizeY = 10;
    //public GameObject[,] tiles = new GameObject[10, 10];
    [SerializeField]
    private GameObject[] tiles;
    [SerializeField]
    private GameObject prefTurret;
    void Start () {
        //tiles = new GameObject[sizeX * sizeY];
        int z = 0;
        for (int x = 0; x < sizeX; x++)
         {
            for (int y = 0; y < sizeY; y++)
            {
                //tiles[z] = nod;
                Vector3 pos = new Vector3(-8f + x, -0.5f - y,1f);
                GameObject temp = Instantiate(tiles[z], pos, Quaternion.identity) as GameObject;
                tiles[z] = temp;

                //Instantiate(tiles[z], pos, Quaternion.identity);
                z++;
            }
            
        }
        
    }
    
	
	void Update () {
        for(int i = 0; i<tiles.Length -1; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i].GetComponent<Tile>().clicked)
                {
                    tiles[i].GetComponent<Tile>().ChangeStatus();
                    
                    GameObject temp2 = Instantiate(prefTurret, tiles[i].transform.position, Quaternion.identity) as GameObject;
                }
            }
        }
    }

}
