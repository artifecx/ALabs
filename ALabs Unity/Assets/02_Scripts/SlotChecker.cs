using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isOpen = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("state"))
        {
            isOpen = false;
        }
        else
        {
            isOpen = true;
        }
    }
    public bool GetIsOpen()
    {
        return isOpen;
    }

}
