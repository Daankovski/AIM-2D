using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private GameObject target;
    private float speed = 10;
	// Use this for initialization
	void Start () {
	    
	}
	public void DeclareTarget(GameObject location)
    {
        target = location;
    }
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if(distance < 0.5f)
            {
                Destroy(this.gameObject);
            }
            Debug.Log(distance);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
