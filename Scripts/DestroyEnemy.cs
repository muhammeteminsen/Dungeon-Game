using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Yaratýk") || collision.gameObject.CompareTag("Yaratýk2") || collision.gameObject.CompareTag("YetenekGeliþtirme") || collision.gameObject.CompareTag("CheckPoint"))
        {
            return;
        }
        else
        {
            Destroy(GameObject.FindWithTag("YaratýkMermi"));
            Destroy(GameObject.FindWithTag("YaratýkMermi2"));

        }
    }
}
