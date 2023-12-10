using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class NoiseManager : MonoBehaviour
{
    public float noiseLevel;
    public GameObject latestNoise;
    private GameObject prevNoise;

    [SerializeField] private GameObject noisePrefab;

    public void CreateNoise(float noise, Vector3 position)
    {
        noiseLevel = noise / CalculateDistanceToEnemy(position);

        if (noiseLevel > 1)
        {
            prevNoise = latestNoise;
            Destroy(latestNoise);

            latestNoise = Instantiate(noisePrefab, position, Quaternion.identity);
            
            if(gm.enemies[0].activeState != eState.Searching)
            {
                gm.enemies[0].SwitchState(new EnemySearchState(gm.enemies[0]));
            }

            if(gm.enemies[0].detection < 100f)
            {
                gm.enemies[0].detection += noiseLevel;
            }

            gm.enemies[0].navAgent.isStopped = false;
            gm.enemies[0].TravelToSound(position);
        }
    }

    private float CalculateDistanceToEnemy(Vector3 noisePosition)
    {
        Vector3 enemyPosition = gm.enemies[0].gameObject.transform.position;

        return Vector3.Distance(noisePosition, enemyPosition);
    }
}
