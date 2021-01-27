using UnityEngine;
using System.Collections;
public class ReactiveTarget : MonoBehaviour {
	[SerializeField] private GameObject ghostPrefab; 
	private GameObject _ghost;
	public void ReactToHit() { 
	//	StartCoroutine(Die());
		_ghost = Instantiate(ghostPrefab) as GameObject;
		_ghost.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
		_ghost.transform.rotation = transform.rotation;
		Destroy(this.gameObject);
	}
	//private IEnumerator Die() {
	//	_ghost = Instantiate(ghostPrefab) as GameObject;
	//	_ghost.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
	//	_ghost.transform.rotation = transform.rotation;
	//	Destroy(this.gameObject);
	//}
}