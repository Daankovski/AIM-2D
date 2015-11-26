using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private float f_speed = 5f;
    [SerializeField]
    private float i_leechTimer = 0;
    private GameObject ObjPlayer;
    private GameObject ObjFlag;
    private Health scr_Health;
    private Flag scr_Flag;

	void Start () {
        ObjPlayer = GameObject.Find("Player");
        ObjFlag = GameObject.Find("Flag");
        ObjFlag = GameObject.Find("flag");


        scr_Health = ObjPlayer.GetComponent<Health>();
        scr_Flag = ObjFlag.GetComponent<Flag>();

        }

    void Update() {

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
            scr_Health.maxHealth -= 5 ;
        }
    }

    void CarryingObject() {
        if (scr_Flag._isCarrying)
        {

            f_speed = .7f;
            if (i_leechTimer >= 10)
            {
                i_leechTimer = 0;
                scr_Health.maxHealth -= .5f;            }
            f_speed = 1.5f;
            if (i_leechTimer >= 10 && ObjPlayer != null)
            {
                i_leechTimer = 0;
                //scr_Health.maxHealth -= .5f;
                scr_Health.Damage(0.5f);
            }
            else {
                i_leechTimer ++;
            }
        }
        else {
            f_speed = 5f;
        }
    }
}

