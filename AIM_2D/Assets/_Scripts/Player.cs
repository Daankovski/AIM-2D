using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private float f_xPos = 0f;
    private float f_yPos = 0f;
    private float speed = 0.1f;

    private float f_xRot = 0f;
    private float f_yRot = 0f;

    private GameObject player;

    void Start () {

       player = GameObject.Find("Cube");
	
	}
	
	void FixedUpdate () {

        player.transform.position = new Vector3(f_xPos, f_yPos, 0f);
        player.transform.eulerAngles = new Vector3(f_xRot, f_yRot, 0f);

        // Up & Down Movement
        if (Input.GetKey(KeyCode.W))
        {
            f_yPos += speed;
            f_xRot = 35f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            f_yPos -= speed;
            f_xRot = -35f;
        }
        else {
            f_xRot = 0f;
        }
        //

        // Left & Right Movement
        if (Input.GetKey(KeyCode.A))
        {
            f_xPos -= speed;
            f_yRot = -35f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            f_xPos += speed;
            f_yRot = 35f;
        }
        else {
            f_yRot = 0f;
        }
        //
        




       	
	}
}
