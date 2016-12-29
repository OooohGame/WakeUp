using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

    public Slider slider;
    private AsyncOperation loadingAsync;

	void Start () {
        StartCoroutine(LoadScene());
	}

    IEnumerator LoadScene() {
        loadingAsync = SceneManager.LoadSceneAsync(Globe.loadName);
        yield return loadingAsync;
    }
	
	void Update () {
        slider.value = loadingAsync.progress;
    }
}
