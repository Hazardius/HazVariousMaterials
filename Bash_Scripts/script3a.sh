#!/bin/bash
#Script prints sum of the integers from 1 to given "n".
#Version with while_true.
read n
m=0
while true
do
  m=`expr $n + $m`
  echo "$n $m"
  n=`expr $n - 1`
  if [ $n -le 0 ]
  then
    break
  fi
done
