using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointsIndex = 0;
    private void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig=enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWayPoints();
        transform.position= waypoints[waypointsIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointsIndex<waypoints.Count)
        {
            Vector3 target = waypoints[waypointsIndex].position;
            float delta = waveConfig.GetMoveSpeed()*Time.deltaTime;
            transform.position=Vector2.MoveTowards(transform.position,target,delta);
            if (transform.position==target)
            {
                waypointsIndex++;
            }
        }
        else    
        {
            Destroy (gameObject);
        }
    }
}

