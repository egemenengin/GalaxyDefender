//Egemen Engin
//https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPathing : MonoBehaviour
{
    List<Transform> wavePoints;
    waveConfig waveConf;
    int wayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        wavePoints = waveConf.getWaypoints();
        transform.position = wavePoints[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        if (wayPointIndex < wavePoints.Count)
        {
            var targetPosition = wavePoints[wayPointIndex].transform.position;
            var movementThisFrame = waveConf.getMoveSpeed()*Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
            //waypointIndex = 0;
        }

    }

    public void setWaveConf(waveConfig newWaveConf)
    {
        waveConf = newWaveConf;
    }
}
