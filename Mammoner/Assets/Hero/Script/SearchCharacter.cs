using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Monster"){
            Debug.Log("★"); 
        }
    }
}
