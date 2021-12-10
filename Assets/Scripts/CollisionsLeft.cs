using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsLeft : MonoBehaviour
{

    PlayerScript ps;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ps = col.gameObject.GetComponent<PlayerScript>();

            if (Input.GetKey(KeyCode.A))
            {
                //ps.canMoveL = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ps = col.gameObject.GetComponent<PlayerScript>();
            //ps.canMoveL = true;
        }
    }

}
