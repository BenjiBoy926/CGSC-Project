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

Here in this veiw, we can see each of the objects listed, and many of them have duplicates.  Pitfalls, safe grounds and grapple points all have multiple instances in this example heirarchy.  Also, note that the grapple is placed as a child of the Player.  This merely demonstrates that the grapple object has little meaning outside of its interaction with the Player.

If you don't understand what's happening in this image, [here's](https://docs.unity3d.com/Manual/LearningtheInterface.html) a helpful page about Unity's interface

If you've never used Unity before and you'd like to learn so you can contribute to the project, you can download the free version of Unity [here](https://store.unity.com/download?ref=personal), and get started learning how to use it [here](https://unity3d.com/learn/tutorials/s/interactive-tutorials).

| <img src="README/Notice.png" alt="drawing" width="30"/> | Note: |
| --- | --- |
This is just one suggested implementation!  The final product may have a heirarchy view that looks very different from this one example