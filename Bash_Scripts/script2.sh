#!/bin/bash
#Script after entering the number "n" and the text, saves text in the "n" files
#with given by the user in the loop names.
echo Give a number!
read number
echo Give a text!
read text
for ((i=1;i<=$number;i++))
do
  echo Give a name of $i textfile!
  read name
  echo "$text" > $name
done
