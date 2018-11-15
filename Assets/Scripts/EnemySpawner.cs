using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[Range(0.1f, 120f)]
	[SerializeField] float secondsBetweenSpawns = 3f;
	[SerializeField] EnemyMovement enemyPrefab;
	[SerializeField] int enemiesInWave = 50;

	// Use this for initialization
	void Start () {
		StartCoroutine(RepeatedlySpawnEnemies());
	}


	IEnumerator RepeatedlySpawnEnemies()
	{
		for (int i = 0; i < enemiesInWave; i++)
		{
			EnemyMovement newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
			newEnemy.transform.parent = transform;
			yield return new WaitForSeconds(secondsBetweenSpawns);
		}
	}
}
