using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet2D : MonoBehaviour
{
    void Start()
    {
        // уничтожить объект по истечению указанного времени (секунд), если пуля никуда не попала
        Destroy(gameObject, 10);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!coll.isTrigger) // чтобы пуля не реагировала на триггер
        {
            switch (coll.tag)
            {
                case "Enemy":
                    // что-то..
                    //тут должке быть скрипт передачи данных в enemy
                    break;
                case "Enemy_2":
                    // что-то еще...
                    break;
            }

            Destroy(gameObject);
        }
    }
}
