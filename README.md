# Tower-Defense

#### In the last 7 weeks I made a Tower Defense. The game went well in the first half of the period. I was unable to solve a number of problems and I got stuck. But I went for a new approach in the autumn holidays. I wachted video's and learned so much. But I also ended up getting stuck with this approach aswell. After the holiday I spoke with one of my teachers and his advice was: "Begin again. And try it your own way. No Video's". I did try so hard to make it in time. But unfortunately I didn't. BUT I did learn so much after this experience. Athough my game isn't as good as I thought in return I did learn alot. 

#### My plan was to make a functional game but I didn't. I'm really happy that I tried my best. I plan to discuss this experience and this result with my teacher next week.

#### What I have Learned is: 
- To ask more questions than I asked this period. 
- To make sure to write things down. 
- Be Better in planning.
- If I start with one thing I end that 100% and after that I start something else. 

#### [Trello]("https://trello.com/b/HtQM66FW/td-ma")
----------------------------------------------------------------------------------
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
