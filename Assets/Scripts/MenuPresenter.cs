using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPresenter : MonoBehaviour {
    public GameObject menu;
    private bool isOpen = false;
    void Start(){
        menu.SetActive(false);
    }
    public void toggleMenu() {
        isOpen = !isOpen;
        menu.SetActive(isOpen);
    }
}
