using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HpStatus : MonoBehaviour
{
   // [SerializeField]
    public float Hero_hp = 40f;
    // Start is called before the first frame update
    void Start()
    {
    }
    void OnTriggerStay2D(Collider2D col)
    {
       // Debug.Log("aaaa"+ Hero_hp);
        //Hero_hp -= Time.deltaTime;
        //Invoke("DelayHeroMethod", Hero_hp);
        Hero_hp -= Time.deltaTime;
        if (Hero_hp <= 0)
        {
            Destroy(gameObject.transform.root.gameObject);
        }
    }
    //void DelayHeroMethod()
    //{
    //    Destroy(gameObject.transform.root.gameObject);
    //}
}