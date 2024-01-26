using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnimations : MonoBehaviour
{
    public Animator _mainAnimation;
    PlayerMovement _ebonarhealth;

    void Start()
    {
        _mainAnimation = GetComponent<Animator>();
        _ebonarhealth = FindAnyObjectByType<PlayerMovement>();
    }

    

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            _mainAnimation.SetBool("walk", true);
        }

        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            _mainAnimation.SetBool("walk", false);
        }

        if (Input.GetButton("Fire1") || Input.GetButtonDown("Fire1"))
        {
            _mainAnimation.SetBool("hit", true);
            
            if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
            {
                _mainAnimation.SetBool("hitstand", true);
                _mainAnimation.SetBool("hit", false);
            }
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            _mainAnimation.SetBool("hit", false);
            _mainAnimation.SetBool("hitstand", false);
        }

        

        if (_ebonarhealth.ebonarCan <= 0)
        {
            _mainAnimation.SetBool("dead", true);
            Time.timeScale = 0;
        }
    }
}
