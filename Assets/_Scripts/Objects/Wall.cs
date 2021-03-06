﻿using UnityEngine;
using System.Collections;

public class Wall : Health {
    public GameObject grid;
    public int IDpos = 0;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        grid = GameObject.Find("Grid");
        IDpos = grid.GetComponent<NodeGrid>().currentID;

    }

    // Update is called once per frame
    void Update () {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            grid.GetComponent<NodeGrid>().ClearTile(IDpos);
        }
        Bar();
    }
}
