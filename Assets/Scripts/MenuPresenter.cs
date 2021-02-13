using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPresenter : MonoBehaviour {
    public GameObject output;
    private IMenuPresenterReciever reciever;
    public GameObject menu;
    public Transform buttonContainer;
    public Button levelButtonPrefab;
    private bool isOpen = false;

    void Start(){
        reciever = output.GetComponent<IMenuPresenterReciever>();
        menu.SetActive(false);
        for(int i=0;i<reciever.numberOfLevels();i++){
            Button button = Instantiate(levelButtonPrefab);
            button.transform.parent = buttonContainer;
            int buttonNumber = i;
            button.onClick.AddListener(() => { pressedButton(buttonNumber); });
        }
    }
    public void pressedButton(int buttonNumber){
        Debug.Log("Pressed " + buttonNumber);
        reciever.loadLevel(buttonNumber);
        isOpen = false;
        menu.SetActive(false);
    }

    public void toggleMenu() {
        isOpen = !isOpen;
        menu.SetActive(isOpen);
    }
}

public interface IMenuPresenterReciever {
    int numberOfLevels();
    void loadLevel(int levelNumber);
}
