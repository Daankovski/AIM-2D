using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
    private GameObject ObjFlag;
    private GameObject ObjPlayer;
    private Health scr_Health;

    [SerializeField]
    private int i_PickupCooldown = 0;

    [SerializeField]
    private bool isPickedUp = false;
    private bool isCooldown = false;

    // Getters & Setters
    public bool _isCarrying {
            get {
                return isPickedUp;
            }
            set {
                isPickedUp = value;
            }
        }    
    //
    
	void Start () {
        ObjPlayer = GameObject.Find("Player");
        ObjFlag = GameObject.Find("Flag");
        scr_Health = ObjFlag.GetComponent<Health>();
	}

	void FixedUpdate () {
        if (isPickedUp) {
            ObjFlag.transform.position = new Vector3(ObjPlayer.transform.position.x, ObjPlayer.transform.position.y, 0f);
        }
        if (!isCooldown)
        {
            i_PickupCooldown = 0;
        }
        else {
            if (i_PickupCooldown < 10)
            {
                i_PickupCooldown++;
            }
            else if (i_PickupCooldown == 10) {
                isCooldown = false;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            scr_Health.maxHealth -= 5;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPickedUp)
            {
                isPickedUp = true;
                isCooldown = false;
            }
            else {
                isPickedUp = false;
                isCooldown = true;
                
            }
        }
    }
}
