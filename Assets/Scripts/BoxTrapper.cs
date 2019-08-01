using UnityEngine;
using System.Collections;

public class BoxTrapper : MonoBehaviour {

    public GameObject VundaBall;

    void OnCollisionEnter(Collision collide)
    { 
    if(collide.gameObject.name == "VBall")
        {
            VundaBall.transform.localPosition = Vector3.Lerp(this.transform.localPosition, levelSettings.VBallVector, 1f);
            //print("I just collided with VundaBall!");
        }
    }

}
