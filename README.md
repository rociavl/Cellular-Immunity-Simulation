# Immune Defense Game

A Unity-based first-person shooter with a biomedical engineering theme. Play as a leukocyte (white blood cell) defending the body against pathogen invasion.

## Game Concept

Navigate through tissue environments as an immune cell and neutralize bacterial threats using your immune system abilities. This educational game demonstrates core Unity systems while teaching players about cellular immunity.

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

## Controls

| Input | Action |
|-------|--------|
| WASD | Move |
| Mouse | Look around |
| Space | Jump |
| Shift | Sprint |
| Left Click | Shoot |

## Project Structure

```
Assets/
├── _Project/                    # Custom game content
│   ├── Scenes/
│   │   └── MainGame.unity       # Main playable scene
│   ├── Scripts/
│   │   ├── Combat/
│   │   │   ├── PlayerShooting.cs    # Raycast shooting mechanic
│   │   │   └── EnemyFollow.cs       # Enemy AI behavior
│   │   ├── Core/                # Game managers (reserved)
│   │   └── Visuals/             # Particles/audio (reserved)
│   ├── Prefabs/
│   │   └── Pathogen_Bacteria.prefab
│   ├── Materials/
│   │   └── PathogenRed.mat      # Glowing enemy material
│   └── Audio/                   # Sound effects (in progress)
│
├── StarterAssets/               # Unity FPS controller package
│   ├── FirstPersonController/
│   │   └── Scripts/
│   │       ├── FirstPersonController.cs
│   │       └── BasicRigidBodyPush.cs
│   ├── InputSystem/
│   │   └── StarterAssetsInputs.cs
│   └── Environment/             # Prefabs for level design
│
└── JMO Assets/
    └── Cartoon FX Remaster/     # 100+ particle effects
```

## Technical Implementation

### Player System
- **Movement:** CharacterController-based with walk (4 m/s) and sprint (6 m/s)
- **Camera:** Cinemachine with vertical pitch clamping (-90 to +90 degrees)
- **Grounded Detection:** Sphere cast at capsule base
- **Gravity:** -15.0 m/s²

### Combat System
- **Shooting:** Raycast-based hitscan (100m range)
- **Targeting:** Center-screen viewport ray from camera
- **Layer Filtering:** Enemy layer (Layer 6) for hit detection
- **Feedback:** Particle effects spawn at impact point

### Enemy AI
- **Behavior:** Continuously follows player position
- **Stop Distance:** 1.5 units from player
- **Float Height:** 1.0 unit (floating bacteria effect)
- **Speed:** 2 m/s
- **Orientation:** Always faces player

### Materials
- **PathogenRed:** URP/Lit shader with emission for glowing effect

## Setup Instructions

### First Time Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/rociavl/Cellular-Immunity-Simulation.git
   cd "My project"
   ```

2. **Open in Unity Hub:**
   - Click "Add" > "Add project from disk"
   - Select the project folder
   - Unity will import all assets (2-3 minutes)

3. **Open the main scene:**
   - Navigate to `Assets/_Project/Scenes/MainGame.unity`
   - Double-click to open

4. **Press Play** to test the game

### Git Workflow

**Before starting work:**
```bash
git pull origin main
```

**After making changes:**
```bash
git add .
git commit -m "Description of changes"
git push origin main
```

## Current Features

- [x] First-person movement and camera
- [x] Enemy AI (follows player, maintains distance)
- [x] Raycast shooting mechanic
- [x] Particle effects on enemy death
- [x] Custom glowing enemy materials
- [x] Physics system (colliders, gravity)
- [ ] Audio system
- [ ] Score UI
- [ ] Wave spawning

## Planned Features

### Phase 2
- Multiple enemy types (bacteria, viruses, fungi)
- Wave-based spawning system
- Player health and damage system
- UI elements (health bar, score counter)

### Phase 3
- Multiple abilities (phagocytosis, cytokine burst)
- Victory/defeat screens
- Difficulty levels
- Additional environments

## Troubleshooting

### Common Issues

**Pink/magenta materials:**
- Ensure URP is properly configured in Project Settings > Graphics
- Reimport materials: Right-click > Reimport

**Player falls through floor:**
- Check that ground objects have colliders
- Verify player has CharacterController component

**Enemies not taking damage:**
- Ensure enemies are on Layer 6 (Enemy)
- Verify enemies have the "Enemy" tag

**Input not working:**
- Check Edit > Project Settings > Input System Package
- Ensure StarterAssetsInputs is attached to player

## Project Requirements Demonstration

This project demonstrates the following Unity concepts:

| Requirement | Implementation |
|-------------|----------------|
| First-Person Controller | WASD + mouse look system |
| Physics System | Rigidbody enemies, collision detection |
| Materials & Shaders | Custom glowing pathogen materials (URP/Lit with emission) |
| Particle Systems | Death effects using Cartoon FX Remaster |
| Audio | Background music and SFX (in progress) |
| C# Scripting | Enemy AI, shooting mechanics, game logic |

## Third-Party Assets

- **[Unity Starter Assets](https://assetstore.unity.com/packages/essentials/starter-assets-first-person-character-controller-196525)** - First-person controller foundation
- **[Cartoon FX Remaster](https://assetstore.unity.com/packages/vfx/particles/cartoon-fx-remaster-109565)** - Particle effects library by Jean Moreno (JMO Assets)

## Course Information

**Course:** Computer Vision - Pattern Recognition
**Institution:** Universitat Politècnica de Catalunya (UPC EEBE)
**Assignment:** Unity Game Development with Technical Systems Integration

## License

Educational project - UPC EEBE 2025-2026
