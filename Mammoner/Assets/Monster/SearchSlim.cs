using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchSlim : MonoBehaviour
{
    private MoveSlim moveSlim;
    [SerializeField]
    private float Slim_hp = 2f;
    // Start is called before the first frame update
    void Start()
    {
        moveSlim = GetComponentInParent<MoveSlim>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Attack")
        {
            //　敵キャラクターの状態を取得
            MoveSlim.SlimState state = moveSlim.GetState();
            if (state != MoveSlim.SlimState.Chase)
            {
                moveSlim.SetState(MoveSlim.SlimState.Chase, col.transform);
            }

            //Slim_hp -= Time.deltaTime
            Invoke("DelayMethod", Slim_hp);


        }
    }

    void DelayMethod()
    {
        Destroy(gameObject);
    }
}
