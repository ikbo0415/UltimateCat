using UnityEngine;
using System.Collections;

public class Fish : MyElement {

	float speed;//скорость падения рыбки
	GameController gameController;
	public int points;//очки которые зарабатываем, когда ловим рыбку

	public void Initialize(float _speed)
	{
		//находим скрипт управляющий игрой
		gameController = GameObject.Find ("Main Camera").GetComponent<GameController> ();
		if (gameController == null)
			Debug.LogError ("НЕ НАЙДЕН СКРИПТ УПРАВЛЯЮЩИЙ ИГРОЙ");
		//задаём рыбке случайную позицию на верху экрана
		transform.position = new Vector3 (Random.Range (0.05f, 0.95f), -0.1f, 0);
		//задаём нужную скорость
		speed = _speed;
	}

	//функция Update в дочерних от MonoDevelop скриптах вызывается в начале каждого кадра
	void Update()
	{
		//тащим рыбку вниз
		transform.position += new Vector3 (0, speed * Time.deltaTime, 0);//дельтатайм это время которое прошло между двумя кадрами(в секудах)
		//Удаляем объект если он ушёл в низ экрана и отнимаем очки
		if (transform.position.y > 1.1f) {
			Destroy (gameObject);
			if (points > 0)
				gameController.AddPoints (-5);
		}
	}

}
