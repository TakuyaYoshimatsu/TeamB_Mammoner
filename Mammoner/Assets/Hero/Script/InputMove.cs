using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMove : MonoBehaviour
{
    [SerializeField]
    float speed = 0.1f;
    Vector2 inputAxis;
    //private Rigidbody2D _rig;
    //public Rigidbody2D Rig { get { return this._rig ? this._rig : this._rig = GetComponent<Rigidbody2D>(); } }
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var v = new Vector2(-speed, rb.velocity.y);
        transform.Translate(v);
    }
}