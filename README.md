# AnagramAnnihilator5000
Simple solution to one of Dave Thomas' famous CodeKata exercise, number 6, in C#. 
It was slightly challenging until I realized LINQ has GroupBy...

Usage: anagramannihilator5000.exe <wordlist.txt>
where wordlist.txt is the name of a text file containing single words separated by lines.

The word list is fed into the program and all anagrams in the word list are located. 
Only other words in the word list are identified as anagrams. It doesn't reference the entire English dictionary -- 
unless that's what you feed into it. 

Once the program is done, it spits out a file called "anagrams.txt." This is a grouped list of anagrams -- each set
words which are anagrams of each other are placed under the same heading, which is a string representing all of the 
letters in the words sorted in alphabetical order. All anagrams are the same string once the letters are placed in
alphabetical order.

Example:

wordlist.txt:
boaster
boaters
borates
evil
enlist
live
listen
silent

anagrams.txt will contain:
Abeorst
  boaster
  boaters
  borates
Eilv
  evil
  live
Eilnst
  enlist
  listen
  silent
  

