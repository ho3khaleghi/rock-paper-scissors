# Rock Paper Scissors

Paper Rock Scissors is a site that hopes to demonstrate how pure JavaScript works in a real-world context. The site will be targeted toward people who not only love to implement more advanced JavaScript concepts but also plying a game. Rock Paper Scissors is a fully responsive JavaScript choice game that will allow users to choose your game option, user your own username, compete with the computer random choice, and have fun.

![Responsice Mockup](./assets/screenshots/rock-paper-scissors-mockup.png)

## Features

Rock Paper Scissors has three views that includes Starting view, Matching view, and Ending view.

Starting view, ables you to choose your username, match option, and some information about the rules of the game.

![Starting View](./assets/screenshots/starting-view.png)

Matching view, makes you to compete with computer by the following rules.

![Matching View](./assets/screenshots/matching-view.png)

Ending view, announces that you have won or lost the game and gives you two options, return to the main menu which resets the whole game and rematch to let you play the game with the username and match option that you had chosen.

![Ending View](./assets/screenshots/ending-view.png)

### Existing Features

- __Starting view features__

  - Featured at the top of the strating view page, the area field for you to choose your username.

![Username](./assets/screenshots/username.png)

  - After choosing your username you have three options which are Best of One (The player or the computer have one chance to win or lose the game.), Best of Three (The player or the computer have three chances to win the or lose the game.), Best of Five (The player or the computer have five chances to win or lose the game.).

![Set Match Options](./assets/screenshots/match-option.png)

  - There is a text field to let you know about the rules of the game.

![Rules](./assets/screenshots/rules.png)

  - After choosing your username and the match option by clicking the Start button you port to the Matching view of the game.

![Start Match](./assets/screenshots/start-match.png)

- __Matching view features__

  - In this view you can see the match option that you have chosen on the top of the page.

![Match Option](./assets/screenshots/match-option-set.png)

  - There is a field you can see your chose, computer choice, and the result of the round by their icons and a nice light respecting the result.

![Choice Texts](./assets/screenshots/text-choices.png)

  - You can track your score, computer score, and the round counter that count the rounds which has a winner, either you or computer.

![Score Bar](./assets/screenshots/result-text.png)

- __Ending view features__

  - After finishing the game you port to the ending view and at the top of the page there will be a thanks message.

![Thanks Message](./assets/screenshots/tnx-message.png)

  - Underneath of the the thanks message you can see that you were the winner or the loser.

![Game Result](./assets/screenshots/ending-result.png)

  - In addition, you may also have two choices to return to the main menu (Starting view) or rematch the game with the same match option and username (Matching view).

![Return or Rematch](./assets/screenshots/ending-choices.png)

## Testing

  - The project is completely responsive to all devices. In testing there were some errors (rotation screen in mobile size, the height of the container in the mobile screen) but with some searching in [Stackoverflow](https://stackoverflow.com/) fixed all of the errors.

### Validator Testing

- HTML
  - No errors were returned when passing through the official [W3C validator](https://validator.w3.org/nu/?doc=https%3A%2F%2Fho3khaleghi.github.io%2Frock-paper-scissors%2F)
- CSS
  - No errors were found when passing through the official [(Jigsaw) validator](https://jigsaw.w3.org/css-validator/validator?uri=https%3A%2F%2Fho3khaleghi.github.io%2Frock-paper-scissors%2F&profile=css3svg&usermedium=all&warning=1&vextwarning=&lang=en)
- JavaScript
  - No errors were found when passing through the official [Jshint validator](https://jshint.com/)
    - The following metrics were returned:
    - There are 26 functions in this file.
    - Function with the largest signature take 1 arguments, while the median is 0.
    - Largest function has 16 statements in it, while the median is 2.5.
    - The most complex function has a cyclomatic complexity value of 11 while the median is 1.
  

### Unfixed Bugs

  - Happily there are no bugs or errors in the project.

## Deployment

  - The site was deployed to GitHub pages. The steps to deploy are as follows: 
    - In the GitHub repository, navigate to the Settings tab 
    - From the source section drop-down menu, select the Master Branch
    - Once the master branch has been selected, the page will be automatically refreshed with a detailed ribbon display to indicate the successful deployment.

The live link can be found here - https://ho3khaleghi.github.io/rock-paper-scissors/

## Credits

  - The codes for the match option buttons and choice buttons are from [Codepen](https://codepen.io/HighFlyer/pen/WNXRZBv) with some customization respective to the need of the project.

  - The codes for the Start button and the result announcer in the ending view  are also from [Codepen](https://codepen.io/Ks145/pen/MWGxbYr) with some customization respective to the need of the project.

  - The next round announcer with is a slide in text is from [Codepen](https://codepen.io/yochans/pen/wvJXvOg) with some changes respective to the need of the project.

### Media

  - The favicon is form [Flaticon](https://www.flaticon.com/free-icon/rock-paper-scissors_6729598?k=1697965150472&log-in=google).

  - With Pixelied I converted the png file to webp. [Pixelied](https://pixelied.com/convert/png-converter/png-to-webp)

  - The background image is from [Vecteezy](https://www.vecteezy.com/vector-art/7207818-futuristic-technological-grid-background-digital-futurist-cyber-space-design-cyberpunk-technology-virtual-reality-science-fiction-matrix-science-light-perspective-wallpaper-vector-illustration).

  - The dice icons and the choice buttons icons are from [Fontawesome](https://fontawesome.com/).