using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseScene : MonoBehaviour
{

    private int i;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = 0.04f;
        i=0;   
    }

    // Update is called once per frame
    void Update()
    {
        if(i==700)
            transform.localScale = new Vector3(-(transform.localScale.x),transform.localScale.y,transform.localScale.z);
        if(i==1400)
            transform.localScale = new Vector3(transform.localScale.x,-(transform.localScale.y),transform.localScale.z);

        if(i>1400)
            transform.Translate(Vector3.right * speed);
            
        
        i++;

     
    }
}
