using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    private bool isText1 =true;
    public Npc npcScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (isText1 == true)
            {
                isText1 = false;
            }
            else
            {
                isText1 = true;
                npcScript.EndDialog = true;
            }
        }
      if(isText1==true)
        {
            text1.SetActive(true);
            text2.SetActive(false);
        }
        else
        {
            text1.SetActive(false);
            text2.SetActive(true);
        }
    }
}
