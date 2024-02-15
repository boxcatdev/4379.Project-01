using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBroadcaster : MonoBehaviour
{
    [field: SerializeField]
    public bool IsTapPressed { get; private set; } = false;
    //TODO add other input events here

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IsTapPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            IsTapPressed = false;
        }
    }
}
