using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EbonarAteşEtme : MonoBehaviour
{
    public GameObject mermiPrefab;
    public Transform mermiCıkısYeri;
    [SerializeField] private float atısHızı;
    public GameObject ebonar;
    public static int _ebonarHit=10;
    

    [Range(0,5)]
    [SerializeField] private float _hitTime=.1f;
    float _hitCount;
    Sounds sounds;


    private void Start()
    {
        sounds = FindAnyObjectByType<Sounds>();
    }


    void Update()
    {
        
        if ((Input.GetButton("Fire1") && Time.time>_hitCount) || (Input.GetButtonDown("Fire1") && Time.time > _hitCount))
        {
            _hitCount = Time.time + _hitTime;
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 firePointPosition = new Vector2(mermiCıkısYeri.position.x, mermiCıkısYeri.position.y);
            Vector2 direction = (mousePosition - firePointPosition).normalized;

            GameObject mermi = Instantiate(mermiPrefab, mermiCıkısYeri.transform.position, mermiCıkısYeri.transform.rotation);
            Rigidbody2D mermiRigidbody = mermi.GetComponent<Rigidbody2D>();


            mermiRigidbody.velocity = new Vector2(direction.x, direction.y) * atısHızı * 10;
            sounds.ebonaraHitSound.Play();
            
            
            

        }

        Destroy(GameObject.FindWithTag("EbonarMermi"), 1f);


    }
}
