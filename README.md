# Project 2 Report

Read the [project 2
specification](https://github.com/feit-comp30019/project-2-specification) for
details on what needs to be covered here. You may modify this template as you see fit, but please
keep the same general structure and headings.

Remember that you must also continue to maintain the Game Design Document (GDD)
in the `GDD.md` file (as discussed in the specification). We've provided a
placeholder for it [here](GDD.md).

## Table of Contents

- [Evaluation Plan](#evaluation-plan)
- [Evaluation Report](#evaluation-report)
- [Shaders and Special Effects](#shaders-and-special-effects)
- [Summary of Contributions](#summary-of-contributions)
- [References and External Resources](#references-and-external-resources)

## Evaluation Plan

An important part of this project is evaluating the game with end users. This will help identify any issues with the game's design and provide an opportunity to make changes before the final submission.

### Evaluation Techniques

- **Querying Technique (Surveys/Questionnaires):**

  - **Why:** To gather subjective feedback from players about their experiences, level of engagement, and thoughts on game mechanics, story, and atmosphere.
  - **Tasks:** After playing a specific portion of the game, participants will answer questions about their emotional response to the environment, sound design (e.g., whispering audio), and their understanding of the narrative (like the scrolling text scene and the subtitles).

### Participants

- **Recruitment:** We will reach out to fellow students, game design enthusiasts, or players within the same genre preference. Advertise through social media or university channels.
- **Qualifying Criteria:** Participants must be 16 or above as it is a criteria for our target audience. They should be familiar with narrative-driven or eerie games to align with the target audience. A mix of experienced gamers and those less familiar with similar games would provide a balanced perspective.

### Data Collection

- **Surveys/Questionnaires:** Mainly Google Forms will be used for this. We will focus on Likert scale questions (e.g., how engaging was the narrative on a scale of 1-5), and open-ended feedback on specific elements like sound or atmosphere.
- **Observations:** Video recording gameplay sessions (with consent), or taking notes during playtesting. We will use screen recording software to capture in-game actions and user behavior.

### Data Analysis

- **Survey Data:** We will do a quantitative analysis of Likert scales to identify common issues. Open-ended questions will be coded for themes (e.g., confusion, atmosphere engagement).

### Timeline

- **Milestone 1:** Finalize participant recruitment and setup of evaluation tools by October 14th.
- **Playtesting Sessions:** Conduct sessions over the week concurrently with participant recuitment, ensuring time for conducting querying techniques.
- **Data Analysis:** By October 18th we will analyze the collected data.
- **Game Changes:** Start making adjustments based on feedback on and after October 18th and finalize before the 26th October.

### Responsibilities

- **Data Collection:** Assign all team members to gather participants to playtest the game.
- **Data Analysis:** Conduct a meeting to analyse the data and document key findings
- **Adjustments to Game:** Divide responsibilities based on areas of expertise
- Trello Board: https://trello.com/b/qKgKiRgA/lols-project

## Evaluation Report

### Participant Demographics

The evaluation involved 6 participants, consisting of casual and experienced gamers. The feedback was collected after participants played the game and answered a series of questions. The group had varied experience levels, with some players familiar with puzzle-based games and others more casual.

### Methodology

The evaluation was conducted by having participants play through the different stages of the game and then answering a feedback questionnaire. The questions focused on their experience regarding bugs, enjoyment, frustrations, and areas of improvement. Players were encouraged to provide additional comments at the end of the survey.

Below are the collected data using this questionnaire method.

<img src="Images/Data%201.png" alt="data1" width="500" height= "400"><img src="Images/Data%202.png" alt="data1" width="500" height= "400">
<img src="Images/Data%203.png" alt="data1" width="500" height= "400"><img src="Images/Data%204.png" alt="data1" width="500" height= "400">

### Key Findings

Based on the raw feedback from the evaluation, here is a summary of the key insights:
- Bugs/Issues:
  - Most players didn’t encounter major bugs, but two participants noted specific issues:
    - The ability to go through some sections of the wall.
    - Hand movement glitches after reading a book.
    - Minor character movement glitches.
- What Participants Enjoyed:
  - The atmosphere, eerie and spooky environment, and background sounds were highly praised.
  - Several participants highlighted the exploration aspect of the game as engaging and adventurous.
  - The puzzles, especially the piano puzzle, were fun and added a sense of tension.
- Frustrations and Confusions:
  - Some participants found the puzzles, especially in Stage 2 and Stage 3, to be a bit confusing or difficult.
  - A common theme was that the symbols were hard to remember, making it challenging to solve puzzles.
  - The piano puzzle was noted as being tricky due to the need to read through all the books to understand the solution.
- Suggestions for Improvement:
  - Improve controls, refine player movement, and fix wall-related bugs.
  - Balance the difficulty better, especially in later stages, so that casual players can progress more easily.
  - Add more levels and content to increase engagement for players wanting a longer experience.
  - Introduce more interaction with villains or additional characters to enhance immersion.

### Changes Made

- Based on the feedback, the following changes were implemented in the game:
  - Bug Fixes:
    - The issue where players could move through some sections of the wall was fixed.
    - Glitches with hand movements after reading books were resolved.
  - Gameplay Adjustments:
    - Added some hints for stage 2 and stage 3’s puzzle to help players solve the puzzle.
### Additional Feedback

Participants found the game to be unique, interactive, and enjoyable, with a good balance of tension and exploration. Moving forward, the team will focus on expanding the game with new levels and refining the player experience based on continued feedback.

## Shaders and Special Effects

In this project, we developed two non-trivial custom Cg/HLSL shaders and created two unique particle systems to enhance the visual experience and gameplay immersion. Below are the detailed descriptions, rationales, and links to the shader asset files in our repository.

### Custom Shaders

#### 1. Glowing Books Shader
- **Shader Description**: This shader creates a glowing effect around books that need to be read. The glow serves to distinguish these books from others, making them visually prominent when the player enters the room.
- **Shader link**: [GlowShader.shader](https://github.com/feit-comp30019/2024s2-project-2-spectro-studio/blob/main/Assets/Shaders/GlowShader.shader)
- **Rationale**: The glowing effect enhances gameplay by guiding players towards important objects. It is especially useful as we have implemented the game in a dark, eerie environment, where visibility is limited. The emission property allows for a more efficient rendering process compared to using additional geometry or lights, helping to reduce CPU load.

![](https://github.com/feit-comp30019/2024s2-project-2-spectro-studio/blob/main/Images/GlowShader.gif)

#### 2. Ghost Handprints Shader
- **Shader Description**: This shader simulates ghostly handprints that appear on the wall near the altar, adding an eerie and atmospheric effect that contributes to the eerie elements of the game.
- **Shader link**: [GhostlyShadow.shader](https://github.com/feit-comp30019/2024s2-project-2-spectro-studio/blob/main/Assets/Shaders/GhostlyShadow.shader)
- **Rationale**: The ghost handprints contribute to the game's eerie atmosphere and visual storytelling. By using a transparent shader, the handprints blend seamlessly with the environment, enhancing immersion. The adjustable alpha value provides flexibility in achieving the desired level of visibility without overwhelming the scene. We used two materials for this shader that flicker randomly to enhance the effect.

![](https://github.com/feit-comp30019/2024s2-project-2-spectro-studio/blob/main/Images/HandPrints.gif)

---

### Particle Systems

#### Ghost Soul Particle System

- **Description**: The Ghost Soul particle system is activated at the altar after completing the last puzzle in Stage 3. It generates ethereal particles that swirl around, enhancing the supernatural elements of the game and providing feedback to the player. This was implemented to show the act of releasing the souls trapped in the library.
  
- **Location**: Located in the *Stage3* scene inside the [Scenes](https://github.com/feit-comp30019/2024s2-project-2-spectro-studio/tree/main/Assets/Scenes) folder in our repository. The renderer used is in the [Materials](https://github.com/feit-comp30019/2024s2-project-2-spectro-studio/tree/main/Assets/Materials) folder.
  
- **Particle System Attributes**:
  - **Start Lifetime**: Randomly varies between 1 to 5 seconds to create a dynamic effect.
  - **Size over Lifetime**: Gradually decreases to create a fading effect.
  - **Shape**: Set to "Cone" with an angle of 20° and a radius of 0.6 to achieve a spiral effect.
  - **Duration**: Set to 3 seconds, aligning with the player's need to exit quickly after completing the puzzle.
  - **Force Over Lifetime**: The ‘Z’ value is set to 2 to enhance the swirl effect.
  - **Noise**: Adjusted to give the soul particles a misty, blended appearance.
  - **Renderer**: Custom smokey material applied to better represent the swirling soul effect.
    
- **Randomness Utilized**: Randomization in lifetime and speed attributes ensures each particle behaves uniquely, creating a more organic, dynamic visual effect.
  
- **Rationale**: The choice of attributes enhances the visual impact of the soul-release ritual. By varying these attributes, we create an engaging experience, emphasizing the magical and mysterious nature of the altar.

  ![](https://github.com/feit-comp30019/2024s2-project-2-spectro-studio/blob/main/Images/SoulRelease.gif)

> **Note**: This is our main particle system for assessment.

#### Dust Particle System

- **Description**: The dust particle system is used across all three stages to create a subtle, atmospheric effect. It simulates floating dust particles, enhancing the game's eerie, abandoned library environment.
  
- **Attributes**:
  - **Start Size**: Small, randomized between 0.1 and 0.3 units to resemble tiny dust particles.
  - **Start Speed**: Low, ranging from 0.1 to 0.5 units to mimic slow-moving dust in the air.
  - **Gravity Modifier**: Set to zero, allowing particles to gently float without falling.
    
- **Rationale**: This system adds realism and enhances the ambiance, making the setting feel ancient and untouched, contributing to the game’s unsettling mood.

![](https://github.com/feit-comp30019/2024s2-project-2-spectro-studio/blob/main/Images/DustParticleSystem.gif)

## Summary of Contributions

- **Erich Wiguna**:
  - Scene transitions (Door code implementation)
  - Piano and Keyboard Puzzle (Code implementation)
  - Altar Puzzle (Code implementation)
  - Trello Documentation
- **Jessica Wijaya**:
  - Characters Blender (John, The librarian)
  - Altar Object
  - Book code implementations (Manager and Counter)
  - Soul's Paper (Aleks, Lena, etc.)
- **Poojani Lokuliyana**:
  - Shaders and Particle Systems
  - Piano and Keyboard Puzzle
  - Whispering Audio in stage 3
  - BookShelves and Books
 - **Reagen Purnama**:
   - Pause Scene
   - Paper Canva Designs
   - Physic (Collider)

## References and External Resources

- **Audio [Freesound.org](https://freesound.org/)**  
  Our project includes various audio effects downloaded from Freesound, a collaborative database of creative commons licensed sounds. Below are the specific audio assets used:

  - **Dorm Door Opening** by pagancow — [Link to sound](https://freesound.org/people/pagancow/sounds/15419/)
  - **Four Voices Whispering** by geoneo0 — [Link to sound](https://freesound.org/people/geoneo0/sounds/193817/)
  - **Help Me Whisper** by freebaird — [Link to sound](https://freesound.org/people/FreeBaird/sounds/198485/)
  - **Melody Mysterious Dhungarianminor** by _username_ — [Link to sound](https://freesound.org/people/harrisonlace/sounds/671474/)
  - **Eerie Wind Sound** by craigsmith — [Link to sound](https://freesound.org/people/craigsmith/sounds/675703/)

Each sound effect was used in accordance with its Creative Commons license and is properly attributed as required by Freesound's licensing terms.

- **Dark Fantasy Kit Lite**  
  This project uses assets from the [Dark Fantasy Kit Lite](https://assetstore.unity.com/packages/3d/environments/fantasy/dark-fantasy-kit-lite-127925), which provides 3D models and environments suited for creating dark, atmospheric fantasy scenes. The asset was downloaded from Unity's Asset Store and is used to enhance the environmental visuals in our game.

- **Old Wooden Cabinet** -
 This was used as a decorative furniture to enhance the dark eerie environment of the library. This was taken from the [Old Wooden Cabinet](https://assetstore.unity.com/packages/3d/props/furniture/old-wooden-cabinet-106249) in Unity asset store.

- **ChatGPT**
This tool is used to help us in our report to ensure there are no mispelling or grammatical error in our sentences - [Link to tool](https://chatgpt.com)
