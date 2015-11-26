using UnityEngine;
using System.Collections;
public class BaseTurret : Health {

    [SerializeField]
    private bool projectileIsBullet = false;
    private LineRenderer lineRenderer;
    private GameObject hitPoint;

    [SerializeField]
    private GameObject bulletPref;

    public GameObject grid;
    public int IDpos = 0;

    [SerializeField]
    private float resetTime;
    [SerializeField]
    private float resetTimeBoost;

    [SerializeField]
    protected float range = 4f;
    [SerializeField]
    private float rangeBoost = 1f;

    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private int damageBoost = 10;

    protected GameObject fieldImage;
    private SpriteRenderer fieldsprite;

    [SerializeField]
    private int upgradeLvl = 1;
    private int maxLvl = 5;

    private Animator animator;
    

    void Start () {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        hitPoint = transform.FindChild("hitpoint").gameObject;
        hitPoint.SetActive(false);


        fieldImage = transform.FindChild("field").gameObject;
        fieldsprite = fieldImage.GetComponent<SpriteRenderer>();
        fieldsprite.color = new Color(1f, 1f, 1f, 0.0f);
        grid = GameObject.Find("Grid");
        IDpos = grid.GetComponent<NodeGrid>().currentID;
        
        //begins with shoot loop.
        StartCoroutine(Shoot()); 
	}

    
    void UpgradeTurret()
    {
        range += rangeBoost;
        resetTime += resetTimeBoost;
        damage += damageBoost;
    }
	protected IEnumerator Shoot()
    {
        //checks all targets within the range
        Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, range, 1 << LayerMask.NameToLayer("enemy"));
        if (targets.Length != 0)
        {
            int i = Random.Range(0,targets.Length);

            float x = targets[i].transform.position.x - transform.position.x;
            float y = targets[i].transform.position.y - transform.position.y;
            float angle2 = Mathf.Rad2Deg * Mathf.Atan2(y, x);
            if (angle2 < 45 / 2 && angle2 > -45 / 2)
            {
                //right 
                animator.SetInteger("direction", 7);

            }
            else if (angle2 > 157 || angle2 < -157)
            {
                //left
                animator.SetInteger("direction", 3);
            }
            else if (angle2 > (180 / 8) * 3 && angle2 < (180 / 8) * 5)
            {
                //up
                animator.SetInteger("direction", 5);
            }

            else if (angle2 < -(180 / 8) * 3 && angle2 > -(180 / 8) * 5)
            {
                //down
                animator.SetInteger("direction", 1);
            }

            else if (angle2 < -(180 / 8) * 1 && angle2 > -(180 / 8) * 3)
            {
                //down right
                animator.SetInteger("direction", 8);
            }
            else if (angle2 > (180 / 8) * 1 && angle2 < (180 / 8) * 3)
            {
                //up right
                animator.SetInteger("direction", 6);
            }
            else if (angle2 < -(180 / 8) * 5 && angle2 > -(180 / 8) * 7)
            {
                //down left
                animator.SetInteger("direction", 2);
            }
            else if (angle2 > (180 / 8) * 5 && angle2 < (180 / 8) * 7)
            {
                //up left
                animator.SetInteger("direction", 4);
            }

            //laser or projectile
            if (!projectileIsBullet)
            {
                //Debug.DrawLine(this.transform.position, targets[0].transform.position, Color.white, 0.5f);
                hitPoint.SetActive(true);

                hitPoint.transform.position = targets[i].transform.position;
                Vector3 temp = hitPoint.transform.position;
                temp.z -= 1f;
                hitPoint.transform.position = temp;

                lineRenderer.enabled = true;
                
                Vector3 hitPos = (targets[i].transform.position -transform.position)*1.9f;
                hitPos.z -= 1;
                lineRenderer.SetPosition(1, hitPos);
            }
            else
            {
                GameObject temp = Instantiate(bulletPref, transform.position, Quaternion.identity) as GameObject;
                temp.GetComponent<Bullet>().DeclareTarget(targets[i].gameObject);

                


            }
            

            //hurts the target
            targets[0].GetComponent<BaseEnemy>().Damage(damage);

        }
        //waits for an amount of time.
        yield return new WaitForSeconds(resetTime);
        hitPoint.SetActive(false);
        lineRenderer.enabled = false;
        StartCoroutine(Shoot());
    }
    void OnMouseEnter()
    {
        fieldImage = transform.FindChild("field").gameObject;
        fieldsprite = fieldImage.GetComponent<SpriteRenderer>();
        fieldsprite.color = new Color(1f, 1f, 1f, 0.3f);
    }
    void OnMouseExit()
    {
        fieldImage = transform.FindChild("field").gameObject;
        fieldsprite = fieldImage.GetComponent<SpriteRenderer>();
        fieldsprite.color = new Color(1f, 1f, 1f, 0.0f);
    }
    void Update () {

        if (currentHealth <=0)
        {
            Destroy(this.gameObject);
            grid.GetComponent<NodeGrid>().ClearTile(IDpos);
            
        }
        //scales the circle with the range of the turret.
        fieldImage.transform.localScale = new Vector3(range, range, 0f);
        Bar();
    }
}
