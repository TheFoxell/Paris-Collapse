using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI progressText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync("ville");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;

            progressText.text = progress * 100 + "%";

            yield return null;
        }
    }
}
