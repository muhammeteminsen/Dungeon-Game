using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ClickyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image _ýmgButton;
    public Sprite _default, _pressed;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _ýmgButton.sprite = _pressed;
        
    }
   

    public void OnPointerUp(PointerEventData eventData)
    {
        _ýmgButton.sprite = _default;
        
    }

    
}
