#!/bin/bash
#Script after entering the variable n prints out 2 lines consisting:
#Numbers from 1 to n.
#Their squares.
echo Write n!
read n
first=""
second=""
if [ $n -gt 1 ]
then
  for ((i=1;i<=$n;i++))
  do
    first+=$i' '
    second+=$[$i*$i]' '
  done
  echo $first
  echo $second
else
  echo Wrong n!
fi
