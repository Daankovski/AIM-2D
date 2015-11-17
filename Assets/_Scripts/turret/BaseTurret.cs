﻿using UnityEngine;
using System.Collections;
public class BaseTurret : Health {


    private int ID;
    [SerializeField]
    private float resetTime;
    [SerializeField]
    private float restTimeBoost;

    [SerializeField]
    private float range = 4f;
    [SerializeField]
    private float rangeBoost = 1f;

    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private int damageBoost = 10;

    private GameObject fieldImage;
    private SpriteRenderer fieldsprite;

    [SerializeField]
    private int upgradeLvl = 1;
    private int maxLvl = 5;
    

    // Use this for initialization
    void Start () {
        
        fieldImage = transform.FindChild("field").gameObject;
        fieldsprite = fieldImage.GetComponent<SpriteRenderer>();
        fieldsprite.color = new Color(1f, 1f, 1f, 0.0f);
        //begins with shoot loop.
        StartCoroutine(Shoot()); 
	}

    public void SetID(int value)
    {
        ID = value;
        Debug.Log
    }
    void UpgradeTurret()
    {
        range += rangeBoost;
        resetTime += restTimeBoost;
        damage += damageBoost;
    }
	IEnumerator Shoot()
    {
        //checks all targets within the range
        Collider2D[] targets = Physics2D.OverlapCircleAll(this.transform.position, range, 1 << LayerMask.NameToLayer("enemy"));
        if (targets.Length != 0)
        {
            //laser or projectile
            Debug.DrawLine(this.transform.position, targets[0].transform.position, Color.white,0.5f);

            //hurts the target
            targets[0].GetComponent<BaseEnemy>().Damage(damage);

        }
        //waits for an amount of time.
        yield return new WaitForSeconds(resetTime);
        StartCoroutine(Shoot());
    }
    void OnMouseEnter()
    {
        fieldsprite.color = new Color(1f, 1f, 1f, 0.3f);
    }
    void OnMouseExit()
    {
        fieldsprite.color = new Color(1f, 1f, 1f, 0.0f);
    }
    void Update () {
        
        //scales the circle with the range of the turret.
        fieldImage.transform.localScale = new Vector3(range, range, 0f);
        Bar();
    }
}
