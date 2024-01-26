using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasarCan : MonoBehaviour
{
    
    public GameObject ebonar;
    public GameObject yaratýkMermi;
    public GameObject yaratýk2Mermi;
    //public GameObject yaratýk3Mermi;
    //public GameObject yaratýk4Mermi;
    public GameObject yaratýkRight;
    public GameObject yaratýk2Right;
    //public GameObject yaratýk3Right;
    //public GameObject yaratýk4Right;
    private float tekrarSaniyesi = .75f;
    
    public float yaratýkAtýsHýzý = 2f;
    Yaratýk1CanHasar yaratýk1CanHasar;
    Yaratýk2CanHasar yaratýk2CanHasar;
    //Yaratýk3CanHasar yaratýk3CanHasar;
    //Yaratýk4CanHasar yaratýk4CanHasar;
    public bool ateþEdiyormu;
    Sounds sounds;
    

    void Start()
    {
        yaratýk1CanHasar = FindAnyObjectByType<Yaratýk1CanHasar>();
        yaratýk2CanHasar = FindAnyObjectByType<Yaratýk2CanHasar>();
        //yaratýk3CanHasar = FindAnyObjectByType<Yaratýk3CanHasar>();
        //yaratýk4CanHasar = FindAnyObjectByType<Yaratýk4CanHasar>();
        sounds = FindAnyObjectByType<Sounds>(); 

  
        InvokeRepeating("YaratýkMermi2FNC", 0f, tekrarSaniyesi);
        InvokeRepeating("YaratýkMermiFNC", 0f, tekrarSaniyesi);  
        
        
    }


    void YaratýkMermiFNC()
    {
        if (yaratýkRight!=null && yaratýk1CanHasar.distanceArea)
        {
            GameObject YaratýkMermi = Instantiate(yaratýkMermi, yaratýkRight.transform.position, yaratýkRight.transform.rotation);
            Rigidbody2D yaratýkMermiRigidbody = YaratýkMermi.GetComponent<Rigidbody2D>();


            Vector2 ebonarKonum = new Vector2(ebonar.transform.position.x, ebonar.transform.position.y);
            Vector2 hareketYönü = ebonarKonum - new Vector2(YaratýkMermi.transform.position.x, YaratýkMermi.transform.position.y);
            yaratýkMermiRigidbody.velocity = hareketYönü.normalized * yaratýkAtýsHýzý * 10;
            
        }
            
   
    }
    void YaratýkMermi2FNC()
    {
        if (yaratýk2Right!=null &&yaratýk2CanHasar.distanceArea)
        {
            GameObject Yaratýk2Mermi = Instantiate(yaratýk2Mermi, yaratýk2Right.transform.position, yaratýk2Right.transform.rotation);
            Rigidbody2D yaratýk2MermiRigidbody = Yaratýk2Mermi.GetComponent<Rigidbody2D>();


            Vector2 ebonarKonum = new Vector2(ebonar.transform.position.x, ebonar.transform.position.y);
            Vector2 hareketYönü = ebonarKonum - new Vector2(Yaratýk2Mermi.transform.position.x, Yaratýk2Mermi.transform.position.y);
            yaratýk2MermiRigidbody.velocity = hareketYönü.normalized * yaratýkAtýsHýzý * 10;
        }
            
          
    }
    //void YaratýkMermi3FNC()
    //{
    //    if (yaratýk3Right!=null && ateþEdiyormu==true  )
    //    {
    //        GameObject Yaratýk3Mermi = Instantiate(yaratýk3Mermi, yaratýk3Right.transform.position, yaratýk3Right.transform.rotation);
    //        Rigidbody2D yaratýk2MermiRigidbody = Yaratýk3Mermi.GetComponent<Rigidbody2D>();


    //        Vector2 ebonarKonum = new Vector2(ebonar.transform.position.x, ebonar.transform.position.y);
    //        Vector2 hareketYönü = ebonarKonum - new Vector2(Yaratýk3Mermi.transform.position.x, Yaratýk3Mermi.transform.position.y);
    //        yaratýk2MermiRigidbody.velocity = hareketYönü.normalized * yaratýkAtýsHýzý * 10;
    //    }
            
          
    //} 
    //void YaratýkMermi4FNC()
    //{
    //    if (yaratýk4Right!=null && ateþEdiyormu==true )
    //    {
    //        GameObject Yaratýk4Mermi = Instantiate(yaratýk4Mermi, yaratýk4Right.transform.position, yaratýk4Right.transform.rotation);
    //        Rigidbody2D yaratýk2MermiRigidbody = Yaratýk4Mermi.GetComponent<Rigidbody2D>();


    //        Vector2 ebonarKonum = new Vector2(ebonar.transform.position.x, ebonar.transform.position.y);
    //        Vector2 hareketYönü = ebonarKonum - new Vector2(Yaratýk4Mermi.transform.position.x, Yaratýk4Mermi.transform.position.y);
    //        yaratýk2MermiRigidbody.velocity = hareketYönü.normalized * yaratýkAtýsHýzý * 10;
    //    }
            
          
    //}
  

    


   
}
