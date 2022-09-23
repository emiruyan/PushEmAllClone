using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float forcePower;//itme gücü
    private float minHeight = -1;
    private GameManager gm;


    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerDeath();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))//Çarpıştığımız objenin tag'ı "Enemy" ise;
        {
          rb.AddForce(-transform.forward* forcePower);//Player'a geriye doğru bir güç uygulasın
        }
    }

    private void PlayerDeath()
    {
        if (transform.position.y <= minHeight)//transform.position.y minHeight'ten küçük eşit ise;
        {
            gm.PlayerDead();//GameManager içinde ki PlayerDead fonksiyonunu çalıştır
        }
    }
}
