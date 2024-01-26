using BarthaSzabolcs.Tutorial_SpriteFlash;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    float moveSpeed = 5f;
    Rigidbody2D rb;
    public Camera kamera;
    private EbonarAteþEtme ebonarAteþEtme;

    private Yaratýk1CanHasar yaratýk1CanHasar;
    private Yaratýk2CanHasar yaratýk2CanHasar;

    public int ebonarCan;
    private bool yetenekObjeAlýndý = false;
    bool anahtarAlýndý;
    bool isWalking = false;
    bool secretchest;
    public int yetenekGeliþtirme;
    public int sceneIndex;

    public static int _enemyHit = 20;

    private UIControl uýControl;



    MainAnimations _mainAnimationforhit;
    SimpleFlash flasheffect;
    HasarCan hasarCan;
    Sounds sounds;




    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        ebonarAteþEtme = FindAnyObjectByType<EbonarAteþEtme>();


        yaratýk1CanHasar = FindAnyObjectByType<Yaratýk1CanHasar>();
        yaratýk2CanHasar = FindAnyObjectByType<Yaratýk2CanHasar>();
        uýControl = FindAnyObjectByType<UIControl>();
        _mainAnimationforhit = FindAnyObjectByType<MainAnimations>();
        flasheffect = FindAnyObjectByType<SimpleFlash>();
        hasarCan = FindAnyObjectByType<HasarCan>();


        //StartEbonarSpriteChangeFNC();


        //transform.position = CheckPoint.lastTransform;

        yetenekGeliþtirme = PlayerPrefs.GetInt(nameof(yetenekGeliþtirme));

        sounds = FindAnyObjectByType<Sounds>();
        sceneIndex = PlayerPrefs.GetInt(nameof(sceneIndex), 0);
        ebonarCan = PlayerPrefs.GetInt(nameof(ebonarCan),100);


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sandýk" && Input.GetKeyDown(KeyCode.E) && ebonarCan < 100)
        {
            ebonarCan = 100;
            Debug.Log("Can Alýndý");
            PlayerPrefs.SetInt(nameof(ebonarCan), ebonarCan);
            uýControl.originalHealthBar.sprite = uýControl._healthBar[5];
            sounds.caseOpening.Play();
            Destroy(GameObject.FindWithTag("Sandýk"));
        }
        if (collision.gameObject.tag == "Gizli Sandýk" && Input.GetKeyDown(KeyCode.E))
        {
            secretchest = true;
            sounds.caseOpening.Play();
            Destroy(GameObject.FindWithTag("Gizli Sandýk"));
        }
    }
    private void OnTriggerEnter2D(Collider2D temas)
    {


        if (temas.gameObject.tag == "BaþlangýçKapý")
        {
            sceneIndex += 2;
            SceneManager.LoadScene(sceneIndex);
            uýControl.Veri();

        }
        else if (temas.gameObject.tag == "1Kapý"  && anahtarAlýndý == true)
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            uýControl.Veri();

        }
        else if (temas.gameObject.tag == "2Kapý" && yaratýk1CanHasar.yaratýkCan <= 0 && anahtarAlýndý == true)
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            uýControl.Veri();

        }
        else if (temas.gameObject.tag == "3Kapý" && yaratýk1CanHasar.yaratýkCan <= 0 && anahtarAlýndý == true)
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            uýControl.Veri();

        }
        else if (temas.gameObject.tag == "4Kapý")
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            uýControl.Veri();


        }
        else if (temas.gameObject.tag == "5-8Kapý")
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            uýControl.Veri();


        }
        else if (temas.gameObject.tag == "9Kapý" && yaratýk1CanHasar.yaratýkCan <= 0 && anahtarAlýndý == true)
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            uýControl.Veri();


        }
        else if (temas.gameObject.tag == "10Kapý" && yaratýk1CanHasar.yaratýkCan <= 0 && yaratýk2CanHasar.yaratýk2Can <= 0 && anahtarAlýndý == true && secretchest)
        {
            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
            uýControl.Veri();


        }
        if (temas.gameObject.CompareTag("Anahtar"))
        {
            anahtarAlýndý = true;
            Destroy(GameObject.FindWithTag("Anahtar"));
            sounds.doorOpening.Play();
            Debug.Log("Anahtar");
        }

        if (temas.gameObject.CompareTag("YetenekGeliþtirme"))
        {
            yetenekGeliþtirme += 300;
            YetenekGeliþtirme.birKereOluþturuldu = true;
            yetenekObjeAlýndý = true;

            PlayerPrefs.SetInt(nameof(yetenekGeliþtirme), yetenekGeliþtirme);
            PlayerPrefs.Save();
            sounds.skillTalent.Play();
            _mainAnimationforhit._mainAnimation.SetTrigger("health");
            if (yetenekObjeAlýndý)
            {
                Destroy(GameObject.FindWithTag("YetenekGeliþtirme"));
            }
        }

        if (temas.gameObject.tag == "YaratýkMermi")
        {

            ebonarCan -= _enemyHit;
            _mainAnimationforhit._mainAnimation.SetTrigger("!hit");
            flasheffect.Flash();
            HealtBarFeedBack.healthBar.SetTrigger("health");
            sounds.ebonarDamageSound.Play();
            if (yaratýk1CanHasar.yaratýkCan < 60)
            {
                yaratýk1CanHasar.yaratýkCan += 10;
            }

        }
        if (temas.gameObject.tag == "YaratýkMermi2")
        {

            ebonarCan -= _enemyHit;
            _mainAnimationforhit._mainAnimation.SetTrigger("!hit");
            flasheffect.Flash();
            HealtBarFeedBack.healthBar.SetTrigger("health");
            sounds.ebonarDamageSound.Play();
            if (yaratýk2CanHasar.yaratýk2Can < 60)
            {
                yaratýk2CanHasar.yaratýk2Can += 10;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D temas)
    {

        YetenekGeliþtirme.birKereOluþturuldu = false;


    }
    void Update()
    {
        Debug.Log(ebonarCan);
        Debug.Log(sceneIndex);
        //ImleceGöreHareketFNC();
        HareketFNC();
        PlayerPrefs.SetInt(nameof(sceneIndex), sceneIndex);
        uýControl.yetenekGeliþtirmeText.text = yetenekGeliþtirme.ToString();


        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        bool walkingThisFrame = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (walkingThisFrame && !isWalking)
        {
            sounds.ebonarWalkSound.Play();
            isWalking = true;
        }
        else if (!walkingThisFrame && isWalking)
        {
            sounds.ebonarWalkSound.Stop();
            isWalking = false;
        }


    }




    void HareketFNC()
    {


        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");


        Vector2 movement = new Vector2(movehorizontal, movevertical);
        rb.velocity = movement * moveSpeed;

    }
    void ImleceGöreHareketFNC()
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;


    }
}
