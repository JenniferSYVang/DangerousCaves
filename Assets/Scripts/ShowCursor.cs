using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursor : MonoBehaviour {
    
        public void Start()
        {
        Cursor.lockState = CursorLockMode.None;
        
        }

    public void Update()
    {
        Cursor.visible = true;
    }

}
