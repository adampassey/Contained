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

        /// <summary>
        /// Sets the `Collider2D` to be a trigger. This is
        /// required as otherwise the collider could react
        /// to collisions with other colliders.
        /// </summary>
        void Start() {
            coll = gameObject.GetComponent<Collider2D>();
            coll.isTrigger = true;
        }

        /// <summary>
        /// When this collider enters another, check to see
        /// if it is fully contained. If so, notify and delegates.
        /// </summary>
        /// <param name="other">The other collider</param>
        public void OnTriggerEnter2D(Collider2D other) {
            if (isHorizontallyContained(other)) {
                notifyOfContain(other);
            }
        }

        /// <summary>
        /// As the collider continually collides with another, check
        /// to see if it is horizontally bound. Notify delegates if
        /// it becomes contained or exits.
        /// </summary>
        /// <param name="other">The other collider</param>
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

        /// <summary>
        /// When the collider exits collision we'll notify
        /// delegates if it was previously contained.
        /// </summary>
        /// <param name="other">The other collider</param>
        public void OnTriggerExit2D(Collider2D other) {
            if (isContained) {
                notifyOfExit(other);
            }
        }

        /// <summary>
        /// Checks whether the collider on this object is horizontally
        /// contained in the one passed by checking the bounds of 
        /// each collider.
        /// </summary>
        /// <param name="other">The collider to check against</param>
        /// <returns>True if horizontally contained, false if not</returns>
        private bool isHorizontallyContained(Collider2D other) {
            if ((coll.bounds.center.x - coll.bounds.size.x / 2) > (other.bounds.center.x - other.bounds.size.x / 2) &&
                (coll.bounds.center.x + coll.bounds.size.x / 2) < (other.bounds.center.x + other.bounds.size.x / 2)) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Notify all components on this object that implement the
        /// `IHorizontallyContained2DDelegate` interface that the collider
        /// has entered containment.
        /// </summary>
        /// <param name="other">The other collider</param>
        private void notifyOfContain(Collider2D other) {
            gameObject.SendMessage("OnHorizontalContain", other);
            isContained = true;
        }

        /// <summary>
        /// Notify all components on this object that implement the
        /// `IHorizontallyContained2DDelegate` interface that the collider
        /// has exited containment.
        /// </summary>
        /// <param name="other">The other collider.</param>
        private void notifyOfExit(Collider2D other) {
            gameObject.SendMessage("OnHorizontalExit", other);
            isContained = false;
        }
    }
}
