using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ButtonTouch() {
        GetComponent<Animation>().Play("ButtonTouch");
    }
}
