# CV-game
Сontrol: 
-  w a s d to move
- MB2 to shoot
to upgrade lvl press 1, 2 or 3
1 - speed
2 - jumping
3 - health
# CV-BallWorld
Every 1/4 second a ball is created in the field of view of the camera
- a text counter shows how many balls have been created so far
- each ball has its own gravity field - attracts other balls
- in the event of a collision, two balls merge into one with a proportionally greater mass and area
gravity,
the surface area of the resulting is equal to the sum of two
component balls
- if the ball has a mass equal to the mass of 50 original balls, it disintegrates as much
balls it is made of - these balls fly at high speed in random z directions
collision disabled for half a second
- the balls stop forming, if there are a total of 250 - then their gravitational fields
they start to act the other way - the balls repel each other; the balls stop sticking together, though
further, collisions are detected and the balls do not overlap
- the balls slow down when moving - air resistance simulation
- no other gravitational forces act on the balls
