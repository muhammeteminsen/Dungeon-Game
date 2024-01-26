using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBarFeedBack : MonoBehaviour
{
    public static Animator healthBar;
    void Start()
    {
        healthBar=GetComponent<Animator>();
    }

   
}
