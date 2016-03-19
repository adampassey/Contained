using UnityEngine;

namespace Contained {

    interface IHorizontallyContainedDelegate {

        void OnContain(Collider2D other);

        void OnExit(Collider2D other);
    }
}
