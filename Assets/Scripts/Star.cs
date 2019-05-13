using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    public GameObject Map;

    [SerializeField]
    public int level;

    public void onClicStart()
    {
        if (Map.activeSelf == false)
        {
            Map.SetActive(true);
        }
        else
        { 
            Map.SetActive(false);
        }
    }
    public void onClicChangeLevel()
    {
        SceneManager.LoadScene(level);
    }

}
