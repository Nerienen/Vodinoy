using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolordoSpawner : MonoBehaviour
{


    public GameObject Obstacle;
    public int mobCount = 1;

    private float ObstacleXAxis;
    private float ObstacleZAxis;
    public float ObstacleYAxis;

    public GameObject waaSource;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMob", 4f, 4f);
    }

    void SpawnMob()
    {
        for (int i = 0; i < mobCount; i++)
        {
            ObstacleXAxis = Random.Range(183, 0);
            ObstacleZAxis = Random.Range(0, 200);



            var position = new Vector3(ObstacleXAxis, ObstacleYAxis, ObstacleZAxis);


            Instantiate(Obstacle, position, Quaternion.identity);
            Instantiate(waaSource, position, Quaternion.identity);
        }

        mobCount++;
    }


}
