# Welcome!
We're the Computer Game Science Club at Saddleback College, and right now 
we're working on a top-down 2-D puzzle platforming game together as a club

## Central Mechanics
There are currently two central mechanics in our game:

* Full top-down 2-D movement 
( <img src="README/asdw.png" alt="drawing" height="15"/> or <img src="README/ArrowKeys.png" alt="drawing" height="15"/>)
* Throw grapple 
( <img src="README/MouseLeftClick.png" alt="drawing" height="13"/> )

This certainly leaves much to be desired in the way of fun and thrilling gameplay!  But once we have a working prototype with scalable code, we'll have a better idea about what thrilling new mechanics could be added to improve our project

![Central mechanics include full top-down 2-D movement, grapple mechanic, floors and pitfalls](README/BasicMechanicsDiagram.png)


## Object Inventory
Player objects:
* Player 
( <img src="README/BlueCircle.png" alt="drawing" width="10"/> )
* Grapple 
( <img src="README/OrangeLine.png" alt="drawing" height="10"/> )

Environmental objects:

* Safe ground 
( <img src="README/BrownSquare.png" alt="drawing" width="10"/> )
* Pitfalls 
( <img src="README/BlackSquare.png" alt="drawing" width="10"/> )
* Grapple points 
( <img src="README/PinkTriangle.png" alt="drawing" width="10"/> )
* Goal 
( <img src="README/GoldStar.png" alt="drawing" width="10"/> )

What we have above is essentially a key for understanding the fun little diagram in the [central mechanic](#central-mechanics) section of this document.

Each object listed roughly corresponds to an instance of a single [gameobject](https://docs.unity3d.com/Manual/class-GameObject.html) in a single scene in our Unity project.  In other words, when developing the initial prototype in Unity, we can expect to see a heirarchy view looking something like this:

![Example heirarchy view for our first prototype](README/ExampleHeirarchy.PNG)

Here in this veiw, we can see each of the objects listed, and many of them have duplicates.  Pitfalls, safe grounds and grapple points all have multiple instances in this example heirarchy.  Also, note that the grapple is placed as a child of the Player.  This demonstrates that the grapple object has little meaning outside of its interaction with the Player.

If you don't understand what's happening in this image, [here's](https://docs.unity3d.com/Manual/LearningtheInterface.html) a helpful page about Unity's interface

If you've never used Unity before and you'd like to learn so you can contribute to the project, you can download the free version of Unity [here](https://store.unity.com/download?ref=personal), and get started learning how to use it [here](https://unity3d.com/learn/tutorials/s/interactive-tutorials).

| <img src="README/Notice.png" alt="drawing" width="30"/> | Note: 
| --- | --- |
| | This is just one suggested implementation!  The final product may have a heirarchy view that looks very different from this one example |

## Program Design
It is far beyond the scope of this document to give a complete description of every class that needs to be designed and implemented in this project!  Nevertheless, there are some design strategies that are important to know as an introduction to this project

Each object in [this](#object-inventory) section of the document should NOT be confused with a single *class* in the project's program files.  Take the player object as an example.  A typical temptation would be to write a class like this...

```cs
using UnityEngine;

public class Player : MonoBehaviour
{
	//...data members

	// Accomplish central grappling mechanic
	public void ThrowGrapple(Vector2 mousePos) 
	{
		//...implementation
	}

	// Accomplish central movement mechanic
	public void Move(Vector2 direction) 
	{
		//...implementation
	}
}
```

...and attach it to the player game object like this...

![Example of a bad way to design the player gameobject and code](README/PlayerComponentBad.png)

This design is *not advisable* for at least three reasons:

* Lacks scalability
	* Every feature later added onto the game related to the player would have to be heaped into this single class, resulting in a huge, bloated piece of code
* Lacks modifiability
	* Bugs from the Player would have to be searched and sifted out in this one badly organized bloated class
* Stunts collaboration
	* It's difficult for multiple programmers to work on the same class file, so in this case, all the *many* features of the Player would have to be assigned to a *single* programmer

A much better program design should be with these two pieces of code...

```cs
using UnityEngine;

// Accomplish central grappling mechanic
public class GrappleThrower : MonoBehaviour
{
	//...data

	public void ThrowGrapple(Vector2 mousePos)
	{
		//...implementation
	}
}
```

```cs
using UnityEngine;

// Accomplish central movement mechanic
public class Mover : MonoBehaviour
{
	//...data

	public void Move(Vector2 direction)
	{
		//...implementation
	}
}
```

...attached to the Player game object like this...

![Example of an effective way to design player gameobjct and code](README/PlayerComponentGood.png)