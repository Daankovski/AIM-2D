using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

    [SerializeField]
    private float f_baseLives = 100f;
    [SerializeField]
    private float f_baseArmour; 
    
    void Start () {
	    
	}

    //  Getters & Setters
        public float i_Lives {
            get {
                return f_baseLives;
            }
            set {
                f_baseLives = value;
            }
        }

        public float i_Armour {
            get {
                return f_baseArmour;
            }
            set {
                f_baseArmour = value;
            }
        }
    //
	
	void Update () {
        Death();
	}

    void Death() {
        if (f_baseLives <= 0) {
            Destroy(gameObject);
        }
    }
}
