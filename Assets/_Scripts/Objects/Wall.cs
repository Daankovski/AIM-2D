using UnityEngine;
using System.Collections;

public class Wall : Health {
    public GameObject grid;
    public int IDpos = 0;

    private Health health;

    // Use this for initialization
    void Start () {
        grid = GameObject.Find("Grid");
        IDpos = grid.GetComponent<NodeGrid>().currentID;

    }

    // Update is called once per frame
    void Update () {
        if (health.i_Lives <= 0)
        {
            Destroy(this.gameObject);
            grid.GetComponent<NodeGrid>().ClearTile(IDpos);
        }
        Bar();
    }
}
