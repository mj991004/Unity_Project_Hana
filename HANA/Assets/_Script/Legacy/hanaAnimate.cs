/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class hanaAnimate : MonoBehaviour
{
    Rigidbody2D rigidbody;
    SkeletonAnimation skeleton;
    bool isGrounded=false;
    bool isLookRIght=true;
    const int size = 4;

    private AnimationReferenceAsset[] AnimClip;
    enum State {IDLE, MOVING, JUMPING};
    State accessAnim, currentAnim;
    PlayerControll controll;
    Transform transform;
    float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        skeleton = GetComponent<SkeletonAnimation>();
        controll = GetComponent<PlayerControll>();
        transform = GetComponent<Transform>();
        currentAnim = State.IDLE;
        skeleton.skeleton.SetAttachment("[base]face", "side/face/[base]smile");

        x = gameObject.transform.localScale.x;
        y = gameObject.transform.localScale.y;
        z = gameObject.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controll.getIsGrounded();

        if (!isGrounded)
        {
            accessAnim = State.JUMPING;
        }
        else if (Input.GetAxis("Horizontal")!=0)
        {
            accessAnim = State.MOVING;
            
        }
        else
        {
            accessAnim = State.IDLE;
        }

        if (rigidbody.velocity.x <0 && isLookRIght==true)
        {
            transform.localScale = new Vector3 (-x,y,z);
            isLookRIght = false;
        }
        else if (rigidbody.velocity.x > 0 && isLookRIght == false)
        {
            transform.localScale = new Vector3(x, y, z);
            isLookRIght = true;
        }

        _AsncAnim(accessAnim, true, 1f);
    }
    private void _AsncAnim(State Anim, bool loop, float timescale)
    {
        if (Anim == currentAnim) return;

        string x="";
        switch (Anim)
        {
            case State.IDLE:
                x = "idle_side";
                break;
            case State.JUMPING:
                x = "get_side";
                break;
            case State.MOVING:
                x = "walk_side";
                break;
        }

        skeleton.state.SetAnimation(0, x, loop);
        skeleton.state.TimeScale = timescale;
        currentAnim = Anim;
    }
}
*/