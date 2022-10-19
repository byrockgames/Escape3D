using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HelperController : MonoBehaviour
{
    public Transform[] TargetPosition;
    public GameObject[] Characters;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
       
        CharactersMove();

    }
    void CharactersMove()
    {
        Characters[0].transform.DOMove(TargetPosition[0].position, 5).SetLoops(3, LoopType.Yoyo);
                   
    }
    


}

