using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public float health =100;
    private GameObject healthBar;
    private float alpha = 1;

    void Start () {
        healthBar = transform.FindChild("health").gameObject;

    }

    public void Damage(int damagevalue)
    {
        
        
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
        yield return new WaitForSeconds(1f);
        if(this.gameObject != null && this.gameObject.tag != "GridObject")
        {
            Destroy(this.gameObject);
        }
        
    }
    
    void Update()
    {
        Bar();
    }
    public void Bar () {
        alpha -= 0.01f;
        healthBar = transform.FindChild("health").gameObject;
        healthBar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
    }
}
