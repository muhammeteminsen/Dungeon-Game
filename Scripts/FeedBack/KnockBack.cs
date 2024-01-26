using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockBackStrengh;
    public float knockBackDuration;

    Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void KnockBackFrom(Vector2 direction) 
    {
        Vector2 knockbackDirection = direction.normalized; 
        rb2D.AddForce(knockbackDirection*knockBackStrengh,ForceMode2D.Impulse);

        Invoke("StopKnockBack", knockBackDuration);
    }
    void StopKnockBack() 
    {
        rb2D.velocity = Vector2.zero;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EbonarMermi"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            GetComponent<KnockBack>().KnockBackFrom(knockbackDirection);
        }
    }
}
