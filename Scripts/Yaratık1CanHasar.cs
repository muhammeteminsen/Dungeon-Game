using BarthaSzabolcs.Tutorial_SpriteFlash;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Yaratık1CanHasar : MonoBehaviour
{
    public float yaratıkCan;

    public GameObject yaratıkRight;
    public GameObject yaratıkLeft;
    public GameObject yaratık;
    public GameObject ebonar;
    public GameObject anahtar;
    

    private float distance;
    private float dynamicDistance = 10;
    public bool distanceArea;
    public float speed = 3f;

    private Animator _enemy1Animator;
    EbonarAteşEtme EbonarHit;

    public ParticleSystem _enemy1DeadEffect;
    public ParticleSystem _hitEffect;
    YetenekGeliştirme yetenekGeliştirme;
    CamShake camShake;
    Sounds sounds;
    HasarCan hasarCan;

    public Rigidbody2D rigidbody2;

    void Start()
    {
        yaratıkCan = 100;

        
        //yaratıkLeft.GetComponent<SpriteRenderer>().enabled = true;
        //yaratıkRight.GetComponent<SpriteRenderer>().enabled = false;
        _enemy1Animator = GetComponent<Animator>();
        yetenekGeliştirme = FindAnyObjectByType<YetenekGeliştirme>();
        camShake = FindAnyObjectByType<CamShake>();
        sounds = FindAnyObjectByType<Sounds>();
        hasarCan = FindAnyObjectByType<HasarCan>();

    }
    public void DestroyEnemy()
    {
        Destroy(gameObject);
        Instantiate(_enemy1DeadEffect, transform.position, Quaternion.identity);
        Instantiate(anahtar, transform.position, transform.rotation);
        yetenekGeliştirme.YetenekObjeOluşturmaFNC();
        camShake.TriggerShake();
        
        sounds.yaratıkDeadSound.Play();
        

    }

    

    private void OnTriggerEnter2D(Collider2D temas)
    {
        
        if (temas.gameObject.CompareTag("Yaratık2"))
        {
            rigidbody2.constraints = RigidbodyConstraints2D.FreezeAll;
            rigidbody2.constraints = RigidbodyConstraints2D.None;
        }
        if (temas.gameObject.tag == "EbonarMermi")
        {
            Instantiate(_hitEffect, transform.position, Quaternion.identity);
            yaratıkCan -= EbonarAteşEtme._ebonarHit;
            _enemy1Animator.SetBool("!hit", true);
            sounds.yaratıkDamageSound.Play();
            camShake.TriggerShake();
            

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _enemy1Animator.SetBool("!hit", false);
        
    }
    IEnumerator rb2Stop() 
    {
        yield return new WaitForSeconds(.1f);
        rigidbody2.constraints = RigidbodyConstraints2D.None;
    }
    void Update()
    {
        Debug.Log(yaratıkCan);
        
        Vector2 ebonarKonum = ebonar.transform.position;
        Vector2 yaratık1Konum = this.transform.position;
        if (yaratıkCan <= 0)
        {
            _enemy1Animator.SetBool("dead", true);
            
        }

        if (ebonarKonum.x <= yaratık1Konum.x)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (distanceArea)
        {
            dynamicDistance = 1000;
            
            
        }



        distance = Vector2.Distance(ebonar.transform.position, transform.position);

        if (distance <= dynamicDistance)
        {
            distanceArea = true;
            transform.position = Vector2.MoveTowards(this.transform.position, ebonar.transform.position, speed * Time.deltaTime);
            _enemy1Animator.SetBool("hit", true);
            _enemy1Animator.SetBool("ıdle", false);
            hasarCan.ateşEdiyormu=true;
            
        }
       
        
        else
        {
            
            
            _enemy1Animator.SetBool("hit", false);
            _enemy1Animator.SetBool("ıdle", true);
        }
    }

}
