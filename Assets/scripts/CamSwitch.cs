using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
        if(Input.GetKeyDown("2"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
