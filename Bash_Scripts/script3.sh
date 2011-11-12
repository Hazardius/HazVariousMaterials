#!/bin/bash
#Script prints sum of the integers from 1 to given "n".
#Version with while_expr.
read n
m=0
while [ $n -gt 0 ]
do
  m=`expr $n + $m`
  echo "$n $m"
  n=`expr $n - 1`
done