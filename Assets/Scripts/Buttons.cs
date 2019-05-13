using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Sprite muteon, muteoff;
    private bool off = true;

   private void Start()
    {
        if(PlayerPrefs.GetString("mute")=="on")//проверяем состояние кнопки
        {
            GetComponent<SpriteRenderer>().sprite = muteon;
            GameObject.Find("music").GetComponent<AudioSource>().Pause();
            off = false;
        }else
        {
            if (PlayerPrefs.GetString("mute") == "off")
            {
                GetComponent<SpriteRenderer>().sprite = muteoff;
                GameObject.Find("music").GetComponent<AudioSource>().Play();
                off = true;
            }
        }


    }
    private void OnMouseDown()
    {
       
        if(off==true)
        {
            PlayerPrefs.SetString("mute", "on");
            GetComponent<SpriteRenderer>().sprite = muteon;
            GameObject.Find("music").GetComponent<AudioSource>().Pause();
            off = false;
        }else
        {
            if(off==false)
            {
                PlayerPrefs.SetString("mute", "off");
                GetComponent<SpriteRenderer>().sprite = muteoff;
                GameObject.Find("music").GetComponent<AudioSource>().Play();
                off = true;
            }
        }
       
    }
}
