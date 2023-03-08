INCLUDE globals.ink

{ PlayerCheckpoint1 == true: -> main4}
{ RiftMonologue == true: -> riftMonologue}

~ monologueMoodString = "none"
->main
=== main ===
~ monologueMoodString = "Angry"
The council's records say there isn't supposed to be anything at these coordinates.... How long has this city been here? How have they stayed undetected for this long....
I should notify the headquarters immediately...
Agent Hiro to HQ. Come in HQ! <i>Static noises</i>.... Hello? <i>Static noises</i>
->main2

=== main2 ===
Shit- the phone's dead. The chaotic energy must be disrupting the signal....
->main3

=== main3 ===
~ monologueMoodString = "Neutral"
Well, it looks like we're stuck here till we figure out what the source is. Let's see if we can talk to the locals here, figure out who runs this place, and get ahold of a working phone....
->DONE 

=== riftMonologue ===
~ monologueMoodString = "Angry"
How have the people here been living around this anomaly for so long? Isn't it clear that the rift is dangerous??
-> riftMonologue2

=== riftMonologue2 ===
~ monologueMoodString = "Angry"
And how has this stayed unnoticed for this long? It's highly unstable... If left untreated it'll swallow to whole city- even universe!
-> riftMonologue3
We need to find out the cause and make a report to HQ as fast as possible. That Professor Wren will surely know more about this.
=== riftMonologue3 ===
~ monologueMoodString = "Neutral"
-> END

=== main4 ===
~ monologueMoodString = "Angry"
Oh dear, Momo.... What have we gotten ourselves into.... I have a bad feeling about this.
->main5

=== main5 ===
~ monologueMoodString = "Neutral"
<i>The phone beeps suddenly. A crackling Voice comes from the speaker: Agent Hiro...? Chrrrchhh... Agent Hiro, come in...!</i>
->main6

=== main6 ===
~ monologueMoodString = "Happy"
~ OutroCutscene = true
Huh...? Oh my god, it's HQ! Agent Hiro coming in! Yes, I read you loud and clear! Go ahead!

->DONE