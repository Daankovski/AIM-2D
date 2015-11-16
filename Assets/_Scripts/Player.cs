using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float f_speed = 5f;
    private GameObject ObjPlayer;
    private GameObject ObjFlag;
    private Lives scr_lives;
    private Flag scr_Flag;

	void Start () {
        ObjPlayer = GameObject.Find("Player");
        ObjFlag = GameObject.Find("Flag");

        scr_lives = ObjPlayer.GetComponent<Lives>();
        scr_Flag = ObjFlag.GetComponent<Flag>();

        // Variables
        scr_lives.i_Armour = 50;
        //
	}

    void FixedUpdate () {
        Movement();
        CarryingObject();
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

    void CarryingObject() {
        if (scr_Flag._isCarrying)
        {
            f_speed = .5f;
        }
        else {
            f_speed = 5f;
        }
    }
}

