# Hangman

This is a game of Hangman! Keep guessing the letters until you complete the word. Guess wrong more than 5 times, and... well, you'll see what happens.

### Notes

* The source code is in the Hangman folder, and the binary in the Executable.rar file.
* My first thoughts were to use an array of arrays to save the different words (arrays of chars), but it seemed easier to user a list of strings when actually implementing it.
* I had planned on iterating on each array to compare the entered letter, which is what I ended up doing except looping through strings.
* I thought I wouldn't have time to draw the gallows, but I did, and I'm happy about it! There are probably better ways of drawing things in the console, but this was the quickest I could think of.
* The requirements appear to suggest that the user can keep guessing indefinitely until they actually get it right. I thought it would make more sense to lose after a certain amount of wrong guesses, so I added that.
* I hadn't considered how to restart the application if the player decided to continue playing; I'm still not fully convinced calling Main() again is the best way, but it worked, and I figured that the program is simple enough that it wouldn't hurt.
* Other comments about my thought process are in the source code :).
* **Amount of time it took:** almost 4 hours, including the time it took figure out how to draw the gallows and body parts. This excludes uploading to GitHub, which I'm not that familiar with (and I can only hope I did it correctly -- had a bit of an issue uploading the executable, so I had to re-build and re-upload; I tested it on another PC, so it should work).
