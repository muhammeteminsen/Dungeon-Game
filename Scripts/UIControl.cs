using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private EbonarAteþEtme ebonarAteþEtme;
    
    public GameObject _yetenekGeliþtirmeUI;
    public TextMeshProUGUI yetenekGeliþtirmeText;
    public TextMeshProUGUI saldýrýGücüText;
    public TextMeshProUGUI ZýrhText;
    public TextMeshProUGUI CanText;
    int saldýrýGücü;
    int zýrh;
    int can;
    bool _yetenekGeliþtirme;
    public GameObject gameOver;

    public Image originalHealthBar;
    public Sprite[] _healthBar;

    public Image enemy1HealthBar;
    public Image enemy2HealthBar;
    //public Image enemy2HealthBar1;
    //public Image enemy2HealthBar2;
    public float smoothspeed = 3f;



    public Button SaldýrýGücüButton;
    public Button ZýrhButton;
    public Button CanButton;


    int yetenekGeliþtirmeXPSaldýrý = 0;
    int yetenekGeliþtirmeXPCan = 0;
    int yetenekGeliþtirmeXPZýrh = 0;

    Sounds sounds;
    Yaratýk1CanHasar yaratýk1CanHasar;
    Yaratýk2CanHasar yaratýk2CanHasar;
    //Yaratýk3CanHasar yaratýk3CanHasar;
    //Yaratýk4CanHasar yaratýk4CanHasar;

    private void Start()
    {
        
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        ebonarAteþEtme = FindAnyObjectByType<EbonarAteþEtme>();
        sounds = FindAnyObjectByType<Sounds>();
        yaratýk1CanHasar = FindAnyObjectByType<Yaratýk1CanHasar>();
        yaratýk2CanHasar = FindAnyObjectByType<Yaratýk2CanHasar>();
        //yaratýk3CanHasar =  FindAnyObjectByType<Yaratýk3CanHasar>();
        //yaratýk4CanHasar =  FindAnyObjectByType<Yaratýk4CanHasar>();
        Time.timeScale = 1;
        _yetenekGeliþtirmeUI.SetActive(false);

        if (playerMovement.yetenekGeliþtirme >= 2 * 100)
            SaldýrýGücüButton.interactable = true;
        CanButton.interactable = true;

        if (playerMovement.yetenekGeliþtirme >= 4 * 100)
            ZýrhButton.interactable = true;



        EbonarAteþEtme._ebonarHit = PlayerPrefs.GetInt(nameof(EbonarAteþEtme._ebonarHit), 10);
        PlayerMovement._enemyHit = PlayerPrefs.GetInt(nameof(PlayerMovement._enemyHit), 20);
        playerMovement.ebonarCan = PlayerPrefs.GetInt(nameof(playerMovement.ebonarCan), 100);

        yetenekGeliþtirmeXPSaldýrý = PlayerPrefs.GetInt(nameof(yetenekGeliþtirmeXPSaldýrý), 0);
        yetenekGeliþtirmeXPZýrh = PlayerPrefs.GetInt(nameof(yetenekGeliþtirmeXPZýrh), 0);
        yetenekGeliþtirmeXPCan = PlayerPrefs.GetInt(nameof(yetenekGeliþtirmeXPCan), 0);

        Debug.Log(yetenekGeliþtirmeXPSaldýrý);
        Debug.Log(yetenekGeliþtirmeXPZýrh);
        Debug.Log(yetenekGeliþtirmeXPCan);
    }



    public void SaldýrýGücü()
    {
        EbonarAteþEtme._ebonarHit += 3;
        playerMovement.yetenekGeliþtirme -= 2 * 150;
        yetenekGeliþtirmeXPSaldýrý += 100;
        saldýrýGücü = EbonarAteþEtme._ebonarHit;
        
        sounds.skillTalent.Play();
    }
    public void Zýrh()
    {
        PlayerMovement._enemyHit -= 5;
        playerMovement.yetenekGeliþtirme -= 450;
        yetenekGeliþtirmeXPZýrh += 100;
        zýrh = PlayerMovement._enemyHit;
        
        sounds.skillTalent.Play();
    }
    public void Can()
    {
        playerMovement.ebonarCan += 4;
        playerMovement.yetenekGeliþtirme -= 2 * 150;
        yetenekGeliþtirmeXPCan += 100;
        can = playerMovement.ebonarCan;
       
        sounds.skillTalent.Play();
    }
    public void Veri() 
    {
        PlayerPrefs.SetInt(nameof(EbonarAteþEtme._ebonarHit), EbonarAteþEtme._ebonarHit);
        PlayerPrefs.SetInt(nameof(PlayerMovement._enemyHit), PlayerMovement._enemyHit);
        PlayerPrefs.SetInt(nameof(playerMovement.ebonarCan), playerMovement.ebonarCan);
        PlayerPrefs.SetInt(nameof(yetenekGeliþtirmeXPCan), yetenekGeliþtirmeXPCan);
        PlayerPrefs.SetInt(nameof(yetenekGeliþtirmeXPSaldýrý), yetenekGeliþtirmeXPSaldýrý);
        PlayerPrefs.SetInt(nameof(yetenekGeliþtirmeXPZýrh), yetenekGeliþtirmeXPZýrh);
    }
    public void YetenekGeliþtirýExýt()
    {
        _yetenekGeliþtirme = !_yetenekGeliþtirme;
        _yetenekGeliþtirmeUI.SetActive(_yetenekGeliþtirme);
    }




    public void TekrarDene()
    {
        SceneManager.LoadScene(playerMovement.sceneIndex);
        playerMovement.ebonarCan =50;
        
    }
    public void AnaEkranaDön()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.Save();
    }
    void Update()
    {
        if (yaratýk1CanHasar.yaratýk != null)
        {
            enemy1HealthBar.fillAmount = (float)yaratýk1CanHasar.yaratýkCan / 100;
        }
        if (yaratýk2CanHasar.yaratýk2 != null)
        {
            enemy2HealthBar.fillAmount = (float)yaratýk2CanHasar.yaratýk2Can / 100;
        }
        //if (yaratýk3CanHasar.yaratýk2 != null)
        //{
        //    enemy2HealthBar1.fillAmount = (float)yaratýk3CanHasar.yaratýk2Can / 100;
        //}
        //if (yaratýk4CanHasar.yaratýk2 != null)
        //{
        //    enemy2HealthBar2.fillAmount = (float)yaratýk4CanHasar.yaratýk2Can / 100;
        //}






        if (playerMovement.ebonarCan <= 0)
            originalHealthBar.sprite = _healthBar[0];


        if (playerMovement.ebonarCan > 15 && playerMovement.ebonarCan <= 30)
            originalHealthBar.sprite = _healthBar[1];

        if (playerMovement.ebonarCan > 30 && playerMovement.ebonarCan <= 45)
            originalHealthBar.sprite = _healthBar[2];

        if (playerMovement.ebonarCan > 45 && playerMovement.ebonarCan <= 60)
            originalHealthBar.sprite = _healthBar[3];

        if (playerMovement.ebonarCan > 60 && playerMovement.ebonarCan <= 75)
            originalHealthBar.sprite = _healthBar[4];

        saldýrýGücüText.text = saldýrýGücü.ToString();
        CanText.text = can.ToString();
        ZýrhText.text = zýrh.ToString();







        if (Input.GetKeyDown(KeyCode.Tab))
        {

            _yetenekGeliþtirme = !_yetenekGeliþtirme;
            _yetenekGeliþtirmeUI.SetActive(_yetenekGeliþtirme);

        }

        if (gameOver.activeSelf == true)
        {
            Time.timeScale = 0;
            sounds.gameOverSound.Play();
        }





        else if (!_yetenekGeliþtirme)
        {
            Time.timeScale = 1;
            ebonarAteþEtme.mermiCýkýsYeri.GetComponent<EbonarAteþEtme>().enabled = true;

        }
        else if (_yetenekGeliþtirme)
        {
            Time.timeScale = 0;
            ebonarAteþEtme.mermiCýkýsYeri.GetComponent<EbonarAteþEtme>().enabled = false;

        }


        saldýrýGücü = EbonarAteþEtme._ebonarHit;
        zýrh = PlayerMovement._enemyHit;
        can = playerMovement.ebonarCan;





        if (playerMovement.yetenekGeliþtirme >= 2 * 100)
            SaldýrýGücüButton.interactable = true;
        CanButton.interactable = true;

        if (playerMovement.yetenekGeliþtirme >= 4 * 100)
            ZýrhButton.interactable = true;


        if (playerMovement.yetenekGeliþtirme <= 0 * 100 || yetenekGeliþtirmeXPSaldýrý == 5 * 100 || playerMovement.yetenekGeliþtirme < 2 * 100 || EbonarAteþEtme._ebonarHit == 25)
        {
            SaldýrýGücüButton.interactable = false;

        }
        if (playerMovement.yetenekGeliþtirme <= 0 * 100 || yetenekGeliþtirmeXPCan == 5 * 100 || playerMovement.yetenekGeliþtirme < 2 * 100 || playerMovement.ebonarCan == 120)
        {
            CanButton.interactable = false;

        }
        if (playerMovement.yetenekGeliþtirme <= 0 * 100 || yetenekGeliþtirmeXPZýrh == 2 * 100 || playerMovement.yetenekGeliþtirme < 4 * 100 || PlayerMovement._enemyHit == 10)
        {
            ZýrhButton.interactable = false;

        }
        PlayerPrefs.Save();
    }


}
