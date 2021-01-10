using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject InventoryAll;
    public bool InventoryDisplay = false; //Idk why it displays an error here?:D
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.B)){
            showhidePanel();
        }
    }

    public void showhidePanel(){
        if(InventoryDisplay == false){
            InventoryAll.gameObject.SetActive(true);
            print("You have opened the Inventory.");
            InventoryDisplay = true;
        } else {
            InventoryAll.gameObject.SetActive(false);
            print("You have closed the Inventory.");
            InventoryDisplay = false;
        }
    }
}
