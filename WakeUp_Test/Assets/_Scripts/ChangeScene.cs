using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    void Start() {
        Globe.loadName = "TestChangeView_Red";
    }

    void Update() {
        //func1:左键加载到一个较小的场景，速度快
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("TestChangeView_Blue2Red");
        }
    }
}
