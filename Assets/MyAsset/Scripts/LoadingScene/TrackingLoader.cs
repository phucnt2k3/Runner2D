using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrackingLoader : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private int _sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsynchronously(_sceneIndex));
    }

    IEnumerator LoadAsynchronously(int indexScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(indexScene);

        while (!operation.isDone)
        {
            Debug.Log("Process: " + operation.progress);
            _slider.value = operation.progress;
            yield return null;
        }
    }
}
