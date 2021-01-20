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
    public bool InventoryDisplay = false; //Idk why it displays an error here?:D
    // Start is called before the first frame update
    // public PlayerMovement Player;
    // public bool PlayerGravity = false;

    // public void SetGravity(){
    //     if(PlayerGravity == false){
    //         PlayerGravity = true;
    //         Player.GravityBoost();
    //     } else {
    //        PlayerGravity = false;
    //        Player.resetGravityBoost();
    //     }
    // }

    
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.B)){
            showhideInventory();
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            showhideMenu();
        }

        // if (Input.GetKeyDown(KeyCode.G)){
        //     SetGravity();
        // }
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
        } else {
            EscMenu.gameObject.SetActive(false);
            print("You have closed the Inventory.");
            MenuDisplay = false;
            Cursor.visible = false;
        }
    }
    public void showhideInventory(){
        if(InventoryDisplay == false && MenuDisplay == false){
            InventoryAll.gameObject.SetActive(true);
            print("You have opened the Inventory.");
            InventoryDisplay = true;
            Cursor.visible = true;  //Make the cursor visible
        } else if (InventoryDisplay == true && MenuDisplay == false){
            InventoryAll.gameObject.SetActive(false);
            print("You have closed the Inventory.");
            InventoryDisplay = false;
            Cursor.visible = false;
        }
    }

    public void backToMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
}
