using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSlim : MonoBehaviour
{


    public enum SlimState
    {
        Walk,
        Wait,
        Chase
    };

    [SerializeField]
    float speed = 0.05f;
    Vector2 inputAxis;
    //private Rigidbody2D _rig;
    //public Rigidbody2D Rig { get { return this._rig ? this._rig : this._rig = GetComponent<Rigidbody2D>(); } }
    Rigidbody2D rb;
    private CharacterController heroController;
    //　目的地
    private Vector3 destination;
    //　歩くスピード
    //[SerializeField]
    //private float walkSpeed = 1.0f;
    //　速度
    private Vector3 velocity;
    //　移動方向
    private Vector3 direction;
    //　到着フラグ
    //private bool arrived;
    //　SetPositionスクリプト
    //private SetPosition setPosition;
    //　待ち時間
    [SerializeField]
    private float waitTime = 5f;
    //　経過時間
    private float elapsedTime;
    // 勇者の状態
    private SlimState state;
    //　プレイヤーTransform
    private Transform HeroTransform;

    // Start is called before the first frame update
    void Start()
    {
        heroController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();
        velocity = Vector2.zero;
        //arrived = false;
        elapsedTime = 10f;
        SetState(SlimState.Walk);
    }

    // Update is called once per frame
    void Update()
    {

        if (state == SlimState.Walk || state == SlimState.Chase)
        {

            //　キャラクターを追いかける状態であればキャラクターの目的地を再設定
            if (state == SlimState.Chase)
            {

            }

        }
        else if (state == SlimState.Wait)
        {
            elapsedTime += Time.deltaTime;



            //　待ち時間を越えたら次の目的地を設定
            if (elapsedTime > waitTime)
            {
                SetState(SlimState.Walk);
            }
        }
    }
    //　敵キャラクターの状態変更メソッド
    public void SetState(SlimState tempState, Transform targetObj = null)
    {
        if (tempState == SlimState.Walk)
        {
            //arrived = false;
            elapsedTime = 0f;
            state = tempState;
        }
        else if (tempState == SlimState.Chase)
        {
            state = tempState;
            //　待機状態から追いかける場合もあるのでOff
            //arrived = false;
            //　追いかける対象をセット
            HeroTransform = targetObj;
        }
        else if (tempState == SlimState.Wait)
        {
            elapsedTime = 0f;
            state = tempState;
            //arrived = true;
            velocity = Vector2.zero;
        }
    }
    //　敵キャラクターの状態取得メソッド
    public SlimState GetState()
    {
        return state;
    }



}