using UnityEngine;

public class SideScrolling : MonoBehaviour
{
   public Transform targetToFollow;

   public float height = 6.5f;
   public float undergroundHeight = -8.5f;

   private void LateUpdate()
   {
     transform.position = new Vector3 (
          Mathf.Clamp(targetToFollow.position.x, 15.5f, 88f),
          transform.position.y,
          transform.position.z);
     
   }

   public void SetUnderground(bool underground)
   {
     Vector3 cameraPosition = transform.position;
     cameraPosition.y = underground ? undergroundHeight : height;
     transform.position = cameraPosition;
   }
}

//    Vector3 cameraPosition = transform.position;
     //    cameraPosition.x = player.position.x;
     //    transform.position = cameraPosition;

     //    Vector3 cameraPosition = transform.position;
     //    cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
     //    cameraPosition.x = Mathf.Clamp(cameraPosition.x, 1.5f, 200f);
     //    transform.position = cameraPosition;