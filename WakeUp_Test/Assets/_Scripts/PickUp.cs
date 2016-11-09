using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUp : MonoBehaviour {

    public GameObject[] cells;
    public GameObject instantiate;
    GameObject item;

    Image[] images;
    Image singleImage;

    Text index;
    int indexInt = 0;
    string indexStr = "";
    int random = 0;
    string randomStrInt = "";
    string randomStr = "";

    public void Pickup() {
        bool isFind = false;

        random = Random.Range(0, 6);
        randomStrInt = random.ToString();
        randomStr = "Pictures/" + randomStrInt;
        Debug.Log(randomStr);

        item = Instantiate(instantiate, transform.position, transform.rotation) as GameObject;
        singleImage = item.transform.GetComponent<Image>();

        singleImage.overrideSprite = Resources.Load(randomStr, typeof(Sprite))as Sprite;

        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i].transform.childCount > 0)
            {
                if (singleImage.overrideSprite.name ==
                    cells[i].transform.GetChild(0).transform.GetComponent<Image>().overrideSprite.name)
                {
                    isFind = true;

                    index = cells[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
                    indexInt = int.Parse(index.text);
                    indexInt += 1;
                    indexStr = indexInt.ToString();
                    index.text = indexStr;
                    Destroy(item);
                }
            }
        }
        if (isFind == false)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i].transform.childCount == 0) {
                    item.transform.SetParent(cells[i].transform);
                    item.transform.localPosition = Vector3.zero;
                    break;
                }
            }
        }
    }
}
