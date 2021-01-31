using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject InventoryAll;
    public GameObject EscMenu;
    public bool MenuDisplay = false;
    [SerializeField] private bool InventoryDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        //Cursor.visible = true;
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.B)){
            showhideInventory();
        }

        if (Input.GetKeyDown(KeyCode.R)){
            showhideMenu();
        }
    }

    public void closeAllInterfaces(){
        InventoryAll.gameObject.SetActive(false);
        InventoryDisplay = false;
    }
    public void showhideMenu(){
         if(MenuDisplay == false){
            EscMenu.gameObject.SetActive(true);
            print("You have opened the Inventory.");
            MenuDisplay = true;
            closeAllInterfaces();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } else {
            EscMenu.gameObject.SetActive(false);
            print("You have closed the Inventory.");
            MenuDisplay = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void showhideInventory(){
        if(InventoryDisplay == false && MenuDisplay == false){
            openInventory();
        } else if (InventoryDisplay == true && MenuDisplay == false){
            closeInventory();
            setInventoryDisplay(false);
        }
    }

    public void closeInventory(){
        InventoryAll.gameObject.SetActive(false);
        print("You have closed the Inventory.");
        FindObjectOfType<GameManager>().InventoryDisplay = false; //closeInventory() is used as a button function so I need to access it in order to change the InventoryDisplay
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void openInventory(){            
        InventoryAll.gameObject.SetActive(true);
        print("You have opened the Inventory.");
        setInventoryDisplay(true);
        Cursor.visible = true;  //Make the cursor visible
        Cursor.lockState = CursorLockMode.None; 
    }

    public bool setInventoryDisplay(bool x){
        return InventoryDisplay = x;
    }

    public void backToMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
}
