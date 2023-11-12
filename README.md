# Description
A simplified slot machine game (console application).

## Requirements

### The rules
- At the start of the game the player should enter the deposit amount (e.g. the initial money balance).
-  After that, for each spin, the player is asked how much money he wants to stake.
- A table with the results of each spin is displayed to the player.
- The win amount should be displayed together with the total balance at the current stage. After the first spin the total balance will be equal to: *({deposit amount} - {stake amount}) + {win amount}*.
- Game ends when the player balance hits 0.

### The game
- A slot game with dimensions 4 rows of 3 symbols each.
- Supports following symbols:

| Symbol        |  Coefficient  |  Probability to appear on a cell |
| ------------- | ------------- | -------------------------------- |
| Apple (A)     |  0.4          |  45%                             |
| Banana (B)    |  0.6          |  35%                             |
| Pineapple (P) |  0.8          |  15%                             |
| Wildcard (*)  |  0            |  5%                              |

- The symbols are placed randomly respecting the probability of each item. For example: there is 5% chance that a Wildcard will be placed in a cell and there is 45% chance for an Apple.
- The player will win only if one or more horizontal lines contain 3 matching symbols. Wildcard (*) is a symbol that matches any other symbol (A, B or P).
- The won amount should be the sum of the coefficients of the symbols on the winning line(s), multiplied by the stake amount.

*Win calculation examples:*

| Win combinations | Calculation of win        |
| ---------------- | --------------------------|
| * P *            | (0 + 0.8 + 0)*10 = 8      |
| A A A            | (0.4 + 0.4 + 0.4)*10 = 12 |
| B B B            | (0.6 + 0.6 + 0.6)*10 = 18 |
| P P P            | (0.8 + 0.8 + 0.8)*10 = 24 |
| A B P            | No matching symbols       |
| * A B            | No matching symbols       |

## Instructions

When you run the app, it will welcome you to the slot game and you have to deposit "money" you would like to play with. 

1. Deposit "money".
2. Press **Enter**.
3. If you have entered a valid deposit input then you have to enter a Stake (*valid input is a numeric value, non negative, greated thah 0 and with only one decimal place. For example, you can use '10.5' to represent ten and a half.*).
4. Press **Enter** to start playing the game.
5. Enter stakes untill the balance is greater than 0.
6. Game ends when the balance hits 0.
