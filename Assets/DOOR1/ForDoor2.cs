using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForDoor2 : MonoBehaviour
{
    public Transform Door, Looker, Re, UnRe;
    public bool B_l, lastB_l;
    public AnimationCurve curvaX, curvaY, curvaZ;
    public float t = 0;
    public float Minus, Plus;

    // Start is called before the first frame update
    void Start()
    {
        //curvaX.keys[1].value = Ru4ka.localPosition.x;
        //curvaY.keys[1].value = Ru4ka.localPosition.y;
        //curvaZ.keys[1].value = Ru4ka.localPosition.z;
        curvaX.MoveKey(1, new Keyframe(1, UnRe.localPosition.x));
        curvaY.MoveKey(1, new Keyframe(1, UnRe.localPosition.y));
        curvaZ.MoveKey(1, new Keyframe(1, UnRe.localPosition.z));
    }

    // Update is called once per frame
    void Update()
    {
        Looker.LookAt(UnRe);
        if (Looker.localEulerAngles.y >= Minus && Looker.localEulerAngles.y <= Plus)
        {
            Door.localEulerAngles = new Vector3(0, Looker.localEulerAngles.y, 0);
        }
        else {
            if (Looker.localEulerAngles.y < Minus) { 
                Door.localEulerAngles = new Vector3(0, Minus, 0);
            }
            if (Looker.localEulerAngles.y > Plus) { 
                Door.localEulerAngles = new Vector3(0, Plus, 0);
            }
        }
        
        
        
        if (B_l) {
            
        } else {//здесь мы шевелим ручку
            //lastBool = true;
            if (lastB_l)
            {
                t = Time.time;
                curvaX.MoveKey(0, new Keyframe(0, UnRe.localPosition.x));
                curvaY.MoveKey(0, new Keyframe(0, UnRe.localPosition.y));
                curvaZ.MoveKey(0, new Keyframe(0, UnRe.localPosition.z));
                //curvaX.keys[0].value = UnRu4ka.localPosition.x;
                //curvaY.keys[0].value = UnRu4ka.localPosition.y;
                //curvaZ.keys[0].value = UnRu4ka.localPosition.z;
                lastB_l = false;
            }
            UnRe.localPosition = new Vector3(curvaX.Evaluate(Time.time - t), curvaY.Evaluate(Time.time - t), curvaZ.Evaluate(Time.time - t));
        }
        B_l = false;
    }
}
