#!/bin/bash
#Script for each positional parameter from 1 to n prints:
#In the 1'st line n times the 1'st parameter, ... , in n'th line 1 time the n'th parameter.
quantity=$#
for ((i=1;i<=$quantity;i++))
do
  quantity2=$[$quantity-$i+1]
  myline=""
  word=$1
  shift
  for ((j=1;j<=$quantity2;j++))
  do
    myline+=$word' '
  done
  echo $myline
done
