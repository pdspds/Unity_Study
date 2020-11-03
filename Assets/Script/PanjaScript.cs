using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanjaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( PlayerScript.PlayerPos.x - transform.position.x >= 10.0f) {
            Destroy(gameObject);
        }
    }
}
