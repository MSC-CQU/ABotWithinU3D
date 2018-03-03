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

        charactor.transform.position = new Vector3(charactor.transform.position.x, camera.transform.position.y - 1f,
            charactor.transform.position.z);
    }

    private void Update()
    {
        //charactor.transform.position = new Vector3(charactor.transform.position.x, camera.transform.position.y, charactor.transform.position.z);

        if (randomTimeSpan < 0 && motionState == MotionState.Wait)
        {

        }
    }

    public void Follow()
    {
        if (isFollowing) return;
        isFollowing = true;
        //charactor.GetComponent<HoloToolkit.Unity.Billboard>().enabled = true;
        StartCoroutine(FollowCamera());
        Debug.Log("Following");
    }

    public void Stand()
    {
        isFollowing = false;
        rigidbody.velocity = Vector3.zero;
        motionState = MotionState.Wait;
        //charactor.GetComponent<HoloToolkit.Unity.Billboard>().enabled = false;
        anim.SetInteger("MoveState", (int)motionState);
        Debug.Log("Standing");
    }

    private IEnumerator FollowCamera()
    {
        float div = 0.01f;
        while (isFollowing)
        {
            Vector3 charactorPosition = charactor.transform.position;
            Vector3 cameraPosition = camera.transform.position;
            float dis = Vector3.Distance(charactorPosition, cameraPosition);
            charactor.transform.position = new Vector3(charactor.transform.position.x,
                Mathf.Lerp(charactor.transform.position.y, camera.transform.position.y - 1f, div += Time.deltaTime),
                charactor.transform.position.z);
            Debug.Log(dis);
            //Debug.Log(isFollowing);
            charactor.transform.LookAt(camera.transform, Vector3.up);
            var tempRotation = charactor.transform.rotation.eulerAngles;
            charactor.transform.rotation = Quaternion.Euler(0, tempRotation.y, tempRotation.z);
            if (dis > 3.5f)
            {
                Vector3 direction = cameraPosition - charactorPosition;
                direction.y = 0f;
                rigidbody.velocity = direction.normalized * 2f;
                motionState = MotionState.Run;
            }
            else if (dis > 2)
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
