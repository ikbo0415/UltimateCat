using UnityEngine;
using System.Collections;

public class MyElement : MonoBehaviour {

	[SerializeField] protected Texture image;//картинка которая будет видна на экране

	//функция OnGUI вызывается при отрисовке интерфейса
	protected void OnGUI() {
		//рисуем наш элемент
		if(image) GUI.DrawTexture( GetPixelInset(image), image );
	}

	/// <summary>
	/// Вычисляет область отрисовки элемента исходя из координат объекта
	/// </summary>
	protected Rect GetPixelInset(Texture texture) {
		//Игровой объект сам по себе пустой и нужен нам лишь для того чтобы задать нужные координаты и размер
		//при этом его координаты по осям x и y должны лежать в пределах от 0 до 1 иначе объект не будет виден на экране
		Vector2 position = GetCenter();
		Vector2 size = GetSize(texture);
		return new Rect( position.x-size.x/2.0f, position.y-size.y/2.0f, size.x, size.y );
	}

	/// <summary>
	/// Вычисляет положение объекта на экране
	/// </summary>
	private Vector2 GetCenter() {
		Vector3 position = transform.position;
		return new Vector2( position.x*Screen.width, position.y*Screen.height );
	}

	/// <summary>
	/// Вычисляет размеры объекта на экране
	/// </summary>
	private Vector2 GetSize(Texture texture) {
		Vector3 scale = transform.localScale;
		float displaySize = (Screen.width + Screen.height)/2.0f;
		return new Vector2(displaySize*scale.x, displaySize*scale.y);
	}
}
