﻿using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 
using UnityEngine.EventSystems; 
public class DragMove : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler { 

	//[SerializeField] GameObject grid = null;
	GameObject InitCanvas = null;
	GameObject Instead_gameObject = null;

	void Start () {
		InitCanvas = GameObject.Find ("Bag").transform.Find ("InitCanvas").gameObject;
	}

    //拖拽
    public void OnDrag(PointerEventData eventData) { 
		if (Input.GetMouseButton (0)) {
			GetComponent<RectTransform>().pivot.Set(0,0); 
			transform.position = Input.mousePosition; 
		}
	}

    //鼠标按下
    public void OnPointerDown(PointerEventData eventData) { 
		if (Input.GetMouseButtonDown (0)) {
			transform.localScale=new Vector3(0.7f,0.7f,0.7f); 
			Instead_gameObject = transform.parent.gameObject;
			transform.SetParent (InitCanvas.transform, true);
			transform.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}

    //鼠标放开
    public void OnPointerUp(PointerEventData eventData) { 
		if (Input.GetMouseButtonUp (0)) {
			transform.localScale = new Vector3 (1f, 1f, 1f);

			print (eventData.pointerCurrentRaycast.gameObject);

			if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.tag == "UCell") {
				transform.SetParent (eventData.pointerCurrentRaycast.gameObject.transform);
			} else if(eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.tag == "UItem"){//交换
				Transform transform_A = eventData.pointerCurrentRaycast.gameObject.transform;
				Transform transform_B_parent = transform_A.parent.transform;
				transform_A.SetParent (Instead_gameObject.transform);
				transform_A.localPosition = Vector3.zero;
				transform.SetParent (transform_B_parent);
			}else{
                //放回原位
                transform.SetParent (Instead_gameObject.transform);
			}
			//transform.GetComponent<CanvasGroup> ().blocksRaycasts = true;
			transform.localPosition = Vector3.zero;
		}
	} 
}