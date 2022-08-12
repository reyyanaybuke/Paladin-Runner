using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    PlayerController Player;
    

    void Start()
    {
       
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
 
    }
    void Update()
    {

    }



}
