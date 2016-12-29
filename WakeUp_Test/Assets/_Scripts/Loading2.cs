using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading2 : MonoBehaviour {

    public Slider slider;
    private AsyncOperation loadingAsync;

    void Start() {
        Globe.loadName = "TestChangeView_Red";
        slider.gameObject.SetActive(false);
    }

    IEnumerator LoadScene()
    {
        loadingAsync = SceneManager.LoadSceneAsync(Globe.loadName);
        yield return loadingAsync;
    }

    void Update () {
        //func2:直接在本场景加载
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LoadScene());
            slider.gameObject.SetActive(true);
        }
        if (slider.IsActive())
            slider.value = loadingAsync.progress;
    }
}
