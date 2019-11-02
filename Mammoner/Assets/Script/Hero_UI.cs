using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hero_UI : MonoBehaviour
{

    public GameObject hero;
    public Text hero_hp;
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
        hero_hp.text = hp.ToString();
   
    }
}
