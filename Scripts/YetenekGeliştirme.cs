using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetenekGeliştirme : MonoBehaviour
{
    public GameObject YetenekObje;
    private Yaratık1CanHasar yaratık1CanHasar;
    private Yaratık2CanHasar yaratık2CanHasar;

    public static bool birKereOluşturuldu = false;

    void Start()
    {

        yaratık1CanHasar = FindAnyObjectByType<Yaratık1CanHasar>();
        yaratık2CanHasar = FindAnyObjectByType<Yaratık2CanHasar>();


    }


    

    public void YetenekObjeOluşturmaFNC()
    {
        if (yaratık1CanHasar.yaratıkCan <= 0 && !birKereOluşturuldu)
        {
            if (yaratık1CanHasar.yaratık!=null)
            {
                Instantiate(YetenekObje, yaratık1CanHasar.yaratık.transform.position, Quaternion.identity);
                birKereOluşturuldu = true;
                Debug.Log("Oluşturuldu");
            }
           
            
            


        }
        if (yaratık2CanHasar.yaratık2Can <= 0 && !birKereOluşturuldu)
        {
            if (yaratık2CanHasar.yaratık2 != null)
            {
                Instantiate(YetenekObje, yaratık2CanHasar.yaratık2.transform.position, Quaternion.identity);
                Debug.Log("Oluşturuldu");
                birKereOluşturuldu = true;
            } 

        }


    }
}
