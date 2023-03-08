INCLUDE globals.ink

{ NanalinCheckpoint2 == true: -> checkpoint2}
{ hasNanalinsBracelet == true: -> afterQuest}
{ NanalinCheckpoint1 == true: -> checkpoint1}

~ moveNanalinToPosition2 = false
~ moodStringNanalin = "Neutral"
~ moodStringPlayer = "Neutral"
->main
=== main ===
~ moodStringNanalin = "Neutral"
~ moodStringPlayer = "Neutral"
~ isEdithTalking = false
~ isHectorTalking = false
~ isNanalinTalking = true
~ isGhostTalking = false
~ NanalinCheckpoint2 = false
<i>Nanalin pops up from manhole and stares at you</i>
->main1

=== main1 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Neutral"
~ moodStringNanalin = "Neutral"
Jeez - you startled me!
->main2

=== main2 ===
~ isNanalinTalking = true
...
->main3

=== main3 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Happy"
Uhm, hi!
I'm Agent Hiro, member of The M.A.G.I.C. Council. I'm looking for Wren, the professor. Can you tell me where he is?
->main4

=== main4 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Neutral"
...
->main5

=== main5 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Neutral"
Pardon. I just assumed you were the Naga Hector told me about. Correct me if I'm wrong.
->main6

=== main6 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Neutral"
Not naga. Nagas are river dragons. Does Nanalin look like dragon?
->main7

=== main7 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Angry"
Well, yes and no. Your horn and scales kinda remind me of a dragon.
->main8

=== main8 ===
~ moodStringPlayer = "Neutral"
And yet, you seem to have human anatomy for your upper body.
->main9

=== main9 ===
~ moodStringPlayer = "Neutral"
Hm... When thinking about it, I've never seen one of your kind before!
->main10

=== main10 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Neutral"
Yes. Nanalin is Nanalin. No dragon, no human and no kind. Only one Nanalin.
->main11

=== main11 ===
So Agent Hiro won't find water dragon. Sorry. Bye -
->main12

=== main12 ===
~ isNanalinTalking = false
Wow, hang on! Please stay. I'd like to talk to you, Nanalin.
I'm looking for Professor Wren. Can you help me?
->main13

=== main13 ===
It's a really serious matter. The rift in your city is dangerous and I need his help right now. Otherwise bad things will happen, understand?
->main14

=== main14 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Angry"
No! Wrong! Rift is no danger!
It helped Nanalin finding new home. Peaceful home. Nanalin comes from place with only true humans and true dragons.
->main15

=== main15 ===
Nanalin mustn't exist. Mama and Papa were hurt, because they stayed by Nanalin's side. But no more. Now Nanalin won't let anyone stay by her side.
->main16

=== main16 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Neutral"
I'm sorry to hear that and I'm glad you found a new home. But are you really fine by yourself?
->main17

=== main17 ===
~ moodStringPlayer = "Angry"
It must be lonely... living alone in the sewers.
->main18

=== main18 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Neutral"
...Yes. But Nanalin got many little friends at new home. Nanalin is fine, Nanalin have to!
->main19

=== main19 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Neutral"
If you say so, then I guess it's fine. Well then, can you PLEASE tell me where to find Professor Wren?
->main20

=== main20 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Angry"
Maybe... maybe it's not fine. Some of Nanalin's friends just died.
->main21

=== main21 ===
~ moodStringNanalin = "Happy"
If Nanalin can have Agent Hiro's cat as new friend, Nanalin would be truely happy. Cat's butt cheeks look delicious!
->main22

=== main22 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Angry"
What the heck - NO! Momo is my best buddy! I'd never give him away!
->main23

=== main23 ===
~ moodStringPlayer = "Angry"
Furthermore, I have a feeling you are avoiding answering my question. Why?
->main24

=== main24 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Angry"
<i>She sulks.</i>
->main25

=== main25 ===
Cat butt.... Yes. Nanalin doesn't want to talk about Wren! Nanalin is still mad!
->main26

=== main26 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Neutral"
What happened? Why are you mad at Professor Wren?
->main27

=== main27 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Angry"
Wren broke his promise. Nanalin can't do water magic without amulet. Wren wanted to borrow it for one day. But it's been three days now. Nanalin feels very empty without water magic....
->main28

=== main28 ===
~ moodStringNanalin = "Neutral"
But Nanalin can't leave sewers. People will get scared, especially little peoples. Like old home... and someone will get hurt. Nanalin is bad luck. Only water magic can bring joy to everyone.
->main29

=== main29 ===
~ moodStringNanalin = "Angry"
Without water magic... Nanalin will truly be lonely....
->main30

=== main30 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Happy"
Hm... that sounds complicated. However, there's one thing I can say for sure: You aren't bad luck, Nanalin!
->main31

=== main31 ===
~ moodStringPlayer = "Angry"
You seem to have experienced a lot of hardship in your past. I understand if it still weighs heavily on you. I genuinely hope you can let go of it one day and live authentically out in the open!
->main32

=== main32 ===
~ moodStringPlayer = "Happy"
This place.... It comes across as a very open-minded and magical city.
->main33

=== main33 ===
~ moodStringPlayer = "Happy"
I'm sure everyone would love and accept you, with or without water magic!
->main34

=== main34 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Happy"
<i>She looks happy.</i>
->main35

=== main35 ===
Agent Hiro sure talks a lot... Nanalin really need her water magic though...
but thanks....
->main36

=== main36 ===
Wren is in his house. His house is in the east district. His house looks like barn. He is hiding.
->main37

=== main37 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Neutral"
Thank you! But I don't follow. Why is he hiding?
->main38

=== main38 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Angry"
That's the only thing Nanalin doesn't know.
->main39

=== main39 ===
~ moodStringNanalin = "Happy"
Will Agent Hiro come back to Nanalin when they know?
->main40

=== main40 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Happy"
Sure! I can do that for you.
->main41

=== main41 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Happy"
Can Agent Hiro also recue Nanalin's magic arm ring from Wren, the moocher?
->main42

=== main42 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Neutral"
Uh, yes. I'll bring back your arm ring. Even so, I think calling the Professor a moocher is a bit harsh, isn't it?
->main43

=== main43 ===
~ isNanalinTalking = true
~ moodStringNanalin = "Angry"
...
Maybe toxic, but true. 
->wishesGoodLuck

=== wishesGoodLuck ===
~ moodStringNanalin = "Happy"
Nanalin wishes Agent Hiro good luck, and don't forget amulet!
->main44

=== main44 ===
~ isNanalinTalking = false
~ moodStringPlayer = "Neutral"
~ NanalinCheckpoint1 = true
Thank you! Alrighty, I have to hurry and find Professor Wren!
->DONE

=== checkpoint1 ===
~ isNanalinTalking = true
Nanalin is still waiting for arm ring. Wren's house is in the east district. His house looks like barn. He is hiding.
->DONE

=== afterQuest ===
~ moodStringPlayer = "Happy"
~ isNanalinTalking = false
Nanalin, I got your arm ring. There you go.
->afterQuest1

=== afterQuest1 ===
~ moodStringPlayer = "Happy"
<i>Hiro gives the arm ring back.</i>
->afterQuest2

=== afterQuest2 ===
~ isNanalinTalking = true
~ NanalinCheckpoint2 = true
~ PlayerCheckpoint1 = true
~ moodStringNanalin = "Happy"
Thank you Agent Hiro! Finally Nanalin can make little people smile again!
->DONE
=== checkpoint2 ===
~ moodStringNanalin = "Happy"
Thank you Agent Hiro! Finally Nanalin can make little people smile again!
->DONE