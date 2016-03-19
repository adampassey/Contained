using UnityEngine;
using Contained;

namespace Example {

    public class ContainedListener : MonoBehaviour, IHorizontallyContained2DDelegate {

        public void OnHorizontalContain(Collider2D other) {
            Debug.Log("Listener notified of containment!");
        }

        public void OnHorizontalExit(Collider2D other) {
            Debug.Log("Listener notified of exit!");
        }
    }
}
