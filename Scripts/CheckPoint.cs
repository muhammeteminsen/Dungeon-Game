using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Vector2[] checkPoints;
    public static Vector2 lastTransform;
    private EbonarAteþEtme ebonarAteþEtme;
    

    void Start()
    {
        ebonarAteþEtme = FindAnyObjectByType<EbonarAteþEtme>();

        
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.gameObject.CompareTag("Ebonar"))
        {

            lastTransform = ebonarAteþEtme.ebonar.transform.position;
            
            Debug.Log("Tamam");
        }
    }
}
