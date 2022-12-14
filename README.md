# Tower-Defense

![](https://github.com/TessavanElderen/Tower-Defense-/blob/Develop/TowerDefense3.0/Gifs/ReadMe%20video%202.0.gif)

### I made a Tower Defence game in the last  7 weeks (19 sep - 11 nov). You can place tower, buy towers, shoot the enemies and more. What I did in the beginning was planning my strategy for the game. The planning and the preparation went good. After I did my best for all the preparations I started the project in Unity. 

### In the game I made a few mechanics. The mechanics were: 
- Placement of the towers
- Shooting at the enemies on the path
- using a shop to buy towers
- MoneySystem to buy towers
- Waves to spawn in enemies

---

## Mechanics
#### The mechanic that I'm the most proud of is the shoot & wave mechanic.

#### Shoot mechanic:
This mechanic is one of the hardest mechanics that I've worked on. The end result that I made is a predict script. De tower has a range around the tower. The tower is in the middle of the range. If the enemy object comes in the range the tower will look at the enemy. After a few minisecondes the tower will shoot a small object (bullet) at the enemy. The bullet object has a script with a speed variable. The tower has a script for the bullet prefab.

#### Wave mechanic:
I'm also proud about my wave system. First I wanted to try it with scriptable objects. I learned how to link the scripbale objects code with another script that I made. Time was not on my side so I tried it another way. The other way was without scriptable objects but I used 1 object (enemy) and the enemy will spawn a few times and after that a new wave with more objects will spawn. I coded it if 3 enemies in the first wave are all dead after that will spawn the next wave and so on. That mechanic was fun because I can change so much. And it can change the whole game. 

--- 

![](https://github.com/TessavanElderen/Tower-Defense-/blob/Develop/TowerDefense3.0/Pictures/Schermafbeelding_20221112_202149.jpg "Placed Towers in the game")

---

#### What I have Learned is:
- To ask more questions than I asked this period. (The questions didn't ask more questions about how you make code more efficient).
- To make sure to write things down. (I wrote things down in trello that was about all the mechanics in the game. But I wanted to write more).
- Be Better in planning. (I needed to write more in my Trello. I was more concentrated with Unity than my planning). 
- If I start with one thing I end that 100% and after that I start something else. (Because I did this project alone I learn more and more about myself. I learned that I did so much at the same time. I learned that I wanted to do I faster and faster and not learning anything on the way. But now I will make a mechanic 100% good. After that I make the next mechanic. 

---
#### Flowcharts
Flowchart for [Tower Placement](#Flowcharts)

---

[My Trello](https://trello.com/b/HtQM66FW/td-ma)

---

<a name="Flowcharts"></a>

#### FlowChart mechanic Tower_Placement. 
In the flowchart below you'll see a roadmap about how you place a tower

 ```mermaid 
flowchart TD

start((Start)) --> Placement{Place Towers}
Placement{Can Place Towers?} -- Yes --> On_Mouse_Position[Tower on Mouse Position]
On_Mouse_Position[Tower on Mouse Postion] --> Movement[Can Move around]
Movement[Can Move around] -- On Path --> Click_On_Path[Can't Place]
Movement[Can Move around] -- On Map --> Click_On_Map[Can Place]
Click_On_Path[Can't Place] -- Range --> Red_Range[Becomes Red]
Click_On_Map[Can Place] -- Range --> Green_Range[Becomes Green]
Green_Range[Becomes Green] -- Mouse --> Mouse[Let Left mouse button go]
Mouse[Let Left mouse button go] --> Place[You Placed a tower]
Red_Range[Becomes Red] --> Movement[Can Move around]
Place[You Placed a tower] --> End((End))
Placement{Can Place Towers?} -- no--> End((End))
```

### 
