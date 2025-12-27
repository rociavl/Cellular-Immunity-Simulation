\# Immune Defense Game



Unity game project for Computer Vision course - biomedical engineering themed first-person shooter.



\## 🎮 Game Concept



Play as a leukocyte (white blood cell) defending the body against pathogen invasion. Navigate through tissue environments and neutralize bacterial threats using your immune system abilities.



\## Technical Requirements



\- \*\*Unity Version:\*\* 6.3 LTS (6000.3.2f1)

\- \*\*Render Pipeline:\*\* URP (Universal Render Pipeline)

\- \*\*Platform:\*\* Windows/Mac/Linux



\## Project Requirements Demonstration



This project demonstrates:

\- ✅ \*\*First-Person Controller\*\* - Player movement with WASD + mouse look

\- ✅ \*\*Physics System\*\* - Rigidbody enemies, collision detection

\- ✅ \*\*Materials \& Shaders\*\* - Custom glowing pathogen materials

\- ✅ \*\*Particle Systems\*\* - Death effects on enemy destruction

\- ✅ \*\*Audio\*\* - Background music and sound effects (in progress)

\- ✅ \*\*C# Scripting\*\* - Enemy AI, shooting mechanics, game logic



\## Controls



\- \*\*WASD\*\* - Move

\- \*\*Mouse\*\* - Look around

\- \*\*Space\*\* - Jump

\- \*\*Shift\*\* - Sprint

\- \*\*Left Click\*\* - Shoot



\## Project Structure

```

Assets/

├── \_Project/              # Our custom game content

│   ├── Scenes/           # Game scenes

│   ├── Scripts/          

│   │   ├── Combat/       # Player shooting, enemy AI

│   │   ├── Visuals/      # Particles, materials, audio

│   │   └── Core/         # Game managers, shared logic

│   ├── Prefabs/          # Reusable game objects

│   ├── Materials/        # Custom materials

│   └── Audio/            # Sound effects and music

├── StarterAssets/        # Unity first-person controller

└── JMO Assets/           # Cartoon FX particle effects

```



\## Setup Instructions



\### First Time Setup:



1\. \*\*Clone the repository:\*\*

```bash

&nbsp;  git clone https://github.com/rociavl/Cellular-Immunity-Simulation.git

&nbsp;  cd ImmuneDefense

```



2\. \*\*Open in Unity Hub:\*\*

&nbsp;  - Add project from disk

&nbsp;  - Select "ImmuneDefense" folder

&nbsp;  - Unity will import all assets (may take 2-3 minutes)



3\. \*\*Open the main scene:\*\*

&nbsp;  - Navigate to `Assets/\_Project/Scenes/MainGame.unity`

&nbsp;  - Double-click to open



4\. \*\*Press Play\*\* to test!



\### Working with Git:



\*\*Before starting work:\*\*

```bash

git pull origin main

```



\*\*After making changes:\*\*

```bash

git add .

git commit -m "Descriptive message about your changes"

git push origin main

```



\## Current Features (Phase 1)



\- \[x] First-person movement

\- \[x] Enemy AI (follows player, stops at distance)

\- \[x] Shooting mechanic (raycast-based)

\- \[x] Particle effects on enemy death

\- \[x] Custom glowing enemy materials

\- \[ ] Audio system (in progress)

\- \[ ] Score UI (in progress)

\- \[ ] Wave spawning (planned)



\## Planned Features (Phase 2 \& 3)



\- Multiple enemy types (bacteria, viruses, fungi)

\- Wave-based spawning system

\- Player health and damage

\- Multiple abilities (phagocytosis, cytokine burst)

\- UI score counter and health bar

\- Victory/defeat screens



\## Course Information



\*\*Course:\*\* Computer Vision - Pattern Recognition  

\*\*Institution:\*\* Universitat Politècnica de Catalunya (UPC EEBE)  

\*\*Assignment:\*\* Unity Game Development with Technical Systems Integration



\## 📄 License



Educational project - UPC EEBE 2025-2026

