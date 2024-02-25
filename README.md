![image](https://github.com/ciderzx/Unity_MengoTour/assets/66687236/81096d3f-391b-412e-8c52-536d34770f99)<h1 align="left">KPU Unity Project [ MengoTour ]</h1>

<p align = "center">
  <img width="40%" height="40%" align = "center" src="https://github.com/ciderzx/Unity_MengoTour/assets/66687236/c7fcabed-bcb3-4319-834c-989bcd2266a7"/>
</p>

<h3> Game Information </h3>

+ 이름 : MengoTour
+ 플랫폼 : Android 
+ 조작 방식 : Touch & Joystick Touch
+ 장르 : Simulation Game
+ 이야기 내용 : 가상세계에서 친구들끼리 각각의 캐릭터로 만나 각 미션을 깨며 나라를 탐방
+ 진행 방식 : '부루마블' 처럼 주사위를 굴려 해당하는 나라의 미션들을 깨며 진행
<br>

<h3> Game System </h3>

<br>

<p align = "left">
  <img width="60%" height="60%" align = "center" src="https://github.com/ciderzx/Unity_MengoTour/assets/66687236/ee7c99b7-e3ab-4a87-9a5f-80e760d713e2"/>
  <br>
  Server Connect Scene : 해당 Scene의 역할은 Server에 접속하는 기능을 하고 Photon Asset의 기능을 활성화 하는 Scene.<br>
  커넥트 버튼을 누르게 되면 Photon Server 에 접속하여 다음 씬으로 넘어가게 됌.
</p>

<br>

<p align = "left">
  <img width="60%" height="60%" align = "center" src="https://github.com/ciderzx/Unity_MengoTour/assets/66687236/6bd7e2c8-944a-4abd-aa53-a690a37bc0f0"/>
  <br>
  Play Choose Scene : 해당 Scene의 역할은 Player 가 사용할 이름 및 모델을 설정하고 저장하는 기능을 담당한 Scene. <br>
  각 모델은 4가지가 있으며 Fox, Eagle, Shark, Nomami로 구성되어 있음. <br>
  해당 이름으로 접속과 Room을 만들 수 있음.
</p>

<br>

<p align = "left">
  <img width="60%" height="60%" align = "center" src="https://github.com/ciderzx/Unity_MengoTour/assets/66687236/6b86bd56-9c6f-48a0-ba89-890a130716d9"/>
  <br>
  Room Scene : 해당 Scene은 Player가 Room의 Host가 되어 다른 Host가 올 수 있는 Room을 만든 Scene. <br>
  Photon Server에 Room을 만들고 Host설정을 한 뒤 대기할 수 있는 기능이 있음.<br>
  해당 Room에 다른 Player가 들어올 수 있으며, Host가 게임을 시작 할 수 있음.
</p>

<br>

<p align = "left">
  <img width="60%" height="60%" align = "center" src="https://github.com/ciderzx/Unity_MengoTour/assets/66687236/a30ec111-a51b-40e2-b4c3-344fa58976fc"/>
  <br>
  Room List Scene : 해당 Scene은 Photon Server에 있는 Room을 보여주고 들어가는 기능이 있는 Scene. <br>
  Player는 Room의 이름을 보고 접속 할 수 있으며 만드는 기능도 있음.
</p>

<br>

<p align = "left">
  <img width="60%" height="60%" align = "center" src="https://github.com/ciderzx/Unity_MengoTour/assets/66687236/d2c7faa3-0912-4d06-aa16-104ac0545840"/>
  <br>
  Play Scene - Dice : 해당 Scene은 실제로 Play가 이루어지고 주사위를 굴리고 다른 맵으로 들어가는 기능이 있는 Scene. <br>
  최대 4명까지 Play가 가능하며, 플레이어가 주사위를 굴려 이동을 하면 그 해당 맵으로 이동할 수 있음.
  
</p>

<br>

<p align = "left">
  <img width="60%" height="60%" align = "center" src="https://github.com/ciderzx/Unity_MengoTour/assets/66687236/a001f748-1b67-425f-9f4e-dd71c37f14b4"/>
  <br>
  Play Scene - Mission : 해당 Scene은 실제로 Play가 이루어지고 조이스틱과 각종 버튼으로 움직일 수 있는 Scene. <br>
  해당 Player는 3인칭 시점과 1인칭 시점으로 Play가 가능하며 점프 및 상호작용이 가능한 기능이 있음.
</p>

<br>

<p align = "left">
  <img width="60%" height="60%" align = "center" src="https://github.com/ciderzx/Unity_MengoTour/assets/66687236/f5dab88d-9b7f-4d87-a021-59d03b695986"/>
  <br>
  Character : 해당 게임에서 Play가 가능한 모델이며 각각의 능력은 다르지 않고 동일 함.
</p>

<br>

---

<h2 align="left"> Project Summary </h2>

<p align = "center">
  <img width="70%" height="70%" align = "center" src="https://github.com/ciderzx/Unity_MengoTour/assets/66687236/5fed93f5-81fc-446a-9f82-6ed48d6bd756"/>
</p>

기여도
+ 기획 : 35%  /  개발 : 65%

About
+ 해당 프로젝트 ‘Mengo Tour’는 3D & VR 온라인 시뮬레이션 입니다. 팀에서 찍은 모델로 나라를 구성하고 온라인에서 만나 해당 나라의 미션을 완수하고 즐기는
  캐주얼 게임 입니다. VR 모델은 ‘Samsung  Gear V R’을 모델로 잡았고 온라인을 구축하기 위해 ‘Photon’ Asset을 사용하여 구현 하였습니다.
+ 진행 방식은 해당 플레이어가 모델을 선택하고 방에 접속하거나 만들어 온라인 플레이를 진행하게 됩니다. 플레이를 하게 되면 주사위를 굴려 해당 숫자만큼 이동하여 
  타일에 설정 된 나라에 플레이어 모두가 들어가 미션을 진행하는 플레이입니다.





---
