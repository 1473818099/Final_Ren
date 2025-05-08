# Final_Ren
Unity 6 FPS game
# Documentation
This project is based on Unity 6. 

4/14 - 4/21
- Created new project
- Encounter Renderpipe line issue, textures display error. Browsed and solved the problem by selecting Window - Rendering - Render Pipeline Converter - Convert all Assests
- Opened demo scene at Polyperfect Universal Pack. 
- Looking at every basic elements, messed around to them.
- Start watching videos of basic Unity developing about FPS game.
a
4/21 - 4/28
- Trying really hard to write the ‘FirstPersonCharacterController’ script. Tried many methods from videos but not working at all. Spent large amount of time to achieve it.
- Completed the First Person Character Controller. (Script ‘MouseLook’ and ‘PlayerMovement’) Achieve it by founding the issue that in some demo scenes, the global settings have been changed by the package developers. Solved the problem by starting from a almost empty templete. Encountered player moving direction wrong. Resolved by move the script to the main player object instead of child object.


4/28 - 5/7
- Completed ‘Bullet’ script. Functioned well. Using if loop to check the status of whether the bullet hit the tag ‘Target’ or not.
- Completed ‘Weapon’ script. Announced a lot of variables. Set three modes to the gun: burst, single and auto. Main function is, when detected mouse being clicked down, create an Instantiate bullet with rigidbody (An object temporary). This script work with ‘Bullet’ script.
- Completed ‘TargetEnemy’ script. Add variable ‘maxHealth’ and ‘currentHealth’ to enemy object. (float) Function is create the targetenemy’s status, giving health value.
- Completed ‘EnemyHealthBar’ script. Function a healthbar displayed front to player.

 

