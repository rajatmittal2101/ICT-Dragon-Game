using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Medium : MonoBehaviour
{
    public GameObject left_Claw, fire_att;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip Clash_sound, Fire_sound, Dead_sound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Left_Claw_On()
    {
        left_Claw.SetActive(true);
    }

    void Left_Claw_Off()
    {  if (left_Claw.activeInHierarchy)
        {
            left_Claw.SetActive(true);
        }
     }


    void Fire_On()
    {
        fire_att.SetActive(true);
    }

    void Fire_Off()
    {
        if (fire_att.activeInHierarchy)
        {
            fire_att.SetActive(true);
        }
    }

    private void Clash_s()
    {
        audioSource.clip = Clash_sound;
        audioSource.Play();
    }

    void Death_sound()
    {
        audioSource.clip = Dead_sound;
        audioSource.Play();
    }

    void Fire_s()
    {
        audioSource.clip = Fire_sound;
        audioSource.Play();
    }

    void Game_over()
    {
        SceneManager.LoadScene("GameOver");
    }
}

