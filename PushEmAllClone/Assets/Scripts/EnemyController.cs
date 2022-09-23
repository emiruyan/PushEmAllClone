using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //GameArea küçük olduğu için NavMesh kullanmıyoruz.
    [SerializeField] private float attackRange;//Enemy'nin atak mesafesi
    [SerializeField] private float moveSpeed;
    private float distance;//Enemy ile Player arasındaki mesafe
    private GameObject player;
    private Vector3 temp;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");//Tag'ı Player olanı bul
    }

    private void Update()
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
}
