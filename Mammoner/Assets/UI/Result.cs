using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Result : MonoBehaviour
{
    public Text txt;
    public GameObject hero;
    public GameObject mamo;
    HpStatus status;
    int hp;
    // Start is called before the first frame update
    void Start()
    {
        status = hero.GetComponent<HpStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        hp = (int)status.Hero_hp;

        if (hp < 1) {
            txt.text = "勝利";
        }
        if (hero != null)
        {
            if (hero.transform.position.x > 7) {
                txt.text = "敗北";
                mamo.SetActive(false);
            }
        }
    }
}
