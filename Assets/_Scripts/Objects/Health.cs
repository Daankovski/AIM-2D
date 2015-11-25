using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    [SerializeField]
    private float f_baseLives = 100f;
    private GameObject healthBar;
    private float alpha = 1;

    void Start () {
        //haalt de healthbar object in de child.
        healthBar = transform.FindChild("health").gameObject;
    }

    public float i_Lives
    {
        get
        {
            return f_baseLives;
        }
        set
        {
            f_baseLives = value;
        }
    }
    
    public void Damage(float damagevalue)
    {
        //als het object aan schade lijdt, wordt de health bar ge weergeeft en wordt de health vermindert, 
        //ook checkt ie of het object 0 helath heeft.
        f_baseLives -= damagevalue;
        alpha = 1;
        if(healthBar != null)
        {
            healthBar.transform.localScale = new Vector3(f_baseLives / 50, 2, 1f);
        }
        
        if (f_baseLives <= 0)
        {
            StartCoroutine(Death());
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.1f);
        if(this.gameObject.tag != "enemy")
        {
            Destroy(this.gameObject);
        }
        
    }
    
    void Update()
    {
        //de rede waarom de statements van de bar niet in de update staan, is zodat de child scripts deze ook in haar eigen update functie
        //kan uitvoeren.
        Bar();
    }
    public void Bar () {
        alpha -= 0.01f;
        healthBar = transform.FindChild("health").gameObject;
        healthBar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
    }
}
