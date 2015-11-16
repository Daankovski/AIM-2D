using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
    private GameObject ObjFlag;

    private Player scr_player;
    [SerializeField]
    private bool isAbleToPickup = false;


    // Getters & Setters
        public bool AbleToPickUp {
            get {
                return isAbleToPickup;
            }
            set {
                isAbleToPickup = value;
            }
        }

    //

	// Use this for initialization
	void Start () {
        scr_player = GetComponent<Player>();
        ObjFlag = GameObject.Find("Flag");
	}

	
	// Update is called once per frame
	void FixedUpdate () {
	    
	}

    void OnTriggerEnter2D(Collision2D other)
    {

    }
}
