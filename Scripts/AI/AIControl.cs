using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    [Header("TargetPlayer")]
    [SerializeField] private Transform Player;

    [Header("AI")]
    [SerializeField] GameObject AIPlayer;
    [SerializeField] float Speed;
    Animator anim;
    Rigidbody rb;

    [Header("Controller")]
    public GameObject GameOverPanel;
    public AudioSource aSourceBurn;
    public AudioSource aSourceRuning;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        GameOverPanel.SetActive(false);
        AIPlayer.SetActive(true);
    }

    void FixedUpdate()
    {
        Vector3 Position = Vector3.MoveTowards(transform.position, Player.position, Speed * Time.fixedDeltaTime);
        rb.MovePosition(Position);
        transform.LookAt(Player);
        anim.SetBool("IsRun", true);
      
    }

    private void OnCollisionEnter(Collision other) {
        
       if(other.gameObject.tag == "Player"){

            Speed = 0f * Time.deltaTime;
            Time.timeScale = 0f;
            GameOverPanel.SetActive(true);
            aSourceBurn.Play();
            aSourceRuning.Stop();
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
