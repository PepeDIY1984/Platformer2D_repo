using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySawGenerator : MonoBehaviour
{
    public float timeMax = 1;
    private float timeInit = 0;
    public GameObject obstacle;
    public GameObject obstacleOrigin;
    public float high = 3f;


    // Start is called before the first frame update
    void Start()
    {
        GameObject obstacleNew = Instantiate(obstacle);
        obstacleNew.transform.position = obstacleOrigin.transform.position;
        Destroy(obstacleNew, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeInit > timeMax)
        {
            GameObject obstacleNew = Instantiate(obstacle);
            obstacleNew.transform.position = obstacleOrigin.transform.position + new Vector3(0, Random.Range(-high, high), 0);
            //Debug.Log(obstacleNew.transform.position);
            //Debug.Log(Random.Range(-high, high));
            Destroy(obstacleNew, 15);
            timeInit = 0;
        }
        else
        {
            timeInit += Time.deltaTime;
        }
    }
}
