using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 3;
	[SerializeField] Tower towerPrefab;
	[SerializeField] Transform towerParent;

	[SerializeField] Queue<Tower> towerQueue = new Queue<Tower>();

	public void AddTower(Waypoint baseWaypoint)
	{
		var towers = FindObjectsOfType<Tower>();
		int numTowers = towers.Length;

		if (numTowers < towerLimit)
		{
			InstantiateNewTower(baseWaypoint);
		}
		else
		{
			MoveExistingTower(baseWaypoint);
		}
	}

	private void InstantiateNewTower(Waypoint baseWaypoint)
	{
		Tower tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
		tower.transform.parent = towerParent;

		tower.baseWaypoint = baseWaypoint;
		baseWaypoint.isPlaceable = false;

		towerQueue.Enqueue(tower);
	}

	private void MoveExistingTower(Waypoint baseWaypoint)
	{
		var oldTower = towerQueue.Dequeue();
		oldTower.baseWaypoint.isPlaceable = true;

		baseWaypoint.isPlaceable = false;
		oldTower.baseWaypoint = baseWaypoint;
		oldTower.transform.position = baseWaypoint.transform.position;

		towerQueue.Enqueue(oldTower);
	}
}
