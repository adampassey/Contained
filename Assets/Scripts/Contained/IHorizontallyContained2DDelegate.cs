using UnityEngine;

namespace Contained {

    interface IHorizontallyContained2DDelegate {

        void OnHorizontalContain(Collider2D other);

        void OnHorizontalExit(Collider2D other);
    }
}
