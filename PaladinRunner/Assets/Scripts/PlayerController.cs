using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public GameObject bitti_pnl;
    public GameObject kazandin_pnl;

    public TMPro.TextMeshProUGUI puan_txt;
    public TMPro.TextMeshProUGUI toplanan_altin_txt;
    public TMPro.TextMeshProUGUI toplanan_guc_txt;

    public Rigidbody rigi;
    bool sol;
    bool sag;

    int puan = 0;
    int toplanan_altin = 0;
    int toplanan_guc = 0;
   
    float hiz = 15.0f;




    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="engel")
        {
            bitti_pnl.SetActive(true);
            Time.timeScale = 0.0f;
        }

        if(other.gameObject.tag=="altin")
        {

            Destroy(other.gameObject);

            toplanan_altin++;
            puan += 5;

            puan_txt.text = puan.ToString("00000");
            toplanan_altin_txt.text = toplanan_altin.ToString();
        }

        if (other.gameObject.tag == "guc")
        {
            Destroy(other.gameObject);

            toplanan_guc++;

            toplanan_guc_txt.text = toplanan_guc.ToString();
        }

        if (other.gameObject.tag == "finish")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0f, transform.position.y, transform.position.z), Time.deltaTime * 60.0f);

            
            animator.SetBool("isDance", true);
            animator.SetBool("isIdle", true);
            hiz = 0;

            kazandin_pnl.SetActive(true);

        }
      

    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody>();

    }

    void Update()
    {


        transform.Translate(0, 0, hiz * Time.deltaTime);
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);
            

            if (parmak.deltaPosition.x > 50.0f)
            {
                
                sag = true;
                sol = false;
            }

            if (parmak.deltaPosition.x < -50.0f)
            {
                
                sag = false;
                sol = true;
            }


            if (sag == true)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(5f, transform.position.y, transform.position.z), Time.deltaTime * 60.0f);
            }

            if (sol == true)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-5f, transform.position.y, transform.position.z), Time.deltaTime * 60.0f);
            }

           
        }


    }
    

}
