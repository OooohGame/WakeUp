using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour {

    private GameObject root;
    private MeshRenderer[] cubes;
    private int count;

    public Material blue;
    public Material red;

    void Start() {
        root = GameObject.Find("Cubes");
        cubes = root.GetComponentsInChildren<MeshRenderer>();
        count = 0;
    }

	void Update () {
        //材质有实例问题，暂用点击次数切换材质
        //func3：直接切换材质
        if (Input.GetMouseButtonDown(0))
        {
            if ((++count) % 2 == 0)
                foreach (MeshRenderer cube in cubes)
                    cube.material = red;
            else
                foreach (MeshRenderer cube in cubes)
                    cube.material = blue;
        }
    }
}
