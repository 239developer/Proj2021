using UnityEngine;
using System.Collections;
public class SceneController1 : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab; 
	private GameObject _enemy; 
	void Update() { 
		if (_enemy == null) {
			_enemy = Instantiate(enemyPrefab) as GameObject; 
			_enemy.transform.position = new Vector3(428, 1, 488);
			float angle = Random.Range(0, 360);
			_enemy.transform.Rotate(0, angle, 0);
		}
	}
}