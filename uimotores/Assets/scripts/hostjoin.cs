using UnityEngine;
using UnityEngine.UI;

public class ModoCoopSelector : MonoBehaviour
{
    [Header("Botões")]
    public Button botaoHost;
    public Button botaoJoin;

    [Header("Sprites")]
    public Sprite hostNormal;
    public Sprite hostSelecionado;
    public Sprite joinNormal;
    public Sprite joinSelecionado;

    [Header("Painéis")]
    public GameObject painelHost;
    public GameObject painelJoin;

    private enum ModoSelecionado { Host, Join }
    private ModoSelecionado modoAtual;

    void Start()
    {
        botaoHost.onClick.AddListener(SelecionarHost);
        botaoJoin.onClick.AddListener(SelecionarJoin);

        SelecionarHost(); // Começa com Host selecionado
    }

    void SelecionarHost()
    {
        if (modoAtual == ModoSelecionado.Host) return;
        modoAtual = ModoSelecionado.Host;

        botaoHost.image.sprite = hostSelecionado;
        botaoJoin.image.sprite = joinNormal;

        painelHost.SetActive(true);
        painelJoin.SetActive(false);
    }

    void SelecionarJoin()
    {
        if (modoAtual == ModoSelecionado.Join) return;
        modoAtual = ModoSelecionado.Join;

        botaoJoin.image.sprite = joinSelecionado;
        botaoHost.image.sprite = hostNormal;

        painelHost.SetActive(false);
        painelJoin.SetActive(true);
    }
}
