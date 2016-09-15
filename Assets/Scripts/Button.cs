using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Button : MyElement {
	
	private bool pressed = false;
	private bool downPressed = false;
	private Vector2 pointPressed;
	private Rect rect;
	
	void Start () {
		downPressed = false;
		pressed = false;
		rect = GetPixelInset(image);
	}
	// Update is called once per frame
	void Update () {
		downPressed = false;
		pressed = false;
		foreach(Touch touch in Input.touches) {
			Vector2 touchPosition = touch.position;
			touchPosition.y = Screen.height - touchPosition.y;
			if( rect.Contains(touchPosition) ) {
				if( touch.phase == TouchPhase.Began ) downPressed = true;
				pressed = true;
				pointPressed = touch.position;
				break;
			}
		}
		#if UNITY_EDITOR
		if(Input.GetMouseButton(0)) {
			Vector2 mouse = Input.mousePosition;
			mouse.y = Screen.height - mouse.y;
			if( rect.Contains(mouse) ) {
				if( Input.GetMouseButtonDown(0) ) downPressed = true;
				pressed = true;
				pointPressed = mouse;
			}
		}
		#endif
	}
	
	public bool IsDownPressed() {
		return downPressed;
	}
	
	public bool IsPressed() {
		return pressed;
	}
	
	public Vector2 GetPointPressed() {
		return pointPressed;
	}
	
}
