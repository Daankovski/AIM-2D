using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public float health =100;
    private GameObject healthBar;
    private float alpha = 1;

    void Start () {
        //haalt de healthbar object in de child.
        healthBar = transform.FindChild("health").gameObject;
    }

    public void Damage(int damagevalue)
    {
        //als het object aan schade lijdt, wordt de health bar ge weergeeft en wordt de health vermindert, 
        //ook checkt ie of het object 0 helath heeft.
        health -= damagevalue;
        alpha = 1;
        if(healthBar != null)
        {
            healthBar.transform.localScale = new Vector3(health / 50, 2, 1f);
        }
        
        if (health <= 0)
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
