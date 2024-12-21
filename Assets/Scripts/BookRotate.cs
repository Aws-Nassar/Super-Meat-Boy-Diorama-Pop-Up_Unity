using UnityEngine;

public class BookRotate : MonoBehaviour
{
    private float rotationSpeed = 100f;
    private float currentAngle = 0f;
    public Transform bookRightCover;
    public Transform movingCamera;
    private float moveSpeed = 2.7f;
    private Vector3 moveDirection = new Vector3(1, 0, 0);

    public static int isBookRotated = 0;
    
    void Update()
    {
        float rotateHorizontal = Input.GetAxis("Horizontal");

        if (rotateHorizontal != 0)
        {
            float rotationChange = -rotateHorizontal * rotationSpeed * Time.deltaTime;
            currentAngle += rotationChange;
            currentAngle = Mathf.Clamp(currentAngle, -180f, 0f);
            bookRightCover.rotation = Quaternion.Euler(0f, 0f, currentAngle);
            if (currentAngle > -180f && currentAngle < 0f)
            {
                if (rotateHorizontal > 0)
                {
                    movingCamera.Translate(moveDirection * moveSpeed * Time.deltaTime);
                }
                else if (rotateHorizontal < 0)
                {
                    movingCamera.Translate(-moveDirection * moveSpeed * Time.deltaTime);
                }
            }
        }

        if (currentAngle == -180f)
        {
            isBookRotated = 1;
        }

        else if (currentAngle == 0f)
        {
            isBookRotated = -1;
        }

        else
        {
            isBookRotated = 0;
        }
    }
}
