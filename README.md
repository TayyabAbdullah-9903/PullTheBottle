# Pull The Bottle 🍾

A satisfying 2D physics-inspired challenge game built in Unity where the player pulls a bottle against a tightly stuck cork to create tension and eventually pop it out.

The game focuses on tactile feedback, resistance simulation, stretch effects, and satisfying pop mechanics to create an engaging hyper-casual interaction experience.

---

## 📌 Game Overview

In **Pull The Bottle**, the player drags the bottle while the cork remains tightly stuck in place. As force builds up, the cork stretches dynamically to simulate tension and resistance. Pulling hard enough causes the bottle to finally pop free with a satisfying release effect.

The core gameplay is centered around:
- Elastic tension simulation
- Resistance-based movement
- Directional stretch effects
- Satisfying release feedback
- Simple but polished interaction mechanics

---

## ✨ Features

- 🍾 Drag-Based Bottle Pulling Mechanic
- 🪢 Dynamic Cork Stretching
- 🎯 Resistance & Tension Simulation
- 💥 Bottle Pop-Out Effect
- 📱 Mobile Touch Support
- 🧠 Custom Elastic Interaction System
- 🎮 Hyper-Casual Gameplay Design
- ⚡ Smooth Directional Stretch Animation

---

## 🧠 Core Mechanics

The system uses:
- Controlled drag movement
- Tension calculation based on displacement
- Directional squash & stretch
- Threshold-based pop logic
- Snap-back behavior on release

Instead of relying entirely on physics joints, the interaction system was manually designed for better gameplay feel and responsiveness.

---

## 🎨 Stretch & Resistance System

The cork dynamically:
- Rotates toward pull direction
- Stretches based on drag distance
- Maintains anchored positioning inside the bottle
- Simulates elastic resistance visually

This creates a satisfying “stuck cork” effect during gameplay.

---

## 📱 Input System

Supports:
- Mobile touch controls
- Mouse input for testing in editor
- Unified drag handling system

---

## 🛠 Built With

- **Unity 2D**
- **C#**
- Custom Drag System
- Directional Stretch Logic
- Touch Input Handling
- Transform-Based Animation
- Hyper-Casual Interaction Design

---

## 🎮 Gameplay Loop

1. Drag the bottle
2. Build tension gradually
3. Stretch the cork dynamically
4. Reach the breaking threshold
5. POP the bottle free

---
