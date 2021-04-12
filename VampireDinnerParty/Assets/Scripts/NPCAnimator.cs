using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    private AIMovement aiMovement;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        aiMovement = GetComponentInParent<AIMovement>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aiMovement.isMoving == true)
        {
            anim.SetInteger("Movespeed", 1);
            return;
        }
        if (aiMovement.isDead == true)
        {
            anim.SetInteger("Movespeed", 2);
            return;
        }

        anim.SetInteger("Movespeed", 0);

        //gameObject.transform.localRotation = gameObject.transform.parent.rotation;
    }
}
