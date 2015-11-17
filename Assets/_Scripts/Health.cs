using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public float health =100;
    private GameObject healthBar;
    private float alpha = 0;
    public void Start () {
        //Damage(0);
        
    }
    
	public void Damage(int damagevalue)
    {
        
        healthBar = transform.FindChild("health").gameObject;
        healthBar.transform.localScale = new Vector3(health/50, 2, 1f);
        health -= damagevalue;
        alpha = 1;
        if(health <= 0)
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
