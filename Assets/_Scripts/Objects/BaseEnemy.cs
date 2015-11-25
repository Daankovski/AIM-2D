﻿using UnityEngine;
using System.Collections;

public class BaseEnemy : Health {

    public Transform target;
    private GameObject waveManager;
    public float speed;
    public bool isAttacking = false;
    [SerializeField]
    private float damage = 10;

    private float scaleX;
    
    void Start () {
        
        Debug.Log(currentHealth);
        //finds the target called flag.
        target = GameObject.Find("flag").transform;
        scaleX = transform.localScale.x;
        waveManager = GameObject.Find("/UI panels/nextwave");
        damage += waveManager.GetComponent<WaveManager>().waveCounter;
        speed += waveManager.GetComponent<WaveManager>().waveCounter / 10f;
        maxHealth += waveManager.GetComponent<WaveManager>().waveCounter * 10f;

        currentHealth = maxHealth;
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
        if(target !=  null)
        {

            if (target.transform.position.x > transform.position.x)
            {
                
                transform.localScale = new Vector3(-scaleX, transform.localScale.y, 1f);

            }
            else
            {
                transform.localScale = new Vector3(scaleX, transform.localScale.y, 1f);
                //float x = transform.localScale.x;
                //transform.localScale = new Vector3(x, transform.localScale.y, 1f);
            }
            
        }
        
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
            waveManager.GetComponent<WaveManager>().coinCounter += Mathf.Ceil( damage * speed /2);
            waveManager.GetComponent<WaveManager>().UpdateCoinUI();
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