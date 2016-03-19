using UnityEngine;
using Contained;

namespace Example {

    public class ContainedListener : MonoBehaviour, IHorizontallyContainedDelegate {

        public void OnContain(Collider2D other) {
            Debug.Log("Listener notified of containment!");
        }

        public void OnExit(Collider2D other) {
            Debug.Log("Listener notified of exit!");
        }
    }
}
