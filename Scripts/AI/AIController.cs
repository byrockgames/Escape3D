using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

 public class AIController : MonoBehaviour
 {
    [SerializeField] GameObject Target;
    public NavMeshAgent navmeshagent;

    Animator anim;

    [SerializeField] float time;

    [SerializeField] GameObject AIPlayer;

    void Start()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        AIPlayer.SetActive(true);
    }
    void FixedUpdate()
    {
        time += Time.deltaTime;
        EnemyController();
    }


     void EnemyController()
     {        
        navmeshagent.SetDestination(Target.transform.position);
        anim.SetBool("IsRun", true);

        if (!anim)
        {
            anim.SetBool("IsRun", false);
        }

        if((int)time == 7)
        {
         navmeshagent.speed += 5f*Time.deltaTime;
        }

        if ((int)time == 12)
        {
            navmeshagent.speed += 5f * Time.deltaTime;
        }

        if ((int)time == 18)
        {
            navmeshagent.speed += 9f * Time.deltaTime;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stop")
        {
            AIPlayer.SetActive(false);
        }
    }
}
