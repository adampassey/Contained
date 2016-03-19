using UnityEngine;

namespace Contained {

    [AddComponentMenu("Contained/HorizontallyContained2D")]
    [RequireComponent(typeof(Collider2D))]
    public class HorizontallyContained2D : MonoBehaviour {

        /// <summary>
        /// The collider component attached to
        /// this object.
        /// </summary>
        private Collider2D coll;

        /// <summary>
        /// Whether or not this collider is
        /// currently contained in another collider.
        /// </summary>
        private bool isContained = false;

        // Use this for initialization
        void Start() {
            coll = gameObject.GetComponent<Collider2D>();
            coll.isTrigger = true;
        }

        public void OnTriggerEnter2D(Collider2D other) {
            if (isHorizontallyContained(other)) {
                notifyOfContain(other);
            }
        }

        public void OnTriggerStay2D(Collider2D other) {
            if (isHorizontallyContained(other)) {
                if (isContained) {
                    return;
                }
                notifyOfContain(other);
            } else {
                if (isContained) {
                    notifyOfExit(other);
                }
            }

        }

        public void OnTriggerExit2D(Collider2D other) {
            if (isContained) {
                notifyOfExit(other);
            }
        }

        private bool isHorizontallyContained(Collider2D other) {
            if ((coll.bounds.center.x - coll.bounds.size.x / 2) > (other.bounds.center.x - other.bounds.size.x / 2) &&
                (coll.bounds.center.x + coll.bounds.size.x / 2) < (other.bounds.center.x + other.bounds.size.x / 2)) {
                return true;
            }
            return false;
        }

        private void notifyOfContain(Collider2D other) {
            gameObject.SendMessage("OnHorizontalContain", other);
            isContained = true;
        }

        private void notifyOfExit(Collider2D other) {
            gameObject.SendMessage("OnHorizontalExit", other);
            isContained = false;
        }
    }
}
