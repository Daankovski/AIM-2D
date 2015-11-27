using UnityEngine;
using System.Collections;

public class BaseEnemy : Health {

    public Transform target;
    private GameObject waveManager;
    public float speed;
    public bool isAttacking = false;
    [SerializeField]
    private float damage = 10;

    private float scaleX;
    private Animator animator;
    
    void Start () {

        animator = GetComponent<Animator>();
        animator.SetBool("FacingTheCamera", false);
        Debug.Log(currentHealth);

        //finds the target called flag.
        target = GameObject.Find("flag").transform;
        scaleX = transform.localScale.x;

        waveManager = GameObject.Find("/UI panels/nextwave");

        //bij elke wave, wordt hij sterker en sneller.
        damage += waveManager.GetComponent<WaveManager>().waveCounter;
        speed += waveManager.GetComponent<WaveManager>().waveCounter / 10f;
        maxHealth += waveManager.GetComponent<WaveManager>().waveCounter * 20f;

        currentHealth = maxHealth;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the enemy collides with an obstacle with a trigger event, it will stop and attack.
        isAttacking = true;
        animator.SetBool("Attacking", true);
        StartCoroutine(Attack(other));
    }
    void OnTriggerExit2D()
    {
        isAttacking = false;
        animator.SetBool("Attacking", false);
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
            OnTriggerExit2D();
        }
    }

    void Update()
    {
        if(target !=  null)
        {

            //bepaalt hoe de animatie gaat als ie loopt.
            if (target.transform.position.y > transform.position.y)
            {
                animator.SetBool("FacingTheCamera", false);
            }
            else
            {
                animator.SetBool("FacingTheCamera", true);
            }
            if (target.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-scaleX, transform.localScale.y, 1f);
            }
            else
            {
                transform.localScale = new Vector3(scaleX, transform.localScale.y, 1f);
            }
            
        }
        
        //dood gaan van de enemy
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
            waveManager.GetComponent<WaveManager>().coinCounter += Mathf.Ceil( damage * speed / 3);
            waveManager.GetComponent<WaveManager>().UpdateCoinUI();
        }

        Bar();

        if (!isAttacking)
        {
            //als de enemy niet aanvalt gaat ie naar de target(flag).
            float step = speed * Time.deltaTime;
            if (target != null)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
        }
        
    }
}
