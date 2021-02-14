using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float dashSpeed; //speed of the dash
    [SerializeField] private float dashTime; //duration of the dash

    //REFERENCES
    ThirdPersonMovementScript1 playerMovScript;

    // Start is called before the first frame update
    void Start()
    {
        playerMovScript = GetComponent<ThirdPersonMovementScript1>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dash
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Dash());
        }

    }

    /// <summary>
    /// Give dash movement to Player
    /// </summary>
    /// <returns></returns>
    private IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            playerMovScript.moveDirection *= dashSpeed;
            playerMovScript.Move(playerMovScript.moveDirection);

            yield return null;
        }
    }
}
