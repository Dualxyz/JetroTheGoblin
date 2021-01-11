﻿using System.Collections;
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.B)){
            showhideInventory();
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
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
        } else {
            EscMenu.gameObject.SetActive(false);
            print("You have closed the Inventory.");
            MenuDisplay = false;
        }
    }
    public void showhideInventory(){
        if(InventoryDisplay == false && MenuDisplay == false){
            InventoryAll.gameObject.SetActive(true);
            print("You have opened the Inventory.");
            InventoryDisplay = true;
        } else if (InventoryDisplay == true && MenuDisplay == false){
            InventoryAll.gameObject.SetActive(false);
            print("You have closed the Inventory.");
            InventoryDisplay = false;
        }
    }

    public void backToMainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
}
