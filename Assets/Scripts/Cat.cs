using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Cat : MyElement {
	//кнопки
	public Button left, right;
	//скорость движения кота
	public float speed;
	GameController gameController;

	void Start()
	{
		gameController = GameObject.Find ("Main Camera").GetComponent<GameController> ();
		if (gameController == null)
			Debug.LogError ("GameController has not been found");
	}

	void Update () {
		//проверяем нажаты ли кнопки и двигаем кота
		if(left.IsPressed())
		{
			transform.position += new Vector3 (-speed*Time.deltaTime, 0f, 0f);
		}
		if(right.IsPressed())
		{
			transform.position += new Vector3 (speed*Time.deltaTime, 0f, 0f);
		}
		//не даём коту вылезти за экран
		if (transform.position.x < 0.1f)
			transform.position = new Vector3 (0.1f, 0.9f, 0f);
		if (transform.position.x > 0.9f)
			transform.position = new Vector3 (0.9f, 0.9f, 0f);
	}

	//Функция OnTriggerEnter вызывается, когда в тригере висящем на объекте появляется другой игровой объект с Rigidbody и Collider
	//Подробней об этой функции можно узнать в документации по Unity
	void OnTriggerEnter(Collider other)
	{
		//ищем компонент Fish в нашем инородном объекте
		Fish fish = other.GetComponent<Fish> ();
		if (fish != null) {
			//если такой компонент имеется то мы удаляем этот объект и добавляем очки
			gameController.AddPoints (fish.points);
			Destroy (other.gameObject);
		}
	}
}

