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
            button.onClick.AddListener(pressedButton);
        }
    }
    public void pressedButton(){
        reciever.loadLevel();
    }

    public void toggleMenu() {
        isOpen = !isOpen;
        menu.SetActive(isOpen);
    }
}

public interface IMenuPresenterReciever {
    int numberOfLevels();
    void loadLevel();
}
