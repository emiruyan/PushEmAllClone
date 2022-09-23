using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    
    //GameArea küçük olduğu için NavMesh kullanmıyoruz.
    [SerializeField] private float attackRange;//Enemy'nin atak mesafesi
    [SerializeField] private float moveSpeed;//Enemy'nin hareket hızı
    [SerializeField] private float forcePower;//itme gücü
    private float minHeight = -1;//Enemy'minimum ölüm pozisyonu
    
    private float distance;//Enemy ile Player arasındaki mesafe
    private GameObject player;
    private Vector3 temp;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");//Tag'ı Player olanı bul
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        EnemyMovement();
        EnemyDeath();
    }

    private void EnemyDeath()
    {
        if (transform.position.y <= minHeight)
        {
            Debug.Log("Enemy Dead");
        }
    }

    private void EnemyMovement()
    {
        temp = player.transform.position;//player transformunu temp'e atadık
        temp.y = transform.position.y;//temp'in y'sini eşitledik
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
        //enemy ile player arasındaki mesafeyi aldık ve distance değişkenine atadık

        if (distance <= attackRange)//distance attackRange küçük eşit ise;
        {
            transform.LookAt(temp);//Enemy direk olarak Player'a bakıyor
            transform.Translate(Vector3.forward * moveSpeed*Time.deltaTime);//Enemy hareket işlemi Translate ile olacak
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pole"))//Çarpan objenin tag'ı "Pole" ise;
        {
            if ( collision.gameObject.GetComponent<PoleController>().GetShot() == true)
            { 
                rb.AddForce(-transform.forward* forcePower);//Player'a geriye doğru bir güç uygulasın
            }

           
        }
    }
}
