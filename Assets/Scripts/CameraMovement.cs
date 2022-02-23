
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothFactor;

    void FixedUpdate()
    {
      
        if(playerTransform.position.x>transform.position.x)
        {
            if(playerTransform.position.x > leftLimit && playerTransform.position.x < rightLimit)
            {    
                Vector3 targetTransform = new Vector3(playerTransform.position.x + offset.x, offset.y,offset.z);

                Vector3 smoothFActor = Vector3.Lerp(transform.position, targetTransform, smoothFactor * Time.fixedDeltaTime);

                transform.position = targetTransform;
            }
        }
       
    }
   
}
