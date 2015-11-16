using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

    [SerializeField]
    private int i_baseLives = 100;
    [SerializeField]
    private int i_baseArmour; 
    
    void Start () {
	    
	}

    //  Getters & Setters
        public int i_Lives {
            get {
                return i_baseLives;
            }
            set {
                i_baseLives = value;
            }
        }

        public int i_Armour {
            get {
                return i_baseArmour;
            }
            set {
                i_baseArmour = value;
            }
        }
    //
	
	void Update () {
        Death();
	}

    void Death() {
        if (i_baseLives <= 0) {
            Destroy(gameObject);
        }
    }
}
