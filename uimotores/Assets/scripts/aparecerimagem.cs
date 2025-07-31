using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MostrarImagemProximidade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject imagemAlvo;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (imagemAlvo != null)
            imagemAlvo.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (imagemAlvo != null)
            imagemAlvo.SetActive(false);
    }
}

