using UnityEngine;
using System.Collections;

public class moveEnemy : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed, 0, 0);
        if(transform.position.x >= 10)
        {
            Destroy(this.gameObject);
        }
	}
}
