using UnityEngine;

namespace Contained {

    /// <summary>
    /// Interface to implement to listen to 
    /// `HorizontallyContained2D` messages.
    /// </summary>
    interface IHorizontallyContained2DDelegate {

        /// <summary>
        /// Will get called when the collider is 
        /// horizontally contained within another.
        /// </summary>
        /// <param name="other">The other collider</param>
        void OnHorizontalContain(Collider2D other);

        /// <summary>
        /// Will get called when the collider is no
        /// longer horizontally contained within another.
        /// </summary>
        /// <param name="other">The other collider</param>
        void OnHorizontalExit(Collider2D other);
    }
}
