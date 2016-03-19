using UnityEngine;
using System.Collections;

namespace Example {

    /// <summary>
    /// When attached will make the object follow the 
    /// mouse around, maintaining a `0` z position.
    /// </summary>
    public class FollowMouse : MonoBehaviour {

        // Update is called once per frame
        void Update() {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0f;
            transform.position = newPosition;
        }
    }
}
