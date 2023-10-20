[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/Xmv1pZ8x)
# README.md

**Pinkmans Playground**

| Name       | Keshav Natarajan    |
| ---------- | --- |
| Student ID | 1005495    |

## Basic Game Description

Pinkmans Playground is a 2D Platformer game where the player needs to collect 3 keys per level in order to unlock a flag and proceed to the next level. However, the flag is also guarded by a door that can only be opened with a button after collecting all the keys. 

![image](https://github.com/50033-game-design-and-development/50033-midterm-partb-keshavblack123/assets/101310828/4e6231d9-340c-46df-8799-5c2d2376c0a4)


### Game Executable

**State system requirements: Windows, macOS, etc**

[Provide a **link** to download your game executable]  
(https://drive.google.com/file/d/1XxFmBlXLU-_sS-mHEKuR3CUDxpl50Md-/view?usp=share_link)  
for MacOS Intel

### How to Play

You use "A" and "D" to move around and Spacebar to jump. You can attack enemies by jumping on them. You can pick up coins for points and keys to enable the flag. You will need to avoid the bullets of the tree trunk, but he is safe to hit from the front. The bunny is deadly everywhere but his head. 

### Gameplay Video

A ~60s recorded run of your game from start to finish (you may record from Unity editor, show your Game window clearly). You may provide a **working link, or a gif embedded directly here.**  
https://youtu.be/gyHq01gCoOg (shorter video)

https://youtu.be/iEqAuV2Tl_Q (original length)

## Features Implementation

Fill up the table below based on the **features** that you want us to grade you with. You may implement more features than what you can afford as your feature points, so you can select the features that we can grade. Feature prerequisite rule should apply.

You are free to transform the table below into short paragraphs if you’d like. The goal is to ensure that we **can find** and **confirm** each node implementation.

| Node ID | Color | Short Description of Implementation | Feature Point Cost | Marks to earn |
| ------- | ----- | ----------------------------------- | ------------------ | ------------- |
|    5    |White| Camera follows the player as he move   |1               |        3      |
|    7    |White|There are platforms and other objects|          1        |           3   |
|    9    |White|Orange background with sun and clouds|          1        |        3      |
|    17   |White|Player has run, death, jump, doublejump animations| 1  |          3     |
|    19   |White|Prefabs of 2 enemies created        |         1          |         3     |
|    22   |White|Trunk has idle, shooting, death animation|     1              |        3      |
|    23   |White|2D canvas has score and buttons|              1      |           3    |
|    24   |White|The number of keys the player needs is displayed| 1     |        3     |
|    25   |White|pause manu works with an option to reume|         1         |      3       |
|    26   |White|HUD manager manages the UI           |          1         |         3     |
|    28   |White|Audiomixer manages more than 6 audio sources|   1         |       3       |
|    31   |White|player and all enemies have death sounds|        1         |       3      |
|    30   |White|coin, key, and switch have audio effects|         1         |      3       |
|    27   |White|All text is readable and UI is clear|           1       |         3    |
|    35   |White|Animations, sprites etc are all in appropriate folders|1|        3      |
|    37   |White|Naming conventions followed throughout the code| 1        |        3      |
|    34   |White|All variables and methods are named appropriately|  1    |         3     |
|    48   |Orange|3 objects: coins, keys, switch (interactive)|    2       |        10     |
|    39   |Orange|Trunk has a shooting attack mechanism|           2        |        10     |
|    75   |Purple|2 Levels created, score stays throughout levels|  4        |        20     |

**Total Feature Point spent:**  
25

**Maximum Marks to earn:**  
91 (or 90 due to cap)

### Feature Tree Visual Representation

Download the feature tree image and indicate the nodes that you have implemented. Display an image of your completed feature tree here, highlight or circle the **nodes** that you have implemented as a visual aid for us when we grade your submission

[Feature Tree Highlighted.pdf](https://github.com/50033-game-design-and-development/50033-midterm-partb-keshavblack123/files/13058846/Feature.Tree.Highlighted.pdf)


### Feature Analysis

For **each** of your **orange**, **pink** and **purple** nodes, explain clearly your game design justification on how this feature upgrades the **overall quality** of the game. In short, you’re providing a short **analysis**.

- If the feature stated that it has to support a core drive, explain which core drive.
- If the feature does not state anything concrete, it becomes an **open ended feature. Please** use proper terminologies whenever possible.
  - You can argue that this feature forms an **elegant rule**, or
  - It improves the UX of the game, or
  - **It improves code maintenance** overall
- Consult our lecture slides for inspiration and samples on how to concisely **analyse** a game.

#### Feature No. 48 [Orange]:  
I added 3 objects, 2 collectibles, coin and key and 1 interactive object.   
The coin: The main purpose of the coin is to give the user a score, with this score that the user may want to maximise and get the highest one they can. 

The key: the key is essential for the user to complete the level, if the user does not retrieve all 3 keys in the level, he may not leave. The user will have to find ways to bypass the enemies or kill them in order to retrieve all 3 keys and exit the level.  

The switch: The user may have all 3 keys, but there is still 1 last step. A sliding door stands in their way. getting all keys also enables this button allowing the user to open the door guarding the end flag, and progress to the next round.

The core drive is accomplishment, to get to the next level with a high score. It is also fun for the user to discover new ways in which to interact with the environment. 

#### Feature No.39 [Orange]:  
The trunk. He is a static shooter guarding the treasures which are the coins and the keys. to get past him you must avoid his bullets. However, once you do, he is vulnerable, so you will need to attack in a quick manner. Attacking from behind works too.  

#### Feature No.75 [Purple]:  
2 levels have been created. The second slighly more difficult than the first with more emenies. However, the level design just gives the user a teaser of the potential of this game. With aesthetic design and creative layout, users will have a good time finding multiple different to complete a level. It is a bit exploratory allowing the user freedom to choose their pwn path. This game only has 2 levels, after which the user will return to the home screen.  

## Notes

Any other notes you would like to add here

## Asset Used & Credits

It’s nice to give **credits** to the creator of the assets (if info is available).  
From Pixel Adventure:  
Terrain  
Pink Man  
Bunny  
Play, Restart, settings buttons  
gold coin  
hit sparkle  
key  
shine sparkle  
button  
checkpoint flag  
trunk

from platformer farm forrest:  
sun
clouds
