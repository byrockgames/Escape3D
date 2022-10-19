using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnergyController : MonoBehaviour
{
    [SerializeField] float Duration;
    [SerializeField] float Strength;
    [SerializeField] int  Vibrato;
    [SerializeField] float Randomness;

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.DOShakePosition(Duration, Strength, Vibrato, Randomness);
    }
}
