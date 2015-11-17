using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    public GameObject prefEnemy;
    public float spawnTime = 2f;
    //private List<GameObject> Enemies = new List<GameObject>();
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawning());
	}
	IEnumerator Spawning()
    {
        Vector3 pos = this.transform.position;
        
        Instantiate(prefEnemy, pos, Quaternion.identity);
        

        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(Spawning());
    }
	// Update is called once per frame
	void Update () {
	
	}
}
