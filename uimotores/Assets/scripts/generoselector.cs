using UnityEngine;
using UnityEngine.UI;

public class GeneroSelector : MonoBehaviour
{
    [Header("Botões")]
    public Button botaoMulher;
    public Button botaoHomem;

    [Header("Sprites dos Botões")]
    public Sprite mulherNormal;
    public Sprite mulherSelecionada;
    public Sprite homemNormal;
    public Sprite homemSelecionado;

    [Header("Fundos")]
    public Image imagemFundo;
    public Sprite fundoFeminino;
    public Sprite fundoMasculino;

    void Start()
    {
        botaoMulher.onClick.AddListener(SelecionarMulher);
        botaoHomem.onClick.AddListener(SelecionarHomem);

        // Define estado inicial (opcional)
        SelecionarHomem();
    }

    public void SelecionarMulher()
    {
        botaoMulher.image.sprite = mulherSelecionada;
        botaoHomem.image.sprite = homemNormal;

        imagemFundo.sprite = fundoFeminino;
    }

    public void SelecionarHomem()
    {
        botaoHomem.image.sprite = homemSelecionado;
        botaoMulher.image.sprite = mulherNormal;

        imagemFundo.sprite = fundoMasculino;
    }
}
