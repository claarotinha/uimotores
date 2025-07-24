using UnityEngine;
using UnityEngine.UI;

public class TrocarSpriteBotao : MonoBehaviour
{
    public Button botao1;
    public Button botao2;

    public Sprite spriteSelecionado1;
    public Sprite spriteNormal1;

    public Sprite spriteSelecionado2;
    public Sprite spriteNormal2;

    void Start()
    {
        botao1.onClick.AddListener(() => Selecionar(1));
        botao2.onClick.AddListener(() => Selecionar(2));

        Selecionar(1); // define o primeiro como padrão (opcional)
    }

    void Selecionar(int id)
    {
        if (id == 1)
        {
            botao1.image.sprite = spriteSelecionado1;
            botao2.image.sprite = spriteNormal2;
        }
        else
        {
            botao1.image.sprite = spriteNormal1;
            botao2.image.sprite = spriteSelecionado2;
        }
    }
}
