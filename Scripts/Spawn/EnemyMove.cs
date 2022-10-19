using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int Power;
    public GameObject[] EnemyObjects;
    void Start()
    {
        

    }

   
    void Update()
    {
        EnemyObjects[0].transform.position += new Vector3(0, 0, Power * Time.deltaTime);

    }
}
        