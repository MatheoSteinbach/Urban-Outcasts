INCLUDE globals.ink

{ getPhone == true: -> EdithCheckpointPhone}
{ EdithCheckpoint1 == true: -> EdithCheckpoint}

~ moveEdithToPosition2 = false
~ moodStringEdith = "Happy"
~ moodStringPlayer = "Neutral"

->main
=== main ===
~ moodStringEdith = "Happy"
~ moodStringPlayer = "Neutral"
~ isEdithTalking = true
~ isHectorTalking = false
~ isNanalinTalking = false
~ isGhostTalking = false
Hello, dear! I've never seen your face before.
->main2

=== main2 ===
~ moodStringEdith = "Neutral"
You're looking like a lost lamb. May I offer you my help, daahling?
->main3

=== main3 ===
~ isEdithTalking = false
~ moodStringPlayer = "Neutral"
Good day. Well, you're not wrong - I <i>am</i> a bit lost.
->main4

=== main4 ===
~ moodStringPlayer = "Happy"
I'm looking for the mayor. Do you know where I can find her?
->main5

=== main5 ===
~ moodStringEdith = "Happy"
~ isEdithTalking = true
<i>She laughs. </i>
->main6

=== main6 ===
~ moodStringEdith = "Neutral"
What a coincidence! 
->main7

=== main7 ===
~ moodStringEdith = "Happy"
She's standing right in front of you.
->main8

=== main8 ===
~ moodStringEdith = "Neutral"
What can I do for you, daahling? 
->main9

=== main9 ===
~ isEdithTalking = false
~ moodStringPlayer = "Neutral"
Oh, I apologize. Please let me officially introduce myself: I am Agent Hiro, member of The M.A.G.I.C. Council.
->main10

=== main10 ===
~ moodStringPlayer = "Angry"
We detected abnormal activity in this area and I'm here to investigate the cause and eliminate it. If left untreated, it could become... well, let's just say 'troublesome.'
->main11

=== main11 ===
~ moodStringPlayer = "Angry"
Anyway, I must admit, I'm really surprised to find a whole civilization this far from our solar system. I wonder how this happened....
->main12

=== main12 ===
~ isEdithTalking = true
~ moodStringEdith = "Angry"
...?! Wh - what could be wrong with our lovely town?
->main13
    
=== main13 ===
I've lived here for a long time, and it's always been a peaceful place. Oh dear! What do I do now?
->main14

=== main14 ===
~ isEdithTalking = false
~ moodStringPlayer = "Happy"
No need to panic. We, The M.A.G.I.C. Council, will take care of the matter. You just need to cooperate and answer some questions.
->main15

=== main15 ===
~ moodStringPlayer = "Neutral"
To begin with, have there been any unusual occurrences lately? And if so, where?
->main16

=== main16 ===
~ isEdithTalking = true
~ moodStringEdith = "Angry"
Uhh.... Unusual, you say...? I don't think so. The only annoying thing I can think of is the rain. It's been raining cats and dogs for ages now.
->main17

=== main17 ===
~ moodStringEdith = "Neutral"
<i>She sighs</i>
->main18

=== main18 ===
If this goes on, my laundry will never get dry, daahling. But this isn't something I'd consider unusual. The rain has always liked our city.
->main19

=== main19 ===
~ isEdithTalking = false
~ moodStringPlayer = "Happy"
Thank you. I'm grateful for any information, no matter how trivial!
->main20

=== main20 ===
~ isEdithTalking = true
~ moodStringEdith = "Angry"
Excuse me, daahling! I can't believe my ears. Are you implying doing laundry is something trivial?
->main21

=== main21 ===
~ moodStringEdith = "Neutral"
Try taking care of a household with ten little lambs by yourself and say that again to me! I dare you!
->main22

=== main22 ===
~ isEdithTalking = false
~ moodStringPlayer = "Neutral"
Uhm, I'm very sorry Ms. Mayor. It was not my intention to offend you.
->main23

=== main23 ===
~ isEdithTalking = true
~ moodStringEdith = "Neutral"
You know what? Just go straight to Professor Wren and ask him anything you want to know.
->main24

=== main24 ===
~ moodStringEdith = "Happy"
He's the most intelligent being in town- he specializes in ancient magic.
->main25

=== main25 ===
~ moodStringEdith = "Neutral"
I don't know anything about your abnormal activity and abaahcadabaah stuff
->main26

=== main26 ===
You can probably find him at Hector's place. It's right next to the house with a ladder. Professor Wren's been there very often lately.
->main27

=== main27 ===
~ isEdithTalking = false
~ moodStringPlayer = "Neutral"
Many thanks! So... I have one last favor to ask.
->main28

=== main28 ===
~ moodStringPlayer = "Angry"
Do you know where I can get a new phone? My old one broke down the moment I entered this place's atmosphere.
->main29

=== main29 ===
~ moodStringPlayer = "Neutral"
I need to stay in constant contact with HQ, so this is very important.
->main30

=== main30 ===
~ moodStringEdith = "Happy"
~ isEdithTalking = true
Sure thing! I know eeehverything about our shopping district!
->main31

=== main31 ===
Just go to the "Bapple" store over there. Their stuff may be a bit overpriced, but trust me - it's worth it.
->main32

=== main32 ===
~ getPhoneQuest = true
~ moodStringEdith = "Neutral"
~ EdithCheckpoint1 = true
~ moveEdithToPosition2 = true
Speaking of which, I'd best continue with my own shopping trip. Good luck, daahling!
->DONE

=== EdithCheckpoint ===
~ isEdithTalking = true
The Bapple store is located up north, it has a big apple right over the entrance. After you get your Phone go visit Hector.
->END

=== EdithCheckpointPhone ===
~ isEdithTalking = true
I see you have your new Phone, now go visit Hector! Just go through that archway to the east of the town.
->END