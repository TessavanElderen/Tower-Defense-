# Tower-Defense
#### I made a Tower Defense. 

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
Place[You Placed a tower] --> start((Start))
