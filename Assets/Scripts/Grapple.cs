using UnityEngine;
using System.Collections;

public class Grapple : MonoBehaviour
{

    public LineRenderer line;
    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;
    public float step = 0.02f;
    public AudioClip grappleSound;

    // Use this for initialization
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (joint.distance > .5f)
        {
            joint.distance -= step;
        }

        else
        {
            line.enabled = false;
            joint.enabled = false;

        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            //draw a ray to the object we are hitting
            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)

            {
                joint.enabled = true;
                SoundManager.instance.RandomizeSfx(grappleSound);
                Vector2 connectionPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                connectionPoint.x = connectionPoint.x / hit.collider.transform.localScale.x;
                connectionPoint.y = connectionPoint.y / hit.collider.transform.localScale.y;
                joint.connectedAnchor = connectionPoint;

                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);


            }
        }
        //ensure there is a connection point
        if (joint.connectedBody != null)
        {
            line.SetPosition(1, joint.connectedBody.transform.TransformPoint(joint.connectedAnchor));
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {

            line.SetPosition(0, transform.position);
        }


        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            joint.enabled = false;
            line.enabled = false;
        }

    }
}

