using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public GameObject[] SpawnObjects;
   
    void Start()
    {
        SpawnObjects[0].SetActive(true);
        SpawnObjects[1].SetActive(true);
        SpawnObjects[2].SetActive(true);
      
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SpawnObjects[0].SetActive(false);
            SpawnObjects[1].SetActive(false);
            SpawnObjects[2].SetActive(false);
        }
      
    }

}
