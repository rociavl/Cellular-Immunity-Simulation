# Immune Defense Game

A Unity-based first-person shooter with a biomedical engineering theme. Play as a leukocyte (white blood cell) defending the body against pathogen invasion.

## Gameplay Video

[![Gameplay Video](https://img.youtube.com/vi/n-AoqdS3Xdw/0.jpg)](https://youtu.be/n-AoqdS3Xdw?si=3CZhGwK1E_SFcpYi)

**Watch on YouTube:** https://youtu.be/n-AoqdS3Xdw?si=3CZhGwK1E_SFcpYi

## Authors

- **Rocio Avalos Morillas**
- **Manuel Padilla Amaya**

**Course:** Computer Vision - Virtual Reality
**Institution:** Universitat Politecnica de Catalunya (UPC EEBE)
**Academic Year:** 2025-2026

## Game Concept

Navigate through tissue environments as an immune cell and neutralize bacterial threats using your immune system abilities. This educational game demonstrates core Unity systems while teaching players about cellular immunity.

## Gameplay Mechanics

| Mechanic | Description |
|----------|-------------|
| **Bacteria Splitting** | 50% chance bacteria duplicates when killed, simulating real binary fission |
| **Super Bacteria** | 1% spawn chance, requires 5 shots to destroy, represents antibiotic-resistant strains |
| **Health Pickups** | Green orbs restore 25 HP, simulating the body's natural regeneration |
| **Enemy AI** | Bacteria chase and attack the player |
| **Minimap** | Toggle with M key, represents chemotaxis (how leukocytes detect bacteria) |
| **Encyclopedia** | Pause menu with 5 categories of immune system facts |

## Controls

| Input | Action |
|-------|--------|
| WASD | Move |
| Mouse | Look around |
| Space | Jump |
| Shift | Sprint |
| Left Click | Shoot |
| M | Toggle minimap |
| ESC | Pause / Encyclopedia |

## Technical Requirements

- **Unity Version:** 6.3 LTS (6000.3.2f1)
- **Render Pipeline:** URP (Universal Render Pipeline)
- **Platform:** Windows / Mac / Linux

### Dependencies

| Package | Version | Purpose |
|---------|---------|---------|
| Universal RP | 17.3.0 | Rendering pipeline |
| Cinemachine | 2.10.5 | Camera system |
| Input System | 1.17.0 | Input handling |
| AI Navigation | 2.0.9 | NavMesh systems |
| Shader Graph | 17.3.0 | Visual shaders |

## Project Structure

```
Assets/_Project/
├── Scenes/
│   └── MainGame.unity
├── Scripts/
│   ├── Combat/
│   │   ├── BacteriaSpawner.cs
│   │   ├── BacteriaSplitter.cs
│   │   ├── EnemyFollow.cs
│   │   ├── EnemyHealth.cs
│   │   └── PlayerShooting.cs
│   ├── Core/
│   │   ├── GameManager.cs
│   │   ├── PlayerHealth.cs
│   │   ├── HealthPickup.cs
│   │   └── HealthPickupSpawner.cs
│   └── UI/
│       ├── UIManager.cs
│       ├── IntroManager.cs
│       ├── PauseManager.cs
│       ├── MinimapCamera.cs
│       └── MinimapToggle.cs
├── Prefabs/
│   ├── Pathogen_Bacteria.prefab
│   ├── SuperBacteria.prefab
│   ├── HealthPickup.prefab
│   └── Bloodvessel.prefab
├── Materials/
│   ├── PathogenRed.mat
│   └── MatSuperbacteria.mat
└── Audio/
    └── (sound effects)
```

## Features

### Completed

- [x] First-person movement and camera
- [x] Enemy AI (follows player, attacks)
- [x] Raycast shooting mechanic
- [x] Particle effects on enemy death
- [x] Custom glowing enemy materials
- [x] Physics system (colliders, gravity)
- [x] Audio system (shooting, damage, healing, ambient)
- [x] Score tracking
- [x] Health system with UI
- [x] Bacteria spawning system
- [x] Super Bacteria (boss enemy)
- [x] Bacteria splitting mechanic
- [x] Health pickups
- [x] Intro screen with educational content
- [x] Minimap with toggle
- [x] Pause menu with encyclopedia

### Educational Content (Encyclopedia)

The pause menu includes facts about:

1. **Leukocytes (White Blood Cells)** - Your body's defense army
2. **Bacteria** - Single-celled invaders
3. **The Immune System** - How your body fights disease
4. **Blood & Circulation** - The transport system
5. **Fun Biology Facts** - Interesting trivia

## Technical Implementation

### Player System
- **Movement:** CharacterController-based with walk (4 m/s) and sprint (6 m/s)
- **Camera:** Cinemachine with vertical pitch clamping (-90 to +90 degrees)
- **Health:** 100 HP with damage cooldown

### Combat System
- **Shooting:** Raycast-based hitscan (100m range)
- **Targeting:** Center-screen viewport ray from camera
- **Layer Filtering:** Enemy layer for hit detection
- **Feedback:** Particle effects and audio on hit

### Enemy AI
- **Behavior:** Continuously follows player position
- **Attack:** Deals 10 damage on contact
- **Normal Bacteria:** 1 HP, 50% split chance on death
- **Super Bacteria:** 5 HP, 1% spawn rate, 50 points

### Materials
- **PathogenRed:** URP/Lit shader with emission for glowing effect
- **MatSuperbacteria:** Golden material for boss enemies

## Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/rociavl/Cellular-Immunity-Simulation.git
   ```

2. **Open in Unity Hub:**
   - Click "Add" > "Add project from disk"
   - Select the project folder
   - Unity will import all assets

3. **Open the main scene:**
   - Navigate to `Assets/_Project/Scenes/MainGame.unity`
   - Double-click to open

4. **Press Play** to test the game

## Project Requirements Demonstration

| Requirement | Implementation |
|-------------|----------------|
| First-Person Controller | WASD + mouse look system |
| Physics System | Rigidbody enemies, collision detection, MeshColliders |
| Materials & Shaders | Custom glowing pathogen materials (URP/Lit with emission) |
| Particle Systems | Death effects using Cartoon FX Remaster |
| Audio | Shooting, damage, healing, and ambient sounds |
| C# Scripting | Enemy AI, shooting mechanics, spawning, UI, encyclopedia |

## Third-Party Assets

- **[Unity Starter Assets](https://assetstore.unity.com/packages/essentials/starter-assets-first-person-character-controller-196525)** - First-person controller
- **[Cartoon FX Remaster](https://assetstore.unity.com/packages/vfx/particles/cartoon-fx-remaster-109565)** - Particle effects (JMO Assets)
- **[Free Pop Sound Effects](https://assetstore.unity.com/)** - Audio effects

## License

Educational project - UPC EEBE 2025-2026
