using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance { get; private set; }

    [Header("UI Elements")]
    public RectTransform panel1; // Painel principal
    public RectTransform panel2; // Painel de loading

    [Header("Transition Settings")]
    public float slideDuration = 0.7f;
    public float loadingDuration = 2f;

    private Vector2 leftOffScreen = new Vector2(-2000, 0);
    private Vector2 rightOffScreen = new Vector2(2000, 0);
    private Vector2 center = Vector2.zero;
    private bool isTransitioning = false;

    public float GetLeftDirection() => leftOffScreen.x;
    public float GetRightDirection() => rightOffScreen.x;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        ResetPositions();
        if (panel2) panel2.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindUIElements();
        ResetPositions();
        if (panel2) panel2.gameObject.SetActive(false);
    }

    void FindUIElements()
    {
        var panel1Obj = GameObject.Find("Panel1");
        var panel2Obj = GameObject.Find("Panel2");

        if (panel1Obj) panel1 = panel1Obj.GetComponent<RectTransform>();
        if (panel2Obj) panel2 = panel2Obj.GetComponent<RectTransform>();
    }

    void ResetPositions()
    {
        if (panel1) panel1.anchoredPosition = center;
        if (panel2) panel2.anchoredPosition = center;
    }

    public void StartTransitionToScene(string sceneName)
    {
        StartTransition(sceneName, leftOffScreen.x); // direção padrão: esquerda
    }

    public void StartTransitionCustom(string sceneName, bool slideToLeft)
    {
        float direction = slideToLeft ? leftOffScreen.x : rightOffScreen.x;
        StartTransition(sceneName, direction);
    }

    public void StartTransition(string sceneName, float slideDirection)
    {
        if (!isTransitioning)
        {
            StartCoroutine(Transition(sceneName, slideDirection));
        }
    }

    IEnumerator Transition(string sceneName, float slideDirection)
    {
        isTransitioning = true;

        if (panel1) yield return StartCoroutine(SlidePanel(panel1, slideDirection));

        if (panel2) panel2.gameObject.SetActive(true);
        yield return new WaitForSeconds(loadingDuration);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        isTransitioning = false;
    }

    IEnumerator SlidePanel(RectTransform panel, float targetX)
    {
        Vector2 startPos = panel.anchoredPosition;
        Vector2 endPos = new Vector2(targetX, startPos.y);
        float elapsed = 0f;

        while (elapsed < slideDuration)
        {
            if (panel != null)
            {
                panel.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsed / slideDuration);
            }
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (panel != null)
        {
            panel.anchoredPosition = endPos;
        }
    }
}
