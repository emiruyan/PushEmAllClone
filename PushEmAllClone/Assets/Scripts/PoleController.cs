using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleController : MonoBehaviour
{
    private Touch touch;
    private bool isTouched;
    private bool isShot;


    private void Update()
    {
        if (Input.touchCount > 0 )//touchCount 0 dan küçük ise;
        {
            touch = Input.GetTouch(0); //ilk Touch'u(Ekrana ilk dokunuşu) alsın 
            isTouched = true;
        } 

        if (isTouched == true)
        {
            if (touch.phase == TouchPhase.Ended)//Dokunma işlemi bittiyse
            {
                StartCoroutine(CancelShot());
                isTouched = false;
            }
        }
    }

    public bool GetShot()
    {
        return isShot;
    }
    
    IEnumerator CancelShot()
    {
        isShot = true;
        yield return new WaitForSeconds(0.8f);
        isShot = false;
    }
}
