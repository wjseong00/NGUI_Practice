using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    //인스펙터 정의

    //배경 오브젝트 Set 를 정의
    public GameObject _BgSetObj;

    //추가1 배경오브젝트2
    public GameObject _BgSetObj2;

    public GameObject _EnemySet1;
    public List<GameObject> _nowEnemyChild = new List<GameObject>();
    public int _EnemyInt = 0;
    public float _YPos;



    //이동속도 정의
    public float _moveSpeed;
    public float _moveSpeedMax;

    //얼만큼 이동했는지를 체크 하기 위한 변수 선언
    public float _xPosMoveChk = 0f;
    public float _xPosMoveChk3 = 0f;

    public float _xPosMoveChkVal1 = 0f;
    public float _xPosMoveChkVal2 = 0f;

   

    public float _timerLim;
    public float _timerForSpeed;

    //게임 스코어를 표현하기 위한 부분
    public UILabel _Score;
    public int _GameScore;
    public int _GameScorePer;

    void Start()
    {
        
    }

    
    void Update()
    {
        SpeedLimChk(); //난이도 조정을 위하여 속도 빨라지는 구문 설정
        

        _xPosMoveChk += _moveSpeed * Time.deltaTime; //매 루프마다 이동량을 누적하여 저장
        _xPosMoveChk3 += _moveSpeed * Time.deltaTime *0.5f; //매 루프마다 두번째 배경 오브젝트의 이동량을 누적하여 저장

        _BgSetObj.transform.localPosition += new Vector3(_moveSpeed * -1F * Time.deltaTime*0.5f, 0, 0); //매 프레임마다 정해진 속력으로 좌측으로 이동
        _BgSetObj2.transform.localPosition += new Vector3(_moveSpeed * -1F * Time.deltaTime, 0, 0); //매 프레임마다 정해진 속력으로 좌측으로 이동
        _EnemySet1.transform.localPosition += new Vector3(_moveSpeed * -1f * Time.deltaTime, 0, 0);//적 세트 이동
        if(_xPosMoveChk >960.0f)//누적 이동량이 960보다 크면 체크
        {
            _xPosMoveChk = 0;
            _BgSetObj2.transform.localPosition = new Vector3(960 * -1.0f, 0, 0);
            _GameScore += _GameScorePer;
            _Score.text = _GameScore.ToString();
            //BGSetObj 의 좌표를 초기값으로 변경
        }
        if (_xPosMoveChk3 > 960.0f)//누적 이동량이 960보다 크면 체크
        {
            _xPosMoveChk3 = 0;
            _BgSetObj.transform.localPosition = new Vector3(960 * -1.0f, 0, 0);
            //BGSetObj2 의 좌표를 초기값으로 변경
        }

        if(_EnemySet1.transform.localPosition.x < _xPosMoveChkVal1)
        {
            _xPosMoveChkVal1 -= _xPosMoveChkVal2;
            ResetChildSet();
            _EnemyInt++;
            if(_EnemyInt>4)
            {
                _EnemyInt = 0;
            }
        }
    }

    private void ResetChildSet()
    {
        _nowEnemyChild[_EnemyInt].transform.localPosition += new Vector3(1440.0f, 0, 0);
        switch (Random.Range(1,4))
        {
            case 1:
                _YPos = 120.0f;
                break;
            case 2:
                _YPos = 240.0f;
                break;
            case 3:
                _YPos = 360.0f;
                break;
            default:
                break;
        }
        _nowEnemyChild[_EnemyInt].transform.localPosition = new Vector3(_nowEnemyChild[_EnemyInt].transform.localPosition.x, _YPos, _nowEnemyChild[_EnemyInt].transform.localPosition.z);
    }

    private void SpeedLimChk()
    {
        _timerForSpeed += Time.deltaTime;
        if (_timerForSpeed > _timerLim)
        {
            _timerForSpeed = 0;
            if (_moveSpeed < _moveSpeedMax)
            {
                _moveSpeed = _moveSpeed * 1.05f; //5%씩 속도증가
            }
            else
            {
                _moveSpeed = _moveSpeedMax;
            }
        }
    }
}
