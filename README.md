# SOFTGAMES Developer Assessment

This is my assessment web app for SOFTGAMES, written in Unity 6/c#.

## Main Menu

This scene provides access to the three task scenes, detailed below. There is also a global space canvas, which houses the FPS counter and other persistent screen elements.

## Ace of Shadows

This shows the 'dealer' deck at the top of the screen, and as per the spec a card is moved to one of the other decks each second until all cards are moved. 

The AceGameManager singleton handles the game logic and calls the CardStack objects to manipulate the cards.

## Magic Words

This downloads the JSON conversation from the URL provided and pre-loads and validates the avatar data and images ready for the conversaton to start. The conversation is then progressed with a click.

The MagicWordsGameManager performs the web requests and controls the dialog flow by calling the UI.

## Phoenix Flame

This scene shows a fire particle system VFX. The three buttons on the UI control triggers on an Animator Controller which perform transitions in the state graph to play different animations to change the colour of the flame.

There is no Manager component here, it simply calls the required functions on the UI componant.


## If I had more time

There are many things I would add and improve if I had a little more time to spend on it. Functionality was prioritised to meet the task spec, with only a small time for adding basic downloaded textures and images for polish.

**Better scene management and loading** - Async loading, loading screen, simple transition (fade) for enter/exit scenes

**Better assets and optimised/POT texture sizes** - Textures were either downloaded or grabbed from what I had available, font could easily be improved from the default TextMeshPro one.

**Ace of Shadows - better decks** - The spec stipulates seeing all 144 cards, but I would probably clamp the number of visual cards in the deck for a nicer stack visual.

**Magic Words** - Better visuals for missing data (question mark avatar) and a better loading state for when data is being downloaded. Also a better font would allow for more emojis to be supported.

**Web Handling** - Normally I would put web request handling with more robust error states into its own utility classes. I've included it directly here for simplicity.

**Phoenix Flame** - Given time I would do some shader work for a much better fire effect than just a simple particle system one

**Animations and Sounds** - I would love to have added animations for buttons, scene entry/exit, speech bubbles and avatars appear/disappear, and some basic audio to bing it more to life.

Thank you for reading, I hope you enjoy this little web app!
