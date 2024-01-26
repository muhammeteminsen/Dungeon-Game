using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [Header("Ebonar")]
    public AudioSource ebonarDamageSound;
    public AudioSource ebonaraHitSound;
    public AudioSource ebonarWalkSound;
    [Header("GameOver")]
    public AudioSource gameOverSound;
    [Header("Enemies")]
    public AudioSource yaratýkDamageSound;
    public AudioSource yaratýkHitSound;
    public AudioSource yaratýkDeadSound;
    [Header("GamePause")]
    public AudioSource gamePause;
    public AudioSource gameUnPause;
    [Header("MenuButtons")]
    public AudioSource menuButonClick;
    public AudioSource menuButonHover;
    [Header("Objects")]
    public AudioSource doorOpening;
    public AudioSource caseOpening;
    [Header("Skills")]
    public AudioSource skillTalent;
    [Header("Music")]
    public AudioSource fightMusic;
    public AudioSource backgroundMusic;
    public AudioSource gameMenuMusic;

    
   

    
    void Update()
    {
        
        
        
        
        
       
        
        menuButonClick.Stop();
        menuButonHover.Stop();
        
        
        
        
        
        
    }
}
