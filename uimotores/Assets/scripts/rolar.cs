using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircularPanelTransition : MonoBehaviour
{
    [Header("Configuração dos Painéis")]
    public RectTransform panel1; // Tela inicial
    public RectTransform panel2; // Loading (meio)
    public RectTransform panel3; // Tela final
    public float slideDuration = 0.7f;
    public float loadingDuration = 2f;

    [Header("Botões")]
    public Button newButton; // No Panel1
    public Button backButton; // No Panel3

    private Vector2 leftOffScreen = new Vector2(-2000, 0);
    private Vector2 rightOffScreen = new Vector2(2000, 0);
    private Vector2 center = Vector2.zero;
    private bool isTransitioning = false;

    void Start()
    {
        ResetPositions();
        newButton.onClick.AddListener(() => StartCoroutine(TransitionToPanel3()));
        backButton.onClick.AddListener(() => StartCoroutine(TransitionToPanel1()));
        
        // Garante que o loading comece desativado
        panel2.gameObject.SetActive(false);
    }

    void ResetPositions()
    {
        panel1.anchoredPosition = center;
        panel2.anchoredPosition = center;
        panel3.anchoredPosition = rightOffScreen;
    }

    IEnumerator TransitionToPanel3()
    {
        if (isTransitioning) yield break;
        isTransitioning = true;

        // 1. Painel1 desliza para ESQUERDA
        yield return StartCoroutine(SlidePanel(panel1, leftOffScreen.x));
        
        // 2. Mostra loading
        panel2.gameObject.SetActive(true);
        yield return new WaitForSeconds(loadingDuration);
        
        // 3. Painel3 entra pela DIREITA
        panel3.anchoredPosition = rightOffScreen;
        yield return StartCoroutine(SlidePanel(panel3, center.x));
        
        // 4. Esconde loading
        panel2.gameObject.SetActive(false);

        isTransitioning = false;
    }

    IEnumerator TransitionToPanel1()
    {
        if (isTransitioning) yield break;
        isTransitioning = true;

        // 1. Painel3 desliza para DIREITA
        yield return StartCoroutine(SlidePanel(panel3, rightOffScreen.x));
        
        // 2. Mostra loading
        panel2.gameObject.SetActive(true);
        yield return new WaitForSeconds(loadingDuration);
        
        // 3. Painel1 entra pela ESQUERDA
        panel1.anchoredPosition = leftOffScreen;
        yield return StartCoroutine(SlidePanel(panel1, center.x));
        
        // 4. Esconde loading (AQUI ESTÁ A CORREÇÃO)
        panel2.gameObject.SetActive(false);

        isTransitioning = false;
    }

    IEnumerator SlidePanel(RectTransform panel, float targetX)
    {
        Vector2 startPos = panel.anchoredPosition;
        Vector2 endPos = new Vector2(targetX, startPos.y);
        float elapsed = 0f;

        while (elapsed < slideDuration)
        {
            panel.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsed/slideDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        panel.anchoredPosition = endPos;
    }
}