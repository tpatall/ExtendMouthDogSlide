# Extend MouthDog Slide
Allows you to change the sliding speed and duration of MouthDogs after they lunged at you.

You might not ever see it in action, or you might become a mid-drift snack for an oversized curling stone traveling at the speed of light. What a thrill!

Should support custom dog skins assuming they dont completely overhaul the AI. Every connected player should have this mod installed.

## Config Settings
All available mod settings can be found in the config file: `dummy.ExtendMouthDogSlide.cfg`

For each setting, the default setting is how it works in the unmodded game.

- **SlideDuration** (default = 2.3)
	- Duration of the slide after a lunge in seconds.
- **TopSpeed** (default = 13)
    - Starting speed of the lunge.
- **AlwaysTopSpeed** (default = false)
	- If the whole slide is at top speed.

Using these settings you can create (for example) the following scenarios:
- SlideDuration = 1 or lower. 
	- Fast lunging dogs with minimal cooldown.
- SlideDuration = 6, TopSpeed = 25, AlwaysTopSpeed = true. 
	- Lunges that slide them all the way out of earshot. They might catch unsuspecting friends though.

## Credits
Thanks for the preconfigured BepInEx and EasySync/CSync (see dependencies)!
