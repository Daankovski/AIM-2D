using UnityEngine;
using System.Collections;

public class BaseEnemy : Health {

    public Transform target;
    public float speed;
    public bool isAttacking = false;
    [SerializeField]
    private int damage = 10;
    private Health health;

    // Use this for initialization
    void Start () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        
        //if the enemy collides with an obstacle with a trigger event, it will stop and attack.
        isAttacking = true;
        StartCoroutine(Attack(other));
    }
    void OnTriggerExit2D()
    {
        isAttacking = false;
        
    }

    IEnumerator Attack(Collider2D other)
    {
        Wall wallscript = other.GetComponent<Wall>();
        if(wallscript != null)
        {
            other.GetComponent<Wall>().Damage(damage);
        }
        else
        {
            other.GetComponent<Health>().Damage(damage);
        }
        yield return new WaitForSeconds(1);
        
        if(isAttacking && other!= null)
        {
            StartCoroutine(Attack(other));
        }
        else
        {
            isAttacking = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(health.i_Lives <= 0)
        {
            Destroy(this.gameObject);
        }
        Bar();
        if (!isAttacking)
        {
            
            float step = speed * Time.deltaTime;
            if (target != null)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
        }
        
    }
}
