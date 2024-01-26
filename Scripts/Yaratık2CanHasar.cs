using BarthaSzabolcs.Tutorial_SpriteFlash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yaratık2CanHasar : MonoBehaviour
{
    public float yaratık2Can;
    public float distance;
    private float dynamicDistance = 10;
    public bool distanceArea;
    public float speed = 3f;
    public GameObject ebonar;

    public GameObject yaratık2Right;
    public GameObject yaratık2Left;
    public GameObject yaratık2;

    public Animator _enemy2Animation;

    YetenekGeliştirme yetenekGeliştirme;
    CamShake camShake;
    Sounds sounds;
    public Rigidbody2D rb2D;

    public ParticleSystem _enemy2DeadEffect;
    public ParticleSystem _hitEffect2;

   

    void Start()
    {
        yaratık2Can = 100;
        _enemy2Animation = GetComponent<Animator>();
        yetenekGeliştirme = FindAnyObjectByType<YetenekGeliştirme>();
        camShake = FindAnyObjectByType<CamShake>();
        sounds = FindAnyObjectByType<Sounds>();
        
    }

    public void DestroyEnemy2()
    {
        Destroy(gameObject);
        Instantiate(_enemy2DeadEffect, transform.position, Quaternion.identity);
        yetenekGeliştirme.YetenekObjeOluşturmaFNC();
        camShake.TriggerShake();
        sounds.yaratıkDeadSound.Play(); 
        
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        if (!temas.gameObject.CompareTag("EbonarMermi"))
        {
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (temas.gameObject.tag == "EbonarMermi")
        {
            yaratık2Can -= EbonarAteşEtme._ebonarHit;
            _enemy2Animation.SetBool("!hit", true);
            Instantiate(_hitEffect2, transform.position, Quaternion.identity);
            camShake.TriggerShake();
            sounds.yaratıkDamageSound.Play();
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _enemy2Animation.SetBool("!hit", false);
        if (!collision.gameObject.CompareTag("EbonarMermi"))
        {
            rb2D.constraints = RigidbodyConstraints2D.None;
        }
    }

    void Update()
    {
        Debug.Log(yaratık2Can);
        distance = Vector2.Distance(ebonar.transform.position, transform.position);
        
        Vector2 ebonarKonum = ebonar.transform.position;
        Vector2 yaratık2Konum = this.transform.position;

        if (yaratık2Can <= 0)
        {
            _enemy2Animation.SetBool("dead", true);
        }
       

        if (ebonarKonum.x <= yaratık2Konum.x)
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
            Debug.Log("Girdi");
        }

        if (distance <= dynamicDistance)
        {
            distanceArea = true;
            transform.position = Vector2.MoveTowards(this.transform.position, ebonar.transform.position, speed * Time.deltaTime);
            _enemy2Animation.SetBool("hit", true);
            _enemy2Animation.SetBool("ıdle", false);
            
        }
        else
        {
            _enemy2Animation.SetBool("hit", false);
            _enemy2Animation.SetBool("ıdle", true);
        }
    }

   

    
}
