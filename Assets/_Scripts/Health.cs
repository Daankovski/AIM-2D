using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    [SerializeField]
    private float f_baseLives = 100f;
    private GameObject healthBar;
    private float alpha = 0;

    [SerializeField]
    private float f_baseArmour;

    public void Start () {
        //Damage(0);    
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

    public float i_Armour
    {
        get
        {
            return f_baseArmour;
        }
        set
        {
            f_baseArmour = value;
        }
    }

    public void Damage(int damagevalue)
    {
        
        healthBar = transform.FindChild("health").gameObject;
        healthBar.transform.localScale = new Vector3(f_baseLives/50, 2, 1f);
        f_baseLives -= damagevalue;
        alpha = 1;
        if(f_baseLives <= 0)
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
