using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	int points;//очки
	Cat cat;//наш кот(игрок)
	public GameObject[] fishes;//вариация рыбок
	float clock;//счётчик времени
	public float time;//период с которым падают рыбки
	Text pointsText;//элемент UI который отображает текст(мы в нём будем записывать очки

	//функция Start в дочерних от MonoDevelop скриптах вызывается перед самым первым кадром
	void Start () {
		points = 0;
		cat = GameObject.Find ("cat").GetComponent<Cat> ();
		if (cat == null)
			Debug.LogError ("НЕ НАЙДЕН КОТ(ИГРОК)");
		pointsText = GetComponentInChildren<Text> ();
		clock = 0f;
	}

	//функция Update в дочерних от MonoDevelop скриптах вызывается в начале каждого кадра
	void Update () {
		//Увеличиваем счётчик
		clock += Time.deltaTime;
		if (clock >= time) {
			//если счётчик превысил период появления рыбки обнуляем его и создаём рыбку
			clock = 0f;
			Fish _fish = Instantiate (fishes[Random.Range(0,3)]).GetComponent<Fish> ();
			_fish.Initialize (0.5f);
		}
	}

	//добавляет очки и обновляет текст в углу экрана
	public void AddPoints(int _points)
	{
		points += _points;
		if (pointsText != null)
			pointsText.text = points.ToString ();
	}
}
