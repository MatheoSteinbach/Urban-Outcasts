INCLUDE globals.ink
{coins >= 10:
    ->main
  - else:
    ->idle 
}

->idle

=== idle ===
Dear customer, if you don't have at least 10 coins, you're poor and we don't want trash like you in our store. Go fuck yourself, yes, yes.
->END
=== main ===
Here you go! One brand new phone that works without picking up interference from the rift. Pleasure doing business with you, yes, yes.
->main2

=== main2 ===
~ getPhone = true
You've acquired a new phone! Press I to take it out.
->END