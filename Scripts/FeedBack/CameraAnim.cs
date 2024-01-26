using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour
{
    public static Animator camAnim;
    private Quaternion lastParentRotation;
    public Transform cameraTransform;
    public float shakeDuration = 0f;
    public float shakeMagnitude = 0.7f;

    Vector3 originalPosition;
    void Start()
    {
        camAnim = GetComponent<Animator>();
        lastParentRotation = transform.parent.localRotation;

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        originalPosition = cameraTransform.localPosition;
    }

    void LateUpdate()
    {
        transform.localRotation = Quaternion.Inverse(transform.parent.localRotation) *
                                                        lastParentRotation *
                                                        transform.localRotation;

        lastParentRotation = transform.parent.localRotation;

       

  
    }


}
