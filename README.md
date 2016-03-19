# Contained

Unity3D components and delegates for detecting whether a `Collider2D` is fully contained within another `Collider2D`.

## Installation

Download the [contained.unitypackage](https://github.com/adampassey/contained/blob/master/contained.unitypackage) and import it into Unity
by going to `Assets > Import Package > Custom Package`. Choose [contained.unitypackage](https://github.com/adampassey/contained/blob/master/contained.unitypackage)
and import all assets.

## Setup

Contained notifies components of horizontal containment only. In order to listen to these events, attach a 
[HorizontallyContained](https://github.com/adampassey/contained/blob/master/Assets/Scripts/Contained/HorizontallyContained.cs)
component to your `GameObject` as well as the component that will be listening to these events. You can then subscribe to these events
by implementing the `IHorizontallyContainedDelegate` from within the `Contained` namespace. An example of this can be seen below:


```c#
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
```
