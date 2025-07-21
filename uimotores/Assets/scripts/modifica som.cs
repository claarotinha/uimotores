using UnityEngine;
using UnityEngine.UI;

public class ModificaSom : MonoBehaviour
{
    public Sprite audioOnSprite;
    public Sprite audioOffSprite;
    public Image toggleImage; // Referência à imagem do botão (ícone)

    public void AoAlternarSom(bool ligado)
    {
        AudioListener.pause = !ligado;
        toggleImage.sprite = ligado ? audioOnSprite : audioOffSprite;
    }
}
