using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMotionController : MonoBehaviour
{
    [SerializeField]
    private GameObject charactor;
    [SerializeField]
    private new GameObject camera;
    [SerializeField]
    private GameObject animator;

    private bool isFollowing;
    private Animator anim;
    private new Rigidbody rigidbody;
    private MotionState motionState;
    private float randomTimeSpan;

    private void Start()
    {
        anim = animator.GetComponent<Animator>();
        rigidbody = charactor.GetComponent<Rigidbody>();
        isFollowing = false;
        motionState = MotionState.Wait;
        randomTimeSpan = Random.Range(1000, 5000);
    }

    private void Update()
    {
        if (randomTimeSpan < 0 && motionState == MotionState.Wait)
        {

        }
    }

    public void Follow()
    {
        if (isFollowing) return;
        isFollowing = true;
        StartCoroutine(FollowCamera());
        Debug.Log("Following");
    }

    public void Stand()
    {
        isFollowing = false;
        rigidbody.velocity = Vector3.zero;
        motionState = MotionState.Wait;
        anim.SetInteger("MoveState", (int)motionState);
        Debug.Log("Standing");
    }

    private IEnumerator FollowCamera()
    {
        while (isFollowing)
        {
            Vector3 charactorPosition = charactor.transform.position;
            Vector3 cameraPosition = camera.transform.position;
            float dis = Vector3.Distance(charactorPosition, cameraPosition);
            charactor.transform.position = new Vector3(charactor.transform.position.x, camera.transform.position.y, charactor.transform.position.z);
            //Debug.Log(dis);
            //Debug.Log(isFollowing);
            charactor.transform.LookAt(camera.transform, Vector3.up);
            if (dis > 7)
            {
                Vector3 direction = cameraPosition - charactorPosition;
                direction.y = 0f;
                rigidbody.velocity = direction.normalized * 2f;
                motionState = MotionState.Run;
            }
            else if (dis > 5)
            {
                Vector3 direction = cameraPosition - charactorPosition;
                direction.y = 0f;
                rigidbody.velocity = direction.normalized;
                motionState = MotionState.Walk;
                //anim.SetTrigger("Walk");
            }
            else
            {
                rigidbody.velocity = Vector3.zero;
                //anim.SetTrigger("Wait");
                motionState = MotionState.Wait;
            }
            anim.SetInteger("MoveState", (int)motionState);
            yield return null;
            //if (!isFollowing) break;
        }
    }

    enum MotionState
    {
        Wait,
        Walk,
        Run
    }
}
