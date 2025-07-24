using UnityEngine;
using UnityEngine.UI;

public class AnimalSelector : MonoBehaviour
{
    [Header("Setas")]
    public Button setaEsquerda;
    public Button setaDireita;

    [Header("Imagem no centro")]
    public Image imagemAnimal;

    [Header("Sprites")]
    public Sprite spriteGato;
    public Sprite spriteCachorro;

    private enum AnimalAtual { Gato, Cachorro }
    private AnimalAtual animalSelecionado = AnimalAtual.Gato;

    void Start()
    {
        setaEsquerda.onClick.AddListener(TrocarAnimal);
        setaDireita.onClick.AddListener(TrocarAnimal);

        AtualizarImagem();
    }

    void TrocarAnimal()
    {
        animalSelecionado = animalSelecionado == AnimalAtual.Gato ? AnimalAtual.Cachorro : AnimalAtual.Gato;
        AtualizarImagem();
    }

    void AtualizarImagem()
    {
        if (animalSelecionado == AnimalAtual.Gato)
            imagemAnimal.sprite = spriteGato;
        else
            imagemAnimal.sprite = spriteCachorro;
    }
}
