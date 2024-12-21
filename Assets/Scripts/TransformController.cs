using UnityEngine;

public class TransformController : MonoBehaviour
{
    public Transform transform1;
    private float transform1MoveX = 5f;

    public Transform transform2;
    private float transform2RotateY = 45f;

    public Transform transform3;
    private float transform3MoveX = 3.1f;

    public Transform transform4;
    private float transform4MoveZ = 2f;

    public Transform transform5;

    private float speed = 5f;

    private bool actionTriggered = false;

    private float transform1MoveTime = 0f;
    private float transform2RotateTime = 0f;
    private float transform3MoveTime = 0f;
    private float transform4MoveTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !actionTriggered && BookRotate.isBookRotated == 1)
        {
            actionTriggered = true;
        }

        else if (actionTriggered && BookRotate.isBookRotated < 1)
        {
            actionTriggered = false;
        }

        if (actionTriggered)
        {
            MoveMeatBoy();
        }
    }

    private void MoveMeatBoy()
    {
        if (transform1MoveTime < transform1MoveX)
        {
            float moveAmount = Time.deltaTime * speed;
            transform1.Translate(Vector3.right * moveAmount, Space.World);
            transform1MoveTime += moveAmount;
        }
        else
        {
            RotateSwitchArm();
        }
    }

    private void RotateSwitchArm()
    {
        if (transform2RotateTime < transform2RotateY)
        {
            float rotateAmount = Time.deltaTime * speed * 3;
            transform2.Rotate(Vector3.up, rotateAmount, Space.World);
            transform2RotateTime += rotateAmount;
        }
        else
        {
            MovePitDoor();
        }
    }

    private void MovePitDoor()
    {
        if (transform3MoveTime < transform3MoveX)
        {
            float moveAmount = Time.deltaTime * speed;
            transform3.Translate(Vector3.right * moveAmount, Space.World);
            transform3MoveTime += moveAmount;
        }
        else
        {
            MoveCageDown();
        }
    }

    private void MoveCageDown()
    {
        if (transform4MoveTime < transform4MoveZ)
        {
            float moveAmount = Time.deltaTime * speed;
            transform4.Translate(-Vector3.forward * moveAmount, Space.World);
            transform5.Translate(-Vector3.forward * moveAmount, Space.World);
            transform4MoveTime += moveAmount;
        }
    }
}
