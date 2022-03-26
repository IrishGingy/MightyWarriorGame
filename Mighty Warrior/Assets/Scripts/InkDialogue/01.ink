VAR fought_guard = false


-> meet_guard
=== meet_guard ===
The guard frowns at you.

*     (greet) [Greet him]
    'Greetings.'
*    (get_out) 'Get out of my way[.'],' you tell the guard.

-     'Hmm,' replies the guard.

*    {greet}     'Having a nice day?' // only if you greeted him

*     'Hmm?'[] you reply.

*    {get_out} [Shove him aside]      // only if you threatened him
    You shove him sharply. He stares in reply, and draws his sword!
    ~fought_guard = true
    -> fight_guard             // this route diverts out of the weave

-    'Mff,' the guard replies, and then offers you a paper bag. 'Toffee?'
-> escape

=== fight_guard ===
You fight the guard...and lose miserably.
-> escape


=== escape ===
{fought_guard:
    You manage to escape with your life after that fight...
-else:
    You leave politely denying the guard's request...if only you knew
what you just escaped.
}

-> END