using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerScript.IsDeath == true) {
            Destroy(gameObject);
        }

        if( PlayerScript.PlayerPos.x - transform.position.x >= 10.0f) {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        LogicValue.PlusScore(10);
        Destroy(gameObject);
    }


}
