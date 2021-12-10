using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderSceneScript : MonoBehaviour
{
    PlayerScript ps;
    public int controlKey;

    // Start is called before the first frame update
    void Start()
    {
        controlKey = 0;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Maneja el estado de:

        //si entra el Player, si es por "A" o "D"
        if (col.gameObject.tag == "Player")
        {
            ps = col.gameObject.GetComponent<PlayerScript>();
            ps.canMove = false;

            if (Input.GetKey(KeyCode.A))
            {
                controlKey = 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                controlKey = 2;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        //Maneja el estado de:

        if (col.gameObject.tag == "Player")
        {
            ps = col.gameObject.GetComponent<PlayerScript>();

            if ((Input.GetKey(KeyCode.A) && controlKey == 2))
            {
                ps.canMove = true;
                controlKey = 0;
            }
            else if (Input.GetKey(KeyCode.D) && controlKey == 1)
            {

                ps.canMove = true;
                controlKey = 0;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {

        //Maneja el estado de:

        if (col.gameObject.tag == "Player")
        {
            ps = col.gameObject.GetComponent<PlayerScript>();
            ps.canMove = true;
            controlKey = 0;
        }
    }

}
