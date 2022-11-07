# Tower-Defense
#### I made a Tower Defence game in the last 7 weeks. You can place tower, buy towers, shoot the enemies and more. What I did in the beginning was planning my strategy for the game. The planning and the preparation was good. After I did my best for all the preparations I started the project in Unity. 

#### In the game I made a few mechanics. I mechanic that I'm the most proud of is the UI and the moneySystem. I learned more about how I use the varibales in other scripts. Also a have made a system for the waves. I learned more about the Scriptable Objects and how to link the scriptable objects code with another code that I made. 

#### What I have Learned is: 
- To ask more questions than I asked this period. 
- To make sure to write things down. 
- Be Better in planning.
- If I start with one thing I end that 100% and after that I start something else. 


---
#### [Trello]("https://trello.com/b/HtQM66FW/td-ma")
---


### FlowChart mechanic Tower_Placement
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
