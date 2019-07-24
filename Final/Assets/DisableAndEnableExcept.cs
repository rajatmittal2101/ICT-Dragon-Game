using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisableAndEnableExcept : MonoBehaviour
{
    public GameObject player;
    public GameObject ground;
    public GameObject fly;

    public GameObject[] exceptions;

    public void DisableButtons()
    {

        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
      //  GameObject[] cpbutton = GameObject.FindGameObjectsWithTag("CPButton");
       // GameObject[] joystick = GameObject.FindGameObjectsWithTag("Joystick");
        

        foreach (GameObject g in buttons)
        {
            g.GetComponent<Button>().interactable = false;
        }

        foreach (GameObject g in exceptions)
        {
            g.GetComponent<Button>().interactable = true;
        }

       // foreach (GameObject g in cpbutton)
        {

         //   g.SetActive(false);

        }

       // foreach (GameObject g in joystick)
        {
           // g.GetComponent<Joystick>().enabled = false;

        }


        ground.SetActive(false);
        fly.SetActive(false);

    }

    public void EnableButtons()
    {

        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
       // GameObject[] cpbutton = GameObject.FindGameObjectsWithTag("CPButton");
       // GameObject[] joystick = GameObject.FindGameObjectsWithTag("Joystick");


        foreach (GameObject g in buttons)
        {

            g.GetComponent<Button>().interactable = true;
        }

      //  foreach (GameObject g in joystick)
        {
           // g.GetComponent<Joystick>().enabled = true;

        }

        if (player.GetComponent<PlayerMovement>().enabled == true)
        {
            ground.SetActive(true);
        }
        else
        {
            fly.SetActive(true);
        }

    }

}
