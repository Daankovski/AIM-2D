using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public void HowToPlay(GameObject howToPlay){
		howToPlay.SetActive (true);
	}

	public void ChangeToScene(int sceneToChangeTo){
		Application.LoadLevel (sceneToChangeTo);
	}
	void Update (){
		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit ();
		}
	}
}