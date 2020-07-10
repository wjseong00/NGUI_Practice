using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float _hp;
    public float _hpMax;
    public GameObject _GM;
    public GM _GMst;

    public UISprite _hpBar;

    void Start()
    {
        _hpMax = _hp;
        
    }

    void Update()
    {
       if(Input.GetKey("up"))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            
        }
       else if(Input.GetKey("down"))
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
       
        //TouchMove();
    }
    //부딪혔을때, HP가 감소함
    private void OnTriggerEnter(Collider other)
    {
        _hp -= 10.0f;
        _hpBar.fillAmount = _hp * 0.01f;
        if(_hp<=0)
        {
            GameEnd();
        }
    }

    private void GameEnd()
    {
        Debug.Log("Game End");
        Time.timeScale = 0;
    }
}
