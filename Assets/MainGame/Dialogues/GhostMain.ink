INCLUDE globals.ink
{ GhostCheckpoint2 == true: -> checkpoint2}
{ moveGhostToPosition2 == true: -> main23}
{ hasEnergyStone == true: -> main21}
{ GhostCheckpoint1 == true: -> checkpoint1}


~ moveGhostToPosition2 = false
~ moodStringGhost = "none"
~ moodStringPlayer = "Neutral"
->main
=== main ===
~ moodStringGhost = "none"
~ moodStringPlayer = "Neutral"
~ isEdithTalking = false
~ isHectorTalking = false
~ isNanalinTalking = false
~ isGhostTalking = false
<i>Hiro knocks on the door.</i>
{NanalinCheckpoint1 == true: -> main1}
->emptyHouse
=== emptyHouse ===
<i>No one is inside</i>
->DONE
=== main1 ===
Hello? I'd like to talk to Professor Wren. Is anyone home?
->main3

=== main3 ===
~ isGhostTalking = true
...
->main4

=== main4 ===
~ isGhostTalking = false
~ moodStringPlayer = "Neutral"
Maybe I should introduce myself.... I'm Agent Hiro, member of The M.A.G.I.C. Council. I'm here to investigate the reason behind the sudden spike of chaotic energy we've detected here.
->main5

=== main5 ===
~ moodStringPlayer = "Angry"
By now, I'm pretty sure the rift is the cause, but I'm still lacking some information!
->main6

=== main6 ===
~ isGhostTalking = true
Oh dear lords, thank the spirits! Finally someone gets it!!
->main7

=== main7 ===
I've been trying to tell the others for days now but none of those numbskulls will listen to me!
->main8

=== main8 ===
~ isGhostTalking = false
~ moodStringPlayer = "Angry"
Could I come inside and talk to you in person?
This is a really urgent matter and if we don't do something about the rift then this city - even the whole universe - may vanish!
->main9

=== main9 ===
~ moodStringPlayer = "Neutral"
Besides, I promised to bring Nanalin her amulet back.... Do you still have it?
->main10

=== main10 ===
~ isGhostTalking = true
I fear that both of your requests are currently not in the realm of possibility.
->main11

=== main11 ===
~ isGhostTalking = false
~ moodStringPlayer = "Neutral"
Wh... what? Why? Could you at least come out? I thought you knew how urgent this is!
->main12

=== main12 ===
~ isGhostTalking = true
I do indeed! But right now, I'm <b>physically</b> unable to do <b>anything</b>.
->main13

=== main13 ===
You see, I'm a spirit from a different realm, and the only thing that allowed me to take on a physical form in this world - my energy stone - got lost. And so I'd rather not show my true from right now, as I fear that people might get scared.
->main14

=== main14 ===
You know, despite the fact that I'm basically stranded here, after my planet was destroyed... I really don't mind it. I enjoy being around people. I enjoy the company. I don't want to loose that now.
->main15

=== main15 ===

->main16

=== main16 ===
~ isGhostTalking = false
~ moodStringPlayer = "Happy"
Is it really that bad...? This place seems to be home to plenty of strange people in all shapes and sizes...!
->main17

=== main17 ===
~ moodStringPlayer = "Angry"
But - all of that doesn't even matter if we don't do something about the rift!
->main18

=== main18 ===
~ isGhostTalking = true
I'm aware, I'm aware....
But I can't risk what I've got going on here.... I've already lost everything before. I can't let that happen again, so I'll figure out a way to fix this. One way or the other.
->main19

=== main19 ===
~ GhostCheckpoint1 = true
I have a request for you. Would you be so kind to look for my Energy Stone?
It'd make both of our life easier... The Energy Stone should be located somewhere in the port district.
->DONE

=== checkpoint1 ===
I have a request for you. Would you be so kind to look for my Energy Stone?
It'd make both of our life easier... The Energy Stone should be located somewhere in the port district.
->DONE
=== main20 ===
// after complete Quest
->main21

=== main21 ===
~ isGhostTalking = false
~ moodStringPlayer = "Neutral"
~ moveGhostToPosition2 = true
Here you go.
->DONE


//spawn here
=== main23 ===
~ isGhostTalking = true
~ moodStringGhost = "Happy"
I'm relieved to have it back.
->main25

=== main25 ===
~ moodStringGhost = "Neutral"
Oh! You wanted to give this back to Nanalin, right?
->main26

=== main26 ===
~ moodStringGhost = "Neutral"
<i>Hiro receives the arm ring.</i>
->main27

=== main27 ===
~ isGhostTalking = false
~ moodStringPlayer = "Neutral"
Why did you take it in the first place?
->main28

=== main28 ===
~ isGhostTalking = true
~ moodStringGhost = "Neutral"
'I've got my reasons. You see, more and more bizarre occurrences have been happening lately.
->main29

=== main29 ===
~ moodStringGhost = "Angry"
Extreme weather conditions and a rising number of malfunctioning electronic devices have been happening left and right. These are just a couple of examples. Even magical items are being influenced by the rift.
->main30

=== main30 ===
~ moodStringGhost = "Neutral"
That's why I started examining different objects of magical importance around the city.'
->main31

=== main31 ===
~ isGhostTalking = false
~ moodStringPlayer = "Angry"
I knew something seemed off about this place....
->main32

=== main32 ===
~ moodStringPlayer = "Neutral"
As soon as I landed, my phone stopped working entirely.
->main33

=== main33 ===
~ moodStringPlayer = "Neutral"
So what did you find out about Nanalin's arm ring?
->main34

=== main34 ===
~ isGhostTalking = true
~ moodStringGhost = "Happy"
Oh, I made some fascinating discoveries!
->main35

=== main35 ===
~ moodStringGhost = "Happy"
Nanalin's arm ring, Hector's ancient power cores, and my energy stone are left untouched from the rift's impact! Exciting, isn't it?
->main36

=== main36 ===
~ isGhostTalking = false
~ moodStringPlayer = "Neutral"
Why's that?
->main37

=== main37 ===
~ isGhostTalking = true
~ moodStringGhost = "Neutral"
Unfortunately, there's only so much I can understand without more empirical data.
->main38

=== main38 ===
~ moodStringGhost = "Neutral"
What I know, is that these objects are incredibly important to their owners, so it might be difficult to get ahold on them.
->main39

=== main39 ===
~ isGhostTalking = false
~ moodStringPlayer = "Angry"
I see.... So the rift has always been here. And since the citizens only saw it as the means by which they found their homes here, it never occurred to them that they were in any danger from it.
->main40

=== main40 ===
~ moodStringPlayer = "Neutral"
You thought that way too, until recently. When you noticed weird things were starting to happen more and more often, right?
->main41

=== main41 ===
~ isGhostTalking = true
That's correct.
->main42

=== main42 ===
~ isGhostTalking = false
~ moodStringPlayer = "Neutral"
Well then, I have a strong suspicion that I think might fit with what's going on....
->main43

=== main43 ===
Could it be that the citizens of this city all came from different universes?
->main44

=== main44 ===
~ isGhostTalking = true
Correct again. That's why we're all somehow... different from each other.
->main45

=== main45 ===
~ moodStringGhost = "Happy"
But that's a good thing! I love talking to my neighbors and learning about other worlds and cultures!
->main46

=== main46 ===
~ isGhostTalking = false
~ moodStringPlayer = "Happy"
I see....
Thanks a lot Professor Wren!
->main47

=== main47 ===
Now I have all the information I need to finally be able to make a proper report to HQ.... No need to worry, we'll take care of it!
->main48

=== main48 ===
~ isGhostTalking = true
Oh, what a relief!
->main49

=== main49 ===
~ GhostCheckpoint2 = true
~ moodStringGhost = "Neutral"
Thank you so much, and please tell Nanalin that I'm sorry for making her wait!
// get nanalins arm ring
->DONE

=== checkpoint2 ===
~ moodStringGhost = "Neutral"
Thank you so much, and please tell Nanalin that I'm sorry for making her wait!
->END