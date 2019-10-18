using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDirectionalAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animation anim;
    public Animator Anim { get { return this._anim ? this._anim : this._anim = GetComponent<Animator>(); } }
    public Vector2 Direction { get; private set; }

    //add start
    private Vector3 prev_h;
    private Vector3 prev_v;
    [SerializeField]
    private int minute;
    [SerializeField]
    private float seconds;
    //　前のUpdateの時の秒数
    private float oldSeconds;
    //攻撃方向フラグ
    int flag = 0;
    //add end

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>();
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }

        //Debug.Log(seconds+"秒");

        Vector2 inputAxis = new Vector2((int)Input.GetAxis("Horizontal"), (int)Input.GetAxis("Vertical"));
        if (inputAxis != Vector2.zero) Direction = inputAxis;

        //add start yoshimatsu
        var Horizontal = transform.position.x - prev_h.x;
        var Vertical   = transform.position.y - prev_v.y;
        //add end yoshimatsu

        

        if (Vertical > 0)
        {
            Direction = Vector2.up;
            flag      = 2;
        }
        if (Horizontal < 0)
        {
            Direction = Vector2.left;
            flag      = 3;
        }
        if (Vertical < 0)
        {
            Direction = Vector2.down;
            flag      = 1;
        }
        if (Horizontal > 0)
        {
            Direction = Vector2.right;
            flag      = 4;
        }

        Debug.Log("Horizontal" + Horizontal + "Vertical" + Vertical);
        if (Direction != Vector2.zero)
        {
            if (Horizontal != 0 && Vertical != 0 || seconds <= 1)
            {
                Anim.speed = 1.0f;
                Anim.SetFloat("x", Direction.x);
                Anim.SetFloat("y", Direction.y);
            }
            else if (Horizontal == 0 && Vertical == 0)
            {
                //anim.Play (flag);
                Debug.Log("★★" + flag);
                Anim.SetInteger("AnimIdx", flag);

            }
            else
            {
                Anim.speed = 1.0f;
                Anim.SetFloat("x", Direction.x);
                Anim.SetFloat("y", Direction.y);
            }
        }
        else
        {
            Anim.speed = 0.0f;
        }
        

        //add start yoshimatsu
        prev_h.x = transform.position.x;
        prev_v.y = transform.position.y;
        //add end yoshimatsu
        oldSeconds = seconds;

    }

    Vector2 GetButtonDirection()
    {
        float x = (Input.GetKey(KeyCode.D)) ? 1.0f : (Input.GetKey(KeyCode.A)) ? -1.0f : 0.0f;
        float y = (Input.GetKey(KeyCode.W)) ? 1.0f : (Input.GetKey(KeyCode.S)) ? -1.0f : 0.0f;
        return new Vector2(x, y);
    }
}