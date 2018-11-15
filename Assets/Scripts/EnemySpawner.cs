using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[Range(0.1f, 120f)]
	[SerializeField] float secondsBetweenSpawns = 3f;
	[SerializeField] EnemyMovement enemyPrefab;
	[SerializeField] int enemiesInWave = 5;

	// Use this for initialization
	void Start () {
		StartCoroutine(RepeatedlySpawnEnemies());
	}


	IEnumerator RepeatedlySpawnEnemies()
	{
		for (int i = 0; i < enemiesInWave; i++)
		{
			Instantiate(enemyPrefab, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
