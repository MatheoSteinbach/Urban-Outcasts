INCLUDE globals.ink
{ HectorCheckpoint2 == true: -> checkpoint2}
{ hasAncientPowerCore == true: -> main35}
{ HectorCheckpoint1 == true: -> checkpoint1}

->main
=== main ===
~ moodStringHector = "Neutral"
~ moodStringPlayer = "Neutral"
~ isEdithTalking = false
~ isHectorTalking = true
~ isNanalinTalking = false
~ isGhostTalking = false
~ HectorCheckpoint1 = false
->main1

=== main1 ===
~ isHectorTalking = false
~ moodStringPlayer = "Happy"
Hey, are you Hector? I'm Agent Hiro, member of The M.A.G.I.C. Council.
->main2

=== main2 ===
~ moodStringPlayer = "Neutral"
The mayor told me I could find the professor at your place. I need to talk to him about the rift immediately.
->main3

=== main3 ===
~ isHectorTalking = true
~ moodStringHector = "Happy"
Oh, hey! Yep, that's me. 
->main4

=== main4 ===
~ moodStringHector = "Neutral"
Sorry to disappoint you though, pal. Ghost ain't around right now. Actually, I haven't seen him in quite some time.
->main5

=== main5 ===
~ isHectorTalking = false
~ moodStringPlayer = "Angry"
Damn.... Do you know where I can find him? This is incredibly urgent!
->main6

=== main6 ===
~ isHectorTalking = true
~ moodStringHector = "Neutral"
Gee, what's with the hurry? I'm sure he'll show up eventually.... The guy likes his peace and quiet sometimes and who can blame 'im, heh. The city can be a pretty busy place.
->main7

=== main7 ===
Though to be honest, he <i>has</i> been actin' a li'l weird lately - well, weirder than usual, that is.
->main8

=== main8 ===
~ moodStringHector = "Angry"
Oh, and - he recently asked me if he can have my ancient power cores. I said 'no,' of course! I need 'em myself after all. But he seemed pretty upset when he left.
->main9

=== main9 ===
~ isHectorTalking = false
~ moodStringPlayer = "Neutral"
Ancient power cores? What are those? Do you know what he needed them for?
->main10

=== main10 ===
~ isHectorTalking = true
Well - no... But they're an incredibly rare source of magical energy! Do you have any clue how hard it was for me to get ahold of them in a place like this? 
->main11

=== main11 ===
~ moodStringHector = "Happy"
I'm gonna be using them to power my wings.
Designed 'em myself 'n' everything.
->main12

=== main12 ===
~ moodStringHector = "Neutral"
And once they're finally done.... Ah - Well,
you see, I'm a <i>pixie</i>. Where I come from, everyone has wings! Everyone but me, that is.... It made me stand out.... And the others weren't exactly accepting of my disability.
->main13

=== main13 ===
~ moodStringHector = "Happy"
That's why I'm here, ya know? Here, everyone is different! I can just be myself. 
->main14

=== main14 ===
~ isHectorTalking = false
~ moodStringPlayer = "Neutral"
I'm - sorry to hear that.... I hope it's okay to ask, but, if you can just be yourself around here, why do you even need wings?
->main15

=== main15 ===
~ isHectorTalking = true
~ moodStringHector = "Neutral"
To be honest, it's really not like I need wings to get around places. At least not here. But ever since I was a wee lad, I've always wanted 'em....
->main16

=== main16 ===
~ moodStringHector = "Happy"
I wanna know how it feels like to be like the other pixies, and this tech stuff.... It's gonna make it possible, after all these years.
->main17

=== main17 ===
~ moodStringHector = "Neutral"
You see, I come from a place where there's nothing like it. Just nature and trees as far as the eye can see. When I came here through the rift, ten years ago, all these lights, displays... even phones! It was all new to me. 
->main18

=== main18 ===
Could you even imagine?? Living without a phone for most of your life? Sounds crazy, right?
->main19

=== main19 ===
~ isHectorTalking = false
~ moodStringPlayer = "Neutral"
Yeah... I'm impressed, honestly! Most primitive species have a much harder time adapting to advanced technology when they first come into contact with it. Oh, uh - no offense...!
->main20

=== main20 ===
~ moodStringPlayer = "Happy"
It just seems like you have a natural talent for tech.
->main21

=== main21 ===
~ moodStringPlayer = "Angry"
But - wait, hold on! You came through the rift?? Is that true?
->main22

=== main22 ===
~ isHectorTalking = true
~ moodStringHector = "Happy"
No offense taken! I know I'm very impressive, hehe.
->main23

=== main23 ===
~ moodStringHector = "Neutral"
And yeah, of course I came through the rift! That's how everyone came to live here - whether they stumbled through themselves or they were born as a descendant of someone else who came through. The whole city was built around it. Why do you ask?
->main24

=== main24 ===
~ isHectorTalking = false
~ moodStringPlayer = "Angry"
Do you have <b>any idea</b> how dangerous this rift could be? For this city, no - for the entire galaxy!
->main25

=== main25 ===
~ isHectorTalking = true
~ moodStringHector = "Angry"
What are you talking about...? It's always been here. I've lived close to it for years! And now, all of a sudden, it's dangerous? Sounds like you're overexaggerating a little if you ask me.
->main26

=== main26 ===
~ isHectorTalking = false
I'm not exaggerating!! The energy this rift creates is highly unstable, and it's becoming more erratic by the minute.
->main27

=== main27 ===
You're lucky it hasn't imploded sooner! Hector please, this situation is dire! The mayor told me you know the professor. Do you have any idea where he could be?
->main28

=== main28 ===
~ isHectorTalking = true
Woah, okay, okay, calm down.... Let me think....
->main29

=== main29 ===
~ moodStringHector = "Happy"
Hmm.... I'm unsure, but maybe, if you help me gather the ancient power cores and complete the wings, he might come out since he's been so interested in them!
->main30

=== main30 ===
~ isHectorTalking = false
What?? I thought you already had them?
->main31

=== main31 ===
~ isHectorTalking = true
~ moodStringHector = "Neutral"
Wellll.... This is a little embarrassing, but I dropped them yesterday and Lulu here got to them first and scurried away. 
->main32

=== main32 ===
~ moodStringHector = "Angry"
No clue where they are right now, and I've been looking all day!
->main33

=== main33 ===
~ moodStringHector = "Happy"
Can you help me? Pleeease. If you want me to help you, you gotta help me too, you see! And I'm sure Ghost is bound to show up once the wings are done! 
->main34

=== main34 ===
~ isHectorTalking = false
~ HectorCheckpoint1 = true
~ moodStringPlayer = "Neutral"
<i>Sigh</i>. Alright... I'll help you find them.
// check for quest complete
->DONE

=== checkpoint1 ===
Have you found my Ancient power core yet?
->DONE

=== main35 ===
~ moodStringPlayer = "Neutral"
Here you go. So, where's the ghost?
->main36

=== main36 ===
~ isHectorTalking = true
~ moodStringHector = "Neutral"
Patience! The wings are gonna be done tomorrow. Good work takes time, you know?
->main37

=== main37 ===
~ moodStringHector = "Happy"
But I greatly appreciate your help! 
->main39

=== main39 ===
~ moodStringHector = "Happy"
Once I'm flyin' around tomorrow, he's definitely gonna show up and be all impressed!
->main40

=== main40 ===
~ isHectorTalking = false
~ moodStringPlayer = "Angry"
Tomorrow?? We don't have time till tomorrow, Hector! I need to talk to the ghost NOW.
->main41

=== main41 ===
~ moodStringPlayer = "Neutral"
Fuck - do you know where he lives? He's gotta have a home right?
->main42

=== main42 ===
~ isHectorTalking = true
~ moodStringHector = "Angry"
He does! But he's not there, probably. I went by his place just this morning to say hi, but he didn't answer. 
->main43

=== main43 ===
~ moodStringHector = "Neutral"
That's odd, I thought, but I wasn't too concerned about it. I've asked around and nobody has seen him all day. Still nothing too out of the ordinary for him, but now you're starting to worry me a little....
->main44

=== main44 ===
Well - if you really need to see him <b>this badly</b>, there may be one person who might know more.... The naga. But I gotta warn you. She's a little... odd.
->main45

=== main45 ===
~ isHectorTalking = false
~ moodStringPlayer = "Neutral"
Well, I gotta try it. No way around it now. Do you know where I can find her?
->main46

=== main46 ===
~ isHectorTalking = true
It's complicated.... She's made herself at home in the sewer systems of the city, and the pipelines run deep 'n' long... 
->main47

=== main47 ===
Your best chance of finding her is probably just... goin' around and knocking on all the manhole covers...?
I'm sorry I can't be of more help to ya, bud....
->main48

=== main48 ===
~ moodStringHector = "Happy"
But I'm sure you can find her eventually if you just keep at it! Good luck, pal! 
->main49

=== main49 ===
~ isHectorTalking = false
~ moodStringPlayer = "Neutral"
Thanks... I hope I'll be able to find him soon. For everyone's sake.
->main50

=== main50 ===
~ HectorCheckpoint2 = true
~ moodStringPlayer = "Happy"
And - good luck with your wings!
See you around!
->DONE

=== checkpoint2 ===
~ moodStringHector = "Neutral"
~ isHectorTalking = true
Your best chance of finding Nanalin is probably just... goin' around and knocking on all the manhole covers...?
I'm sorry I can't be of more help to ya, bud....
->DONE
