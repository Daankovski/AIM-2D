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
    

    void Start () {
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
            //laser or projectile
            if(!projectileIsBullet)
            {
                //Debug.DrawLine(this.transform.position, targets[0].transform.position, Color.white, 0.5f);
                hitPoint.SetActive(true);

                hitPoint.transform.position = targets[0].transform.position;
                Vector3 temp = hitPoint.transform.position;
                temp.z -= 1f;
                hitPoint.transform.position = temp;

                lineRenderer.enabled = true;
                
                Vector3 hitPos = (targets[0].transform.position -transform.position)*1.9f;
                hitPos.z -= 1;
                lineRenderer.SetPosition(1, hitPos);
            }
            else
            {
                GameObject temp = Instantiate(bulletPref, transform.position, Quaternion.identity) as GameObject;
                temp.GetComponent<Bullet>().DeclareTarget(targets[0].gameObject);
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

        if (health <=0)
        {
            Destroy(this.gameObject);
            grid.GetComponent<NodeGrid>().ClearTile(IDpos);
            
        }
        //scales the circle with the range of the turret.
        fieldImage.transform.localScale = new Vector3(range, range, 0f);
        Bar();
    }
}
