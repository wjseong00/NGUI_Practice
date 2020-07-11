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
            transform.position += new Vector3(0, Mathf.Lerp(0, speed * Time.deltaTime, Time.time), 0);

        }
       else if(Input.GetKey("down"))
        {
            transform.position -= new Vector3(0, Mathf.Lerp(0, speed * Time.deltaTime, Time.time), 0);
        }
       
        TouchMove();
    }
    //부딪혔을때, HP가 감소함
    private void OnTriggerEnter(Collider other)
    {
        _hp -= 10.0f;
        _hpBar.fillAmount = _hp * 0.01f;
        if(_hp<=0)
        {
            _GMst.GameOver();
        }
    }
    void TouchMove()
    {
        if(Input.touchCount >0)
        {
            if(Input.GetTouch(0).deltaPosition.y>1.0f)
            {
                transform.position += new Vector3(0, Mathf.Lerp(0,speed * Time.deltaTime, Time.time),0);
            }
            else if (Input.GetTouch(0).deltaPosition.y<-1.0f)
            {
                transform.position -= new Vector3(0, Mathf.Lerp(0, speed * Time.deltaTime, Time.time), 0);
            }
        }
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, -200.0f, 180.0f), transform.localPosition.z);
    }
    
}
