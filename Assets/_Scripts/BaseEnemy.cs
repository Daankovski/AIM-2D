using UnityEngine;
using System.Collections;

public class BaseEnemy : Health {

    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool Attacking = false;
    [SerializeField]
    private int damage = 10;
    // Use this for initialization
    void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        
        //if the enemy collides with an obstacle with a trigger event, it will stop and attack.
        Attacking = true;
        StartCoroutine(Attack(other));
    }
    void OnTriggerExit2D()
    {
        Attacking = false;
        
    }

    IEnumerator Attack(Collider2D other)
    {

        other.GetComponent<Health>().Damage(damage);
        yield return new WaitForSeconds(1);
        
        Debug.Log("attack!");
        if(Attacking && other!= null)
        {
            StartCoroutine(Attack(other));
        }
        else
        {
            Attacking = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Bar();
        if (!Attacking)
        {
            
            float step = speed * Time.deltaTime;
            if (target != null)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
        }
        
    }
}
