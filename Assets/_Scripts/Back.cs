using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour
{

    public GameObject HowToPlay;

    public void menu(GameObject goTomenu)
    {
        goTomenu.SetActive(true);
        HowToPlay.SetActive(false);
    }
}
