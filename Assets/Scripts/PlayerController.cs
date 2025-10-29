using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    private float minY = -4.35f;
    private float maxY = 4.35f;
    public float vertical;


    void Update()
    {
        //Vector3 currentPosition = transform.position;

        //currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);
        //transform.position = currentPosition;

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY), 0);

        bool isPressingUp = Input.GetKey(KeyCode.W);
        bool isPressingDown = Input.GetKey(KeyCode.S);
        vertical = 0;


        if(isPressingUp)
        {
            if(transform.position.y < maxY)
            {
                transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
                vertical = 0.2f;
            }
            

        }
        else if(isPressingDown)
        {
            if(transform.position.y > minY)
            {
                transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
                vertical = -0.2f;
            }
        }
    }
}
