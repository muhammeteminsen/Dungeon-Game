using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Vector2[] checkPoints;
    public static Vector2 lastTransform;
    private EbonarAtežEtme ebonarAtežEtme;
    

    void Start()
    {
        ebonarAtežEtme = FindAnyObjectByType<EbonarAtežEtme>();

        
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.gameObject.CompareTag("Ebonar"))
        {

            lastTransform = ebonarAtežEtme.ebonar.transform.position;
            
            Debug.Log("Tamam");
        }
    }
}
