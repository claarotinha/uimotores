using UnityEngine;
using UnityEngine.UI;

public class ButtonSceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    public bool slideToLeft = true;

    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn && SceneTransitionManager.Instance != null)
        {
            btn.onClick.AddListener(() =>
            {
                SceneTransitionManager.Instance.StartTransitionCustom(sceneToLoad, slideToLeft);
            });
        }
    }
}
