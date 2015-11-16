using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
    private GameObject ObjFlag;
    private GameObject ObjPlayer;

    [SerializeField]
    private bool isPickedUp = false;

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
	}

	void FixedUpdate () {
        if (isPickedUp) {
            ObjFlag.transform.position = new Vector3(ObjPlayer.transform.position.x, ObjPlayer.transform.position.y, 0f);
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPickedUp)
            {
                isPickedUp = false;
            }
            else {
                isPickedUp = true;
            }
        }
    }
}
