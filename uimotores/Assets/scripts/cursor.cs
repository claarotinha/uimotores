using UnityEngine;

public class CursorUI : MonoBehaviour
{
    RectTransform rectTransform;

    void Start()
    {
        // Só esconde o cursor se o jogo estiver rodando (na Game view)
#if UNITY_EDITOR
        Cursor.visible = Application.isPlaying;
#else
        Cursor.visible = true;
#endif
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent as RectTransform,
            Input.mousePosition,
            null,
            out pos
        );

        rectTransform.anchoredPosition = pos;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        // Quando voltar o foco para o editor, mostra o cursor real
#if UNITY_EDITOR
        Cursor.visible = !hasFocus ? true : Application.isPlaying;
#endif
    }
}
