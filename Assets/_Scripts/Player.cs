using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float f_speed = 5f;
    private GameObject ObjPlayer;
    private Lives scr_lives;
    private Flag scr_flag;

    [SerializeField]
    private bool isCarrying = false;
    
	
	void Start () {
        ObjPlayer = GameObject.Find("Player");

        scr_lives = ObjPlayer.GetComponent<Lives>();

        // Variables
        scr_lives.i_Armour = 50;
        //
	}

    void FixedUpdate () {
        Movement();
    }


    // Player Movement
    void Movement() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, y, 0);
        transform.Translate(movement * f_speed * Time.deltaTime);
    }
    //

    // Collision
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy") {
            scr_lives.i_Lives -= 5 ;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Triggerd");
        if (other.gameObject.tag == "flag") {
            scr_flag.AbleToPickUp = true;

            if (scr_flag.AbleToPickUp = true && Input.GetKey(KeyCode.Space)) {
                Debug.Log("HALLO");
            }
        }
        
        
    }
    //

}

